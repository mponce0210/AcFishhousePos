
' Imports System.Data.SqlClient


Imports System.Configuration
Imports System.Data.SqlClient

Public Class FrmVerificadorPrecio
    ' A nivel de formulario
    Private currentProducto As DataRow  ' último producto consultado (puede ser Nothing)
    Private connStr As String = ConfigurationManager.
        ConnectionStrings("MiConexion").ConnectionString
    Private ReadOnly tips As New ToolTip() With {.ShowAlways = True}
    Public Property ProductoSeleccionado As DataRow = Nothing
    Public Property CantidadSeleccionada As Decimal = 0D

    ' ===== FrmVerificadorPrecios.vb =====
    Public Class FrmVerificadorPrecios
        ' Resultado para la forma de ventas:
        Public Property ProductoSeleccionado As DataRow = Nothing
        Public Property CantidadSeleccionada As Decimal = 0D

        ' Interno del verificador:
        Private currentProducto As DataRow = Nothing
        Private ReadOnly tips As New ToolTip() With {.ShowAlways = True}
    End Class



    Private Sub ConsultarProducto(Optional codigo As String = Nothing, Optional idProducto As Integer? = Nothing)
        currentProducto = Nothing
        LblNombre.Text = ""
        LblPrecio.Text = ""
        lblExist.Text = ""

        If (String.IsNullOrWhiteSpace(codigo) AndAlso Not idProducto.HasValue) Then Exit Sub

        Dim dt As New DataTable()
        Using cn As New SqlConnection(connStr),
              cmd As New SqlCommand("dbo.sp_Producto_Verificar", cn)

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Codigo", SqlDbType.NVarChar, 60).Value = If(String.IsNullOrWhiteSpace(codigo), CType(DBNull.Value, Object), codigo)
            cmd.Parameters.Add("@IdProducto", SqlDbType.Int).Value = If(idProducto.HasValue, idProducto.Value, CType(DBNull.Value, Object))

            Using da As New SqlDataAdapter(cmd)
                da.Fill(dt)
            End Using
        End Using

        If dt.Rows.Count = 0 Then
            LblNombre.Text = "Producto no encontrado"
            LblPrecio.Text = ""
            Return
        End If

        currentProducto = dt.Rows(0)

        ' Pintar UI
        LblNombre.Text = currentProducto!Descripcion.ToString()
        LblPrecio.Text = String.Format("${0:N2}", Convert.ToDecimal(currentProducto!PrecioPub))
        lblExist.Text = "Existencia: " & Convert.ToDecimal(currentProducto!Existencia).ToString("N2")

        ' Estética (precio grande, verde, bold)
        LblPrecio.Font = New Font(LblPrecio.Font.FontFamily, 48, FontStyle.Bold)
        LblPrecio.ForeColor = Color.DarkGreen  ' puedes cambiar a el que prefieras
    End Sub

    Private Sub TxtScan_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtScan.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            ConsultarProducto(TxtScan.Text.Trim(), Nothing)
            TxtScan.SelectAll()
        End If
    End Sub

    Private Sub FrmVerificadorPrecio_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.F1 Then
            e.Handled = True
            BtnAgregar.PerformClick()
        ElseIf e.KeyCode = Keys.Escape Then
            e.Handled = True
            BtnCancelar.PerformClick()
        End If

    End Sub

    Private Sub BtnAgregar_Click(sender As Object, e As EventArgs) Handles BtnAgregar.Click

        If currentProducto Is Nothing Then
            MessageBox.Show("Primero escanea o busca un producto.", "Verificador", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtScan.Focus() : Exit Sub
        End If

        ProductoSeleccionado = currentProducto
        CantidadSeleccionada = Convert.ToDecimal(NudCant.Value)

        Me.DialogResult = DialogResult.OK
        Me.Close()

    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        TxtScan.Clear()
        LblNombre.Text = ""
        LblPrecio.Text = ""
        lblExist.Text = ""
        currentProducto = Nothing
        TxtScan.Focus()
    End Sub

    Private Sub FrmVerificadorPrecio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtScan.Clear()
        LblNombre.Text = ""
        LblPrecio.Text = ""
        lblExist.Text = ""
        currentProducto = Nothing
        TxtScan.Focus()
        NudCant.Minimum = 1 : NudCant.Maximum = 999 : NudCant.Value = 1
        TxtScan.Focus()
    End Sub

    Private Sub TxtScan_Enter(sender As Object, e As EventArgs) Handles TxtScan.Enter
        tips.Show("Escanea o escribe el código y presiona ENTER.", TxtScan, 10, -20, 2000)
    End Sub

    Public Sub CargarPorId(idProducto As Integer)
        ConsultarProducto(Nothing, idProducto)
    End Sub


End Class