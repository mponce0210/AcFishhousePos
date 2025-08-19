Imports System.Configuration
Imports System.Data.SqlClient


Public Class FrmAperturaCaja
    Private connStr As String = ConfigurationManager.
            ConnectionStrings("MiConexion").ConnectionString
    Public Property IdAperturaGenerada As Integer = 0

    Private Sub FrmAperturaCaja_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        TxtUsuario.Text = Environment.UserName  ' o el usuario de tu sistema
        TxtTerminal.Text = Environment.MachineName
        DtpApertura.Value = DateTime.Now
        nudMontoInicial.DecimalPlaces = 2
        nudMontoInicial.ThousandsSeparator = True
        nudMontoInicial.Minimum = 0
        nudMontoInicial.Maximum = 10000000D

        lblInfoUsuario.Text = $"Usuario: {TxtUsuario.Text} | Terminal: {TxtTerminal.Text} | {DateTime.Now:dd/MM/yyyy HH:mm}"
    End Sub
    Private Sub FrmAperturaCaja_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            e.Handled = True : BtnAbrir.PerformClick()
        ElseIf e.KeyCode = Keys.Escape Then
            e.Handled = True : BtnCancelar.PerformClick()
        End If
    End Sub
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnAbrir_Click(sender As Object, e As EventArgs) Handles BtnAbrir.Click
        If Not Validar() Then Exit Sub
        If AbrirTurno() Then
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If
    End Sub
    Private Function Validar() As Boolean
        If nudMontoInicial.Value < 0D Then
            MessageBox.Show("El monto inicial no puede ser negativo.", "Apertura de caja",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            nudMontoInicial.Focus()
            Return False
        End If
        Return True
    End Function

    Private Function AbrirTurno() As Boolean
        Try
            Using cn As New SqlConnection(connStr),
                  cmd As New SqlCommand("dbo.sp_AperturaCaja_Abrir", cn)

                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@Username", TxtUsuario.Text.Trim())
                cmd.Parameters.AddWithValue("@MontoInicial", nudMontoInicial.Value)
                cmd.Parameters.AddWithValue("@Observaciones", If(String.IsNullOrWhiteSpace(TxtObs.Text), DBNull.Value, TxtObs.Text.Trim()))
                cmd.Parameters.AddWithValue("@TerminalName", TxtTerminal.Text.Trim())

                Dim pOut As New SqlParameter("@IdAperturaCaja", SqlDbType.Int) With {.Direction = ParameterDirection.Output}
                cmd.Parameters.Add(pOut)

                cn.Open()
                cmd.ExecuteNonQuery()

                IdAperturaGenerada = CInt(pOut.Value)

                ' Guarda en una variable global/estática para el resto del sistema
                AperturaCajaContext.IdAperturaActual = IdAperturaGenerada
                AperturaCajaContext.Usuario = TxtUsuario.Text.Trim()
                AperturaCajaContext.Terminal = TxtTerminal.Text.Trim()
                AperturaCajaContext.FechaHora = DtpApertura.Value
                AperturaCajaContext.MontoInicial = nudMontoInicial.Value

                Return True
            End Using

        Catch ex As SqlException
            MessageBox.Show(ex.Message, "Apertura de caja", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As Exception
            MessageBox.Show("Error al abrir turno: " & ex.Message, "Apertura de caja",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function


End Class