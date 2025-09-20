Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.Web.WebView2.Core
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class FrmPizarron
    Private connStr As String = ConfigurationManager _
      .ConnectionStrings("MiConexion").ConnectionString

    Private ReadOnly bs As New BindingSource()
    '--- Campos de la forma
    Private currentNoteId As Integer? = Nothing    ' NoteID actual
    Private tvMode As Boolean = False
    Private editingCatId As Integer? = Nothing


    Private Sub FrmPizarron_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tvRubros.LabelEdit = True
        CargarRubros()
        CargarCboTipo()

        dglista.AutoGenerateColumns = False
        dglista.ReadOnly = True
        dglista.AllowUserToAddRows = False
        dglista.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader
        dglista.DataSource = bs

        AddCol("Título", "Titulo", True, 240, wrap:=True)
        AddCol("Tipo", "TipoTxt", False, 80)
        AddCol("Resumen", "Resumen", True, 500, wrap:=True)
        AddCol("Tags", "Tags", False, 120)
        AddCol("Vigencia", "VigenciaStr", False, 120)
        AddChk("Fijada", "EsFijada", 60)
        AddCol("Últ. mod.", "UltMod", False, 130)

        InitCards() ' prepara WebView2
        CargarLista(SelectedCatId:=Nothing)

        tvRubros.HideSelection = False
        tvRubros.CollapseAll()
    End Sub
    Private Sub CargarCboTipo()
        Dim dt As New DataTable()
        dt.Columns.Add("Id", GetType(Integer))
        dt.Columns.Add("Nombre", GetType(String))

        dt.Rows.Add(0, "Nota")
        dt.Rows.Add(1, "Receta")
        dt.Rows.Add(2, "Enfermedad")
        dt.Rows.Add(3, "Tip")
        dt.Rows.Add(4, "Checklist")

        With cboTipo
            .DropDownStyle = ComboBoxStyle.DropDownList
            .DataSource = dt
            .DisplayMember = "Nombre"
            .ValueMember = "Id"
            .SelectedValue = 0      ' por defecto “Nota”; cámbialo si quieres otro
        End With
    End Sub
    ' Private Function GetTipoFromCombo() As Integer
    '    If cboTipo.SelectedValue Is Nothing Then Return 0
    'Return CInt(cboTipo.SelectedValue)
    'End Function
    Private Function GetTipoFromCombo() As Integer
        ' Ajusta según tus Items; aquí asumo: [Seleccione], Nota, Receta, Enfermedad, Tip, Checklist
        If cboTipo.SelectedIndex <= 0 Then Return 0
        Return cboTipo.SelectedIndex - 1
    End Function

    Private Function GetSelectedCatId() As Integer?
        If tvRubros.SelectedNode Is Nothing Then Return Nothing
        Return CInt(tvRubros.SelectedNode.Tag)
    End Function


    Private Sub SetTipoInCombo(tipo As Integer)
        Try
            cboTipo.SelectedValue = tipo
        Catch
            cboTipo.SelectedIndex = 0 ' fallback
        End Try
    End Sub



    Private Sub AddCol(h As String, prop As String, fill As Boolean, w As Integer, Optional wrap As Boolean = False)
        Dim c As New DataGridViewTextBoxColumn With {.HeaderText = h, .DataPropertyName = prop, .Width = w}
        If fill Then c.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        If wrap Then c.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        dglista.Columns.Add(c)
    End Sub
    Private Sub AddChk(h As String, prop As String, w As Integer)
        dglista.Columns.Add(New DataGridViewCheckBoxColumn With {.HeaderText = h, .DataPropertyName = prop, .Width = w})
    End Sub
    Private Sub tvRubros_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvRubros.AfterSelect
        Dim catId As Integer = CInt(e.Node.Tag)
        CargarLista(catId)
    End Sub
    Private Sub CargarLista(SelectedCatId As Integer?)
        Dim dt As New DataTable()
        Using cn As New SqlConnection(connStr),
          da As New SqlDataAdapter("sp_Pizarra_Listar", cn)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.AddWithValue("@CatID", If(SelectedCatId.HasValue, SelectedCatId.Value, CType(DBNull.Value, Object)))
            da.SelectCommand.Parameters.AddWithValue("@Tipo", If(cboTipo.SelectedIndex <= 0, CType(DBNull.Value, Object), cboTipo.SelectedIndex - 1))
            da.SelectCommand.Parameters.AddWithValue("@Texto", If(String.IsNullOrWhiteSpace(Txtbuscar.Text), CType(DBNull.Value, Object), Txtbuscar.Text))
            da.SelectCommand.Parameters.AddWithValue("@SoloVigentes", chkVigentes.Checked)
            da.Fill(dt)
        End Using

        ' Derivados para el grid
        If Not dt.Columns.Contains("TipoTxt") Then dt.Columns.Add("TipoTxt", GetType(String))
        If Not dt.Columns.Contains("VigenciaStr") Then dt.Columns.Add("VigenciaStr", GetType(String))
        For Each r As DataRow In dt.Rows
            r("TipoTxt") = TipoIntATexto(CInt(r("Tipo")))
            Dim d1 = If(IsDBNull(r("VigenciaDesde")), "—", CDate(r("VigenciaDesde")).ToString("dd/MM"))
            Dim d2 = If(IsDBNull(r("VigenciaHasta")), "—", CDate(r("VigenciaHasta")).ToString("dd/MM"))
            r("VigenciaStr") = d1 & " → " & d2
        Next

        bs.DataSource = dt
        RenderCardsFromDT(dt) ' misma data a las tarjetas
    End Sub

    Private Function TipoIntATexto(t As Integer) As String
        Select Case t
            Case 0 : Return "Nota"
            Case 1 : Return "Receta"
            Case 2 : Return "Enfermedad"
            Case 3 : Return "Tip"
            Case 4 : Return "Checklist"
            Case Else : Return "?"
        End Select
    End Function

    Private ReadOnly CardsHtml As String = "<html><head><meta charset='utf-8'><style>
        body{font-family:Segoe UI;margin:8px}
        .grid{display:flex;flex-wrap:wrap;gap:10px}
        .card{border:1px solid #ddd;border-radius:12px;padding:10px;width:260px;box-shadow:0 2px 6px rgba(0,0,0,.08)}
        .small{font-size:12px;opacity:.7;margin:4px 0}
        </style>
            <script>
                function escapeHtml(s){return s? s.replace(/&/g,'&amp;').replace(/</g,'&lt;') : '';}
                function renderCards(items){
                const g=document.getElementById('grid'); g.innerHTML='';
                items.forEach(it=>{
                const d=document.createElement('div'); d.className='card';
                d.innerHTML = `<div><b>${escapeHtml(it.Titulo||'')}</b></div>
                    <div class='small'>${escapeHtml(it.TipoTxt||'')} · ${escapeHtml(it.VigenciaStr||'')}</div>
                    <div>${escapeHtml(it.Resumen||'')}</div>
                    <div class='small'>${escapeHtml(it.Tags||'')}</div>`;
                    d.onclick=()=>chrome.webview.postMessage(JSON.stringify({cmd:'ver', id:it.NoteID}));
                    g.appendChild(d);
                    });
                        }
            </script></head><body><div id='grid' class='grid'></div></body></html>"


    Private Async Function InitCards() As Task
        Await wvCards.EnsureCoreWebView2Async(Nothing)
        wvCards.CoreWebView2.NavigateToString(CardsHtml)
        AddHandler wvCards.CoreWebView2.WebMessageReceived, AddressOf CardsMessage
    End Function
    Private Sub CardsMessage(sender As Object, e As CoreWebView2WebMessageReceivedEventArgs)
        Dim msg = e.TryGetWebMessageAsString()
        Dim jo = JObject.Parse(msg)
        If jo("cmd")?.ToString() = "ver" Then
            Dim id As Integer = CInt(jo("id"))
            CargarDetalle(id)
        End If
    End Sub

    Private Async Sub RenderCardsFromDT(dt As DataTable)
        Dim datos = dt.AsEnumerable().
        Select(Function(r) New With {
            .NoteID = r.Field(Of Integer)("NoteID"),
            .Titulo = r.Field(Of String)("Titulo"),
            .Resumen = If(dt.Columns.Contains("Resumen"), r.Field(Of String)("Resumen"), ""),
            .TipoTxt = r.Field(Of String)("TipoTxt"),
            .VigenciaStr = r.Field(Of String)("VigenciaStr"),
            .Tags = r.Field(Of String)("Tags")
        }).ToList()
        Dim json = JsonConvert.SerializeObject(datos)
        If wvCards.CoreWebView2 IsNot Nothing Then
            Await wvCards.CoreWebView2.ExecuteScriptAsync($"renderCards({json})")
        End If
    End Sub

    ' Private Sub dgLista_SelectionChanged(sender As Object, e As EventArgs) Handles dglista.SelectionChanged
    '    If bs.Current Is Nothing Then Exit Sub
    '   Dim row As DataRowView = CType(bs.Current, DataRowView)
    '  CargarDetalle(CInt(row("NoteID")))
    'End Sub
    Private Sub CargarDetalle(noteId As Integer)




        Using cn As New SqlConnection(connStr),
          cmd As New SqlCommand("sp_Pizarra_Obtener", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@NoteID", noteId)
            cn.Open()
            Using rd = cmd.ExecuteReader()
                If rd.Read() Then
                    txtNoteId.Text = rd("NoteID").ToString()
                    txttitulo.Text = rd("Titulo").ToString()
                    txtcontenido.Text = rd("Contenido").ToString()
                    txttags.Text = rd("Tags").ToString()
                    chkFijada.Checked = CBool(rd("EsFijada"))
                    numPrioridad.Value = CDec(rd("Prioridad"))
                    ' MetaJSON -> campos específicos (si aplica)
                    Dim meta = rd("MetaJSON").ToString()
                    ' Ejemplo: lee "Especie" si existe
                    If Not String.IsNullOrEmpty(meta) Then
                        Dim jo = JObject.Parse(meta)
                        txtEspecie.Text = jo.Value(Of String)("Especie")
                    End If
                End If
                Dim tipo As Integer = CInt(rd("Tipo"))
                SetTipoInCombo(tipo)
            End Using
        End Using

    End Sub
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Dim noteId As Object = If(String.IsNullOrEmpty(txtNoteID.Text), CType(DBNull.Value, Object), CInt(txtNoteID.Text))
        Dim meta As New JObject()
        If Not String.IsNullOrWhiteSpace(txtEspecie.Text) Then meta("Especie") = txtEspecie.Text

        Dim catCsv As String = Nothing
        If tvRubros.SelectedNode IsNot Nothing Then catCsv = CStr(tvRubros.SelectedNode.Tag) ' simple: 1 rubro (puedes pasar varios)

        Using cn As New SqlConnection(connStr),
          cmd As New SqlCommand("sp_Pizarra_Guardar", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add(New SqlParameter("@NoteID", SqlDbType.Int) With {.Direction = ParameterDirection.InputOutput, .Value = noteId})
            cmd.Parameters.AddWithValue("@Tipo", cboTipo.SelectedIndex) ' ajusta según UI
            cmd.Parameters.AddWithValue("@Titulo", txtTitulo.Text)
            cmd.Parameters.AddWithValue("@Contenido", txtContenido.Text)
            cmd.Parameters.AddWithValue("@Tags", txtTags.Text)
            cmd.Parameters.AddWithValue("@Estado", 1)
            cmd.Parameters.AddWithValue("@EsFijada", chkFijada.Checked)
            cmd.Parameters.AddWithValue("@Prioridad", CInt(numPrioridad.Value))
            cmd.Parameters.AddWithValue("@VigenciaDesde", If(dtDesde.Checked, dtDesde.Value, CType(DBNull.Value, Object)))
            cmd.Parameters.AddWithValue("@VigenciaHasta", If(dtHasta.Checked, dtHasta.Value, CType(DBNull.Value, Object)))
            cmd.Parameters.AddWithValue("@Autor", Environment.UserName)
            cmd.Parameters.AddWithValue("@MetaJSON", meta.ToString())
            cmd.Parameters.AddWithValue("@CatIDs", If(String.IsNullOrEmpty(catCsv), CType(DBNull.Value, Object), catCsv))
            cn.Open()
            cmd.ExecuteNonQuery()
            txtNoteID.Text = cmd.Parameters("@NoteID").Value.ToString()
        End Using

        ' Refresca lista y tarjetas
        Dim selCat As Integer? = If(tvRubros.SelectedNode IsNot Nothing, CInt(tvRubros.SelectedNode.Tag), CType(Nothing, Integer?))
        CargarLista(selCat)
    End Sub

    Private Sub CargarRubros()
        tvRubros.BeginUpdate()
        tvRubros.Nodes.Clear()

        Dim dt As New DataTable()
        Using cn As New SqlClient.SqlConnection(connStr),
              da As New SqlClient.SqlDataAdapter("sp_Rubros_ListarTree", cn)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.Fill(dt)
        End Using

        ' Construir árbol (diccionario por CatID)
        Dim map As New Dictionary(Of Integer, TreeNode)
        For Each r As DataRow In dt.Rows
            Dim id = CInt(r("CatID"))
            Dim parentId = If(IsDBNull(r("ParentID")), CType(Nothing, Integer?), CInt(r("ParentID")))
            Dim n As New TreeNode(CStr(r("Nombre"))) With {.Tag = id}
            If parentId.HasValue AndAlso map.ContainsKey(parentId.Value) Then
                map(parentId.Value).Nodes.Add(n)
            Else
                tvRubros.Nodes.Add(n)
            End If
            map(id) = n
        Next
        tvRubros.ExpandAll()
        tvRubros.EndUpdate()
    End Sub

    Private Sub tvRubros_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles tvRubros.NodeMouseClick
        tvRubros.SelectedNode = e.Node
        If e.Button = MouseButtons.Right Then ctxRubros.Show(tvRubros, e.Location)
    End Sub

    Private Sub mnuNuevoSubrubro_Click(sender As Object, e As EventArgs) Handles mnunuevoSubrubro.Click
        Dim parent = tvRubros.SelectedNode
        Dim nombre = InputBox("Nombre del nuevo subrubro:", "Nuevo rubro")
        If String.IsNullOrWhiteSpace(nombre) Then Exit Sub

        Using cn As New SqlClient.SqlConnection(connStr),
          cmd As New SqlClient.SqlCommand("sp_Rubro_Insertar", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@ParentID", If(parent Is Nothing, DBNull.Value, parent.Tag))
            cmd.Parameters.AddWithValue("@Nombre", nombre)
            cn.Open()
            Dim newId = CInt(cmd.ExecuteScalar())
            Dim n As New TreeNode(nombre) With {.Tag = newId}
            If parent Is Nothing Then tvRubros.Nodes.Add(n) Else parent.Nodes.Add(n)
            tvRubros.SelectedNode = n
        End Using
    End Sub

    Private Sub mnuRenombrar_Click(sender As Object, e As EventArgs) Handles mnuRenombrar.Click
        If tvRubros.SelectedNode IsNot Nothing Then tvRubros.SelectedNode.BeginEdit()
    End Sub

    Private Sub tvRubros_AfterLabelEdit(sender As Object, e As NodeLabelEditEventArgs) Handles tvRubros.AfterLabelEdit
        If e.Label Is Nothing Then Exit Sub ' cancelado
        Dim nuevo = e.Label.Trim()
        If nuevo = "" Then e.CancelEdit = True : Exit Sub

        Using cn As New SqlClient.SqlConnection(connStr),
          cmd As New SqlClient.SqlCommand("sp_Rubro_Renombrar", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@CatID", CInt(e.Node.Tag))
            cmd.Parameters.AddWithValue("@Nombre", nuevo)
            cn.Open()
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    Private Sub mnuEliminar_Click(sender As Object, e As EventArgs) Handles mnuEliminar.Click
        Dim n = tvRubros.SelectedNode
        If n Is Nothing Then Exit Sub
        If MessageBox.Show("¿Eliminar/Desactivar este rubro?", "Confirmar", MessageBoxButtons.YesNo) = DialogResult.No Then Exit Sub

        Using cn As New SqlClient.SqlConnection(connStr),
          cmd As New SqlClient.SqlCommand("sp_Rubro_Eliminar", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@CatID", CInt(n.Tag))
            cn.Open()
            cmd.ExecuteNonQuery()
        End Using
        n.Remove()
    End Sub

    Private Sub LimpiarDetalle()
        currentNoteId = Nothing
        If cboTipo.Items.Count > 0 Then cboTipo.SelectedIndex = 1 ' Nota por defecto; ajusta si quieres otro
        txttitulo.Clear()
        txtcontenido.Clear()
        txttags.Clear()
        numPrioridad.Value = 0
        chkFijada.Checked = False
        If dtdesde.ShowCheckBox Then dtdesde.Checked = False
        If dtHasta.ShowCheckBox Then dtHasta.Checked = False
        txttitulo.Focus()
        txtNoteId.Clear()

    End Sub
    Private Function GetEstadoActual() As Integer
        Dim drv = TryCast(bs.Current, DataRowView)
        If drv IsNot Nothing AndAlso Not drv.Row.IsNull("Estado") Then
            Return CInt(drv("Estado"))
        End If
        Return 1 ' Publicado por defecto si no viene
    End Function
    Private Function BuildMetaJson() As String
        ' Ejemplo: si tuvieras txtEspecie, txtMedicamento, etc.
        ' Dim jo As New Newtonsoft.Json.Linq.JObject()
        ' jo("Especie") = txtEspecie.Text
        ' jo("Medicamento") = txtMedicamento.Text
        ' Return jo.ToString()
        Return Nothing
    End Function

    Private Sub GuardarNota(Optional estado As Integer? = Nothing, Optional forzarPin As Boolean? = Nothing)
        If String.IsNullOrWhiteSpace(txttitulo.Text) Then
            MessageBox.Show("Captura un Título.", "Pizarrón", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txttitulo.Focus() : Exit Sub
        End If

        Dim catId? = GetSelectedCatId()
        If Not catId.HasValue Then
            MessageBox.Show("Selecciona un rubro en el árbol para asociar la nota.", "Pizarrón", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim tipo As Integer = GetTipoFromCombo()
        Dim meta As String = BuildMetaJson()

        Dim estadoFinal As Integer = If(estado.HasValue, estado.Value, GetEstadoActual())
        Dim pinFinal As Boolean = If(forzarPin.HasValue, forzarPin.Value, chkFijada.Checked)

        Using cn As New SqlClient.SqlConnection(connStr),
              cmd As New SqlClient.SqlCommand("sp_Pizarra_Guardar", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim pId = cmd.Parameters.Add("@NoteID", SqlDbType.Int)
            pId.Direction = ParameterDirection.InputOutput
            pId.Value = If(currentNoteId.HasValue, CType(currentNoteId.Value, Object), DBNull.Value)

            cmd.Parameters.AddWithValue("@Tipo", tipo)
            cmd.Parameters.AddWithValue("@Titulo", txttitulo.Text.Trim())
            cmd.Parameters.AddWithValue("@Contenido", txtcontenido.Text.Trim())
            cmd.Parameters.AddWithValue("@Tags", txttags.Text.Trim())
            cmd.Parameters.AddWithValue("@Estado", estadoFinal)
            cmd.Parameters.AddWithValue("@EsFijada", pinFinal)
            cmd.Parameters.AddWithValue("@Prioridad", CInt(numPrioridad.Value))
            cmd.Parameters.AddWithValue("@VigenciaDesde", If(dtdesde.ShowCheckBox AndAlso dtdesde.Checked, dtdesde.Value, CType(DBNull.Value, Object)))
            cmd.Parameters.AddWithValue("@VigenciaHasta", If(dtHasta.ShowCheckBox AndAlso dtHasta.Checked, dtHasta.Value, CType(DBNull.Value, Object)))
            cmd.Parameters.AddWithValue("@Autor", Environment.UserName)
            cmd.Parameters.AddWithValue("@MetaJSON", If(String.IsNullOrWhiteSpace(meta), CType(DBNull.Value, Object), meta))
            cmd.Parameters.AddWithValue("@CatIDs", catId.Value.ToString()) ' sencillo: un solo rubro seleccionado

            cn.Open()
            cmd.ExecuteNonQuery()
            currentNoteId = CInt(cmd.Parameters("@NoteID").Value)
        End Using

        ' Refresca lista y tarjetas (usa el CatID actual)
        CargarLista(catId)
    End Sub

    Private Sub BtnNuevo_Click(sender As Object, e As EventArgs) Handles BtnNuevo.Click
        If tvRubros.SelectedNode Is Nothing Then
            MessageBox.Show("Selecciona un rubro en el árbol.", "Pizarrón") : Exit Sub
        End If
        editingCatId = CInt(tvRubros.SelectedNode.Tag)
        LimpiarDetalle()
    End Sub

    Private Sub BtnPublicar_Click(sender As Object, e As EventArgs) Handles BtnPublicar.Click

        GuardarNota(estado:=1)
        MessageBox.Show("Nota publicada.", "Pizarrón", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub BtnPin_Click(sender As Object, e As EventArgs) Handles BtnPin.Click

        If Not currentNoteId.HasValue Then
            MessageBox.Show("Selecciona o guarda primero la nota.", "Pizarrón", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Dim nuevoPin As Boolean = Not chkFijada.Checked
        chkFijada.Checked = nuevoPin
        GuardarNota(forzarPin:=nuevoPin)  ' conserva el estado actual, sólo cambia pin

    End Sub

   

    Private Sub dgLista_SelectionChanged(sender As Object, e As EventArgs) Handles dglista.SelectionChanged
        If bs.Current Is Nothing Then Exit Sub
        Dim drv As DataRowView = CType(bs.Current, DataRowView)
        currentNoteId = CInt(drv("NoteID"))
        CargarDetalle(currentNoteId.Value)
    End Sub

    Private Sub btnRecetas_Click(sender As Object, e As EventArgs) Handles btnRecetas.Click
        ' Usa el rubro de edición actual (o el seleccionado del árbol)
        Dim catId As Integer? = If(editingCatId, If(tvRubros.SelectedNode Is Nothing, Nothing, CInt(tvRubros.SelectedNode.Tag)))
        txtNoteId.Clear()

        If Not catId.HasValue Then
            MessageBox.Show("Selecciona un rubro en el árbol para asociar la receta.", "Pizarrón")
            Exit Sub
        End If

        ' Si hay una nota seleccionada y es Receta, pásala para editar
        Dim noteId As Integer? = Nothing
        Dim drv = TryCast(bs.Current, DataRowView)
        If drv IsNot Nothing AndAlso Not drv.Row.IsNull("NoteID") AndAlso Not drv.Row.IsNull("Tipo") Then
            If CInt(drv("Tipo")) = 1 Then noteId = CInt(drv("NoteID")) ' 1 = Receta
        End If

        Using f As New FrmRecetaModal(connStr, catId.Value, noteId)
            If f.ShowDialog(Me) = DialogResult.OK Then
                ' Refresca lista por si guardó/actualizó
                CargarLista(catId.Value)
            End If
        End Using
    End Sub

    Private Sub btnInstalaciones_Click(sender As Object, e As EventArgs) Handles btnInstalaciones.Click
        ' Rubro para asociar la guía
        Dim catId As Integer? = If(editingCatId, If(tvRubros.SelectedNode Is Nothing, Nothing, CInt(tvRubros.SelectedNode.Tag)))
        If Not catId.HasValue Then
            MessageBox.Show("Selecciona un rubro en el árbol para asociar la guía.", "Pizarrón")
            Exit Sub
        End If

        ' Si hay nota seleccionada y es Instalación (Tipo=5), pásala para editar
        Dim noteId As Integer? = Nothing
        Dim drv = TryCast(bs.Current, DataRowView)
        If drv IsNot Nothing AndAlso Not drv.Row.IsNull("NoteID") AndAlso Not drv.Row.IsNull("Tipo") Then
            If CInt(drv("Tipo")) = 5 Then noteId = CInt(drv("NoteID"))
        End If

        Using f As New FrmInstalacionModal(connStr, catId.Value, noteId)
            If f.ShowDialog(Me) = DialogResult.OK Then
                CargarLista(catId.Value)
            End If
        End Using
    End Sub
End Class