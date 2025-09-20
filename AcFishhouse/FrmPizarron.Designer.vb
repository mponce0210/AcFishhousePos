<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPizarron
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim TreeNode13 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Proveedores")
        Dim TreeNode14 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Servicios ")
        Dim TreeNode15 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Afirme")
        Dim TreeNode16 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Mercado Pago")
        Dim TreeNode17 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Terminales Bancarias ", New System.Windows.Forms.TreeNode() {TreeNode15, TreeNode16})
        Dim TreeNode18 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Acuario Fish House", New System.Windows.Forms.TreeNode() {TreeNode13, TreeNode14, TreeNode17})
        Dim TreeNode19 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Ich")
        Dim TreeNode20 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Enfermedades", New System.Windows.Forms.TreeNode() {TreeNode19})
        Dim TreeNode21 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Recetas")
        Dim TreeNode22 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Wifi Passwords")
        Dim TreeNode23 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Tips")
        Dim TreeNode24 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Acuarios Principiantes")
        Me.tvRubros = New System.Windows.Forms.TreeView()
        Me.ctxRubros = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnunuevoSubrubro = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuRenombrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.Txtbuscar = New System.Windows.Forms.TextBox()
        Me.chkVigentes = New System.Windows.Forms.CheckBox()
        Me.cboTipo = New System.Windows.Forms.ComboBox()
        Me.BtnNuevo = New System.Windows.Forms.Button()
        Me.BtnGuardar = New System.Windows.Forms.Button()
        Me.BtnPublicar = New System.Windows.Forms.Button()
        Me.BtnPin = New System.Windows.Forms.Button()
        Me.btnTv = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tcVista = New System.Windows.Forms.TabPage()
        Me.wvcards = New Microsoft.Web.WebView2.WinForms.WebView2()
        Me.dglista = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.WebView21 = New Microsoft.Web.WebView2.WinForms.WebView2()
        Me.txtNoteId = New System.Windows.Forms.TextBox()
        Me.txttitulo = New System.Windows.Forms.TextBox()
        Me.txtcontenido = New System.Windows.Forms.TextBox()
        Me.txttags = New System.Windows.Forms.TextBox()
        Me.txtEspecie = New System.Windows.Forms.TextBox()
        Me.numPrioridad = New System.Windows.Forms.NumericUpDown()
        Me.chkFijada = New System.Windows.Forms.CheckBox()
        Me.dtdesde = New System.Windows.Forms.DateTimePicker()
        Me.dtHasta = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnRecetas = New System.Windows.Forms.Button()
        Me.btnInstalaciones = New System.Windows.Forms.Button()
        Me.ctxRubros.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tcVista.SuspendLayout()
        CType(Me.wvcards, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dglista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.WebView21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numPrioridad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tvRubros
        '
        Me.tvRubros.ContextMenuStrip = Me.ctxRubros
        Me.tvRubros.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tvRubros.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.tvRubros.LabelEdit = True
        Me.tvRubros.Location = New System.Drawing.Point(1, 226)
        Me.tvRubros.Name = "tvRubros"
        TreeNode13.Name = "Nodo1"
        TreeNode13.Text = "Proveedores"
        TreeNode14.Name = "Nodo2"
        TreeNode14.Text = "Servicios "
        TreeNode15.Name = "Nodo9"
        TreeNode15.Text = "Afirme"
        TreeNode16.Name = "Nodo10"
        TreeNode16.Text = "Mercado Pago"
        TreeNode17.Name = "Nodo8"
        TreeNode17.Text = "Terminales Bancarias "
        TreeNode18.Name = "Nodo0"
        TreeNode18.Text = "Acuario Fish House"
        TreeNode19.Name = "Nodo4"
        TreeNode19.Text = "Ich"
        TreeNode20.Name = "Nodo3"
        TreeNode20.Text = "Enfermedades"
        TreeNode21.Name = "Nodo5"
        TreeNode21.Text = "Recetas"
        TreeNode22.Name = "Nodo6"
        TreeNode22.Text = "Wifi Passwords"
        TreeNode23.Name = "Nodo7"
        TreeNode23.Text = "Tips"
        TreeNode24.Name = "Nodo11"
        TreeNode24.Text = "Acuarios Principiantes"
        Me.tvRubros.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode18, TreeNode20, TreeNode21, TreeNode22, TreeNode23, TreeNode24})
        Me.tvRubros.Size = New System.Drawing.Size(237, 591)
        Me.tvRubros.TabIndex = 0
        '
        'ctxRubros
        '
        Me.ctxRubros.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnunuevoSubrubro, Me.mnuRenombrar, Me.mnuEliminar})
        Me.ctxRubros.Name = "ctxRubros"
        Me.ctxRubros.Size = New System.Drawing.Size(134, 70)
        Me.ctxRubros.Text = "Captura"
        '
        'mnunuevoSubrubro
        '
        Me.mnunuevoSubrubro.Name = "mnunuevoSubrubro"
        Me.mnunuevoSubrubro.Size = New System.Drawing.Size(133, 22)
        Me.mnunuevoSubrubro.Text = "Nuevo"
        '
        'mnuRenombrar
        '
        Me.mnuRenombrar.Name = "mnuRenombrar"
        Me.mnuRenombrar.Size = New System.Drawing.Size(133, 22)
        Me.mnuRenombrar.Text = "Renombrar"
        '
        'mnuEliminar
        '
        Me.mnuEliminar.Name = "mnuEliminar"
        Me.mnuEliminar.Size = New System.Drawing.Size(133, 22)
        Me.mnuEliminar.Text = "Eliminar"
        '
        'Txtbuscar
        '
        Me.Txtbuscar.Location = New System.Drawing.Point(805, 192)
        Me.Txtbuscar.Name = "Txtbuscar"
        Me.Txtbuscar.Size = New System.Drawing.Size(168, 20)
        Me.Txtbuscar.TabIndex = 2
        Me.Txtbuscar.Visible = False
        '
        'chkVigentes
        '
        Me.chkVigentes.AutoSize = True
        Me.chkVigentes.Location = New System.Drawing.Point(2, 169)
        Me.chkVigentes.Name = "chkVigentes"
        Me.chkVigentes.Size = New System.Drawing.Size(67, 17)
        Me.chkVigentes.TabIndex = 3
        Me.chkVigentes.Text = "Vigentes"
        Me.chkVigentes.UseVisualStyleBackColor = True
        Me.chkVigentes.Visible = False
        '
        'cboTipo
        '
        Me.cboTipo.FormattingEnabled = True
        Me.cboTipo.Location = New System.Drawing.Point(87, 102)
        Me.cboTipo.Name = "cboTipo"
        Me.cboTipo.Size = New System.Drawing.Size(246, 21)
        Me.cboTipo.TabIndex = 4
        '
        'BtnNuevo
        '
        Me.BtnNuevo.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNuevo.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.BtnNuevo.Location = New System.Drawing.Point(736, 39)
        Me.BtnNuevo.Name = "BtnNuevo"
        Me.BtnNuevo.Size = New System.Drawing.Size(75, 23)
        Me.BtnNuevo.TabIndex = 5
        Me.BtnNuevo.Text = "Nuevo"
        Me.BtnNuevo.UseVisualStyleBackColor = True
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGuardar.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.BtnGuardar.Location = New System.Drawing.Point(817, 39)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(75, 23)
        Me.BtnGuardar.TabIndex = 6
        Me.BtnGuardar.Text = "Guardar"
        Me.BtnGuardar.UseVisualStyleBackColor = True
        '
        'BtnPublicar
        '
        Me.BtnPublicar.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPublicar.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.BtnPublicar.Location = New System.Drawing.Point(898, 39)
        Me.BtnPublicar.Name = "BtnPublicar"
        Me.BtnPublicar.Size = New System.Drawing.Size(75, 23)
        Me.BtnPublicar.TabIndex = 7
        Me.BtnPublicar.Text = "Publicar"
        Me.BtnPublicar.UseVisualStyleBackColor = True
        '
        'BtnPin
        '
        Me.BtnPin.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPin.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.BtnPin.Location = New System.Drawing.Point(805, 163)
        Me.BtnPin.Name = "BtnPin"
        Me.BtnPin.Size = New System.Drawing.Size(75, 23)
        Me.BtnPin.TabIndex = 8
        Me.BtnPin.Text = "Pin"
        Me.BtnPin.UseVisualStyleBackColor = True
        Me.BtnPin.Visible = False
        '
        'btnTv
        '
        Me.btnTv.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTv.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btnTv.Location = New System.Drawing.Point(898, 163)
        Me.btnTv.Name = "btnTv"
        Me.btnTv.Size = New System.Drawing.Size(75, 23)
        Me.btnTv.TabIndex = 9
        Me.btnTv.Text = "Tv"
        Me.btnTv.UseVisualStyleBackColor = True
        Me.btnTv.Visible = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tcVista)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(244, 226)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(966, 589)
        Me.TabControl1.TabIndex = 10
        '
        'tcVista
        '
        Me.tcVista.BackColor = System.Drawing.Color.Transparent
        Me.tcVista.Controls.Add(Me.wvcards)
        Me.tcVista.Controls.Add(Me.dglista)
        Me.tcVista.Location = New System.Drawing.Point(4, 22)
        Me.tcVista.Name = "tcVista"
        Me.tcVista.Padding = New System.Windows.Forms.Padding(3)
        Me.tcVista.Size = New System.Drawing.Size(958, 563)
        Me.tcVista.TabIndex = 0
        Me.tcVista.Text = "PIZARRON "
        '
        'wvcards
        '
        Me.wvcards.AllowExternalDrop = True
        Me.wvcards.BackColor = System.Drawing.Color.LightCyan
        Me.wvcards.CreationProperties = Nothing
        Me.wvcards.DefaultBackgroundColor = System.Drawing.Color.White
        Me.wvcards.Location = New System.Drawing.Point(15, 208)
        Me.wvcards.Name = "wvcards"
        Me.wvcards.Size = New System.Drawing.Size(937, 337)
        Me.wvcards.TabIndex = 1
        Me.wvcards.ZoomFactor = 1.0R
        '
        'dglista
        '
        Me.dglista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dglista.Location = New System.Drawing.Point(15, 6)
        Me.dglista.Name = "dglista"
        Me.dglista.Size = New System.Drawing.Size(937, 177)
        Me.dglista.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.WebView21)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(958, 563)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "INACTIVO"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'WebView21
        '
        Me.WebView21.AllowExternalDrop = True
        Me.WebView21.CreationProperties = Nothing
        Me.WebView21.DefaultBackgroundColor = System.Drawing.Color.White
        Me.WebView21.Location = New System.Drawing.Point(10, 15)
        Me.WebView21.Name = "WebView21"
        Me.WebView21.Size = New System.Drawing.Size(700, 348)
        Me.WebView21.TabIndex = 2
        Me.WebView21.ZoomFactor = 1.0R
        '
        'txtNoteId
        '
        Me.txtNoteId.Location = New System.Drawing.Point(1134, 78)
        Me.txtNoteId.Name = "txtNoteId"
        Me.txtNoteId.Size = New System.Drawing.Size(66, 20)
        Me.txtNoteId.TabIndex = 11
        Me.txtNoteId.Visible = False
        '
        'txttitulo
        '
        Me.txttitulo.Location = New System.Drawing.Point(87, 146)
        Me.txttitulo.Name = "txttitulo"
        Me.txttitulo.Size = New System.Drawing.Size(246, 20)
        Me.txttitulo.TabIndex = 12
        '
        'txtcontenido
        '
        Me.txtcontenido.Location = New System.Drawing.Point(339, 102)
        Me.txtcontenido.Multiline = True
        Me.txtcontenido.Name = "txtcontenido"
        Me.txtcontenido.Size = New System.Drawing.Size(381, 111)
        Me.txtcontenido.TabIndex = 13
        '
        'txttags
        '
        Me.txttags.Location = New System.Drawing.Point(87, 193)
        Me.txttags.Name = "txttags"
        Me.txttags.Size = New System.Drawing.Size(246, 20)
        Me.txttags.TabIndex = 14
        '
        'txtEspecie
        '
        Me.txtEspecie.Location = New System.Drawing.Point(1024, 102)
        Me.txtEspecie.Name = "txtEspecie"
        Me.txtEspecie.Size = New System.Drawing.Size(100, 20)
        Me.txtEspecie.TabIndex = 15
        Me.txtEspecie.Visible = False
        '
        'numPrioridad
        '
        Me.numPrioridad.Location = New System.Drawing.Point(1024, 79)
        Me.numPrioridad.Name = "numPrioridad"
        Me.numPrioridad.Size = New System.Drawing.Size(100, 20)
        Me.numPrioridad.TabIndex = 16
        Me.numPrioridad.Visible = False
        '
        'chkFijada
        '
        Me.chkFijada.AutoSize = True
        Me.chkFijada.Location = New System.Drawing.Point(2, 195)
        Me.chkFijada.Name = "chkFijada"
        Me.chkFijada.Size = New System.Drawing.Size(42, 17)
        Me.chkFijada.TabIndex = 17
        Me.chkFijada.Text = "Fijo"
        Me.chkFijada.UseVisualStyleBackColor = True
        Me.chkFijada.Visible = False
        '
        'dtdesde
        '
        Me.dtdesde.Location = New System.Drawing.Point(1032, 52)
        Me.dtdesde.Name = "dtdesde"
        Me.dtdesde.Size = New System.Drawing.Size(168, 20)
        Me.dtdesde.TabIndex = 18
        Me.dtdesde.Visible = False
        '
        'dtHasta
        '
        Me.dtHasta.Location = New System.Drawing.Point(1024, 26)
        Me.dtHasta.Name = "dtHasta"
        Me.dtHasta.Size = New System.Drawing.Size(176, 20)
        Me.dtHasta.TabIndex = 19
        Me.dtHasta.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label1.Location = New System.Drawing.Point(84, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 17)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "TIPO : "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label2.Location = New System.Drawing.Point(84, 126)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 17)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "TITULO"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label3.Location = New System.Drawing.Point(336, 82)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(102, 17)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "COMENTARIOS:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label4.Location = New System.Drawing.Point(87, 173)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 17)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "TAGS #"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label5.Location = New System.Drawing.Point(84, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(527, 20)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "BASE DE CONOCIMIENTOS Y NOTAS DEL ACUARIO"
        '
        'btnRecetas
        '
        Me.btnRecetas.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRecetas.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btnRecetas.Location = New System.Drawing.Point(736, 68)
        Me.btnRecetas.Name = "btnRecetas"
        Me.btnRecetas.Size = New System.Drawing.Size(75, 23)
        Me.btnRecetas.TabIndex = 25
        Me.btnRecetas.Text = "Recetas"
        Me.btnRecetas.UseVisualStyleBackColor = True
        '
        'btnInstalaciones
        '
        Me.btnInstalaciones.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInstalaciones.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btnInstalaciones.Location = New System.Drawing.Point(817, 68)
        Me.btnInstalaciones.Name = "btnInstalaciones"
        Me.btnInstalaciones.Size = New System.Drawing.Size(156, 23)
        Me.btnInstalaciones.TabIndex = 26
        Me.btnInstalaciones.Text = "Manuales / Instalaciones"
        Me.btnInstalaciones.UseVisualStyleBackColor = True
        '
        'FrmPizarron
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1222, 845)
        Me.Controls.Add(Me.btnInstalaciones)
        Me.Controls.Add(Me.btnRecetas)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtHasta)
        Me.Controls.Add(Me.dtdesde)
        Me.Controls.Add(Me.chkFijada)
        Me.Controls.Add(Me.numPrioridad)
        Me.Controls.Add(Me.txtEspecie)
        Me.Controls.Add(Me.txttags)
        Me.Controls.Add(Me.txtcontenido)
        Me.Controls.Add(Me.txttitulo)
        Me.Controls.Add(Me.txtNoteId)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btnTv)
        Me.Controls.Add(Me.BtnPin)
        Me.Controls.Add(Me.BtnPublicar)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.BtnNuevo)
        Me.Controls.Add(Me.cboTipo)
        Me.Controls.Add(Me.chkVigentes)
        Me.Controls.Add(Me.Txtbuscar)
        Me.Controls.Add(Me.tvRubros)
        Me.Name = "FrmPizarron"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Anotaciones Tips Medicamentos  Enfermedades "
        Me.ctxRubros.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.tcVista.ResumeLayout(False)
        CType(Me.wvcards, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dglista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.WebView21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numPrioridad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tvRubros As TreeView
    Friend WithEvents ctxRubros As ContextMenuStrip
    Friend WithEvents mnunuevoSubrubro As ToolStripMenuItem
    Friend WithEvents mnuRenombrar As ToolStripMenuItem
    Friend WithEvents mnuEliminar As ToolStripMenuItem
    Friend WithEvents Txtbuscar As TextBox
    Friend WithEvents chkVigentes As CheckBox
    Friend WithEvents cboTipo As ComboBox
    Friend WithEvents BtnNuevo As Button
    Friend WithEvents BtnGuardar As Button
    Friend WithEvents BtnPublicar As Button
    Friend WithEvents BtnPin As Button
    Friend WithEvents btnTv As Button
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents tcVista As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents dglista As DataGridView
    Friend WithEvents txtNoteId As TextBox
    Friend WithEvents txttitulo As TextBox
    Friend WithEvents txtcontenido As TextBox
    Friend WithEvents txttags As TextBox
    Friend WithEvents txtEspecie As TextBox
    Friend WithEvents numPrioridad As NumericUpDown
    Friend WithEvents chkFijada As CheckBox
    Friend WithEvents dtdesde As DateTimePicker
    Friend WithEvents dtHasta As DateTimePicker
    Friend WithEvents wvcards As Microsoft.Web.WebView2.WinForms.WebView2
    Friend WithEvents WebView21 As Microsoft.Web.WebView2.WinForms.WebView2
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents btnRecetas As Button
    Friend WithEvents btnInstalaciones As Button
End Class
