Imports System.Net
Imports System.Text
Imports Microsoft.Web.WebView2.Core
Imports Newtonsoft.Json.Linq

Public Class FrmInstalacionModal
    '======== Campos-inyección
    Private ReadOnly _connStr As String
    Private ReadOnly _catId As Integer
    Private _noteId As Integer?

    Public Sub New(connStr As String, catId As Integer, Optional noteId As Integer? = Nothing)
        InitializeComponent()
        BuildLayout()
        _connStr = connStr
        _catId = catId
        _noteId = noteId
    End Sub

    '======== Load
    Private Async Sub FrmInstalacionModal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = If(_noteId.HasValue, "Editar Guía de Instalación", "Nueva Guía de Instalación")
        Await wvPrev.EnsureCoreWebView2Async(Nothing)
        If _noteId.HasValue Then CargarGuia(_noteId.Value)
        RenderPreview()
    End Sub

    '======== Cargar guía
    Private Sub CargarGuia(noteId As Integer)
        Using cn As New SqlClient.SqlConnection(_connStr),
              cmd As New SqlClient.SqlCommand("sp_Pizarra_Obtener", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@NoteID", noteId)
            cn.Open()
            Using rd = cmd.ExecuteReader()
                If rd.Read() Then
                    txtTitulo.Text = rd("Titulo").ToString()
                    Dim meta As JObject = If(IsDBNull(rd("MetaJSON")) OrElse rd("MetaJSON") Is Nothing _
                                             OrElse rd("MetaJSON").ToString() = "",
                                             New JObject(),
                                             JObject.Parse(rd("MetaJSON").ToString()))
                    txtEquipo.Text = meta.Value(Of String)("Equipo")
                    txtMarcaModelo.Text = meta.Value(Of String)("MarcaModelo")

                    Dim esp = meta("Especificaciones")?.ToObject(Of Dictionary(Of String, String))()
                    If esp IsNot Nothing Then
                        txtVoltaje.Text = If(esp.ContainsKey("Voltaje"), esp("Voltaje"), "")
                        txtPotencia.Text = If(esp.ContainsKey("Potencia"), esp("Potencia"), "")
                        txtFlujo.Text = If(esp.ContainsKey("Flujo"), esp("Flujo"), "")
                        txtCapTanque.Text = If(esp.ContainsKey("CapacidadTanque"), esp("CapacidadTanque"), "")
                    End If

                    FillListBox(lstMateriales, meta("Materiales"))
                    FillListBox(lstHerramientas, meta("Herramientas"))
                    FillListBox(lstPasos, meta("Pasos"))
                    txtSeguridad.Text = meta.Value(Of String)("Seguridad")
                    FillListBox(lstMantenimiento, meta("MantenimientoInicial"))
                    txtNotas.Text = meta.Value(Of String)("Notas")
                End If
            End Using
        End Using
    End Sub

    Private Sub FillListBox(lb As ListBox, token As JToken)
        lb.Items.Clear()
        If token Is Nothing Then Exit Sub
        Dim arr = token.ToObject(Of List(Of String))()
        If arr IsNot Nothing Then lb.Items.AddRange(arr.ToArray())
    End Sub

    '======== Helpers listas
    Private Sub AddItem(lb As ListBox, prompt As String)
        Dim s = InputBox(prompt, Me.Text, "")
        If Not String.IsNullOrWhiteSpace(s) Then lb.Items.Add(s.Trim())
    End Sub
    Private Sub EditItem(lb As ListBox, prompt As String)
        If lb.SelectedIndex < 0 Then Exit Sub
        Dim s = InputBox(prompt, Me.Text, lb.SelectedItem.ToString())
        If Not String.IsNullOrWhiteSpace(s) Then lb.Items(lb.SelectedIndex) = s.Trim()
    End Sub
    Private Sub DelItem(lb As ListBox)
        If lb.SelectedIndex >= 0 Then lb.Items.RemoveAt(lb.SelectedIndex)
    End Sub
    Private Sub MoveUp(lb As ListBox)
        Dim i = lb.SelectedIndex : If i <= 0 Then Exit Sub
        Dim v = lb.Items(i) : lb.Items.RemoveAt(i) : lb.Items.Insert(i - 1, v) : lb.SelectedIndex = i - 1
    End Sub
    Private Sub MoveDown(lb As ListBox)
        Dim i = lb.SelectedIndex : If i < 0 OrElse i >= lb.Items.Count - 1 Then Exit Sub
        Dim v = lb.Items(i) : lb.Items.RemoveAt(i) : lb.Items.Insert(i + 1, v) : lb.SelectedIndex = i + 1
    End Sub

    '======== Guardar
    'Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs)

        If String.IsNullOrWhiteSpace(txtTitulo.Text) Then
            MessageBox.Show("Captura el Título de la guía.", "Instalaciones")
            txtTitulo.Focus() : Exit Sub
        End If

        Dim esp = New JObject From {
            {"Voltaje", txtVoltaje.Text.Trim()},
            {"Potencia", txtPotencia.Text.Trim()},
            {"Flujo", txtFlujo.Text.Trim()},
            {"CapacidadTanque", txtCapTanque.Text.Trim()}
        }

        Dim meta As New JObject From {
            {"Equipo", txtEquipo.Text.Trim()},
            {"MarcaModelo", txtMarcaModelo.Text.Trim()},
            {"Especificaciones", esp},
            {"Materiales", JArray.FromObject(lbToList(lstMateriales))},
            {"Herramientas", JArray.FromObject(lbToList(lstHerramientas))},
            {"Pasos", JArray.FromObject(lbToList(lstPasos))},
            {"Seguridad", txtSeguridad.Text.Trim()},
            {"MantenimientoInicial", JArray.FromObject(lbToList(lstMantenimiento))},
            {"Notas", txtNotas.Text.Trim()},
            {"Imagenes", New JArray()}
        }

        Using cn As New SqlClient.SqlConnection(_connStr),
              cmd As New SqlClient.SqlCommand("sp_Pizarra_Guardar", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim pId = cmd.Parameters.Add("@NoteID", SqlDbType.Int)
            pId.Direction = ParameterDirection.InputOutput
            pId.Value = If(_noteId.HasValue, CType(_noteId.Value, Object), DBNull.Value)

            cmd.Parameters.Add("@Tipo", SqlDbType.TinyInt).Value = CByte(5) ' 5 = Instalación
            cmd.Parameters.AddWithValue("@Titulo", txtTitulo.Text.Trim())
            cmd.Parameters.AddWithValue("@Contenido", txtNotas.Text.Trim())
            cmd.Parameters.AddWithValue("@Tags", DBNull.Value)
            cmd.Parameters.AddWithValue("@Estado", 1)
            cmd.Parameters.AddWithValue("@EsFijada", 0)
            cmd.Parameters.AddWithValue("@Prioridad", 0)
            cmd.Parameters.AddWithValue("@VigenciaDesde", DBNull.Value)
            cmd.Parameters.AddWithValue("@VigenciaHasta", DBNull.Value)
            cmd.Parameters.AddWithValue("@Autor", Environment.UserName)
            cmd.Parameters.AddWithValue("@MetaJSON", meta.ToString())
            cmd.Parameters.AddWithValue("@CatIDs", _catId.ToString())

            cn.Open()
            cmd.ExecuteNonQuery()
            _noteId = CInt(cmd.Parameters("@NoteID").Value)
        End Using

        MessageBox.Show("Guía guardada.", "Instalaciones")
        Me.DialogResult = DialogResult.OK
    End Sub

    Private Function lbToList(lb As ListBox) As List(Of String)
        Return lb.Items.Cast(Of Object)().Select(Function(o) o.ToString()).ToList()
    End Function

    '======== Preview
    Private Sub btnPrevisualizar_Click(sender As Object, e As EventArgs) 'Handles btnPrevisualizar.Click
        RenderPreview()
    End Sub

    Private Sub RenderPreview()
        Dim html As String = BuildInstalacionHtml(
            titulo:=txtTitulo.Text,
            equipo:=txtEquipo.Text,
            modelo:=txtMarcaModelo.Text,
            volt:=txtVoltaje.Text,
            pot:=txtPotencia.Text,
            flujo:=txtFlujo.Text,
            cap:=txtCapTanque.Text,
            materiales:=lbToList(lstMateriales),
            herramientas:=lbToList(lstHerramientas),
            pasos:=lbToList(lstPasos),
            seguridad:=txtSeguridad.Text,
            mantenimiento:=lbToList(lstMantenimiento),
            notas:=txtNotas.Text
        )
        If wvPrev.CoreWebView2 IsNot Nothing Then
            wvPrev.CoreWebView2.NavigateToString(html)
        End If
    End Sub

    '======== PDF
    Private Async Sub btnPdf_Click(sender As Object, e As EventArgs) 'Handles btnPdf.Click
        If wvPrev.CoreWebView2 Is Nothing Then
            Await wvPrev.EnsureCoreWebView2Async(Nothing)
            RenderPreview()
        End If

        Using sfd As New SaveFileDialog() With {
            .Filter = "PDF|*.pdf",
            .FileName = SanitizeFileName(txtTitulo.Text & ".pdf")
        }
            If sfd.ShowDialog(Me) <> DialogResult.OK Then Exit Sub
            Dim opts = wvPrev.CoreWebView2.Environment.CreatePrintSettings()
            opts.Orientation = CoreWebView2PrintOrientation.Portrait
            opts.MarginTop = 0.5 : opts.MarginRight = 0.5 : opts.MarginBottom = 0.5 : opts.MarginLeft = 0.5
            Await wvPrev.CoreWebView2.PrintToPdfAsync(sfd.FileName, opts)
        End Using

        MessageBox.Show("PDF generado.", "Instalaciones")
    End Sub

    Private Shared Function SanitizeFileName(s As String) As String
        For Each c In IO.Path.GetInvalidFileNameChars()
            s = s.Replace(c, "_"c)
        Next
        Return s
    End Function

    '======== HTML
    Private Function BuildInstalacionHtml(titulo As String, equipo As String, modelo As String,
                                          volt As String, pot As String, flujo As String, cap As String,
                                          materiales As List(Of String), herramientas As List(Of String),
                                          pasos As List(Of String), seguridad As String,
                                          mantenimiento As List(Of String), notas As String) As String
        Dim enc = Function(x As String) WebUtility.HtmlEncode(If(x, ""))

        Dim ul = Function(lst As List(Of String)) If(lst Is Nothing OrElse lst.Count = 0,
            "<p>—</p>",
            "<ul>" & String.Join("", lst.Select(Function(i) "<li>" & enc(i) & "</li>")) & "</ul>")

        Dim ol = Function(lst As List(Of String)) If(lst Is Nothing OrElse lst.Count = 0,
            "<p>—</p>",
            "<ol>" & String.Join("", lst.Select(Function(i) "<li>" & enc(i) & "</li>")) & "</ol>")

        Dim sb As New StringBuilder()
        sb.AppendLine("<html><head><meta charset='utf-8'><style>")
        sb.AppendLine("body{font-family:Segoe UI;margin:16px;color:#222}")
        sb.AppendLine(".hdr{display:flex;justify-content:space-between;border-bottom:2px solid #0aa;padding-bottom:6px;margin-bottom:10px}")
        sb.AppendLine(".title{font-size:20px;font-weight:600}.sub{opacity:.7;font-size:12px}")
        sb.AppendLine(".box{border:1px solid #ddd;border-radius:10px;padding:10px;margin:10px 0}")
        sb.AppendLine("dl{display:grid;grid-template-columns:160px 1fr;gap:6px 12px;margin:0} dt{font-weight:600}")
        sb.AppendLine("</style></head><body>")

        sb.AppendLine("<div class='hdr'>")
        sb.AppendLine("  <div class='title'>Guía de Instalación</div>")
        sb.AppendFormat("  <div class='sub'>Acuario Fish House · {0:dd/MM/yyyy HH:mm}</div>", DateTime.Now).AppendLine()
        sb.AppendLine("</div>")

        sb.AppendFormat("<h3>{0}</h3>", enc(titulo)).AppendLine()
        sb.AppendLine("<div class='box'><dl>")
        sb.AppendFormat("<dt>Equipo</dt><dd>{0}</dd>", enc(equipo)).AppendLine()
        sb.AppendFormat("<dt>Marca/Modelo</dt><dd>{0}</dd>", enc(modelo)).AppendLine()
        sb.AppendFormat("<dt>Voltaje</dt><dd>{0}</dd>", enc(volt)).AppendLine()
        sb.AppendFormat("<dt>Potencia</dt><dd>{0}</dd>", enc(pot)).AppendLine()
        sb.AppendFormat("<dt>Flujo</dt><dd>{0}</dd>", enc(flujo)).AppendLine()
        sb.AppendFormat("<dt>Capacidad tanque</dt><dd>{0}</dd>", enc(cap)).AppendLine()
        sb.AppendLine("</dl></div>")

        sb.AppendLine("<div class='box'><h3>Materiales</h3>")
        sb.Append(ul(materiales)).AppendLine("</div>")

        sb.AppendLine("<div class='box'><h3>Herramientas</h3>")
        sb.Append(ul(herramientas)).AppendLine("</div>")

        sb.AppendLine("<div class='box'><h3>Pasos</h3>")
        sb.Append(ol(pasos)).AppendLine("</div>")

        sb.AppendLine("<div class='box'><h3>Seguridad</h3>")
        sb.AppendFormat("<p>{0}</p>", enc(seguridad)).AppendLine("</div>")

        sb.AppendLine("<div class='box'><h3>Mantenimiento inicial</h3>")
        sb.Append(ul(mantenimiento)).AppendLine("</div>")

        sb.AppendLine("<div class='box'><h3>Notas</h3>")
        sb.AppendFormat("<p>{0}</p>", enc(notas)).AppendLine("</div>")

        sb.AppendLine("</body></html>")
        Return sb.ToString()
    End Function

    '======== Designer (layout mínimo)
#Region "Designer"
    Private scMain As SplitContainer
    Private pnlLeft As Panel
    Private lblTitulo As Label, txtTitulo As TextBox
    Private lblEquipo As Label, txtEquipo As TextBox
    Private lblMarca As Label, txtMarcaModelo As TextBox
    Private lblVolt As Label, txtVoltaje As TextBox
    Private lblPot As Label, txtPotencia As TextBox
    Private lblFlujo As Label, txtFlujo As TextBox
    Private lblCap As Label, txtCapTanque As TextBox
    Private grpListas As GroupBox
    Private lstMateriales As ListBox, lstHerramientas As ListBox, lstPasos As ListBox, lstMantenimiento As ListBox
    Private btnMatAdd As Button, btnMatEdit As Button, btnMatDel As Button, btnMatUp As Button, btnMatDown As Button
    Private btnHerAdd As Button, btnHerEdit As Button, btnHerDel As Button, btnHerUp As Button, btnHerDown As Button
    Private btnPasoAdd As Button, btnPasoEdit As Button, btnPasoDel As Button, btnPasoUp As Button, btnPasoDown As Button
    Private btnManAdd As Button, btnManEdit As Button, btnManDel As Button, btnManUp As Button, btnManDown As Button
    Private lblSeg As Label, txtSeguridad As TextBox
    Private lblNotas As Label, txtNotas As TextBox
    Private flButtons As FlowLayoutPanel
    Private btnGuardar As Button, btnPrevisualizar As Button, btnPdf As Button, btnCancelar As Button
    Private wvPrev As Microsoft.Web.WebView2.WinForms.WebView2

    'Private Sub InitializeComponent()
    Private Sub BuildLayout()
        '==== Instancias (solo una vez, sin duplicados)
        Me.scMain = New SplitContainer()
        Me.pnlLeft = New Panel()
        Me.lblTitulo = New Label()
        Me.txtTitulo = New TextBox()
        Me.lblEquipo = New Label()
        Me.txtEquipo = New TextBox()
        Me.lblMarca = New Label()
        Me.txtMarcaModelo = New TextBox()
        Me.lblVolt = New Label()
        Me.txtVoltaje = New TextBox()
        Me.lblPot = New Label()
        Me.txtPotencia = New TextBox()
        Me.lblFlujo = New Label()
        Me.txtFlujo = New TextBox()
        Me.lblCap = New Label()
        Me.txtCapTanque = New TextBox()
        Me.lstMateriales = New ListBox()
        Me.lstHerramientas = New ListBox()
        Me.lstPasos = New ListBox()
        Me.lstMantenimiento = New ListBox()
        Me.btnMatAdd = New Button() : Me.btnMatEdit = New Button() : Me.btnMatDel = New Button()
        Me.btnHerAdd = New Button() : Me.btnHerEdit = New Button() : Me.btnHerDel = New Button()
        Me.btnPasoAdd = New Button() : Me.btnPasoEdit = New Button() : Me.btnPasoDel = New Button()
        Me.btnManAdd = New Button() : Me.btnManEdit = New Button() : Me.btnManDel = New Button()
        Me.lblSeg = New Label() : Me.txtSeguridad = New TextBox()
        Me.lblNotas = New Label() : Me.txtNotas = New TextBox()
        Me.flButtons = New FlowLayoutPanel()
        Me.btnGuardar = New Button() : Me.btnPrevisualizar = New Button() : Me.btnPdf = New Button() : Me.btnCancelar = New Button()
        Me.wvPrev = New Microsoft.Web.WebView2.WinForms.WebView2()

        CType(Me.scMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scMain.Panel1.SuspendLayout()
        Me.scMain.Panel2.SuspendLayout()
        Me.scMain.SuspendLayout()
        CType(Me.wvPrev, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()

        '==== Split principal
        Me.scMain.Dock = DockStyle.Fill
        Me.scMain.SplitterDistance = 460

        '==== Panel izquierdo (captura)
        Me.pnlLeft.Dock = DockStyle.Fill
        Me.scMain.Panel1.Controls.Add(Me.pnlLeft)

        '---- Encabezados
        Me.lblTitulo.Text = "Título"
        Me.lblTitulo.SetBounds(10, 10, 120, 18)
        Me.txtTitulo.SetBounds(10, 30, 430, 24)

        Me.lblEquipo.Text = "Equipo"
        Me.lblEquipo.SetBounds(10, 62, 120, 18)
        Me.txtEquipo.SetBounds(10, 82, 430, 24)

        Me.lblMarca.Text = "Marca/Modelo"
        Me.lblMarca.SetBounds(10, 114, 120, 18)
        Me.txtMarcaModelo.SetBounds(10, 134, 430, 24)

        '---- Especificaciones
        Me.lblVolt.Text = "Voltaje"
        Me.lblVolt.SetBounds(10, 166, 80, 18)
        Me.txtVoltaje.SetBounds(10, 186, 95, 24)

        Me.lblPot.Text = "Potencia"
        Me.lblPot.SetBounds(120, 166, 80, 18)
        Me.txtPotencia.SetBounds(120, 186, 95, 24)

        Me.lblFlujo.Text = "Flujo"
        Me.lblFlujo.SetBounds(230, 166, 80, 18)
        Me.txtFlujo.SetBounds(230, 186, 95, 24)

        Me.lblCap.Text = "Capacidad"
        Me.lblCap.SetBounds(340, 166, 80, 18)
        Me.txtCapTanque.SetBounds(340, 186, 100, 24)

        '---- Listas (2x2)
        Me.lstMateriales.BorderStyle = BorderStyle.FixedSingle
        Me.lstHerramientas.BorderStyle = BorderStyle.FixedSingle
        Me.lstPasos.BorderStyle = BorderStyle.FixedSingle
        Me.lstMantenimiento.BorderStyle = BorderStyle.FixedSingle

        Me.lstMateriales.SetBounds(10, 220, 210, 110)
        Me.lstHerramientas.SetBounds(230, 220, 210, 110)
        Me.lstPasos.SetBounds(10, 360, 210, 110)
        Me.lstMantenimiento.SetBounds(230, 360, 210, 110)

        '---- Botones de listas (Add/Edit/Del)
        Me.btnMatAdd.Text = "+" : Me.btnMatEdit.Text = "✎" : Me.btnMatDel.Text = "–"
        Me.btnHerAdd.Text = "+" : Me.btnHerEdit.Text = "✎" : Me.btnHerDel.Text = "–"
        Me.btnPasoAdd.Text = "+" : Me.btnPasoEdit.Text = "✎" : Me.btnPasoDel.Text = "–"
        Me.btnManAdd.Text = "+" : Me.btnManEdit.Text = "✎" : Me.btnManDel.Text = "–"

        Me.btnMatAdd.SetBounds(10, 334, 30, 24)
        Me.btnMatEdit.SetBounds(44, 334, 30, 24)
        Me.btnMatDel.SetBounds(78, 334, 30, 24)

        Me.btnHerAdd.SetBounds(230, 334, 30, 24)
        Me.btnHerEdit.SetBounds(264, 334, 30, 24)
        Me.btnHerDel.SetBounds(298, 334, 30, 24)

        Me.btnPasoAdd.SetBounds(10, 474, 30, 24)
        Me.btnPasoEdit.SetBounds(44, 474, 30, 24)
        Me.btnPasoDel.SetBounds(78, 474, 30, 24)

        Me.btnManAdd.SetBounds(230, 474, 30, 24)
        Me.btnManEdit.SetBounds(264, 474, 30, 24)
        Me.btnManDel.SetBounds(298, 474, 30, 24)

        '---- Seguridad / Notas (bajadas para no chocar con botonera)
        Me.lblSeg.Text = "Seguridad"
        Me.lblSeg.SetBounds(10, 508, 100, 18)
        Me.txtSeguridad.Multiline = True
        Me.txtSeguridad.ScrollBars = ScrollBars.Vertical
        Me.txtSeguridad.SetBounds(10, 528, 430, 70)

        Me.lblNotas.Text = "Notas"
        Me.lblNotas.SetBounds(10, 604, 100, 18)
        Me.txtNotas.Multiline = True
        Me.txtNotas.ScrollBars = ScrollBars.Vertical
        Me.txtNotas.SetBounds(10, 624, 430, 70)

        '==== Panel derecho (preview)
        Me.wvPrev.Dock = DockStyle.Fill
        Me.scMain.Panel2.Controls.Add(Me.wvPrev)

        '==== Botonera inferior (una sola hilera)
        Me.flButtons.FlowDirection = FlowDirection.RightToLeft
        Me.flButtons.Dock = DockStyle.Bottom
        Me.flButtons.Height = 44
        Me.btnGuardar.Text = "Guardar"
        Me.btnPrevisualizar.Text = "Previsualizar"
        Me.btnPdf.Text = "PDF"
        Me.btnCancelar.Text = "Cancelar"

        ' Cableado (solo una vez)
        AddHandler Me.btnGuardar.Click, AddressOf btnGuardar_Click
        AddHandler Me.btnPrevisualizar.Click, AddressOf btnPrevisualizar_Click
        AddHandler Me.btnPdf.Click, AddressOf btnPdf_Click
        AddHandler Me.btnCancelar.Click, AddressOf btnCancelar_Click

        Me.flButtons.Controls.AddRange(New Control() {Me.btnCancelar, Me.btnPdf, Me.btnPrevisualizar, Me.btnGuardar})
        Me.AcceptButton = Me.btnGuardar
        Me.CancelButton = Me.btnCancelar

        '==== Agregar controles
        Me.pnlLeft.Controls.AddRange(New Control() {
            lblTitulo, txtTitulo, lblEquipo, txtEquipo, lblMarca, txtMarcaModelo,
            lblVolt, txtVoltaje, lblPot, txtPotencia, lblFlujo, txtFlujo, lblCap, txtCapTanque,
            lstMateriales, lstHerramientas, lstPasos, lstMantenimiento,
            btnMatAdd, btnMatEdit, btnMatDel, btnHerAdd, btnHerEdit, btnHerDel,
            btnPasoAdd, btnPasoEdit, btnPasoDel, btnManAdd, btnManEdit, btnManDel,
            lblSeg, txtSeguridad, lblNotas, txtNotas
        })

        Me.scMain.Panel1.Controls.Add(Me.pnlLeft)
        Me.Controls.Add(Me.scMain)
        Me.Controls.Add(Me.flButtons)

        '==== Eventos de listas
        AddHandler btnMatAdd.Click, Sub() AddItem(lstMateriales, "Nuevo material")
        AddHandler btnMatEdit.Click, Sub() EditItem(lstMateriales, "Editar material")
        AddHandler btnMatDel.Click, Sub() DelItem(lstMateriales)
        AddHandler btnHerAdd.Click, Sub() AddItem(lstHerramientas, "Nueva herramienta")
        AddHandler btnHerEdit.Click, Sub() EditItem(lstHerramientas, "Editar herramienta")
        AddHandler btnHerDel.Click, Sub() DelItem(lstHerramientas)
        AddHandler btnPasoAdd.Click, Sub() AddItem(lstPasos, "Nuevo paso")
        AddHandler btnPasoEdit.Click, Sub() EditItem(lstPasos, "Editar paso")
        AddHandler btnPasoDel.Click, Sub() DelItem(lstPasos)
        AddHandler btnManAdd.Click, Sub() AddItem(lstMantenimiento, "Nuevo mantenimiento")
        AddHandler btnManEdit.Click, Sub() EditItem(lstMantenimiento, "Editar mantenimiento")
        AddHandler btnManDel.Click, Sub() DelItem(lstMantenimiento)

        '==== Form
        Me.StartPosition = FormStartPosition.CenterParent
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MinimizeBox = False
        Me.MaximizeBox = False
        Me.ShowInTaskbar = False
        Me.ClientSize = New Drawing.Size(1040, 760)
        Me.Text = "Guía de Instalación"

        Me.scMain.Panel1.ResumeLayout(False)
        Me.scMain.Panel2.ResumeLayout(False)
        CType(Me.scMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scMain.ResumeLayout(False)
        CType(Me.wvPrev, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
    End Sub

#End Region

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs)
        Me.DialogResult = DialogResult.Cancel
    End Sub


End Class
