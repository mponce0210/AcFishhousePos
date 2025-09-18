Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Public Class MarcasForm

    'Private connStr As String = My.Settings.connStr
    Private connStr As String = ConfigurationManager _
        .ConnectionStrings("MiConexion").ConnectionString
    Private da As SqlDataAdapter
    Private dt As DataTable
    Private WithEvents bs As New BindingSource()

    Private Sub MarcasForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        ConfigurarGrid()
        CargarMarcas()
        AgregarAtajos()
    End Sub

    Private Sub ConfigurarGrid()
        DgvMarcas.AutoGenerateColumns = False
        DgvMarcas.Columns.Clear()

        ' IdMarca (RO)
        Dim cId As New DataGridViewTextBoxColumn() With {
            .Name = "IdMarca",
            .DataPropertyName = "IdMarca",
            .HeaderText = "ID",
            .ReadOnly = True,
            .Width = 60
        }
        DgvMarcas.Columns.Add(cId)

        ' Nombre
        Dim cNom As New DataGridViewTextBoxColumn() With {
            .Name = "Nombre",
            .DataPropertyName = "Nombre",
            .HeaderText = "Nombre de la Marca",
            .Width = 240
        }
        DgvMarcas.Columns.Add(cNom)

        ' Activo
        Dim cAct As New DataGridViewCheckBoxColumn() With {
            .Name = "Activo",
            .DataPropertyName = "Activo",
            .HeaderText = "Activo",
            .Width = 60
        }
        DgvMarcas.Columns.Add(cAct)

        ' Orden
        Dim cOrd As New DataGridViewTextBoxColumn() With {
            .Name = "Orden",
            .DataPropertyName = "Orden",
            .HeaderText = "Orden",
            .Width = 70
        }
        DgvMarcas.Columns.Add(cOrd)

        ' CodigoExterno
        Dim cCod As New DataGridViewTextBoxColumn() With {
            .Name = "CodigoExterno",
            .DataPropertyName = "CodigoExterno",
            .HeaderText = "Código externo",
            .Width = 120
        }
        DgvMarcas.Columns.Add(cCod)

        ' LogoUrl
        Dim cLogo As New DataGridViewTextBoxColumn() With {
            .Name = "LogoUrl",
            .DataPropertyName = "LogoUrl",
            .HeaderText = "Logo URL",
            .Width = 180
        }
        DgvMarcas.Columns.Add(cLogo)

        ' FechaCreacion (RO)
        Dim cFC As New DataGridViewTextBoxColumn() With {
            .Name = "FechaCreacion",
            .DataPropertyName = "FechaCreacion",
            .HeaderText = "Creación",
            .ReadOnly = True,
            .Width = 140
        }
        DgvMarcas.Columns.Add(cFC)

        ' FechaMod (RO)
        Dim cFM As New DataGridViewTextBoxColumn() With {
            .Name = "FechaMod",
            .DataPropertyName = "FechaMod",
            .HeaderText = "Últ. Mod",
            .ReadOnly = True,
            .Width = 140
        }
        DgvMarcas.Columns.Add(cFM)

        ' UsuarioMod (opcional RO)
        Dim cUM As New DataGridViewTextBoxColumn() With {
            .Name = "UsuarioMod",
            .DataPropertyName = "UsuarioMod",
            .HeaderText = "UsuarioMod",
            .ReadOnly = True,
            .Width = 120
        }
        DgvMarcas.Columns.Add(cUM)
    End Sub

    Private Sub CargarMarcas()
        dt = New DataTable()

        Using cn As New SqlConnection(connStr)
            da = New SqlDataAdapter("sp_Marcas_Listar", cn)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            ' (Opcional) filtros:
            da.SelectCommand.Parameters.AddWithValue("@SoloActivas", DBNull.Value)
            da.SelectCommand.Parameters.AddWithValue("@FiltroNombre", DBNull.Value)
            da.SelectCommand.Parameters.AddWithValue("@Top", DBNull.Value)

            ' INSERT
            da.InsertCommand = New SqlCommand("sp_Marcas_Insertar", cn)
            da.InsertCommand.CommandType = CommandType.StoredProcedure
            da.InsertCommand.Parameters.Add("@Nombre", SqlDbType.VarChar, 100, "Nombre")
            da.InsertCommand.Parameters.Add("@Activo", SqlDbType.Bit, 0, "Activo")
            da.InsertCommand.Parameters.Add("@Orden", SqlDbType.Int, 0, "Orden")
            da.InsertCommand.Parameters.Add("@CodigoExterno", SqlDbType.VarChar, 50, "CodigoExterno")
            da.InsertCommand.Parameters.Add("@LogoUrl", SqlDbType.VarChar, 300, "LogoUrl")
            da.InsertCommand.Parameters.Add("@UsuarioMod", SqlDbType.VarChar, 80, "UsuarioMod")
            da.InsertCommand.UpdatedRowSource = UpdateRowSource.FirstReturnedRecord

            ' UPDATE
            da.UpdateCommand = New SqlCommand("sp_Marcas_Actualizar", cn)
            da.UpdateCommand.CommandType = CommandType.StoredProcedure
            da.UpdateCommand.Parameters.Add("@IdMarca", SqlDbType.Int, 0, "IdMarca")
            da.UpdateCommand.Parameters.Add("@Nombre", SqlDbType.VarChar, 100, "Nombre")
            da.UpdateCommand.Parameters.Add("@Activo", SqlDbType.Bit, 0, "Activo")
            da.UpdateCommand.Parameters.Add("@Orden", SqlDbType.Int, 0, "Orden")
            da.UpdateCommand.Parameters.Add("@CodigoExterno", SqlDbType.VarChar, 50, "CodigoExterno")
            da.UpdateCommand.Parameters.Add("@LogoUrl", SqlDbType.VarChar, 300, "LogoUrl")
            da.UpdateCommand.Parameters.Add("@UsuarioMod", SqlDbType.VarChar, 80, "UsuarioMod")
            da.UpdateCommand.UpdatedRowSource = UpdateRowSource.FirstReturnedRecord

            ' DELETE -> desactivar (usa fila Deleted, tomamos IdMarca Original)
            da.DeleteCommand = New SqlCommand("sp_Marcas_Desactivar", cn)
            da.DeleteCommand.CommandType = CommandType.StoredProcedure
            Dim pDel As SqlParameter = da.DeleteCommand.Parameters.Add("@IdMarca", SqlDbType.Int, 0, "IdMarca")
            pDel.SourceVersion = DataRowVersion.Original
            da.DeleteCommand.Parameters.Add("@UsuarioMod", SqlDbType.VarChar, 80, "UsuarioMod")
            da.DeleteCommand.UpdatedRowSource = UpdateRowSource.FirstReturnedRecord

            da.Fill(dt)
        End Using

        bs.DataSource = dt
        DgvMarcas.DataSource = bs
    End Sub

    Private Sub GuardarCambios()
        DgvMarcas.EndEdit()
        bs.EndEdit()
        Using cn As New SqlConnection(connStr)
            da.InsertCommand.Connection = cn
            da.UpdateCommand.Connection = cn
            da.DeleteCommand.Connection = cn
            cn.Open()
            da.Update(dt)
        End Using
    End Sub

    ' Buscar local
    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        Dim f As String = txtBuscar.Text.Trim().Replace("'", "''")
        If f = "" Then
            bs.RemoveFilter()
        Else
            bs.Filter = $"Nombre LIKE '%{f}%'"
        End If
    End Sub

    ' Validaciones
    Private Sub dgvMarcas_RowValidating(sender As Object, e As DataGridViewCellCancelEventArgs) Handles DgvMarcas.RowValidating
        If DgvMarcas.IsCurrentRowDirty Then
            Dim row As DataGridViewRow = DgvMarcas.Rows(e.RowIndex)
            Dim nombre As Object = row.Cells("Nombre").Value
            If nombre Is Nothing OrElse String.IsNullOrWhiteSpace(nombre.ToString()) Then
                MessageBox.Show("El campo 'Nombre' es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                e.Cancel = True
                Return
            End If
            ' Duplicados en memoria
            Dim nomVal = nombre.ToString().Trim().ToUpperInvariant()
            Dim countDup = dt.AsEnumerable().Count(Function(r) r.RowState <> DataRowState.Deleted AndAlso
                                                   r.Field(Of String)("Nombre") IsNot Nothing AndAlso
                                                   r.Field(Of String)("Nombre").Trim().ToUpperInvariant() = nomVal)
            If countDup > 1 Then
                MessageBox.Show("Ya existe una marca con ese nombre.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub dgvMarcas_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles DgvMarcas.DataError
        MessageBox.Show("Dato inválido: " & e.Exception.Message, "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        e.ThrowException = False
    End Sub

    ' Botones
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            GuardarCambios()
            MessageBox.Show("Cambios guardados.", "Marcas", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As SqlException
            MessageBox.Show("No se pudieron guardar los cambios: " & ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRefrescar_Click(sender As Object, e As EventArgs) Handles btnReFrescar.Click
        CargarMarcas()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles Btneliminar.Click
        If bs.Current Is Nothing Then Return
        Dim drv As DataRowView = CType(bs.Current, DataRowView)
        Dim nombre As String = TryCast(drv("Nombre"), String)
        If MessageBox.Show($"¿Desactivar la marca '{nombre}'?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            drv.Delete() ' Ejecutará sp_Marcas_Desactivar con IdMarca (Original)
            btnGuardar.PerformClick()
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        bs.AddNew()
        DgvMarcas.CurrentCell = DgvMarcas.Rows(DgvMarcas.NewRowIndex).Cells("Nombre")
        DgvMarcas.BeginEdit(True)
    End Sub

    Private Sub AgregarAtajos()
        AddHandler Me.KeyDown, Sub(s, e)
                                   If e.Control AndAlso e.KeyCode = Keys.S Then
                                       btnGuardar.PerformClick()
                                       e.SuppressKeyPress = True
                                   ElseIf e.KeyCode = Keys.F5 Then
                                       btnReFrescar.PerformClick()
                                       e.SuppressKeyPress = True
                                   End If
                               End Sub
    End Sub

End Class
