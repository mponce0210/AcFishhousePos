<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class VentasForm
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
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbF3Producto = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.TlSBtnVerifica = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.Lblticket = New System.Windows.Forms.Label()
        Me.LblCodigo = New System.Windows.Forms.Label()
        Me.BtnEnter = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.IdProducto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CdBarras = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DesProducto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PreVenta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImporteVen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Existencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LblCantPro = New System.Windows.Forms.Label()
        Me.LblCantidad = New System.Windows.Forms.Label()
        Me.LblTotal = New System.Windows.Forms.Label()
        Me.LblPagoCon = New System.Windows.Forms.Label()
        Me.LblCambio = New System.Windows.Forms.Label()
        Me.LblDTotal = New System.Windows.Forms.Label()
        Me.LblDCambio = New System.Windows.Forms.Label()
        Me.BtnCobro = New System.Windows.Forms.Button()
        Me.BtnBorrar = New System.Windows.Forms.Button()
        Me.TxtPago = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.BtnHistorial = New System.Windows.Forms.Button()
        Me.NudTC = New System.Windows.Forms.NumericUpDown()
        Me.NuDEfe = New System.Windows.Forms.NumericUpDown()
        Me.LblMixTc = New System.Windows.Forms.Label()
        Me.lblMixEfe = New System.Windows.Forms.Label()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.RBTransfer = New System.Windows.Forms.RadioButton()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.RBMixto = New System.Windows.Forms.RadioButton()
        Me.RBDebito = New System.Windows.Forms.RadioButton()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.RBCredito = New System.Windows.Forms.RadioButton()
        Me.RbEfectivo = New System.Windows.Forms.RadioButton()
        Me.cboProducto = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.NudTC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NuDEfe, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbF3Producto, Me.ToolStripSeparator1, Me.TlSBtnVerifica, Me.ToolStripLabel1, Me.ToolStripLabel2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(968, 49)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbF3Producto
        '
        Me.tsbF3Producto.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tsbF3Producto.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsbF3Producto.ForeColor = System.Drawing.SystemColors.Highlight
        Me.tsbF3Producto.Image = Global.AcFishhouse.My.Resources.Resources.buscar__1_1
        Me.tsbF3Producto.Name = "tsbF3Producto"
        Me.tsbF3Producto.Size = New System.Drawing.Size(102, 46)
        Me.tsbF3Producto.Text = "F3 Producto"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 49)
        '
        'TlSBtnVerifica
        '
        Me.TlSBtnVerifica.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TlSBtnVerifica.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TlSBtnVerifica.ForeColor = System.Drawing.SystemColors.Highlight
        Me.TlSBtnVerifica.Image = Global.AcFishhouse.My.Resources.Resources.editar
        Me.TlSBtnVerifica.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TlSBtnVerifica.Name = "TlSBtnVerifica"
        Me.TlSBtnVerifica.Size = New System.Drawing.Size(148, 46)
        Me.TlSBtnVerifica.Text = "F4 Verificador $"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripLabel1.ForeColor = System.Drawing.SystemColors.Highlight
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(186, 46)
        Me.ToolStripLabel1.Text = "Atajos : Cantidad Enter (Calcular) /"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripLabel2.ForeColor = System.Drawing.SystemColors.Highlight
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(206, 46)
        Me.ToolStripLabel2.Text = "/ Borrar Renglon Click #-Reng (Delete)"
        '
        'Lblticket
        '
        Me.Lblticket.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Lblticket.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Lblticket.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblticket.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Lblticket.Location = New System.Drawing.Point(-3, 52)
        Me.Lblticket.Name = "Lblticket"
        Me.Lblticket.Size = New System.Drawing.Size(100, 23)
        Me.Lblticket.TabIndex = 1
        Me.Lblticket.Text = "Venta - Ticket "
        '
        'LblCodigo
        '
        Me.LblCodigo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblCodigo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.LblCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCodigo.ForeColor = System.Drawing.SystemColors.Highlight
        Me.LblCodigo.Location = New System.Drawing.Point(-3, 75)
        Me.LblCodigo.Name = "LblCodigo"
        Me.LblCodigo.Size = New System.Drawing.Size(163, 23)
        Me.LblCodigo.TabIndex = 2
        Me.LblCodigo.Text = "Codigo del Producto"
        Me.LblCodigo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnEnter
        '
        Me.BtnEnter.Enabled = False
        Me.BtnEnter.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEnter.ForeColor = System.Drawing.SystemColors.Highlight
        Me.BtnEnter.Location = New System.Drawing.Point(707, 71)
        Me.BtnEnter.Name = "BtnEnter"
        Me.BtnEnter.Size = New System.Drawing.Size(205, 23)
        Me.BtnEnter.TabIndex = 1
        Me.BtnEnter.Text = "Enter-Agregar Producto"
        Me.BtnEnter.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdProducto, Me.CdBarras, Me.DesProducto, Me.PreVenta, Me.Cantidad, Me.ImporteVen, Me.Existencia})
        Me.DataGridView1.Location = New System.Drawing.Point(0, 101)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(689, 244)
        Me.DataGridView1.TabIndex = 5
        Me.DataGridView1.TabStop = False
        '
        'IdProducto
        '
        Me.IdProducto.HeaderText = "IdProducto"
        Me.IdProducto.Name = "IdProducto"
        Me.IdProducto.ReadOnly = True
        '
        'CdBarras
        '
        Me.CdBarras.FillWeight = 150.0!
        Me.CdBarras.HeaderText = "Codigo Barras"
        Me.CdBarras.Name = "CdBarras"
        Me.CdBarras.ReadOnly = True
        '
        'DesProducto
        '
        Me.DesProducto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DesProducto.HeaderText = "Descripcion Ptco"
        Me.DesProducto.Name = "DesProducto"
        Me.DesProducto.ReadOnly = True
        Me.DesProducto.Width = 104
        '
        'PreVenta
        '
        Me.PreVenta.HeaderText = "Precio Venta"
        Me.PreVenta.Name = "PreVenta"
        '
        'Cantidad
        '
        Me.Cantidad.HeaderText = "Cant."
        Me.Cantidad.Name = "Cantidad"
        '
        'ImporteVen
        '
        Me.ImporteVen.HeaderText = "Importe"
        Me.ImporteVen.Name = "ImporteVen"
        '
        'Existencia
        '
        Me.Existencia.HeaderText = "Existencia"
        Me.Existencia.Name = "Existencia"
        Me.Existencia.ReadOnly = True
        '
        'LblCantPro
        '
        Me.LblCantPro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblCantPro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCantPro.ForeColor = System.Drawing.Color.DarkGreen
        Me.LblCantPro.Location = New System.Drawing.Point(9, 33)
        Me.LblCantPro.Name = "LblCantPro"
        Me.LblCantPro.Size = New System.Drawing.Size(44, 23)
        Me.LblCantPro.TabIndex = 6
        Me.LblCantPro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblCantidad
        '
        Me.LblCantidad.AutoSize = True
        Me.LblCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCantidad.ForeColor = System.Drawing.SystemColors.Highlight
        Me.LblCantidad.Location = New System.Drawing.Point(59, 33)
        Me.LblCantidad.Name = "LblCantidad"
        Me.LblCantidad.Size = New System.Drawing.Size(179, 18)
        Me.LblCantidad.TabIndex = 7
        Me.LblCantidad.Text = "Productos en la Venta."
        Me.LblCantidad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTotal
        '
        Me.LblTotal.AutoSize = True
        Me.LblTotal.Font = New System.Drawing.Font("Segoe UI Black", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotal.ForeColor = System.Drawing.SystemColors.Highlight
        Me.LblTotal.Location = New System.Drawing.Point(772, 229)
        Me.LblTotal.Name = "LblTotal"
        Me.LblTotal.Size = New System.Drawing.Size(72, 20)
        Me.LblTotal.TabIndex = 8
        Me.LblTotal.Text = "TOTAL : "
        '
        'LblPagoCon
        '
        Me.LblPagoCon.AutoSize = True
        Me.LblPagoCon.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPagoCon.ForeColor = System.Drawing.SystemColors.Highlight
        Me.LblPagoCon.Location = New System.Drawing.Point(727, 61)
        Me.LblPagoCon.Name = "LblPagoCon"
        Me.LblPagoCon.Size = New System.Drawing.Size(85, 15)
        Me.LblPagoCon.TabIndex = 9
        Me.LblPagoCon.Text = "PAGO CON :"
        '
        'LblCambio
        '
        Me.LblCambio.AutoSize = True
        Me.LblCambio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCambio.ForeColor = System.Drawing.SystemColors.Highlight
        Me.LblCambio.Location = New System.Drawing.Point(663, 124)
        Me.LblCambio.Name = "LblCambio"
        Me.LblCambio.Size = New System.Drawing.Size(71, 15)
        Me.LblCambio.TabIndex = 10
        Me.LblCambio.Text = "CAMBIO : "
        '
        'LblDTotal
        '
        Me.LblDTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDTotal.ForeColor = System.Drawing.Color.DarkGreen
        Me.LblDTotal.Location = New System.Drawing.Point(683, 244)
        Me.LblDTotal.Name = "LblDTotal"
        Me.LblDTotal.Size = New System.Drawing.Size(259, 85)
        Me.LblDTotal.TabIndex = 11
        Me.LblDTotal.Text = "0.00"
        Me.LblDTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblDCambio
        '
        Me.LblDCambio.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDCambio.ForeColor = System.Drawing.Color.DarkGreen
        Me.LblDCambio.Location = New System.Drawing.Point(718, 84)
        Me.LblDCambio.Name = "LblDCambio"
        Me.LblDCambio.Size = New System.Drawing.Size(188, 81)
        Me.LblDCambio.TabIndex = 13
        Me.LblDCambio.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'BtnCobro
        '
        Me.BtnCobro.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.BtnCobro.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCobro.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCobro.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.BtnCobro.Location = New System.Drawing.Point(707, 101)
        Me.BtnCobro.Name = "BtnCobro"
        Me.BtnCobro.Size = New System.Drawing.Size(205, 91)
        Me.BtnCobro.TabIndex = 14
        Me.BtnCobro.Text = "F12 - COBRAR"
        Me.BtnCobro.UseVisualStyleBackColor = False
        '
        'BtnBorrar
        '
        Me.BtnBorrar.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.BtnBorrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBorrar.ForeColor = System.Drawing.SystemColors.Highlight
        Me.BtnBorrar.Location = New System.Drawing.Point(502, 16)
        Me.BtnBorrar.Name = "BtnBorrar"
        Me.BtnBorrar.Size = New System.Drawing.Size(205, 28)
        Me.BtnBorrar.TabIndex = 15
        Me.BtnBorrar.Text = "DEL- Borrar Art."
        Me.BtnBorrar.UseVisualStyleBackColor = False
        '
        'TxtPago
        '
        Me.TxtPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPago.ForeColor = System.Drawing.Color.DarkGreen
        Me.TxtPago.Location = New System.Drawing.Point(818, 54)
        Me.TxtPago.Name = "TxtPago"
        Me.TxtPago.Size = New System.Drawing.Size(82, 22)
        Me.TxtPago.TabIndex = 17
        Me.TxtPago.Text = "0.00"
        Me.TxtPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.BtnHistorial)
        Me.GroupBox1.Controls.Add(Me.NudTC)
        Me.GroupBox1.Controls.Add(Me.NuDEfe)
        Me.GroupBox1.Controls.Add(Me.BtnBorrar)
        Me.GroupBox1.Controls.Add(Me.LblMixTc)
        Me.GroupBox1.Controls.Add(Me.lblMixEfe)
        Me.GroupBox1.Controls.Add(Me.PictureBox5)
        Me.GroupBox1.Controls.Add(Me.LblCantPro)
        Me.GroupBox1.Controls.Add(Me.RBTransfer)
        Me.GroupBox1.Controls.Add(Me.PictureBox4)
        Me.GroupBox1.Controls.Add(Me.TxtPago)
        Me.GroupBox1.Controls.Add(Me.RBMixto)
        Me.GroupBox1.Controls.Add(Me.LblCantidad)
        Me.GroupBox1.Controls.Add(Me.RBDebito)
        Me.GroupBox1.Controls.Add(Me.LblPagoCon)
        Me.GroupBox1.Controls.Add(Me.PictureBox2)
        Me.GroupBox1.Controls.Add(Me.PictureBox3)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Controls.Add(Me.LblDCambio)
        Me.GroupBox1.Controls.Add(Me.RBCredito)
        Me.GroupBox1.Controls.Add(Me.LblCambio)
        Me.GroupBox1.Controls.Add(Me.RbEfectivo)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.Highlight
        Me.GroupBox1.Location = New System.Drawing.Point(0, 351)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(923, 181)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Resumen Ventas "
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Button1.Location = New System.Drawing.Point(283, 16)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(205, 28)
        Me.Button1.TabIndex = 35
        Me.Button1.Text = "Mod. Cantidad. Art"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'BtnHistorial
        '
        Me.BtnHistorial.Location = New System.Drawing.Point(713, 14)
        Me.BtnHistorial.Name = "BtnHistorial"
        Me.BtnHistorial.Size = New System.Drawing.Size(199, 30)
        Me.BtnHistorial.TabIndex = 8
        Me.BtnHistorial.Text = "Historial de Tickets"
        Me.BtnHistorial.UseVisualStyleBackColor = True
        '
        'NudTC
        '
        Me.NudTC.DecimalPlaces = 2
        Me.NudTC.ForeColor = System.Drawing.Color.DarkGreen
        Me.NudTC.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.NudTC.Location = New System.Drawing.Point(584, 144)
        Me.NudTC.Name = "NudTC"
        Me.NudTC.Size = New System.Drawing.Size(68, 22)
        Me.NudTC.TabIndex = 33
        Me.NudTC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'NuDEfe
        '
        Me.NuDEfe.DecimalPlaces = 2
        Me.NuDEfe.ForeColor = System.Drawing.Color.DarkGreen
        Me.NuDEfe.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.NuDEfe.Location = New System.Drawing.Point(584, 92)
        Me.NuDEfe.Name = "NuDEfe"
        Me.NuDEfe.Size = New System.Drawing.Size(68, 22)
        Me.NuDEfe.TabIndex = 32
        Me.NuDEfe.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblMixTc
        '
        Me.LblMixTc.AutoSize = True
        Me.LblMixTc.Location = New System.Drawing.Point(581, 123)
        Me.LblMixTc.Name = "LblMixTc"
        Me.LblMixTc.Size = New System.Drawing.Size(58, 16)
        Me.LblMixTc.TabIndex = 31
        Me.LblMixTc.Text = "MixT.C."
        '
        'lblMixEfe
        '
        Me.lblMixEfe.AutoSize = True
        Me.lblMixEfe.Location = New System.Drawing.Point(581, 73)
        Me.lblMixEfe.Name = "lblMixEfe"
        Me.lblMixEfe.Size = New System.Drawing.Size(61, 16)
        Me.lblMixEfe.TabIndex = 30
        Me.lblMixEfe.Text = "MixEfec"
        Me.lblMixEfe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = Global.AcFishhouse.My.Resources.Resources.simbolos
        Me.PictureBox5.Location = New System.Drawing.Point(395, 83)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(68, 43)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox5.TabIndex = 29
        Me.PictureBox5.TabStop = False
        '
        'RBTransfer
        '
        Me.RBTransfer.Appearance = System.Windows.Forms.Appearance.Button
        Me.RBTransfer.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack
        Me.RBTransfer.FlatAppearance.BorderSize = 3
        Me.RBTransfer.FlatAppearance.CheckedBackColor = System.Drawing.Color.DarkGreen
        Me.RBTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RBTransfer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RBTransfer.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RBTransfer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.RBTransfer.Location = New System.Drawing.Point(377, 134)
        Me.RBTransfer.Name = "RBTransfer"
        Me.RBTransfer.Size = New System.Drawing.Size(100, 31)
        Me.RBTransfer.TabIndex = 5
        Me.RBTransfer.TabStop = True
        Me.RBTransfer.Text = "TRANSFER"
        Me.RBTransfer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.RBTransfer.UseVisualStyleBackColor = True
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = Global.AcFishhouse.My.Resources.Resources.movil
        Me.PictureBox4.Location = New System.Drawing.Point(495, 83)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(70, 43)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox4.TabIndex = 27
        Me.PictureBox4.TabStop = False
        '
        'RBMixto
        '
        Me.RBMixto.Appearance = System.Windows.Forms.Appearance.Button
        Me.RBMixto.FlatAppearance.BorderColor = System.Drawing.SystemColors.MenuHighlight
        Me.RBMixto.FlatAppearance.BorderSize = 3
        Me.RBMixto.FlatAppearance.CheckedBackColor = System.Drawing.Color.DarkGreen
        Me.RBMixto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RBMixto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RBMixto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RBMixto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.RBMixto.Location = New System.Drawing.Point(497, 134)
        Me.RBMixto.Name = "RBMixto"
        Me.RBMixto.Size = New System.Drawing.Size(68, 31)
        Me.RBMixto.TabIndex = 6
        Me.RBMixto.TabStop = True
        Me.RBMixto.Text = "MIXTO"
        Me.RBMixto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.RBMixto.UseVisualStyleBackColor = True
        '
        'RBDebito
        '
        Me.RBDebito.Appearance = System.Windows.Forms.Appearance.Button
        Me.RBDebito.AutoSize = True
        Me.RBDebito.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack
        Me.RBDebito.FlatAppearance.BorderSize = 3
        Me.RBDebito.FlatAppearance.CheckedBackColor = System.Drawing.Color.DarkGreen
        Me.RBDebito.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RBDebito.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RBDebito.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RBDebito.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.RBDebito.Location = New System.Drawing.Point(274, 134)
        Me.RBDebito.Name = "RBDebito"
        Me.RBDebito.Size = New System.Drawing.Size(85, 31)
        Me.RBDebito.TabIndex = 5
        Me.RBDebito.TabStop = True
        Me.RBDebito.Text = "T.DEBITO"
        Me.RBDebito.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.RBDebito.UseVisualStyleBackColor = True
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.AcFishhouse.My.Resources.Resources.tarjeta_de_debito
        Me.PictureBox2.Location = New System.Drawing.Point(185, 85)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(66, 43)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 23
        Me.PictureBox2.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.AcFishhouse.My.Resources.Resources.visa
        Me.PictureBox3.Location = New System.Drawing.Point(283, 83)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(67, 43)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 25
        Me.PictureBox3.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.AcFishhouse.My.Resources.Resources.cASH
        Me.PictureBox1.Location = New System.Drawing.Point(68, 83)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(88, 45)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 22
        Me.PictureBox1.TabStop = False
        '
        'RBCredito
        '
        Me.RBCredito.Appearance = System.Windows.Forms.Appearance.Button
        Me.RBCredito.AutoSize = True
        Me.RBCredito.FlatAppearance.BorderColor = System.Drawing.SystemColors.MenuHighlight
        Me.RBCredito.FlatAppearance.BorderSize = 3
        Me.RBCredito.FlatAppearance.CheckedBackColor = System.Drawing.Color.DarkGreen
        Me.RBCredito.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RBCredito.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RBCredito.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RBCredito.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.RBCredito.Location = New System.Drawing.Point(170, 134)
        Me.RBCredito.Name = "RBCredito"
        Me.RBCredito.Size = New System.Drawing.Size(95, 31)
        Me.RBCredito.TabIndex = 4
        Me.RBCredito.TabStop = True
        Me.RBCredito.Text = "T.CREDITO"
        Me.RBCredito.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.RBCredito.UseVisualStyleBackColor = True
        '
        'RbEfectivo
        '
        Me.RbEfectivo.Appearance = System.Windows.Forms.Appearance.Button
        Me.RbEfectivo.AutoSize = True
        Me.RbEfectivo.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack
        Me.RbEfectivo.FlatAppearance.BorderSize = 3
        Me.RbEfectivo.FlatAppearance.CheckedBackColor = System.Drawing.Color.DarkGreen
        Me.RbEfectivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RbEfectivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbEfectivo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RbEfectivo.Location = New System.Drawing.Point(68, 134)
        Me.RbEfectivo.Name = "RbEfectivo"
        Me.RbEfectivo.Size = New System.Drawing.Size(88, 31)
        Me.RbEfectivo.TabIndex = 3
        Me.RbEfectivo.TabStop = True
        Me.RbEfectivo.Text = "EFECTIVO"
        Me.RbEfectivo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.RbEfectivo.UseVisualStyleBackColor = True
        '
        'cboProducto
        '
        Me.cboProducto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboProducto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cboProducto.FormattingEnabled = True
        Me.cboProducto.IntegralHeight = False
        Me.cboProducto.Location = New System.Drawing.Point(166, 75)
        Me.cboProducto.MaxDropDownItems = 15
        Me.cboProducto.Name = "cboProducto"
        Me.cboProducto.Size = New System.Drawing.Size(523, 21)
        Me.cboProducto.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label1.Location = New System.Drawing.Point(94, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(595, 23)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Venta - Ticket "
        '
        'VentasForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(968, 544)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboProducto)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BtnCobro)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.LblTotal)
        Me.Controls.Add(Me.BtnEnter)
        Me.Controls.Add(Me.LblDTotal)
        Me.Controls.Add(Me.LblCodigo)
        Me.Controls.Add(Me.Lblticket)
        Me.Controls.Add(Me.ToolStrip1)
        Me.KeyPreview = True
        Me.Name = "VentasForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ventas"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.NudTC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NuDEfe, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents tsbF3Producto As ToolStripButton
    Friend WithEvents Lblticket As Label
    Friend WithEvents LblCodigo As Label
    Friend WithEvents BtnEnter As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents LblCantPro As Label
    Friend WithEvents LblCantidad As Label
    Friend WithEvents LblTotal As Label
    Friend WithEvents LblPagoCon As Label
    Friend WithEvents LblCambio As Label
    Friend WithEvents LblDTotal As Label
    Friend WithEvents LblDCambio As Label
    Friend WithEvents BtnCobro As Button
    Friend WithEvents BtnBorrar As Button
    Friend WithEvents TxtPago As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cboProducto As ComboBox
    Friend WithEvents RBCredito As RadioButton
    Friend WithEvents RbEfectivo As RadioButton
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents RBDebito As RadioButton
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents RBMixto As RadioButton
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents RBTransfer As RadioButton
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents NuDEfe As NumericUpDown
    Friend WithEvents LblMixTc As Label
    Friend WithEvents lblMixEfe As Label
    Friend WithEvents NudTC As NumericUpDown
    Friend WithEvents BtnHistorial As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents IdProducto As DataGridViewTextBoxColumn
    Friend WithEvents CdBarras As DataGridViewTextBoxColumn
    Friend WithEvents DesProducto As DataGridViewTextBoxColumn
    Friend WithEvents PreVenta As DataGridViewTextBoxColumn
    Friend WithEvents Cantidad As DataGridViewTextBoxColumn
    Friend WithEvents ImporteVen As DataGridViewTextBoxColumn
    Friend WithEvents Existencia As DataGridViewTextBoxColumn
    Friend WithEvents TlSBtnVerifica As ToolStripButton
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents ToolStripLabel2 As ToolStripLabel
    Friend WithEvents Button1 As Button
End Class
