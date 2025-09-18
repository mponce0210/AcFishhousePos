<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class mainForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(mainForm))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.CATALOGOSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MARCASToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VentasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InventarioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.INVENTARIOFISHHOUSEToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BIOTROPICToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IMPORTARXLSBIOTROPICToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CORTESCAJAToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.APERTURACAJAToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DINEROENCAJAToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VENTANASToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.REPORTESToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.REPPRODVENDIDOSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IMPRESIONESToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TICKETToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ACERCADEToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VERSIONPOSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbExit = New System.Windows.Forms.ToolStripButton()
        Me.tsbPrint = New System.Windows.Forms.ToolStripButton()
        Me.tsbExportExcel = New System.Windows.Forms.ToolStripButton()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tssCaja = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssUsuario = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssTerminal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssObs = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssUltAct = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssAfirme = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssRiesgo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.PIZARRONFISHHOUSEToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CATALOGOSToolStripMenuItem, Me.VentasToolStripMenuItem, Me.InventarioToolStripMenuItem, Me.CORTESCAJAToolStripMenuItem, Me.VENTANASToolStripMenuItem, Me.REPORTESToolStripMenuItem, Me.IMPRESIONESToolStripMenuItem, Me.ACERCADEToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.MdiWindowListItem = Me.VENTANASToolStripMenuItem
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(972, 24)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'CATALOGOSToolStripMenuItem
        '
        Me.CATALOGOSToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MARCASToolStripMenuItem})
        Me.CATALOGOSToolStripMenuItem.Name = "CATALOGOSToolStripMenuItem"
        Me.CATALOGOSToolStripMenuItem.Size = New System.Drawing.Size(85, 20)
        Me.CATALOGOSToolStripMenuItem.Text = "CATALOGOS"
        '
        'MARCASToolStripMenuItem
        '
        Me.MARCASToolStripMenuItem.Name = "MARCASToolStripMenuItem"
        Me.MARCASToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.MARCASToolStripMenuItem.Text = "MARCAS"
        '
        'VentasToolStripMenuItem
        '
        Me.VentasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PToolStripMenuItem})
        Me.VentasToolStripMenuItem.Name = "VentasToolStripMenuItem"
        Me.VentasToolStripMenuItem.Size = New System.Drawing.Size(112, 20)
        Me.VentasToolStripMenuItem.Text = "PUNTO DE VENTA"
        '
        'PToolStripMenuItem
        '
        Me.PToolStripMenuItem.Name = "PToolStripMenuItem"
        Me.PToolStripMenuItem.Size = New System.Drawing.Size(115, 22)
        Me.PToolStripMenuItem.Text = "VENTAS"
        '
        'InventarioToolStripMenuItem
        '
        Me.InventarioToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.INVENTARIOFISHHOUSEToolStripMenuItem, Me.BIOTROPICToolStripMenuItem, Me.IMPORTARXLSBIOTROPICToolStripMenuItem})
        Me.InventarioToolStripMenuItem.Name = "InventarioToolStripMenuItem"
        Me.InventarioToolStripMenuItem.Size = New System.Drawing.Size(85, 20)
        Me.InventarioToolStripMenuItem.Text = "INVENTARIO"
        '
        'INVENTARIOFISHHOUSEToolStripMenuItem
        '
        Me.INVENTARIOFISHHOUSEToolStripMenuItem.Name = "INVENTARIOFISHHOUSEToolStripMenuItem"
        Me.INVENTARIOFISHHOUSEToolStripMenuItem.Size = New System.Drawing.Size(213, 22)
        Me.INVENTARIOFISHHOUSEToolStripMenuItem.Text = "INVENTARIO FISH HOUSE"
        '
        'BIOTROPICToolStripMenuItem
        '
        Me.BIOTROPICToolStripMenuItem.Name = "BIOTROPICToolStripMenuItem"
        Me.BIOTROPICToolStripMenuItem.Size = New System.Drawing.Size(213, 22)
        Me.BIOTROPICToolStripMenuItem.Text = "BIOTROPIC"
        '
        'IMPORTARXLSBIOTROPICToolStripMenuItem
        '
        Me.IMPORTARXLSBIOTROPICToolStripMenuItem.Name = "IMPORTARXLSBIOTROPICToolStripMenuItem"
        Me.IMPORTARXLSBIOTROPICToolStripMenuItem.Size = New System.Drawing.Size(213, 22)
        Me.IMPORTARXLSBIOTROPICToolStripMenuItem.Text = "IMPORTAR XLS BIOTROPIC"
        '
        'CORTESCAJAToolStripMenuItem
        '
        Me.CORTESCAJAToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.APERTURACAJAToolStripMenuItem, Me.DINEROENCAJAToolStripMenuItem})
        Me.CORTESCAJAToolStripMenuItem.Name = "CORTESCAJAToolStripMenuItem"
        Me.CORTESCAJAToolStripMenuItem.Size = New System.Drawing.Size(92, 20)
        Me.CORTESCAJAToolStripMenuItem.Text = "CORTES CAJA"
        '
        'APERTURACAJAToolStripMenuItem
        '
        Me.APERTURACAJAToolStripMenuItem.Name = "APERTURACAJAToolStripMenuItem"
        Me.APERTURACAJAToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.APERTURACAJAToolStripMenuItem.Text = "APERTURA CAJA"
        '
        'DINEROENCAJAToolStripMenuItem
        '
        Me.DINEROENCAJAToolStripMenuItem.Name = "DINEROENCAJAToolStripMenuItem"
        Me.DINEROENCAJAToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.DINEROENCAJAToolStripMenuItem.Text = "DINERO EN CAJA"
        '
        'VENTANASToolStripMenuItem
        '
        Me.VENTANASToolStripMenuItem.Name = "VENTANASToolStripMenuItem"
        Me.VENTANASToolStripMenuItem.Size = New System.Drawing.Size(77, 20)
        Me.VENTANASToolStripMenuItem.Text = "VENTANAS"
        '
        'REPORTESToolStripMenuItem
        '
        Me.REPORTESToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.REPPRODVENDIDOSToolStripMenuItem, Me.PIZARRONFISHHOUSEToolStripMenuItem})
        Me.REPORTESToolStripMenuItem.Name = "REPORTESToolStripMenuItem"
        Me.REPORTESToolStripMenuItem.Size = New System.Drawing.Size(72, 20)
        Me.REPORTESToolStripMenuItem.Text = "REPORTES"
        '
        'REPPRODVENDIDOSToolStripMenuItem
        '
        Me.REPPRODVENDIDOSToolStripMenuItem.Name = "REPPRODVENDIDOSToolStripMenuItem"
        Me.REPPRODVENDIDOSToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.REPPRODVENDIDOSToolStripMenuItem.Text = "REP. PROD. VENDIDOS"
        '
        'IMPRESIONESToolStripMenuItem
        '
        Me.IMPRESIONESToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TICKETToolStripMenuItem})
        Me.IMPRESIONESToolStripMenuItem.Name = "IMPRESIONESToolStripMenuItem"
        Me.IMPRESIONESToolStripMenuItem.Size = New System.Drawing.Size(92, 20)
        Me.IMPRESIONESToolStripMenuItem.Text = "IMPRESIONES"
        '
        'TICKETToolStripMenuItem
        '
        Me.TICKETToolStripMenuItem.Name = "TICKETToolStripMenuItem"
        Me.TICKETToolStripMenuItem.Size = New System.Drawing.Size(110, 22)
        Me.TICKETToolStripMenuItem.Text = "TICKET"
        '
        'ACERCADEToolStripMenuItem
        '
        Me.ACERCADEToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VERSIONPOSToolStripMenuItem})
        Me.ACERCADEToolStripMenuItem.Name = "ACERCADEToolStripMenuItem"
        Me.ACERCADEToolStripMenuItem.Size = New System.Drawing.Size(90, 20)
        Me.ACERCADEToolStripMenuItem.Text = "ACERCA DE .."
        '
        'VERSIONPOSToolStripMenuItem
        '
        Me.VERSIONPOSToolStripMenuItem.Name = "VERSIONPOSToolStripMenuItem"
        Me.VERSIONPOSToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.VERSIONPOSToolStripMenuItem.Text = "VERSION POS"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbExit, Me.tsbPrint, Me.tsbExportExcel})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(972, 27)
        Me.ToolStrip1.TabIndex = 4
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbExit
        '
        Me.tsbExit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbExit.Image = CType(resources.GetObject("tsbExit.Image"), System.Drawing.Image)
        Me.tsbExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbExit.Name = "tsbExit"
        Me.tsbExit.Size = New System.Drawing.Size(24, 24)
        Me.tsbExit.Text = "SALIR"
        '
        'tsbPrint
        '
        Me.tsbPrint.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbPrint.Image = CType(resources.GetObject("tsbPrint.Image"), System.Drawing.Image)
        Me.tsbPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbPrint.Name = "tsbPrint"
        Me.tsbPrint.Size = New System.Drawing.Size(24, 24)
        Me.tsbPrint.Text = "Impimir"
        '
        'tsbExportExcel
        '
        Me.tsbExportExcel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbExportExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbExportExcel.Image = CType(resources.GetObject("tsbExportExcel.Image"), System.Drawing.Image)
        Me.tsbExportExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbExportExcel.Name = "tsbExportExcel"
        Me.tsbExportExcel.Size = New System.Drawing.Size(24, 24)
        Me.tsbExportExcel.Text = "EXCEL"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssCaja, Me.tssUsuario, Me.tssTerminal, Me.tssObs, Me.tssUltAct, Me.tssAfirme, Me.tssRiesgo})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 613)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(972, 25)
        Me.StatusStrip1.TabIndex = 6
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tssCaja
        '
        Me.tssCaja.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tssCaja.Name = "tssCaja"
        Me.tssCaja.Size = New System.Drawing.Size(162, 20)
        Me.tssCaja.Text = "ToolStripStatusLabel1"
        '
        'tssUsuario
        '
        Me.tssUsuario.ForeColor = System.Drawing.SystemColors.Highlight
        Me.tssUsuario.Name = "tssUsuario"
        Me.tssUsuario.Size = New System.Drawing.Size(119, 20)
        Me.tssUsuario.Text = "ToolStripStatusLabel1"
        '
        'tssTerminal
        '
        Me.tssTerminal.Name = "tssTerminal"
        Me.tssTerminal.Size = New System.Drawing.Size(119, 20)
        Me.tssTerminal.Text = "ToolStripStatusLabel1"
        '
        'tssObs
        '
        Me.tssObs.Name = "tssObs"
        Me.tssObs.Size = New System.Drawing.Size(119, 20)
        Me.tssObs.Text = "ToolStripStatusLabel1"
        '
        'tssUltAct
        '
        Me.tssUltAct.Name = "tssUltAct"
        Me.tssUltAct.Size = New System.Drawing.Size(119, 20)
        Me.tssUltAct.Text = "ToolStripStatusLabel1"
        '
        'tssAfirme
        '
        Me.tssAfirme.Name = "tssAfirme"
        Me.tssAfirme.Size = New System.Drawing.Size(119, 20)
        Me.tssAfirme.Text = "ToolStripStatusLabel1"
        '
        'tssRiesgo
        '
        Me.tssRiesgo.Name = "tssRiesgo"
        Me.tssRiesgo.Size = New System.Drawing.Size(119, 20)
        Me.tssRiesgo.Text = "ToolStripStatusLabel1"
        '
        'PIZARRONFISHHOUSEToolStripMenuItem
        '
        Me.PIZARRONFISHHOUSEToolStripMenuItem.Name = "PIZARRONFISHHOUSEToolStripMenuItem"
        Me.PIZARRONFISHHOUSEToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.PIZARRONFISHHOUSEToolStripMenuItem.Text = "PIZARRON FISH HOUSE"
        '
        'mainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Menu
        Me.BackgroundImage = Global.AcFishhouse.My.Resources.Resources.removebg2
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(972, 638)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "mainForm"
        Me.Text = "ACUARIO FISH HOUSE "
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents VentasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InventarioToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents INVENTARIOFISHHOUSEToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents IMPRESIONESToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TICKETToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BIOTROPICToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents tsbExportExcel As ToolStripButton
    Friend WithEvents tsbPrint As ToolStripButton
    Friend WithEvents tsbExit As ToolStripButton
    Friend WithEvents VENTANASToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CORTESCAJAToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DINEROENCAJAToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents APERTURACAJAToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents tssUsuario As ToolStripStatusLabel
    Friend WithEvents tssTerminal As ToolStripStatusLabel
    Friend WithEvents tssObs As ToolStripStatusLabel
    Friend WithEvents tssCaja As ToolStripStatusLabel
    Friend WithEvents tssUltAct As ToolStripStatusLabel
    Friend WithEvents tssAfirme As ToolStripStatusLabel
    Friend WithEvents tssRiesgo As ToolStripStatusLabel
    Friend WithEvents IMPORTARXLSBIOTROPICToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ACERCADEToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VERSIONPOSToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents REPORTESToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents REPPRODVENDIDOSToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CATALOGOSToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MARCASToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PIZARRONFISHHOUSEToolStripMenuItem As ToolStripMenuItem
End Class
