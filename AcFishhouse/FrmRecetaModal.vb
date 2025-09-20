
Imports Microsoft.Web.WebView2.Core
Imports Newtonsoft.Json.Linq
Imports System.Net
Imports System.Text

Public Class FrmRecetaModal
    Private ReadOnly _connStr As String
    Private ReadOnly _catId As Integer
    Private _noteId As Integer? = Nothing
    Public Sub New(connStr As String, catId As Integer, Optional noteId As Integer? = Nothing)
        InitializeComponent()
        _connStr = connStr
        _catId = catId
        _noteId = noteId
    End Sub

    Private Async Sub FrmRecetaModal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = If(_noteId.HasValue, "Editar Receta", "Nueva Receta")
        Await wvPrev.EnsureCoreWebView2Async(Nothing)
        If _noteId.HasValue Then CargarReceta(_noteId.Value)
        RenderPreview()
    End Sub
    Private Sub CargarReceta(noteId As Integer)
        Using cn As New SqlClient.SqlConnection(_connStr),
              cmd As New SqlClient.SqlCommand("sp_Pizarra_Obtener", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@NoteID", noteId)
            cn.Open()
            Using rd = cmd.ExecuteReader()
                If rd.Read() Then
                    txttitulo.Text = rd("Titulo").ToString()
                    Dim meta As JObject = If(IsDBNull(rd("MetaJSON")) OrElse rd("MetaJSON") Is Nothing _
                                             OrElse rd("MetaJSON").ToString() = "",
                                             New JObject(),
                                             JObject.Parse(rd("MetaJSON").ToString()))
                    txtEspecie.Text = meta.Value(Of String)("Especie")
                    txtDiagnostico.Text = meta.Value(Of String)("Diagnostico")
                    Txtmedicamento.Text = meta.Value(Of String)("Medicamento")
                    txtdosis.Text = meta.Value(Of String)("Dosis")
                    txtFrecuencia.Text = meta.Value(Of String)("Frecuencia")
                    numDuracion.Value = CDec(If(meta.Value(Of Integer?)("DuracionDias"), 0))
                    txtcambiosAgua.Text = meta.Value(Of String)("CambiosAgua")
                    txtadvertencias.Text = meta.Value(Of String)("Advertencias")
                    txtNotasEspecialista.Text = meta.Value(Of String)("NotasEspecialista")
                End If
            End Using
        End Using
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        If String.IsNullOrWhiteSpace(txttitulo.Text) Then
            MessageBox.Show("Captura el Título de la receta.", "Recetas") : txttitulo.Focus() : Exit Sub
        End If
        Dim meta As New JObject(
                 New JProperty("Especie", txtEspecie.Text.Trim()),
                 New JProperty("Diagnostico", txtDiagnostico.Text.Trim()),
                 New JProperty("Medicamento", Txtmedicamento.Text.Trim()),
                 New JProperty("Dosis", txtdosis.Text.Trim()),
                 New JProperty("Frecuencia", txtFrecuencia.Text.Trim()),
                 New JProperty("DuracionDias", CInt(numDuracion.Value)),
                 New JProperty("CambiosAgua", txtcambiosAgua.Text.Trim()),
                 New JProperty("Advertencias", txtadvertencias.Text.Trim()),
                 New JProperty("NotasEspecialista", txtNotasEspecialista.Text.Trim()))

        Using cn As New SqlClient.SqlConnection(_connStr),
              cmd As New SqlClient.SqlCommand("sp_Pizarra_Guardar", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim pId = cmd.Parameters.Add("@NoteID", SqlDbType.Int)
            pId.Direction = ParameterDirection.InputOutput
            pId.Value = If(_noteId.HasValue, CType(_noteId.Value, Object), DBNull.Value)

            cmd.Parameters.Add("@Tipo", SqlDbType.TinyInt).Value = CByte(1) ' 1 = Receta
            cmd.Parameters.AddWithValue("@Titulo", txttitulo.Text.Trim())
            cmd.Parameters.AddWithValue("@Contenido", txtNotasEspecialista.Text.Trim()) ' por si quieres un resumen
            cmd.Parameters.AddWithValue("@Tags", DBNull.Value)
            cmd.Parameters.AddWithValue("@Estado", 1) ' publicado
            cmd.Parameters.AddWithValue("@EsFijada", 0)
            cmd.Parameters.AddWithValue("@Prioridad", 0)
            cmd.Parameters.AddWithValue("@VigenciaDesde", DBNull.Value)
            cmd.Parameters.AddWithValue("@VigenciaHasta", DBNull.Value)
            cmd.Parameters.AddWithValue("@Autor", Environment.UserName)
            cmd.Parameters.AddWithValue("@MetaJSON", meta.ToString())
            cmd.Parameters.AddWithValue("@CatIDs", _catId.ToString()) ' asocia al rubro recibido

            cn.Open()
            cmd.ExecuteNonQuery()
            _noteId = CInt(cmd.Parameters("@NoteID").Value)
        End Using

        MessageBox.Show("Receta guardada.", "Recetas")
        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub BtnPrevisualizar_Click(sender As Object, e As EventArgs) Handles BtnPrevisualizar.Click
        RenderPreview()
    End Sub
    Private Sub RenderPreview()
        Dim html As String = BuildRecetaHtml(
            titulo:=txttitulo.Text,
            especie:=txtEspecie.Text,
            dx:=txtDiagnostico.Text,
            med:=Txtmedicamento.Text,
            dosis:=txtdosis.Text,
            freq:=txtFrecuencia.Text,
            durDias:=CInt(numDuracion.Value),
            cambios:=txtcambiosAgua.Text,
            adv:=txtadvertencias.Text,
            notas:=txtNotasEspecialista.Text
        )
        If wvPrev.CoreWebView2 IsNot Nothing Then
            wvPrev.CoreWebView2.NavigateToString(html)
        End If
    End Sub
    Private Async Sub BtnPdf_Click(sender As Object, e As EventArgs) Handles BtnPdf.Click
        Try
            ' 1) Asegura WebView2 y refresca la vista previa
            If wvPrev.CoreWebView2 Is Nothing Then
                Await wvPrev.EnsureCoreWebView2Async(Nothing)
                RenderPreview()
            End If

            ' 2) Pide ruta del PDF
            Using sfd As New SaveFileDialog() With {
            .Filter = "PDF|*.pdf",
            .FileName = SanitizeFileName(txttitulo.Text & ".pdf")
        }
                If sfd.ShowDialog(Me) <> DialogResult.OK Then Exit Sub

                ' 3) Crea opciones de impresión (no se instancia con New)
                Dim opts As CoreWebView2PrintSettings =
                wvPrev.CoreWebView2.Environment.CreatePrintSettings()
                opts.Orientation = CoreWebView2PrintOrientation.Portrait
                opts.MarginTop = 0.5 : opts.MarginRight = 0.5
                opts.MarginBottom = 0.5 : opts.MarginLeft = 0.5
                opts.ScaleFactor = 1.0

                ' 4) Exporta a PDF
                Await wvPrev.CoreWebView2.PrintToPdfAsync(sfd.FileName, opts)
            End Using

            MessageBox.Show("PDF generado.", "Recetas", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("No se pudo generar el PDF: " & ex.Message, "Recetas",
                        MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Shared Function SanitizeFileName(s As String) As String
        For Each c In IO.Path.GetInvalidFileNameChars()
            s = s.Replace(c, "_"c)
        Next
        Return s
    End Function

    '=== Plantilla HTML ===
    Private Function BuildRecetaHtml(titulo As String, especie As String, dx As String,
                                 med As String, dosis As String, freq As String,
                                 durDias As Integer, cambios As String, adv As String, notas As String) As String

        Dim enc = Function(x As String) WebUtility.HtmlEncode(If(x, ""))

        Dim sb As New StringBuilder()
        sb.AppendLine("<html><head><meta charset='utf-8'>")
        sb.AppendLine("<style>")
        sb.AppendLine("body{font-family:Segoe UI; color:#222;margin:16px}")
        sb.AppendLine(".hdr{display:flex;justify-content:space-between;border-bottom:2px solid #0aa;padding-bottom:6px;margin-bottom:10px}")
        sb.AppendLine(".title{font-size:20px;font-weight:600}")
        sb.AppendLine(".sub{opacity:.7;font-size:12px}")
        sb.AppendLine(".box{border:1px solid #ddd;border-radius:10px;padding:10px;margin:10px 0}")
        sb.AppendLine("dl{display:grid;grid-template-columns:140px 1fr;gap:6px 12px;margin:0}")
        sb.AppendLine("dt{font-weight:600}")
        sb.AppendLine("</style></head><body>")

        sb.AppendLine("<div class='hdr'>")
        sb.AppendLine("  <div class='title'>Receta / Indicaciones</div>")
        sb.AppendFormat("  <div class='sub'>Acuario Fish House · {0:dd/MM/yyyy HH:mm}</div>", DateTime.Now).AppendLine()
        sb.AppendLine("</div>")

        sb.AppendFormat("<h3>{0}</h3>", enc(titulo)).AppendLine()
        sb.AppendLine("<div class='box'><dl>")
        sb.AppendFormat("<dt>Especie</dt><dd>{0}</dd>", enc(especie)).AppendLine()
        sb.AppendFormat("<dt>Diagnóstico</dt><dd>{0}</dd>", enc(dx)).AppendLine()
        sb.AppendFormat("<dt>Medicamento</dt><dd>{0}</dd>", enc(med)).AppendLine()
        sb.AppendFormat("<dt>Dosis</dt><dd>{0}</dd>", enc(dosis)).AppendLine()
        sb.AppendFormat("<dt>Frecuencia</dt><dd>{0}</dd>", enc(freq)).AppendLine()
        sb.AppendFormat("<dt>Duración</dt><dd>{0}</dd>", If(durDias > 0, durDias & " días", "—")).AppendLine()
        sb.AppendFormat("<dt>Cambios de agua</dt><dd>{0}</dd>", enc(cambios)).AppendLine()
        sb.AppendFormat("<dt>Advertencias</dt><dd>{0}</dd>", enc(adv)).AppendLine()
        sb.AppendLine("</dl></div>")

        sb.AppendLine("<h3>Instrucciones</h3>")
        sb.AppendFormat("<div class='box'>{0}</div>", enc(notas)).AppendLine()

        sb.AppendLine("</body></html>")
        Return sb.ToString()
    End Function

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub
End Class