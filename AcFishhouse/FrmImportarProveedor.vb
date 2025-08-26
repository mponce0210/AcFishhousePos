Imports System.Data
Imports System.Data.SqlClient
Imports ClosedXML.Excel
Imports System.Configuration
Imports System.IO
Imports System.Security.Cryptography



Public Class FrmImportarProveedor

    ' Public Class TuClase
    Private ReadOnly connStr As String = ConfigurationManager.ConnectionStrings("MiConexion").ConnectionString
    Private _batchId As Guid = Guid.Empty
    Private _importId As Integer = 0
    Private _backupId As Integer = 0
    Private _usuario As String = Environment.UserName 'ajusta si tienes contexto propio
    '====== Helpers de conexión ======
    Private Function NewConn() As SqlConnection
            Return New SqlConnection(connStr)
        End Function

    'End Class

    'Private ReadOnly connStr As String = "Server=TU_SERVER;Database=TU_DB;Trusted_Connection=True;"


    Private Function NewBatchId() As Guid
        Return Guid.NewGuid()
    End Function


    Private Function LeerExcelNormalizado(ruta As String, proveedor As String) As DataTable
        ' Lee hoja DATA
        Dim dtRaw As New DataTable("RAW")
        Using wb As New XLWorkbook(ruta)
            Dim ws = wb.Worksheet("DATA")
            Dim first = True
            For Each row In ws.RangeUsed().Rows()
                If first Then
                    For Each c In row.Cells() : dtRaw.Columns.Add(c.GetString().Trim()) : Next
                    first = False
                Else
                    Dim dr = dtRaw.NewRow()
                    For i = 0 To dtRaw.Columns.Count - 1
                        dr(i) = row.Cell(i + 1).Value
                    Next
                    If Not dr.ItemArray.All(Function(x) String.IsNullOrWhiteSpace(Convert.ToString(x))) Then
                        dtRaw.Rows.Add(dr)
                    End If
                End If
            Next
        End Using

        ' DataTable estándar
        Dim dtStd As New DataTable("STD")
        Dim stdCols = {
            "SKU_Proveedor", "Descripcion", "Categoria", "CostoProveedor",
            "PrecioSugerido", "Unidad", "CodigoBarras", "IdProdServicio", "Marca", "Observaciones"
        }
        For Each c In stdCols
            Select Case c
                Case "CostoProveedor", "PrecioSugerido" : dtStd.Columns.Add(c, GetType(Decimal))
                Case Else : dtStd.Columns.Add(c, GetType(String))
            End Select
        Next

        ' Mapeo desde SQL
        Dim map As New Dictionary(Of String, (Target As String, Transform As String, Required As Boolean))
        Using cn = NewConn(), cmd As New SqlCommand("
            SELECT SourceHeader, TargetColumn, Transform, Required
            FROM dbo.Proveedor_ColumnMap WHERE Proveedor=@p", cn)
            cmd.Parameters.AddWithValue("@p", proveedor)
            cn.Open()
            Using rd = cmd.ExecuteReader()
                While rd.Read()
                    map(rd.GetString(0).Trim()) = (rd.GetString(1).Trim(), If(rd.IsDBNull(2), "", rd.GetString(2).Trim()), rd.GetBoolean(3))
                End While
            End Using
        End Using

        ' Normalizar
        For Each r As DataRow In dtRaw.Rows
            Dim dr = dtStd.NewRow()
            For Each kvp In map
                Dim src = kvp.Key
                If dtRaw.Columns.Contains(src) Then
                    Dim tgt = kvp.Value.Target
                    Dim tfm = kvp.Value.Transform.ToUpperInvariant()
                    Dim s = If(IsDBNull(r(src)), "", r(src).ToString().Trim())
                    Select Case tfm
                        Case "TRIM" : dr(tgt) = s
                        Case "UPPER" : dr(tgt) = s.ToUpperInvariant()
                        Case "TEXT" : dr(tgt) = s
                        Case "DECIMAL2"
                            dr(tgt) = If(String.IsNullOrWhiteSpace(s), DBNull.Value, CType(Decimal.Parse(s, Globalization.CultureInfo.InvariantCulture), Object))
                        Case "CLEANBRCODE" : dr(tgt) = s.Replace("-", "").Replace(" ", "")
                        Case Else : dr(tgt) = s
                    End Select
                End If
            Next
            dtStd.Rows.Add(dr)
        Next

        Return dtStd
    End Function

    'aqui me quede
    Private Function BulkToProveedorStaging(dtStd As DataTable, proveedor As String, batchId As Guid, usuario As String) As Integer
        Dim dtBulk = dtStd.Copy()
        dtBulk.Columns.Add("Proveedor", GetType(String))
        dtBulk.Columns.Add("BatchId", GetType(Guid))
        dtBulk.Columns.Add("UsuarioCarga", GetType(String))
        dtBulk.Columns.Add("FechaCarga", GetType(DateTime))
        For Each r As DataRow In dtBulk.Rows
            r("Proveedor") = proveedor
            r("BatchId") = batchId
            r("UsuarioCarga") = usuario
            r("FechaCarga") = DateTime.Now
        Next

        Using cn = NewConn(), bulk As New SqlBulkCopy(cn)
            cn.Open()
            bulk.DestinationTableName = "dbo.Proveedor_Staging"
            For Each c As DataColumn In dtStd.Columns
                bulk.ColumnMappings.Add(c.ColumnName, c.ColumnName)
            Next
            bulk.ColumnMappings.Add("Proveedor", "Proveedor")
            bulk.ColumnMappings.Add("BatchId", "BatchId")
            bulk.ColumnMappings.Add("UsuarioCarga", "UsuarioCarga")
            bulk.ColumnMappings.Add("FechaCarga", "FechaCarga")
            bulk.BatchSize = 2000
            bulk.WriteToServer(dtBulk)
        End Using
        Return dtBulk.Rows.Count
    End Function

    Private Sub ProyectarA_Biotropic_Staging(batchId As Guid)
        Using cn = NewConn(), cmd As New SqlCommand("
            INSERT INTO dbo.Biotropic_Staging
              (BioPreAct, BioCodigoAlterno, BioMayoreo, BioDescripcionProd, CodigoBarras, IdProdServicio, BioMarca, BioObservaciones, BatchId, UsuarioCarga, FechaCarga)
            SELECT BioPreAct, BioCodigoAlterno, BioMayoreo, BioDescripcionProd, CodigoBarras, IdProdServicio, BioMarca, BioObservaciones, BatchId, UsuarioCarga, FechaCarga
            FROM dbo.vProveedorStaging_Biotropic
            WHERE BatchId=@b", cn)
            cmd.Parameters.AddWithValue("@b", batchId)
            cn.Open()
            cmd.ExecuteNonQuery()
        End Using

    End Sub
    Private Structure ImportInfo
        Public ImportId As Integer
        Public BackupId As Integer
    End Structure

    Private Function BeginImport_Biotropic(batchId As Guid, usuario As String, archivo As String, archivoHash As Byte()) As ImportInfo
        Dim info As New ImportInfo()
        Using cn = NewConn(), cmd As New SqlCommand("dbo.sp_Biotropic_BeginImport", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@BatchId", batchId)
            cmd.Parameters.AddWithValue("@Usuario", usuario)
            cmd.Parameters.AddWithValue("@ArchivoNombre", Path.GetFileName(archivo))
            If archivoHash IsNot Nothing Then
                cmd.Parameters.Add("@ArchivoHash", SqlDbType.VarBinary, 32).Value = archivoHash
            Else
                cmd.Parameters.Add("@ArchivoHash", SqlDbType.VarBinary, 32).Value = DBNull.Value
            End If
            Dim pImp = cmd.Parameters.Add("@ImportId", SqlDbType.Int) : pImp.Direction = ParameterDirection.Output
            Dim pBak = cmd.Parameters.Add("@BackupId", SqlDbType.Int) : pBak.Direction = ParameterDirection.Output
            cn.Open()
            cmd.ExecuteNonQuery()
            info.ImportId = CInt(pImp.Value)
            info.BackupId = CInt(pBak.Value)
        End Using
        Return info
    End Function

    Private Sub Validate_Biotropic(batchId As Guid, importId As Integer)
        Using cn = NewConn(), cmd As New SqlCommand("dbo.sp_Biotropic_Validate", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@BatchId", batchId)
            cmd.Parameters.AddWithValue("@ImportId", importId)
            cn.Open()
            cmd.ExecuteNonQuery() ' Si hay errores, el SP lanza RAISERROR
        End Using
    End Sub

    Private Sub Commit_Biotropic(batchId As Guid, importId As Integer)
        Using cn = NewConn(), cmd As New SqlCommand("dbo.sp_Biotropic_Commit", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@BatchId", batchId)
            cmd.Parameters.AddWithValue("@ImportId", importId)
            cn.Open()
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    Private Sub Restore_Biotropic(backupId As Integer)
        Using cn = NewConn(), cmd As New SqlCommand("dbo.sp_Biotropic_Restore", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@BackupId", backupId)
            cn.Open()
            cmd.ExecuteNonQuery()
        End Using
    End Sub
    Private Sub SetResumen(leidas As Integer, validas As Integer, ins As Integer, act As Integer, eli As Integer,
                           estado As String, colorEstado As Color)
        lblFilasLeidas.Text = $"Leidas: {leidas}"
        lblFilasValidad.Text = $"Validas: {validas}"
        LblInsertadas.Text = $"Insertados: {ins}"
        lblActualizados.Text = $"Actualizados: {act}"
        lblEliminados.Text = $"Eliminados: {eli}"
        lblestadoImport.Text = $"Estado - {estado}"
        lblestadoImport.ForeColor = colorEstado
    End Sub

    Private Sub CargarErrores(importId As Integer)
        Using cn = NewConn(), da As New SqlDataAdapter("
            SELECT RowNum, Campo, MensajeError 
            FROM dbo.Biotropic_ImportErrors WHERE ImportId=@i", cn)
            da.SelectCommand.Parameters.AddWithValue("@i", importId)
            Dim dt As New DataTable()
            da.Fill(dt)
            dvgErrores.DataSource = dt
            FormatearGrid(dvgErrores)
            lblErroresResumen.Text = $"Errores: {dt.Rows.Count}"
        End Using
    End Sub

    Private Sub FormatearGrid(g As DataGridView)
        g.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        g.ReadOnly = True
        g.AllowUserToAddRows = False
        g.RowHeadersVisible = False
    End Sub

    Private Sub Log(msg As String)
        txtlog.AppendText($"[{DateTime.Now:HH:mm:ss}] {msg}{Environment.NewLine}")
    End Sub


    Private Sub btnvalidar_Click(sender As Object, e As EventArgs) Handles btnvalidar.Click


        If cmbProveedor.SelectedValue Is Nothing OrElse String.IsNullOrWhiteSpace(txtArchivo.Text) Then
            MessageBox.Show("Selecciona proveedor y archivo.", "Aviso")
            Return
        End If

        Dim proveedor = cmbProveedor.SelectedValue.ToString()
        _batchId = Guid.NewGuid()
        tssProveedor.Text = $"Proveedor: {proveedor}"
        tssBatch.Text = $"Batch: {_batchId}"

        Try
            ' 1) Lee y normaliza a estándar
            Dim dtStd = LeerExcelNormalizado(txtArchivo.Text, proveedor)
            dgvPreview.DataSource = dtStd
            ' FormatearGrid(dgvPreview)

            ' 2) BulkCopy a Proveedor_Staging
            Dim leidas = BulkToProveedorStaging(dtStd, proveedor, _batchId, _usuario)

            ' 3) Proyecta a Biotropic_Staging (vista)
            ProyectarA_Biotropic_Staging(_batchId)

            ' 4) BeginImport (registra + backup de producción)
            Dim info = BeginImport_Biotropic(_batchId, _usuario, txtArchivo.Text, Nothing)
            _importId = info.ImportId
            _backupId = info.BackupId
            tssImportId.Text = $"ImportId: {_importId}"

            ' 5) Validar en SQL (llenará Biotropic_ImportErrors si falla)
            Validate_Biotropic(_batchId, _importId)

            ' 6) Resumen
            Dim validas = leidas ' si no hubo errores
            SetResumen(leidas, validas, 0, 0, 0, "Validación OK", Color.DarkGreen)
            tssEstado.Text = "Validación OK"
            Log($"Validación OK. Leídas: {leidas}. Batch:{_batchId} ImportId:{_importId} BackupId:{_backupId}")
        Catch ex As SqlException
            tssEstado.Text = "Errores en validación"
            SetResumen(0, 0, 0, 0, 0, "Errores", Color.Firebrick)
            CargarErrores(_importId)
            TabMain.SelectedTab = tabErrores
            Log("ERROR SQL en Validar: " & ex.Message)
        Catch ex As Exception
            tssEstado.Text = "Error"
            Log("ERROR en Validar: " & ex.Message)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnProcesar_Click(sender As Object, e As EventArgs) Handles btnProcesar.Click
        If _batchId = Guid.Empty OrElse _importId = 0 Then
            MessageBox.Show("Primero valida para generar Batch/ImportId.", "Aviso")
            Return
        End If

        If MessageBox.Show("Se hará TRUNCATE de BIOTROPIC y se cargará el archivo validado. ¿Continuar?",
                           "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) <> DialogResult.Yes Then Return

        Try
            Commit_Biotropic(_batchId, _importId)
            SetResumen(lblFilasLeidas.Text.Split(":"c)(1), lblFilasValidad.Text.Split(":"c)(1), 0, 0, 0, "PROCESADO OK", Color.DarkGreen)
            tssEstado.Text = "PROCESADO OK"
            Log($"Commit OK. ImportId:{_importId} BackupId:{_backupId}")
        Catch ex As SqlException
            tssEstado.Text = "ERROR en proceso"
            Log("ERROR SQL en Commit: " & ex.Message)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnRollBack_Click(sender As Object, e As EventArgs) Handles BtnRollBack.Click
        If _backupId <= 0 Then
            MessageBox.Show("No hay BackupId registrado en esta sesión. (Valida/Procesa para generarlo)", "Aviso")
            Return
        End If
        If MessageBox.Show($"Se restaurará producción desde BackupId {_backupId}. ¿Continuar?",
                           "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) <> DialogResult.Yes Then Return

        Try
            Restore_Biotropic(_backupId)
            tssEstado.Text = $"Restaurado (BackupId {_backupId})"
            Log($"Rollback OK. BackupId:{_backupId}")
        Catch ex As SqlException
            tssEstado.Text = "ERROR en rollback"
            Log("ERROR SQL en Rollback: " & ex.Message)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FrmImportarProveedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LlenarProveedores()
        ResetUI()
    End Sub

    Private Sub LlenarProveedores()
        ' Por ahora solo BIOTROPIC (deja listo para más adelante)
        Dim dt As New DataTable()
        dt.Columns.Add("Nombre")
        dt.Rows.Add("BIOTROPIC")
        cmbProveedor.DataSource = dt
        cmbProveedor.DisplayMember = "Nombre"
        cmbProveedor.ValueMember = "Nombre"
        cmbProveedor.SelectedIndex = 0

        tssUsuario.Text = $"Usuario: {_usuario}"
        tssProveedor.Text = "Proveedor: BIOTROPIC"
        tssBatch.Text = "Batch: —"
        tssImportId.Text = "ImportId: —"
        tssEstado.Text = "Listo"
    End Sub
    Private Sub ResetUI()
        txtArchivo.Text = ""
        lblArchivoInfo.Text = "Info: —"
        _batchId = Guid.Empty : _importId = 0 : _backupId = 0
        tssBatch.Text = "Batch: —" : tssImportId.Text = "ImportId: —"
        SetResumen(0, 0, 0, 0, 0, "—", Color.Black)

        dgvPreview.DataSource = Nothing
        dvgErrores.DataSource = Nothing
        txtlog.Clear()
        TabMain.SelectedTab = tabPreview
    End Sub

    Private Sub BtnDescargarPlantilla_Click(sender As Object, e As EventArgs) Handles BtnDescargarPlantilla.Click
        'Genera la plantilla estándar al vuelo
        Using sfd As New SaveFileDialog()
            sfd.Title = "Guardar plantilla estándar"
            sfd.Filter = "Excel (*.xlsx)|*.xlsx"
            sfd.FileName = "Plantilla_Proveedores_Estandar.xlsx"
            If sfd.ShowDialog() <> DialogResult.OK Then Return

            CrearPlantillaEstandar(sfd.FileName)
            MessageBox.Show("Plantilla guardada correctamente.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Using
    End Sub

    Private Sub CrearPlantillaEstandar(ruta As String)
        Dim wb As New XLWorkbook()
        'README
        Dim wsR = wb.AddWorksheet("README")
        wsR.Cell(1, 1).Value = "Plantilla estándar de proveedores"
        wsR.Cell(3, 1).Value = "Instrucciones:"
        wsR.Cell(4, 1).Value = "1) Llena DATA. 2) No cambies encabezados. 3) XLSX. 4) CodigoBarras como TEXTO."

        'DATA
        Dim wsD = wb.AddWorksheet("DATA")
        Dim headers = {
            "SKU_Proveedor*", "Descripcion*", "Categoria", "CostoProveedor*",
            "PrecioSugerido", "Unidad", "CodigoBarras", "IdProdServicio", "Marca", "Observaciones"
        }
        For i = 0 To headers.Length - 1
            wsD.Cell(1, i + 1).Value = headers(i)
            wsD.Column(i + 1).Width = 22
        Next
        wsD.Cell(2, 1).Value = "P001" : wsD.Cell(2, 2).Value = "Producto ejemplo"

        'CATALOGOS
        Dim wsC = wb.AddWorksheet("CATALOGOS")
        wsC.Cell(1, 1).Value = "Unidades sugeridas"
        wsC.Cell(2, 1).Value = "PZA" : wsC.Cell(3, 1).Value = "KG" : wsC.Cell(4, 1).Value = "LITRO"

        'EJEMPLO
        Dim wsE = wb.AddWorksheet("EJEMPLO")
        For i = 0 To headers.Length - 1 : wsE.Cell(1, i + 1).Value = headers(i) : Next
        wsE.Cell(2, 1).Value = "SKU999" : wsE.Cell(2, 2).Value = "Producto DEMO"
        wb.SaveAs(ruta)
    End Sub

    Private Sub BtnExaminar_Click(sender As Object, e As EventArgs) Handles BtnExaminar.Click
        Using ofd As New OpenFileDialog()
            ofd.Filter = "Excel (*.xlsx)|*.xlsx|Excel antiguo (*.xls)|*.xls"
            ofd.Title = "Seleccionar archivo del proveedor"
            If ofd.ShowDialog() <> DialogResult.OK Then Return

            txtArchivo.Text = ofd.FileName
            Dim fi As New FileInfo(ofd.FileName)
            Dim hash = CalcularHashArchivo(ofd.FileName)
            lblArchivoInfo.Text = $"Info: {fi.Name} | {Math.Round(fi.Length / 1024.0, 1)} KB | {fi.LastWriteTime:dd/MM/yyyy HH:mm} | MD5 {hash}"
            Log($"Archivo seleccionado: {fi.FullName}")
        End Using
    End Sub

    Private Function CalcularHashArchivo(path As String) As String
        Using md5 As MD5 = MD5.Create(), fs As FileStream = File.OpenRead(path)
            Return BitConverter.ToString(md5.ComputeHash(fs)).Replace("-", "")
        End Using
    End Function



End Class