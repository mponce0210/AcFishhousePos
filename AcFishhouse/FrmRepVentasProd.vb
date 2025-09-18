
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Public Class FrmProductosVendidos


    Private ReadOnly connStr As String = ConfigurationManager.ConnectionStrings("MiConexion").ConnectionString
    Private Sub FrmProductosVendidos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Llena combo de periodos
        CboPeriodo.DropDownStyle = ComboBoxStyle.DropDownList
        CboPeriodo.Items.Clear()
        CboPeriodo.Items.AddRange(New Object() {
            "Semana actual",
            "Mes actual",
            "Mes anterior",
            "Año actual",
            "Un período personalizado"
        })
        CboPeriodo.SelectedIndex = 4 ' Mes actual por default

        dtpDesde.Enabled = False
        DtpHasta.Enabled = False

        ' Formato del grid
        PrepararGrid()

        ' Primera consulta
        Consultar()

    End Sub

    Private Sub CboPeriodo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboPeriodo.SelectedIndexChanged
        Dim personalizado = (CboPeriodo.SelectedIndex = 4)
        dtpDesde.Enabled = personalizado
        DtpHasta.Enabled = personalizado
        RefrescarTodo()
    End Sub

    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        Consultar()

    End Sub
    Private Sub Consultar()
        Dim modo As String
        Dim desde As Object = DBNull.Value
        Dim hasta As Object = DBNull.Value

        Select Case CboPeriodo.SelectedIndex
            Case 0 : modo = "SEMANA"
            Case 1 : modo = "MES"
            Case 2 : modo = "MES_ANT"
            Case 3 : modo = "ANIO"
            Case 4
                modo = "PERS"
                desde = dtpDesde.Value.Date
                hasta = DtpHasta.Value.Date
            Case Else
                modo = "MES"
        End Select

        Dim dt As New DataTable()
        Using cn As New SqlConnection(connStr),
              da As New SqlDataAdapter("dbo.rpt_ProductosVendidos", cn)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.AddWithValue("@Modo", modo)
            da.SelectCommand.Parameters.AddWithValue("@Desde", If(desde Is Nothing, DBNull.Value, desde))
            da.SelectCommand.Parameters.AddWithValue("@Hasta", If(hasta Is Nothing, DBNull.Value, hasta))
            da.Fill(dt)
        End Using

        dgvResultados.DataSource = dt

        ' Total vendido = sum(Cantidad * PrecioPublico)  (o usa la columna Importe)
        Dim total As Decimal = 0D
        If dt.Rows.Count > 0 Then
            total = Convert.ToDecimal(dt.Compute("SUM(Importe)", Nothing))
        End If
        tssTotalVend.Text = total.ToString("C2")
    End Sub

    Private Sub PrepararGrid()
        With dgvResultados
            .AutoGenerateColumns = False
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .Columns.Clear()

            ' Código
            Dim colCodigo As New DataGridViewTextBoxColumn()
            colCodigo.Name = "colCodigo"
            colCodigo.HeaderText = "Código"
            colCodigo.DataPropertyName = "Codigo"
            colCodigo.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns.Add(colCodigo)

            ' Descripción
            Dim colDescripcion As New DataGridViewTextBoxColumn()
            colDescripcion.Name = "colDescripcion"
            colDescripcion.HeaderText = "Descripción del producto"
            colDescripcion.DataPropertyName = "DescripcionProducto"
            colDescripcion.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns.Add(colDescripcion)

            ' Cantidad
            Dim colCantidad As New DataGridViewTextBoxColumn()
            colCantidad.Name = "colCantidad"
            colCantidad.HeaderText = "Cantidad"
            colCantidad.DataPropertyName = "Cantidad"
            colCantidad.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            colCantidad.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            colCantidad.DefaultCellStyle.Format = "N2"
            colCantidad.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns.Add(colCantidad)

            ' Precio al público
            Dim colPrecio As New DataGridViewTextBoxColumn()
            colPrecio.Name = "colPrecio"
            colPrecio.HeaderText = "Precio al público"
            colPrecio.DataPropertyName = "PrecioPublico"
            colPrecio.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            colPrecio.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            colPrecio.DefaultCellStyle.ForeColor = Color.DarkGreen
            colPrecio.DefaultCellStyle.Font = New Font(dgvResultados.Font, FontStyle.Bold)
            colPrecio.DefaultCellStyle.Format = "C2"
            colPrecio.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns.Add(colPrecio)

            ' Departamento
            Dim colDepartamento As New DataGridViewTextBoxColumn()
            colDepartamento.Name = "colDepartamento"
            colDepartamento.HeaderText = "Departamento"
            colDepartamento.DataPropertyName = "Departamento"
            colDepartamento.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns.Add(colDepartamento)

            ' Importe
            Dim colImporte As New DataGridViewTextBoxColumn()
            colImporte.Name = "colImporte"
            colImporte.HeaderText = "Importe"
            colImporte.DataPropertyName = "Importe"
            colImporte.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            colImporte.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            colImporte.DefaultCellStyle.ForeColor = Color.DarkGreen
            colImporte.DefaultCellStyle.Font = New Font(dgvResultados.Font, FontStyle.Bold)
            colImporte.DefaultCellStyle.Format = "C2"
            colImporte.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns.Add(colImporte)
        End With
    End Sub

    Private Sub GetRango(ByRef fIni As Date, ByRef fFin As Date)
        Dim hoy As Date = Date.Today
        Select Case CboPeriodo.SelectedIndex
            Case 0 ' Semana actual
                Dim dayOfWeek As Integer = (CInt(hoy.DayOfWeek) + 6) Mod 7 ' lunes=0
                fIni = hoy.AddDays(-dayOfWeek)
                fFin = fIni.AddDays(6)
            Case 1 ' Mes actual
                fIni = New Date(hoy.Year, hoy.Month, 1)
                fFin = hoy
            Case 2 ' Mes anterior
                Dim mAnt As Date = hoy.AddMonths(-1)
                fIni = New Date(mAnt.Year, mAnt.Month, 1)
                fFin = New Date(mAnt.Year, mAnt.Month, Date.DaysInMonth(mAnt.Year, mAnt.Month))
            Case 3 ' Año actual
                fIni = New Date(hoy.Year, 1, 1)
                fFin = hoy
            Case 4 ' Personalizado
                fIni = dtpDesde.Value.Date
                fFin = DtpHasta.Value.Date
            Case Else
                fIni = hoy : fFin = hoy
        End Select
    End Sub

    Private Sub dtpDesde_ValueChanged(sender As Object, e As EventArgs) Handles dtpDesde.ValueChanged
        If CboPeriodo.SelectedIndex = 4 Then RefrescarTodo()
    End Sub

    Private Sub DtpHasta_ValueChanged(sender As Object, e As EventArgs) Handles DtpHasta.ValueChanged
        If CboPeriodo.SelectedIndex = 4 Then RefrescarTodo()
    End Sub
    Private Sub RefrescarTodo()
        Dim fi As Date, ff As Date
        GetRango(fi, ff)

        Consultar() '(fi, ff) ' llena dgvResultados (ya lo tienes)
        CargarTicketsDia(fi, ff)        ' nuevo
        CargarTop20(fi, ff)             ' nuevo
    End Sub

    Private Sub CargarTicketsDia(fi As Date, ff As Date)
        Dim dt As New DataTable()
        Using cn As New SqlConnection(connStr),
              da As New SqlDataAdapter("dbo.rpt_Ventas_TicketsPorDia", cn)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.AddWithValue("@FIni", fi)
            da.SelectCommand.Parameters.AddWithValue("@FFin", ff)
            da.Fill(dt)
        End Using
        dgvTicketsDia.DataSource = dt
        FormatoTicketsDia()
    End Sub
    Private Sub CargarTop20(fi As Date, ff As Date)
        Dim dt As New DataTable()
        Using cn As New SqlConnection(connStr),
              da As New SqlDataAdapter("dbo.rpt_Ventas_TopProductos20", cn)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.AddWithValue("@FIni", fi)
            da.SelectCommand.Parameters.AddWithValue("@FFin", ff)
            da.Fill(dt)
        End Using
        dgvTop20.DataSource = dt
        FormatoTop20()
    End Sub

    Private Sub FormatoTicketsDia()
        With dgvTicketsDia
            .AutoGenerateColumns = True
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            If .Columns.Contains("Dia") Then
                .Columns("Dia").HeaderText = "Día"
                .Columns("Dia").DefaultCellStyle.Format = "dd/MM/yyyy"
                .Columns("Dia").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End If
            If .Columns.Contains("Tickets") Then
                .Columns("Tickets").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Tickets").DefaultCellStyle.Format = "N0"
            End If
            If .Columns.Contains("Importe") Then
                .Columns("Importe").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Importe").DefaultCellStyle.Format = "C2"
                .Columns("Importe").DefaultCellStyle.ForeColor = Color.DarkGreen
                .Columns("Importe").DefaultCellStyle.Font = New Font(.Font, FontStyle.Bold)
            End If
        End With
    End Sub
    Private Sub FormatoTop20()
        With dgvTop20
            .AutoGenerateColumns = True
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .RowHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            If .Columns.Contains("ProductoID") Then .Columns("ProductoID").HeaderText = "ID"
            If .Columns.Contains("Producto") Then .Columns("Producto").HeaderText = "Producto"

            If .Columns.Contains("Cantidad") Then
                .Columns("Cantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Cantidad").DefaultCellStyle.Format = "N2"
            End If

            If .Columns.Contains("Importe") Then
                .Columns("Importe").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Importe").DefaultCellStyle.Format = "C2"
                .Columns("Importe").DefaultCellStyle.ForeColor = Color.DarkGreen
                .Columns("Importe").DefaultCellStyle.Font = New Font(.Font, FontStyle.Bold)
            End If
        End With
    End Sub

    Private Sub btnLinkExportar_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles btnLinkExportar.LinkClicked

        If dgvResultados.DataSource Is Nothing Then Return
        Using sfd As New SaveFileDialog With {.Filter = "Excel (*.xlsx)|*.xlsx", .FileName = "ProductosVendidos.xlsx"}
            If sfd.ShowDialog() = DialogResult.OK Then
                ExportarGridAExcel(CType(dgvResultados.DataSource, DataTable), sfd.FileName)
                MessageBox.Show("Archivo generado.", "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End Using
    End Sub

    Private Sub ExportarGridAExcel(dt As DataTable, ruta As String)
        ' Si ya tienes ClosedXML referenciado
        Try
            Using wb As New ClosedXML.Excel.XLWorkbook()
                Dim ws = wb.AddWorksheet("Datos")
                ws.Cell(1, 1).InsertTable(dt, "Tabla", True)
                ws.Columns().AdjustToContents()
                wb.SaveAs(ruta)
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al exportar: " & ex.Message)
        End Try
    End Sub

    Private Sub LnkDash_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkDash.LinkClicked
        ' OJO: reemplaza por tu URL compartida de Looker/Sheets
        Dim url = "https://lookerstudio.google.com/s/oHnwdngNoug"
        AbrirUrl(url)
        LnkDash.LinkVisited = True
    End Sub


    Private Sub AbrirUrl(url As String)
        Try
            If String.IsNullOrWhiteSpace(url) Then
                Throw New Exception("El link está vacío.")
            End If
            ' Asegura esquema:
            If Not (url.StartsWith("http://", StringComparison.OrdinalIgnoreCase) _
            OrElse url.StartsWith("https://", StringComparison.OrdinalIgnoreCase)) Then
                url = "https://" & url
            End If

            ' Abre en el navegador predeterminado (compatible .NET Framework y .NET 5+)
            Dim psi As New ProcessStartInfo With {
            .FileName = url,
            .UseShellExecute = True
        }
            Process.Start(psi)

        Catch ex As Exception
            MessageBox.Show("No pude abrir el Dashboard. Verifica el link compartido." &
                        Environment.NewLine & ex.Message,
                        "Abrir Dashboard", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



End Class