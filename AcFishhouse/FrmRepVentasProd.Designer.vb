<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmProductosVendidos
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lbltitulo = New System.Windows.Forms.Label()
        Me.lblMostrar = New System.Windows.Forms.Label()
        Me.LblDesde = New System.Windows.Forms.Label()
        Me.lblHasta = New System.Windows.Forms.Label()
        Me.CboPeriodo = New System.Windows.Forms.ComboBox()
        Me.dtpDesde = New System.Windows.Forms.DateTimePicker()
        Me.DtpHasta = New System.Windows.Forms.DateTimePicker()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.dgvResultados = New System.Windows.Forms.DataGridView()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.tsstotalVendidosLbl = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssTotalVend = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GrpTicketDia = New System.Windows.Forms.GroupBox()
        Me.dgvTicketsDia = New System.Windows.Forms.DataGridView()
        Me.grptop20 = New System.Windows.Forms.GroupBox()
        Me.dgvTop20 = New System.Windows.Forms.DataGridView()
        Me.btnLinkExportar = New System.Windows.Forms.LinkLabel()
        Me.LnkDash = New System.Windows.Forms.LinkLabel()
        CType(Me.dgvResultados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip.SuspendLayout()
        Me.GrpTicketDia.SuspendLayout()
        CType(Me.dgvTicketsDia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grptop20.SuspendLayout()
        CType(Me.dgvTop20, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbltitulo
        '
        Me.lbltitulo.AutoSize = True
        Me.lbltitulo.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltitulo.ForeColor = System.Drawing.SystemColors.Highlight
        Me.lbltitulo.Location = New System.Drawing.Point(358, 33)
        Me.lbltitulo.Name = "lbltitulo"
        Me.lbltitulo.Size = New System.Drawing.Size(281, 21)
        Me.lbltitulo.TabIndex = 0
        Me.lbltitulo.Text = "REPORTE DE PRODUCTOS VENDIDOS "
        Me.lbltitulo.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblMostrar
        '
        Me.lblMostrar.AutoSize = True
        Me.lblMostrar.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMostrar.ForeColor = System.Drawing.SystemColors.Highlight
        Me.lblMostrar.Location = New System.Drawing.Point(136, 75)
        Me.lblMostrar.Name = "lblMostrar"
        Me.lblMostrar.Size = New System.Drawing.Size(211, 21)
        Me.lblMostrar.TabIndex = 1
        Me.lblMostrar.Text = "MOSTRAR VENTAS DESDE : "
        Me.lblMostrar.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LblDesde
        '
        Me.LblDesde.AutoSize = True
        Me.LblDesde.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDesde.ForeColor = System.Drawing.SystemColors.Highlight
        Me.LblDesde.Location = New System.Drawing.Point(358, 75)
        Me.LblDesde.Name = "LblDesde"
        Me.LblDesde.Size = New System.Drawing.Size(85, 21)
        Me.LblDesde.TabIndex = 2
        Me.LblDesde.Text = "Desde el : "
        Me.LblDesde.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblHasta
        '
        Me.lblHasta.AutoSize = True
        Me.lblHasta.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHasta.ForeColor = System.Drawing.SystemColors.Highlight
        Me.lblHasta.Location = New System.Drawing.Point(516, 77)
        Me.lblHasta.Name = "lblHasta"
        Me.lblHasta.Size = New System.Drawing.Size(76, 21)
        Me.lblHasta.TabIndex = 3
        Me.lblHasta.Text = "Hasta el :"
        Me.lblHasta.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'CboPeriodo
        '
        Me.CboPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboPeriodo.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboPeriodo.FormattingEnabled = True
        Me.CboPeriodo.Location = New System.Drawing.Point(140, 100)
        Me.CboPeriodo.Name = "CboPeriodo"
        Me.CboPeriodo.Size = New System.Drawing.Size(207, 23)
        Me.CboPeriodo.TabIndex = 4
        '
        'dtpDesde
        '
        Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDesde.Location = New System.Drawing.Point(362, 101)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(152, 20)
        Me.dtpDesde.TabIndex = 5
        '
        'DtpHasta
        '
        Me.DtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpHasta.Location = New System.Drawing.Point(520, 101)
        Me.DtpHasta.Name = "DtpHasta"
        Me.DtpHasta.Size = New System.Drawing.Size(152, 20)
        Me.DtpHasta.TabIndex = 6
        '
        'btnConsultar
        '
        Me.btnConsultar.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConsultar.ForeColor = System.Drawing.SystemColors.Highlight
        Me.btnConsultar.Location = New System.Drawing.Point(703, 92)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(86, 29)
        Me.btnConsultar.TabIndex = 7
        Me.btnConsultar.Text = "Consultar"
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'dgvResultados
        '
        Me.dgvResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvResultados.Location = New System.Drawing.Point(26, 143)
        Me.dgvResultados.Name = "dgvResultados"
        Me.dgvResultados.Size = New System.Drawing.Size(988, 328)
        Me.dgvResultados.TabIndex = 8
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsstotalVendidosLbl, Me.tssTotalVend})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 829)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(1039, 30)
        Me.StatusStrip.TabIndex = 9
        Me.StatusStrip.Text = "StatusStrip1"
        '
        'tsstotalVendidosLbl
        '
        Me.tsstotalVendidosLbl.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsstotalVendidosLbl.ForeColor = System.Drawing.SystemColors.Highlight
        Me.tsstotalVendidosLbl.Name = "tsstotalVendidosLbl"
        Me.tsstotalVendidosLbl.Size = New System.Drawing.Size(150, 25)
        Me.tsstotalVendidosLbl.Text = "Total Vendido : "
        '
        'tssTotalVend
        '
        Me.tssTotalVend.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tssTotalVend.ForeColor = System.Drawing.Color.DarkOliveGreen
        Me.tssTotalVend.Name = "tssTotalVend"
        Me.tssTotalVend.Size = New System.Drawing.Size(176, 25)
        Me.tssTotalVend.Text = "ToolStripStatusLabel1"
        '
        'GrpTicketDia
        '
        Me.GrpTicketDia.Controls.Add(Me.dgvTicketsDia)
        Me.GrpTicketDia.Font = New System.Drawing.Font("Segoe UI Black", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpTicketDia.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.GrpTicketDia.Location = New System.Drawing.Point(26, 503)
        Me.GrpTicketDia.Name = "GrpTicketDia"
        Me.GrpTicketDia.Size = New System.Drawing.Size(303, 323)
        Me.GrpTicketDia.TabIndex = 10
        Me.GrpTicketDia.TabStop = False
        Me.GrpTicketDia.Text = "Tickets Por Dia"
        '
        'dgvTicketsDia
        '
        Me.dgvTicketsDia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTicketsDia.Location = New System.Drawing.Point(6, 24)
        Me.dgvTicketsDia.Name = "dgvTicketsDia"
        Me.dgvTicketsDia.Size = New System.Drawing.Size(283, 293)
        Me.dgvTicketsDia.TabIndex = 11
        '
        'grptop20
        '
        Me.grptop20.Controls.Add(Me.dgvTop20)
        Me.grptop20.Font = New System.Drawing.Font("Segoe UI Black", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grptop20.ForeColor = System.Drawing.SystemColors.Highlight
        Me.grptop20.Location = New System.Drawing.Point(335, 503)
        Me.grptop20.Name = "grptop20"
        Me.grptop20.Size = New System.Drawing.Size(692, 323)
        Me.grptop20.TabIndex = 0
        Me.grptop20.TabStop = False
        Me.grptop20.Text = "Top 20 Productos"
        '
        'dgvTop20
        '
        Me.dgvTop20.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTop20.Location = New System.Drawing.Point(3, 24)
        Me.dgvTop20.Name = "dgvTop20"
        Me.dgvTop20.Size = New System.Drawing.Size(670, 293)
        Me.dgvTop20.TabIndex = 0
        '
        'btnLinkExportar
        '
        Me.btnLinkExportar.AutoSize = True
        Me.btnLinkExportar.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLinkExportar.ForeColor = System.Drawing.SystemColors.Highlight
        Me.btnLinkExportar.Location = New System.Drawing.Point(804, 51)
        Me.btnLinkExportar.Name = "btnLinkExportar"
        Me.btnLinkExportar.Size = New System.Drawing.Size(105, 17)
        Me.btnLinkExportar.TabIndex = 11
        Me.btnLinkExportar.TabStop = True
        Me.btnLinkExportar.Text = "Exportar a Excel"
        '
        'LnkDash
        '
        Me.LnkDash.AutoSize = True
        Me.LnkDash.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LnkDash.ForeColor = System.Drawing.SystemColors.Highlight
        Me.LnkDash.Location = New System.Drawing.Point(808, 92)
        Me.LnkDash.Name = "LnkDash"
        Me.LnkDash.Size = New System.Drawing.Size(101, 17)
        Me.LnkDash.TabIndex = 12
        Me.LnkDash.TabStop = True
        Me.LnkDash.Text = "Ir al DashBoard"
        '
        'FrmProductosVendidos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1039, 859)
        Me.Controls.Add(Me.LnkDash)
        Me.Controls.Add(Me.btnLinkExportar)
        Me.Controls.Add(Me.grptop20)
        Me.Controls.Add(Me.GrpTicketDia)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.dgvResultados)
        Me.Controls.Add(Me.btnConsultar)
        Me.Controls.Add(Me.DtpHasta)
        Me.Controls.Add(Me.dtpDesde)
        Me.Controls.Add(Me.CboPeriodo)
        Me.Controls.Add(Me.lblHasta)
        Me.Controls.Add(Me.LblDesde)
        Me.Controls.Add(Me.lblMostrar)
        Me.Controls.Add(Me.lbltitulo)
        Me.Name = "FrmProductosVendidos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REPORTE VENTAS POR PRODUCTO"
        CType(Me.dgvResultados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.GrpTicketDia.ResumeLayout(False)
        CType(Me.dgvTicketsDia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grptop20.ResumeLayout(False)
        CType(Me.dgvTop20, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbltitulo As Label
    Friend WithEvents lblMostrar As Label
    Friend WithEvents LblDesde As Label
    Friend WithEvents lblHasta As Label
    Friend WithEvents CboPeriodo As ComboBox
    Friend WithEvents dtpDesde As DateTimePicker
    Friend WithEvents DtpHasta As DateTimePicker
    Friend WithEvents btnConsultar As Button
    Friend WithEvents dgvResultados As DataGridView
    Friend WithEvents StatusStrip As StatusStrip
    Friend WithEvents tsstotalVendidosLbl As ToolStripStatusLabel
    Friend WithEvents tssTotalVend As ToolStripStatusLabel
    Friend WithEvents GrpTicketDia As GroupBox
    Friend WithEvents grptop20 As GroupBox
    Friend WithEvents dgvTicketsDia As DataGridView
    Friend WithEvents dgvTop20 As DataGridView
    Friend WithEvents btnLinkExportar As LinkLabel
    Friend WithEvents LnkDash As LinkLabel
End Class
