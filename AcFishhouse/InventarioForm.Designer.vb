<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class InventarioForm
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DtgInventario = New System.Windows.Forms.DataGridView()
        Me.btnguardar = New System.Windows.Forms.Button()
        Me.scMain = New System.Windows.Forms.SplitContainer()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.TsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.tsbEditar = New System.Windows.Forms.ToolStripButton()
        Me.TsbBuscar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.TStripBtnGrabar = New System.Windows.Forms.ToolStripButton()
        Me.TlSBtnrefresh = New System.Windows.Forms.ToolStripButton()
        Me.BtnBuscar = New System.Windows.Forms.Button()
        Me.cboProveedor = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.CboMarca = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.BtnExportarPdf = New System.Windows.Forms.Button()
        Me.BtnEliminar = New System.Windows.Forms.Button()
        Me.BtnNuevo = New System.Windows.Forms.Button()
        Me.BtnEditar = New System.Windows.Forms.Button()
        Me.btnImportarExcel = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CboCategoria = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtbuscar = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gbEdicion = New System.Windows.Forms.GroupBox()
        Me.NumCuantos = New System.Windows.Forms.NumericUpDown()
        Me.txtcuantos = New System.Windows.Forms.MaskedTextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cboProveedorEdit = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.CboUnuidadMed = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.CboMarcaEdit = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.BtnCancelar = New System.Windows.Forms.Button()
        Me.ChkActivo = New System.Windows.Forms.CheckBox()
        Me.nudPrecio = New System.Windows.Forms.NumericUpDown()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.nudCosto = New System.Windows.Forms.NumericUpDown()
        Me.numMinimo = New System.Windows.Forms.NumericUpDown()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.NudExistencia = New System.Windows.Forms.NumericUpDown()
        Me.cboCatEdit = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtDescripcion = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtCodigo = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblid = New System.Windows.Forms.Label()
        Me.errValidacion = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tsslTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TsslStockBajo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TSSFechahora = New System.Windows.Forms.ToolStripStatusLabel()
        Me.bsProductos = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.DtgInventario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.scMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scMain.Panel1.SuspendLayout()
        Me.scMain.Panel2.SuspendLayout()
        Me.scMain.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.gbEdicion.SuspendLayout()
        CType(Me.NumCuantos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudPrecio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudCosto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numMinimo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudExistencia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.errValidacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.bsProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DtgInventario
        '
        Me.DtgInventario.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DtgInventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.NullValue = Nothing
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DtgInventario.DefaultCellStyle = DataGridViewCellStyle1
        Me.DtgInventario.Location = New System.Drawing.Point(0, 19)
        Me.DtgInventario.Name = "DtgInventario"
        Me.DtgInventario.ReadOnly = True
        Me.DtgInventario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DtgInventario.Size = New System.Drawing.Size(1357, 192)
        Me.DtgInventario.TabIndex = 1
        '
        'btnguardar
        '
        Me.btnguardar.Location = New System.Drawing.Point(661, 360)
        Me.btnguardar.Name = "btnguardar"
        Me.btnguardar.Size = New System.Drawing.Size(93, 28)
        Me.btnguardar.TabIndex = 2
        Me.btnguardar.Text = "Grabar"
        Me.btnguardar.UseVisualStyleBackColor = True
        '
        'scMain
        '
        Me.scMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scMain.Location = New System.Drawing.Point(0, 0)
        Me.scMain.Name = "scMain"
        Me.scMain.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'scMain.Panel1
        '
        Me.scMain.Panel1.BackColor = System.Drawing.SystemColors.Highlight
        Me.scMain.Panel1.Controls.Add(Me.ToolStrip1)
        Me.scMain.Panel1.Controls.Add(Me.BtnBuscar)
        Me.scMain.Panel1.Controls.Add(Me.cboProveedor)
        Me.scMain.Panel1.Controls.Add(Me.Label13)
        Me.scMain.Panel1.Controls.Add(Me.CboMarca)
        Me.scMain.Panel1.Controls.Add(Me.Label12)
        Me.scMain.Panel1.Controls.Add(Me.Button7)
        Me.scMain.Panel1.Controls.Add(Me.BtnExportarPdf)
        Me.scMain.Panel1.Controls.Add(Me.BtnEliminar)
        Me.scMain.Panel1.Controls.Add(Me.BtnNuevo)
        Me.scMain.Panel1.Controls.Add(Me.BtnEditar)
        Me.scMain.Panel1.Controls.Add(Me.btnImportarExcel)
        Me.scMain.Panel1.Controls.Add(Me.Label3)
        Me.scMain.Panel1.Controls.Add(Me.CboCategoria)
        Me.scMain.Panel1.Controls.Add(Me.Label2)
        Me.scMain.Panel1.Controls.Add(Me.txtbuscar)
        Me.scMain.Panel1.Controls.Add(Me.Label1)
        '
        'scMain.Panel2
        '
        Me.scMain.Panel2.Controls.Add(Me.gbEdicion)
        Me.scMain.Panel2.Controls.Add(Me.DtgInventario)
        Me.scMain.Size = New System.Drawing.Size(1390, 558)
        Me.scMain.SplitterDistance = 147
        Me.scMain.TabIndex = 3
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TsbNuevo, Me.tsbEditar, Me.TsbBuscar, Me.ToolStripSeparator1, Me.TStripBtnGrabar, Me.TlSBtnrefresh})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1390, 24)
        Me.ToolStrip1.TabIndex = 9
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'TsbNuevo
        '
        Me.TsbNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TsbNuevo.Image = Global.AcFishhouse.My.Resources.Resources.nuevo_producto
        Me.TsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TsbNuevo.Name = "TsbNuevo"
        Me.TsbNuevo.Size = New System.Drawing.Size(23, 21)
        Me.TsbNuevo.Text = "Nuevo"
        '
        'tsbEditar
        '
        Me.tsbEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbEditar.Image = Global.AcFishhouse.My.Resources.Resources.editar
        Me.tsbEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEditar.Name = "tsbEditar"
        Me.tsbEditar.Size = New System.Drawing.Size(23, 21)
        Me.tsbEditar.Text = "Editar"
        '
        'TsbBuscar
        '
        Me.TsbBuscar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TsbBuscar.Image = Global.AcFishhouse.My.Resources.Resources.buscar__1_1
        Me.TsbBuscar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TsbBuscar.Name = "TsbBuscar"
        Me.TsbBuscar.Size = New System.Drawing.Size(23, 21)
        Me.TsbBuscar.Text = "Buscar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 24)
        '
        'TStripBtnGrabar
        '
        Me.TStripBtnGrabar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TStripBtnGrabar.Image = Global.AcFishhouse.My.Resources.Resources.disco
        Me.TStripBtnGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TStripBtnGrabar.Name = "TStripBtnGrabar"
        Me.TStripBtnGrabar.Size = New System.Drawing.Size(23, 21)
        Me.TStripBtnGrabar.Text = "Grabar"
        '
        'TlSBtnrefresh
        '
        Me.TlSBtnrefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TlSBtnrefresh.Image = Global.AcFishhouse.My.Resources.Resources.actualizar
        Me.TlSBtnrefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TlSBtnrefresh.Name = "TlSBtnrefresh"
        Me.TlSBtnrefresh.Size = New System.Drawing.Size(23, 21)
        Me.TlSBtnrefresh.Text = "Refresh"
        '
        'BtnBuscar
        '
        Me.BtnBuscar.BackgroundImage = Global.AcFishhouse.My.Resources.Resources.buscar__1_
        Me.BtnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnBuscar.Image = Global.AcFishhouse.My.Resources.Resources.ayuda
        Me.BtnBuscar.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnBuscar.Location = New System.Drawing.Point(12, 40)
        Me.BtnBuscar.Name = "BtnBuscar"
        Me.BtnBuscar.Size = New System.Drawing.Size(48, 41)
        Me.BtnBuscar.TabIndex = 8
        Me.BtnBuscar.UseVisualStyleBackColor = True
        Me.BtnBuscar.Visible = False
        '
        'cboProveedor
        '
        Me.cboProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProveedor.FormattingEnabled = True
        Me.cboProveedor.Location = New System.Drawing.Point(637, 83)
        Me.cboProveedor.Name = "cboProveedor"
        Me.cboProveedor.Size = New System.Drawing.Size(261, 21)
        Me.cboProveedor.TabIndex = 7
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(531, 84)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(100, 15)
        Me.Label13.TabIndex = 6
        Me.Label13.Text = "PROVEEDOR :"
        '
        'CboMarca
        '
        Me.CboMarca.FormattingEnabled = True
        Me.CboMarca.Location = New System.Drawing.Point(262, 86)
        Me.CboMarca.Name = "CboMarca"
        Me.CboMarca.Size = New System.Drawing.Size(193, 21)
        Me.CboMarca.TabIndex = 5
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(187, 92)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(62, 15)
        Me.Label12.TabIndex = 4
        Me.Label12.Text = "MARCA :"
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(31, 316)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(90, 31)
        Me.Button7.TabIndex = 3
        Me.Button7.Text = "Button7"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'BtnExportarPdf
        '
        Me.BtnExportarPdf.Enabled = False
        Me.BtnExportarPdf.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnExportarPdf.Location = New System.Drawing.Point(1185, 61)
        Me.BtnExportarPdf.Name = "BtnExportarPdf"
        Me.BtnExportarPdf.Size = New System.Drawing.Size(90, 31)
        Me.BtnExportarPdf.TabIndex = 3
        Me.BtnExportarPdf.Text = "Export.PDF"
        Me.BtnExportarPdf.UseVisualStyleBackColor = True
        '
        'BtnEliminar
        '
        Me.BtnEliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEliminar.ForeColor = System.Drawing.SystemColors.Highlight
        Me.BtnEliminar.Location = New System.Drawing.Point(993, 61)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(90, 31)
        Me.BtnEliminar.TabIndex = 3
        Me.BtnEliminar.Text = "LIMPIAR"
        Me.BtnEliminar.UseVisualStyleBackColor = True
        '
        'BtnNuevo
        '
        Me.BtnNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNuevo.Location = New System.Drawing.Point(1288, 103)
        Me.BtnNuevo.Name = "BtnNuevo"
        Me.BtnNuevo.Size = New System.Drawing.Size(90, 31)
        Me.BtnNuevo.TabIndex = 3
        Me.BtnNuevo.Text = "Nuevo"
        Me.BtnNuevo.UseVisualStyleBackColor = True
        Me.BtnNuevo.Visible = False
        '
        'BtnEditar
        '
        Me.BtnEditar.BackgroundImage = Global.AcFishhouse.My.Resources.Resources.mesa_de_edicion
        Me.BtnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnEditar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEditar.Location = New System.Drawing.Point(12, 87)
        Me.BtnEditar.Name = "BtnEditar"
        Me.BtnEditar.Size = New System.Drawing.Size(48, 37)
        Me.BtnEditar.TabIndex = 3
        Me.BtnEditar.UseVisualStyleBackColor = True
        Me.BtnEditar.Visible = False
        '
        'btnImportarExcel
        '
        Me.btnImportarExcel.Font = New System.Drawing.Font("Segoe UI Black", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImportarExcel.ForeColor = System.Drawing.SystemColors.Highlight
        Me.btnImportarExcel.Location = New System.Drawing.Point(1089, 61)
        Me.btnImportarExcel.Name = "btnImportarExcel"
        Me.btnImportarExcel.Size = New System.Drawing.Size(90, 31)
        Me.btnImportarExcel.TabIndex = 3
        Me.btnImportarExcel.Text = "Impt.Excel"
        Me.btnImportarExcel.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(1020, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(224, 24)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "FILTROS / ACCIONES "
        '
        'CboCategoria
        '
        Me.CboCategoria.FormattingEnabled = True
        Me.CboCategoria.Location = New System.Drawing.Point(637, 40)
        Me.CboCategoria.Name = "CboCategoria"
        Me.CboCategoria.Size = New System.Drawing.Size(261, 21)
        Me.CboCategoria.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(540, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 15)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "CATEGORIA :"
        '
        'txtbuscar
        '
        Me.txtbuscar.Location = New System.Drawing.Point(262, 38)
        Me.txtbuscar.Name = "txtbuscar"
        Me.txtbuscar.Size = New System.Drawing.Size(261, 20)
        Me.txtbuscar.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(186, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 15)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "BUSCAR :"
        '
        'gbEdicion
        '
        Me.gbEdicion.BackColor = System.Drawing.Color.White
        Me.gbEdicion.Controls.Add(Me.NumCuantos)
        Me.gbEdicion.Controls.Add(Me.txtcuantos)
        Me.gbEdicion.Controls.Add(Me.Label17)
        Me.gbEdicion.Controls.Add(Me.cboProveedorEdit)
        Me.gbEdicion.Controls.Add(Me.Label16)
        Me.gbEdicion.Controls.Add(Me.CboUnuidadMed)
        Me.gbEdicion.Controls.Add(Me.Label15)
        Me.gbEdicion.Controls.Add(Me.CboMarcaEdit)
        Me.gbEdicion.Controls.Add(Me.Label14)
        Me.gbEdicion.Controls.Add(Me.BtnCancelar)
        Me.gbEdicion.Controls.Add(Me.ChkActivo)
        Me.gbEdicion.Controls.Add(Me.nudPrecio)
        Me.gbEdicion.Controls.Add(Me.Label11)
        Me.gbEdicion.Controls.Add(Me.nudCosto)
        Me.gbEdicion.Controls.Add(Me.numMinimo)
        Me.gbEdicion.Controls.Add(Me.Label10)
        Me.gbEdicion.Controls.Add(Me.Label9)
        Me.gbEdicion.Controls.Add(Me.Label8)
        Me.gbEdicion.Controls.Add(Me.NudExistencia)
        Me.gbEdicion.Controls.Add(Me.cboCatEdit)
        Me.gbEdicion.Controls.Add(Me.Label7)
        Me.gbEdicion.Controls.Add(Me.TxtDescripcion)
        Me.gbEdicion.Controls.Add(Me.Label6)
        Me.gbEdicion.Controls.Add(Me.TxtCodigo)
        Me.gbEdicion.Controls.Add(Me.Label5)
        Me.gbEdicion.Controls.Add(Me.Label4)
        Me.gbEdicion.Controls.Add(Me.lblid)
        Me.gbEdicion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbEdicion.Location = New System.Drawing.Point(12, 229)
        Me.gbEdicion.Name = "gbEdicion"
        Me.gbEdicion.Size = New System.Drawing.Size(1345, 161)
        Me.gbEdicion.TabIndex = 2
        Me.gbEdicion.TabStop = False
        Me.gbEdicion.Text = "Panel Edicion "
        '
        'NumCuantos
        '
        Me.NumCuantos.Location = New System.Drawing.Point(763, 65)
        Me.NumCuantos.Name = "NumCuantos"
        Me.NumCuantos.Size = New System.Drawing.Size(62, 22)
        Me.NumCuantos.TabIndex = 27
        Me.NumCuantos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtcuantos
        '
        Me.txtcuantos.Location = New System.Drawing.Point(705, 99)
        Me.txtcuantos.Mask = "0000"
        Me.txtcuantos.Name = "txtcuantos"
        Me.txtcuantos.Size = New System.Drawing.Size(70, 22)
        Me.txtcuantos.TabIndex = 26
        Me.txtcuantos.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.txtcuantos.Visible = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(685, 68)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(81, 16)
        Me.Label17.TabIndex = 24
        Me.Label17.Text = "Cantidad : "
        '
        'cboProveedorEdit
        '
        Me.cboProveedorEdit.FormattingEnabled = True
        Me.cboProveedorEdit.Location = New System.Drawing.Point(954, 68)
        Me.cboProveedorEdit.Name = "cboProveedorEdit"
        Me.cboProveedorEdit.Size = New System.Drawing.Size(246, 24)
        Me.cboProveedorEdit.TabIndex = 23
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(865, 68)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(92, 16)
        Me.Label16.TabIndex = 22
        Me.Label16.Text = "Proveedor : "
        '
        'CboUnuidadMed
        '
        Me.CboUnuidadMed.FormattingEnabled = True
        Me.CboUnuidadMed.Location = New System.Drawing.Point(522, 62)
        Me.CboUnuidadMed.Name = "CboUnuidadMed"
        Me.CboUnuidadMed.Size = New System.Drawing.Size(146, 24)
        Me.CboUnuidadMed.TabIndex = 21
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(438, 65)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(69, 16)
        Me.Label15.TabIndex = 20
        Me.Label15.Text = "Unidad : "
        '
        'CboMarcaEdit
        '
        Me.CboMarcaEdit.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.CboMarcaEdit.FormattingEnabled = True
        Me.CboMarcaEdit.IntegralHeight = False
        Me.CboMarcaEdit.Location = New System.Drawing.Point(218, 62)
        Me.CboMarcaEdit.MaxDropDownItems = 5
        Me.CboMarcaEdit.Name = "CboMarcaEdit"
        Me.CboMarcaEdit.Size = New System.Drawing.Size(214, 24)
        Me.CboMarcaEdit.TabIndex = 19
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(150, 62)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(62, 16)
        Me.Label14.TabIndex = 18
        Me.Label14.Text = "Marca : "
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancelar.Location = New System.Drawing.Point(832, 114)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 31)
        Me.BtnCancelar.TabIndex = 17
        Me.BtnCancelar.Text = "Cancelar"
        Me.BtnCancelar.UseVisualStyleBackColor = True
        '
        'ChkActivo
        '
        Me.ChkActivo.AutoSize = True
        Me.ChkActivo.Location = New System.Drawing.Point(1226, 29)
        Me.ChkActivo.Name = "ChkActivo"
        Me.ChkActivo.Size = New System.Drawing.Size(69, 20)
        Me.ChkActivo.TabIndex = 16
        Me.ChkActivo.Text = "Activo"
        Me.ChkActivo.UseVisualStyleBackColor = True
        '
        'nudPrecio
        '
        Me.nudPrecio.DecimalPlaces = 2
        Me.nudPrecio.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.nudPrecio.Location = New System.Drawing.Point(563, 124)
        Me.nudPrecio.Maximum = New Decimal(New Integer() {200000, 0, 0, 0})
        Me.nudPrecio.Name = "nudPrecio"
        Me.nudPrecio.Size = New System.Drawing.Size(93, 22)
        Me.nudPrecio.TabIndex = 15
        Me.nudPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudPrecio.ThousandsSeparator = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(569, 105)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(64, 16)
        Me.Label11.TabIndex = 14
        Me.Label11.Text = "Precio : "
        '
        'nudCosto
        '
        Me.nudCosto.DecimalPlaces = 2
        Me.nudCosto.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.nudCosto.Location = New System.Drawing.Point(452, 124)
        Me.nudCosto.Maximum = New Decimal(New Integer() {200000, 0, 0, 0})
        Me.nudCosto.Name = "nudCosto"
        Me.nudCosto.Size = New System.Drawing.Size(93, 22)
        Me.nudCosto.TabIndex = 13
        Me.nudCosto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudCosto.ThousandsSeparator = True
        '
        'numMinimo
        '
        Me.numMinimo.Location = New System.Drawing.Point(336, 124)
        Me.numMinimo.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.numMinimo.Name = "numMinimo"
        Me.numMinimo.Size = New System.Drawing.Size(95, 22)
        Me.numMinimo.TabIndex = 12
        Me.numMinimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(466, 105)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(59, 16)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "Costo : "
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(347, 105)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 16)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "Minimo"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(215, 105)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(98, 16)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "Existencias : "
        '
        'NudExistencia
        '
        Me.NudExistencia.Location = New System.Drawing.Point(218, 124)
        Me.NudExistencia.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.NudExistencia.Minimum = New Decimal(New Integer() {10, 0, 0, -2147483648})
        Me.NudExistencia.Name = "NudExistencia"
        Me.NudExistencia.Size = New System.Drawing.Size(95, 22)
        Me.NudExistencia.TabIndex = 8
        Me.NudExistencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cboCatEdit
        '
        Me.cboCatEdit.FormattingEnabled = True
        Me.cboCatEdit.Location = New System.Drawing.Point(954, 25)
        Me.cboCatEdit.Name = "cboCatEdit"
        Me.cboCatEdit.Size = New System.Drawing.Size(246, 24)
        Me.cboCatEdit.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(873, 30)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(75, 16)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Categoria"
        '
        'TxtDescripcion
        '
        Me.TxtDescripcion.Location = New System.Drawing.Point(521, 27)
        Me.TxtDescripcion.Name = "TxtDescripcion"
        Me.TxtDescripcion.Size = New System.Drawing.Size(336, 22)
        Me.TxtDescripcion.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(438, 30)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 16)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Producto :"
        '
        'TxtCodigo
        '
        Me.TxtCodigo.Location = New System.Drawing.Point(218, 27)
        Me.TxtCodigo.Name = "TxtCodigo"
        Me.TxtCodigo.Size = New System.Drawing.Size(214, 22)
        Me.TxtCodigo.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(143, 30)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 16)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Codigo : "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(1, 30)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 16)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "IdProd : "
        '
        'lblid
        '
        Me.lblid.AutoSize = True
        Me.lblid.Location = New System.Drawing.Point(72, 30)
        Me.lblid.Name = "lblid"
        Me.lblid.Size = New System.Drawing.Size(37, 16)
        Me.lblid.TabIndex = 0
        Me.lblid.Text = "hola"
        '
        'errValidacion
        '
        Me.errValidacion.ContainerControl = Me
        '
        'ToolStripContainer1
        '
        '
        'ToolStripContainer1.ContentPanel
        '
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.scMain)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(1390, 558)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(1390, 583)
        Me.ToolStripContainer1.TabIndex = 4
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsslTotal, Me.TsslStockBajo, Me.TSSFechahora})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 561)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1390, 22)
        Me.StatusStrip1.TabIndex = 5
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tsslTotal
        '
        Me.tsslTotal.Name = "tsslTotal"
        Me.tsslTotal.Size = New System.Drawing.Size(75, 17)
        Me.tsslTotal.Text = "Resgistros : 0"
        '
        'TsslStockBajo
        '
        Me.TsslStockBajo.Name = "TsslStockBajo"
        Me.TsslStockBajo.Size = New System.Drawing.Size(80, 17)
        Me.TsslStockBajo.Text = "Stock Bajo : 0 "
        '
        'TSSFechahora
        '
        Me.TSSFechahora.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.TSSFechahora.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TSSFechahora.ForeColor = System.Drawing.SystemColors.Highlight
        Me.TSSFechahora.Name = "TSSFechahora"
        Me.TSSFechahora.Size = New System.Drawing.Size(78, 17)
        Me.TSSFechahora.Text = "Fecha y Hora"
        '
        'InventarioForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1390, 583)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Controls.Add(Me.btnguardar)
        Me.Name = "InventarioForm"
        Me.Text = "INVENTARIO"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DtgInventario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scMain.Panel1.ResumeLayout(False)
        Me.scMain.Panel1.PerformLayout()
        Me.scMain.Panel2.ResumeLayout(False)
        CType(Me.scMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scMain.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.gbEdicion.ResumeLayout(False)
        Me.gbEdicion.PerformLayout()
        CType(Me.NumCuantos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudPrecio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudCosto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numMinimo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudExistencia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.errValidacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.bsProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DtgInventario As DataGridView
    Friend WithEvents btnguardar As Button
    Friend WithEvents scMain As SplitContainer
    Friend WithEvents CboCategoria As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtbuscar As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnImportarExcel As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Button7 As Button
    Friend WithEvents BtnExportarPdf As Button
    Friend WithEvents BtnEliminar As Button
    Friend WithEvents BtnNuevo As Button
    Friend WithEvents BtnEditar As Button
    Friend WithEvents gbEdicion As GroupBox
    Friend WithEvents bsProductos As BindingSource
    Friend WithEvents TxtCodigo As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lblid As Label
    Friend WithEvents cboCatEdit As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TxtDescripcion As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents numMinimo As NumericUpDown
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents NudExistencia As NumericUpDown
    Friend WithEvents nudPrecio As NumericUpDown
    Friend WithEvents Label11 As Label
    Friend WithEvents nudCosto As NumericUpDown
    Friend WithEvents ChkActivo As CheckBox
    Friend WithEvents BtnCancelar As Button
    Friend WithEvents errValidacion As ErrorProvider
    Friend WithEvents cboProveedor As ComboBox
    Friend WithEvents Label13 As Label
    Friend WithEvents CboMarca As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents CboMarcaEdit As ComboBox
    Friend WithEvents Label14 As Label
    Friend WithEvents cboProveedorEdit As ComboBox
    Friend WithEvents Label16 As Label
    Friend WithEvents CboUnuidadMed As ComboBox
    Friend WithEvents Label17 As Label
    Friend WithEvents txtcuantos As MaskedTextBox
    Friend WithEvents BtnBuscar As Button
    Friend WithEvents ToolStripContainer1 As ToolStripContainer
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents TsbNuevo As ToolStripButton
    Friend WithEvents tsbEditar As ToolStripButton
    Friend WithEvents TsbBuscar As ToolStripButton
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents tsslTotal As ToolStripStatusLabel
    Friend WithEvents TsslStockBajo As ToolStripStatusLabel
    Friend WithEvents TSSFechahora As ToolStripStatusLabel
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents TlSBtnrefresh As ToolStripButton
    Friend WithEvents TStripBtnGrabar As ToolStripButton
    Friend WithEvents NumCuantos As NumericUpDown
End Class
