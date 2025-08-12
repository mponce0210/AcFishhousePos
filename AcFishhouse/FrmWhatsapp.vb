Imports System.IO
Imports System.Collections.Specialized
Imports System.Diagnostics
Public Class FrmWhatsapp

    ' <<< AQUÍ, a nivel de clase >>>
    Private _archivoSeleccionado As String = Nothing
    Private Const TICKETS_DIR As String = "C:\TicketsACFH"
    Private Sub FrmWhatsapp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' (opcional) garantizar que la carpeta exista
        If Not Directory.Exists(TICKETS_DIR) Then
            Directory.CreateDirectory(TICKETS_DIR)
        End If
    End Sub

    Private Sub BtnEnviar_Click(sender As Object, e As EventArgs) Handles BtnEnviar.Click
        ' 1) Normalizamos teléfono
        Dim phone As String = NormalizarTelefono(TxtNumTel.Text)
        If String.IsNullOrWhiteSpace(phone) OrElse phone.Length < 10 Then
            MessageBox.Show("Ingresa un número válido (incluye lada). Ejemplo: 5218123456789",
                            "WhatsApp", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TxtNumTel.Focus()
            Return
        End If

        ' 2) Mensaje
        Dim texto As String = TxtMsg.Text.Trim()
        If texto = "" Then texto = "Hola, le compartimos su ticket y Gracias por su compra ¡lo esperamos nuevamente!!!! "

        ' 3) URL de WhatsApp (web). También funciona con app de escritorio si el sistema redirige.
        Dim url As String = "https://api.whatsapp.com/send?phone=" & phone &
                            "&text=" & Uri.EscapeDataString(texto)

        Try
            Process.Start(New ProcessStartInfo(url) With {.UseShellExecute = True})

            ' Sugerencia al usuario
            Dim aviso As String = "Se abrió WhatsApp. Ahora presiona **Ctrl+V** para pegar el archivo que ya está en el portapapeles." &
                                  If(String.IsNullOrEmpty(_archivoSeleccionado), "",
                                     vbCrLf & vbCrLf & "Archivo: " & _archivoSeleccionado)
            MessageBox.Show(aviso, "WhatsApp", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("No se pudo abrir WhatsApp: " & ex.Message, "WhatsApp",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function NormalizarTelefono(input As String) As String
        If String.IsNullOrWhiteSpace(input) Then Return ""
        ' Quita todo menos dígitos
        Dim digits As String = New String(input.Where(AddressOf Char.IsDigit).ToArray())
        ' Si empieza con 0, 00 o 52… ajusta según tu operación
        If digits.StartsWith("00") Then digits = digits.Substring(2)
        If Not digits.StartsWith("52") Then
            ' Si ya viene con 11-12 dígitos y código de país diferente, quita este bloque
            If digits.Length = 10 Then
                digits = "52" & digits ' MX por defecto
            End If
        End If
        Return digits
    End Function

    Private Sub BtnAdjuntar_Click(sender As Object, e As EventArgs) Handles BtnAdjuntar.Click


        Using ofd As New OpenFileDialog()
            ofd.Title = "Selecciona archivo a adjuntar"
            ' Acepta imágenes y PDFs
            ofd.Filter = "Imágenes|*.jpg;*.jpeg;*.png;*.bmp|PDF|*.pdf|Todos los archivos|*.*"
            ofd.Multiselect = False

            If ofd.ShowDialog() <> DialogResult.OK Then Exit Sub

            Dim ruta As String = ofd.FileName
            If Not File.Exists(ruta) Then
                MessageBox.Show("El archivo ya no existe.", "Adjuntar", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Try
                Dim ext = Path.GetExtension(ruta).ToLowerInvariant()

                ' Si es imagen -> al portapapeles como imagen
                If ext = ".jpg" OrElse ext = ".jpeg" OrElse ext = ".png" OrElse ext = ".bmp" Then
                    ' Usar Using para liberar la imagen
                    Using img As Image = Image.FromFile(ruta)
                        Clipboard.SetImage(img)
                    End Using
                    LblAdjunta.Text = "Imagen lista para pegar (Ctrl+V)"
                Else
                    ' Cualquier otro archivo (PDF incluido) -> portapapeles como archivo
                    Dim files As New StringCollection()
                    files.Add(ruta)
                    Clipboard.SetFileDropList(files)
                    LblAdjunta.Text = "Archivo listo para pegar (Ctrl+V): " & Path.GetFileName(ruta)
                End If

                MessageBox.Show("Listo. Abre tu chat de WhatsApp y presiona Ctrl+V para adjuntar.",
                                "Adjuntar", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                MessageBox.Show("Error al adjuntar: " & ex.Message, "Adjuntar", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using


    End Sub

    Private Sub AbrirCarpetaConArchivoSeleccionado()
        If Not String.IsNullOrEmpty(_archivoSeleccionado) AndAlso File.Exists(_archivoSeleccionado) Then
            Process.Start(New ProcessStartInfo("explorer.exe",
                "/select,""" & _archivoSeleccionado & """") With {.UseShellExecute = True})
        ElseIf Directory.Exists(TICKETS_DIR) Then
            Process.Start(New ProcessStartInfo(TICKETS_DIR) With {.UseShellExecute = True})
        End If
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Me.Close()
    End Sub
End Class