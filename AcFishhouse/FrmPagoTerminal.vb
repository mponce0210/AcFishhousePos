Imports System.Configuration
Imports System.Data.SqlClient

Public Class FrmPagoTerminal

    Private connStr As String = ConfigurationManager.
        ConnectionStrings("MiConexion").ConnectionString

    Private ReadOnly _ventaId As Integer
    Private ReadOnly _monto As Decimal
    Private ReadOnly _terminalSugerida As Integer?   ' <-- NUEVO

    Public Sub New(ventaId As Integer, monto As Decimal, Optional terminalSugerida As Integer? = Nothing)
        InitializeComponent()
        _ventaId = ventaId
        _monto = monto
        _terminalSugerida = terminalSugerida
    End Sub

    Private Sub FrmPagoTerminal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lbltotal.Text = _monto.ToString("$#,##0.00")
        CargarTerminales()

        ' Preseleccionar terminal sugerida si viene
        If _terminalSugerida.HasValue Then
            Try
                cmbTerminal.SelectedValue = _terminalSugerida.Value
            Catch
                ' Ignorar si no está en el datasource
            End Try
        End If
    End Sub

    Private Sub CargarTerminales()
        Dim dt As New DataTable()
        Using cn As New SqlConnection(connStr),
              cmd As New SqlCommand("
                SELECT IdTerminal, CONCAT(NombreTerminal, ' (', Banco, ')') AS Nombre
                FROM dbo.CatTerminalesBancarias
                WHERE Activo = 1
                ORDER BY NombreTerminal", cn)
            cn.Open()
            dt.Load(cmd.ExecuteReader())
        End Using

        cmbTerminal.DataSource = dt
        cmbTerminal.DisplayMember = "Nombre"
        cmbTerminal.ValueMember = "IdTerminal"
        If dt.Rows.Count > 0 Then cmbTerminal.SelectedIndex = 0
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles Btnguardar.Click
        If cmbTerminal.SelectedValue Is Nothing Then
            MessageBox.Show("Selecciona la terminal.", "Pago con Terminal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbTerminal.DroppedDown = True : Exit Sub
        End If

        Try
            Using cn As New SqlConnection(connStr),
                  cmd As New SqlCommand("dbo.sp_VentasPorTerminal_Registrar", cn)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("@VentaId", SqlDbType.Int).Value = _ventaId
                cmd.Parameters.Add("@IdTerminal", SqlDbType.Int).Value = CInt(cmbTerminal.SelectedValue)
                cmd.Parameters.Add("@Monto", SqlDbType.Decimal).Value = _monto
                cmd.Parameters.Add("@ReferenciaBancaria", SqlDbType.NVarChar, 100).Value =
                    If(String.IsNullOrWhiteSpace(TxtReferencia.Text), CType(DBNull.Value, Object), TxtReferencia.Text.Trim())
                cmd.Parameters.Add("@Comentarios", SqlDbType.NVarChar, 250).Value =
                    If(String.IsNullOrWhiteSpace(TxtComentarios.Text), CType(DBNull.Value, Object), TxtComentarios.Text.Trim())

                cn.Open()
                cmd.ExecuteNonQuery()
            End Using

            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("No se pudo registrar el pago de terminal: " & ex.Message,
                            "Pago con Terminal", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub FrmPagoTerminal_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then BtnCancelar.PerformClick()
        If e.Control AndAlso e.KeyCode = Keys.Enter Then Btnguardar.PerformClick()
    End Sub


End Class