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
        Me.VentasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InventarioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.INVENTARIOFISHHOUSEToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BIOTROPICToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VENTANASToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IMPRESIONESToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TICKETToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbExit = New System.Windows.Forms.ToolStripButton()
        Me.tsbPrint = New System.Windows.Forms.ToolStripButton()
        Me.tsbExportExcel = New System.Windows.Forms.ToolStripButton()
        Me.MenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VentasToolStripMenuItem, Me.InventarioToolStripMenuItem, Me.VENTANASToolStripMenuItem, Me.IMPRESIONESToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.MdiWindowListItem = Me.VENTANASToolStripMenuItem
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(972, 24)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
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
        Me.InventarioToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.INVENTARIOFISHHOUSEToolStripMenuItem, Me.BIOTROPICToolStripMenuItem})
        Me.InventarioToolStripMenuItem.Name = "InventarioToolStripMenuItem"
        Me.InventarioToolStripMenuItem.Size = New System.Drawing.Size(85, 20)
        Me.InventarioToolStripMenuItem.Text = "INVENTARIO"
        '
        'INVENTARIOFISHHOUSEToolStripMenuItem
        '
        Me.INVENTARIOFISHHOUSEToolStripMenuItem.Name = "INVENTARIOFISHHOUSEToolStripMenuItem"
        Me.INVENTARIOFISHHOUSEToolStripMenuItem.Size = New System.Drawing.Size(208, 22)
        Me.INVENTARIOFISHHOUSEToolStripMenuItem.Text = "INVENTARIO FISH HOUSE"
        '
        'BIOTROPICToolStripMenuItem
        '
        Me.BIOTROPICToolStripMenuItem.Name = "BIOTROPICToolStripMenuItem"
        Me.BIOTROPICToolStripMenuItem.Size = New System.Drawing.Size(208, 22)
        Me.BIOTROPICToolStripMenuItem.Text = "BIOTROPIC"
        '
        'VENTANASToolStripMenuItem
        '
        Me.VENTANASToolStripMenuItem.Name = "VENTANASToolStripMenuItem"
        Me.VENTANASToolStripMenuItem.Size = New System.Drawing.Size(77, 20)
        Me.VENTANASToolStripMenuItem.Text = "VENTANAS"
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
        'mainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Menu
        Me.BackgroundImage = Global.AcFishhouse.My.Resources.Resources.removebg2
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(972, 471)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.DoubleBuffered = True
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "mainForm"
        Me.Text = "ACUARIO FISH HOUSE "
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
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
End Class
