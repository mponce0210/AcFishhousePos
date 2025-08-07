Imports System.Configuration
Imports System.Data.SqlClient
Public Class FrmBusquedaProductos
    Private ReadOnly connStr As String =
        ConfigurationManager.
            ConnectionStrings("MiConexion").
            ConnectionString
    Public Property ProductoSeleccionado As DataRowView
    Private bsProductos As New BindingSource()

    Private Sub FrmBusquedaProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarProductos()
    End Sub

    Private Sub CargarProductos()
        Dim dt As New DataTable()
        Using cn As New SqlConnection(connStr),
              da As New SqlDataAdapter("dbo.sp_Productos_Inventario", cn)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.Fill(dt)
        End Using

        bsProductos.DataSource = dt
        dgvProductos.DataSource = bsProductos


    End Sub

    Private Sub txtFiltro_TextChanged(sender As Object, e As EventArgs) _
       Handles txtFiltro.TextChanged
        Dim f = txtFiltro.Text.Replace("'", "''")
        If f = "" Then
            bsProductos.RemoveFilter()
        Else
            bsProductos.Filter = $"CodigoBarra LIKE '%{f}%' OR Descripcion LIKE '%{f}%'"
        End If
    End Sub

    Private Sub dgvProductos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductos.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub
        ProductoSeleccionado = DirectCast(bsProductos.Current, DataRowView)
        Me.DialogResult = DialogResult.OK
        Me.Close()


    End Sub
End Class