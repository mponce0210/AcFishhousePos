Imports System.Data.SqlClient
Imports System.Configuration

Public Class LoginForm

    Private connStr As String = ConfigurationManager.
         ConnectionStrings("MiConexion").ConnectionString
    Private dtUsers As DataTable

    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' 2) Crear la instancia del DataTable
        dtUsers = New DataTable()

        btnLogin.BackColor = Color.FromArgb(0, 120, 215)
        btnCancelar.BackColor = Color.FromArgb(0, 120, 215)

        Dim sql As String = "SELECT Username, Nombre FROM dbo.Users ORDER BY Username"

        Try
            Using cn As New SqlConnection(connStr),
                  cmd As New SqlCommand(sql, cn)
                ' 3) Declarar y crear el SqlDataAdapter
                Dim adapter As New SqlDataAdapter(cmd)

                cn.Open()
                adapter.Fill(dtUsers)    ' Ahora dtUsers ya existe
            End Using

            ' 4) Vincular al ComboBox
            cmbusers.DataSource = dtUsers
            cmbusers.DisplayMember = "Username"
            cmbusers.ValueMember = "Nombre"
            cmbusers.SelectedIndex = -1

        Catch ex As Exception
            MessageBox.Show("Error al cargar usuarios: " & ex.Message,
                            "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbUsers_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles cmbusers.SelectedIndexChanged

        If cmbusers.SelectedIndex >= 0 Then
            Txtnom.Text = cmbusers.SelectedValue.ToString()
        Else
            Txtnom.Clear()
        End If

    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim user As String = cmbusers.Text.Trim()
        Dim pass As String = txtPassword.Text.Trim()

        If pass = "" Then
            MessageBox.Show("Ingresa tu contraseña.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Using cn As New SqlConnection(connStr),
              cmd As New SqlCommand("dbo.usp_ValidateUser", cn)
                cmd.CommandType = CommandType.StoredProcedure

                cmd.Parameters.AddWithValue("@Username", user)
                cmd.Parameters.AddWithValue("@Password", pass)

                Dim pRole As New SqlParameter("@RoleID", SqlDbType.Int)
                pRole.Direction = ParameterDirection.Output
                cmd.Parameters.Add(pRole)

                cn.Open()
                cmd.ExecuteNonQuery()

                Dim roleID As Integer = Convert.ToInt32(cmd.Parameters("@RoleID").Value)

                If roleID > 0 Then
                    MessageBox.Show($"Bienvenido, {user} (Rol: {roleID})",
                                "OK", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Dim mainForm As New mainForm()
                    mainForm.UserRole = roleID
                    mainForm.Show()
                    Me.Hide()

                Else
                    MessageBox.Show("Usuario o contraseña incorrectos.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End Using

        Catch ex As Exception
            MessageBox.Show("Error al validar usuario: " & ex.Message,
                        "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Application.Exit()
    End Sub
End Class