<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmHistorialVentas
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.LblHist = New System.Windows.Forms.Label()
        Me.ScHistorial = New System.Windows.Forms.SplitContainer()
        Me.pnlFiltroFEcha = New System.Windows.Forms.Panel()
        Me.BtnHoy = New System.Windows.Forms.Button()
        Me.DtpFiltro = New System.Windows.Forms.DateTimePicker()
        Me.LbldelDia = New System.Windows.Forms.Label()
        Me.DgvTickets = New System.Windows.Forms.DataGridView()
        Me.TxtBuscarTicket = New System.Windows.Forms.TextBox()
        Me.lblFiltro = New System.Windows.Forms.Label()
        Me.GbDetalleTicket = New System.Windows.Forms.GroupBox()
        Me.BtnEnviarWs = New System.Windows.Forms.Button()
        Me.TxtNumW = New System.Windows.Forms.TextBox()
        Me.LblTel = New System.Windows.Forms.Label()
        Me.BtnImprimir = New System.Windows.Forms.Button()
        Me.TxtTotal = New System.Windows.Forms.TextBox()
        Me.LblCambio = New System.Windows.Forms.Label()
        Me.TxtPagoConDetalle = New System.Windows.Forms.TextBox()
        Me.LblPagoCon = New System.Windows.Forms.Label()
        Me.DgvDetalle = New System.Windows.Forms.DataGridView()
        Me.lblFechaHora = New System.Windows.Forms.Label()
        Me.LblCliente = New System.Windows.Forms.Label()
        Me.lblfolioDetalle = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.ScHistorial, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ScHistorial.Panel1.SuspendLayout()
        Me.ScHistorial.Panel2.SuspendLayout()
        Me.ScHistorial.SuspendLayout()
        Me.pnlFiltroFEcha.SuspendLayout()
        CType(Me.DgvTickets, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GbDetalleTicket.SuspendLayout()
        CType(Me.DgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblHist
        '
        Me.LblHist.BackColor = System.Drawing.SystemColors.Highlight
        Me.LblHist.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblHist.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.LblHist.Location = New System.Drawing.Point(0, 0)
        Me.LblHist.Name = "LblHist"
        Me.LblHist.Size = New System.Drawing.Size(1012, 23)
        Me.LblHist.TabIndex = 0
        Me.LblHist.Text = "HISTORIAL DE VENTAS"
        '
        'ScHistorial
        '
        Me.ScHistorial.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.ScHistorial.Location = New System.Drawing.Point(4, 26)
        Me.ScHistorial.Name = "ScHistorial"
        '
        'ScHistorial.Panel1
        '
        Me.ScHistorial.Panel1.Controls.Add(Me.pnlFiltroFEcha)
        Me.ScHistorial.Panel1.Controls.Add(Me.DgvTickets)
        Me.ScHistorial.Panel1.Controls.Add(Me.TxtBuscarTicket)
        Me.ScHistorial.Panel1.Controls.Add(Me.lblFiltro)
        '
        'ScHistorial.Panel2
        '
        Me.ScHistorial.Panel2.Controls.Add(Me.GbDetalleTicket)
        Me.ScHistorial.Size = New System.Drawing.Size(1119, 365)
        Me.ScHistorial.SplitterDistance = 621
        Me.ScHistorial.TabIndex = 1
        '
        'pnlFiltroFEcha
        '
        Me.pnlFiltroFEcha.Controls.Add(Me.BtnHoy)
        Me.pnlFiltroFEcha.Controls.Add(Me.DtpFiltro)
        Me.pnlFiltroFEcha.Controls.Add(Me.LbldelDia)
        Me.pnlFiltroFEcha.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlFiltroFEcha.Location = New System.Drawing.Point(0, 304)
        Me.pnlFiltroFEcha.Name = "pnlFiltroFEcha"
        Me.pnlFiltroFEcha.Size = New System.Drawing.Size(617, 57)
        Me.pnlFiltroFEcha.TabIndex = 3
        '
        'BtnHoy
        '
        Me.BtnHoy.Location = New System.Drawing.Point(385, 13)
        Me.BtnHoy.Name = "BtnHoy"
        Me.BtnHoy.Size = New System.Drawing.Size(75, 23)
        Me.BtnHoy.TabIndex = 3
        Me.BtnHoy.Text = "Hoy"
        Me.BtnHoy.UseVisualStyleBackColor = True
        '
        'DtpFiltro
        '
        Me.DtpFiltro.Location = New System.Drawing.Point(69, 13)
        Me.DtpFiltro.Name = "DtpFiltro"
        Me.DtpFiltro.Size = New System.Drawing.Size(305, 20)
        Me.DtpFiltro.TabIndex = 2
        '
        'LbldelDia
        '
        Me.LbldelDia.AutoSize = True
        Me.LbldelDia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbldelDia.ForeColor = System.Drawing.SystemColors.Highlight
        Me.LbldelDia.Location = New System.Drawing.Point(8, 13)
        Me.LbldelDia.Name = "LbldelDia"
        Me.LbldelDia.Size = New System.Drawing.Size(55, 15)
        Me.LbldelDia.TabIndex = 2
        Me.LbldelDia.Text = "Del Dia"
        '
        'DgvTickets
        '
        Me.DgvTickets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvTickets.Location = New System.Drawing.Point(11, 35)
        Me.DgvTickets.Name = "DgvTickets"
        Me.DgvTickets.ReadOnly = True
        Me.DgvTickets.Size = New System.Drawing.Size(598, 263)
        Me.DgvTickets.TabIndex = 2
        '
        'TxtBuscarTicket
        '
        Me.TxtBuscarTicket.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtBuscarTicket.Location = New System.Drawing.Point(160, 9)
        Me.TxtBuscarTicket.Name = "TxtBuscarTicket"
        Me.TxtBuscarTicket.Size = New System.Drawing.Size(449, 20)
        Me.TxtBuscarTicket.TabIndex = 1
        '
        'lblFiltro
        '
        Me.lblFiltro.AutoSize = True
        Me.lblFiltro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFiltro.ForeColor = System.Drawing.SystemColors.Highlight
        Me.lblFiltro.Location = New System.Drawing.Point(8, 10)
        Me.lblFiltro.Name = "lblFiltro"
        Me.lblFiltro.Size = New System.Drawing.Size(112, 15)
        Me.lblFiltro.TabIndex = 0
        Me.lblFiltro.Text = "Buscar por folio "
        Me.lblFiltro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GbDetalleTicket
        '
        Me.GbDetalleTicket.Controls.Add(Me.PictureBox1)
        Me.GbDetalleTicket.Controls.Add(Me.BtnEnviarWs)
        Me.GbDetalleTicket.Controls.Add(Me.TxtNumW)
        Me.GbDetalleTicket.Controls.Add(Me.LblTel)
        Me.GbDetalleTicket.Controls.Add(Me.BtnImprimir)
        Me.GbDetalleTicket.Controls.Add(Me.TxtTotal)
        Me.GbDetalleTicket.Controls.Add(Me.LblCambio)
        Me.GbDetalleTicket.Controls.Add(Me.TxtPagoConDetalle)
        Me.GbDetalleTicket.Controls.Add(Me.LblPagoCon)
        Me.GbDetalleTicket.Controls.Add(Me.DgvDetalle)
        Me.GbDetalleTicket.Controls.Add(Me.lblFechaHora)
        Me.GbDetalleTicket.Controls.Add(Me.LblCliente)
        Me.GbDetalleTicket.Controls.Add(Me.lblfolioDetalle)
        Me.GbDetalleTicket.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbDetalleTicket.ForeColor = System.Drawing.SystemColors.Highlight
        Me.GbDetalleTicket.Location = New System.Drawing.Point(3, 3)
        Me.GbDetalleTicket.Name = "GbDetalleTicket"
        Me.GbDetalleTicket.Size = New System.Drawing.Size(471, 355)
        Me.GbDetalleTicket.TabIndex = 0
        Me.GbDetalleTicket.TabStop = False
        Me.GbDetalleTicket.Text = "Ticket {numero}"
        '
        'BtnEnviarWs
        '
        Me.BtnEnviarWs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEnviarWs.Location = New System.Drawing.Point(364, 25)
        Me.BtnEnviarWs.Name = "BtnEnviarWs"
        Me.BtnEnviarWs.Size = New System.Drawing.Size(91, 35)
        Me.BtnEnviarWs.TabIndex = 12
        Me.BtnEnviarWs.Text = "Enviar a Whts"
        Me.BtnEnviarWs.UseVisualStyleBackColor = True
        '
        'TxtNumW
        '
        Me.TxtNumW.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNumW.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.TxtNumW.Location = New System.Drawing.Point(250, 66)
        Me.TxtNumW.Name = "TxtNumW"
        Me.TxtNumW.Size = New System.Drawing.Size(101, 21)
        Me.TxtNumW.TabIndex = 11
        Me.TxtNumW.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TxtNumW.Visible = False
        '
        'LblTel
        '
        Me.LblTel.AutoSize = True
        Me.LblTel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTel.ForeColor = System.Drawing.SystemColors.Highlight
        Me.LblTel.Location = New System.Drawing.Point(257, 6)
        Me.LblTel.Name = "LblTel"
        Me.LblTel.Size = New System.Drawing.Size(67, 15)
        Me.LblTel.TabIndex = 10
        Me.LblTel.Text = "Telefono:"
        Me.LblTel.Visible = False
        '
        'BtnImprimir
        '
        Me.BtnImprimir.Location = New System.Drawing.Point(320, 303)
        Me.BtnImprimir.Name = "BtnImprimir"
        Me.BtnImprimir.Size = New System.Drawing.Size(145, 39)
        Me.BtnImprimir.TabIndex = 9
        Me.BtnImprimir.Text = "IMPRIMIR TKT"
        Me.BtnImprimir.UseVisualStyleBackColor = True
        '
        'TxtTotal
        '
        Me.TxtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotal.ForeColor = System.Drawing.Color.DarkGreen
        Me.TxtTotal.Location = New System.Drawing.Point(98, 329)
        Me.TxtTotal.Name = "TxtTotal"
        Me.TxtTotal.Size = New System.Drawing.Size(80, 21)
        Me.TxtTotal.TabIndex = 8
        Me.TxtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblCambio
        '
        Me.LblCambio.AutoSize = True
        Me.LblCambio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCambio.ForeColor = System.Drawing.SystemColors.Highlight
        Me.LblCambio.Location = New System.Drawing.Point(15, 324)
        Me.LblCambio.Name = "LblCambio"
        Me.LblCambio.Size = New System.Drawing.Size(47, 15)
        Me.LblCambio.TabIndex = 7
        Me.LblCambio.Text = "Total :"
        '
        'TxtPagoConDetalle
        '
        Me.TxtPagoConDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPagoConDetalle.Location = New System.Drawing.Point(98, 301)
        Me.TxtPagoConDetalle.Name = "TxtPagoConDetalle"
        Me.TxtPagoConDetalle.Size = New System.Drawing.Size(80, 18)
        Me.TxtPagoConDetalle.TabIndex = 6
        Me.TxtPagoConDetalle.Text = "N/A"
        Me.TxtPagoConDetalle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblPagoCon
        '
        Me.LblPagoCon.AutoSize = True
        Me.LblPagoCon.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPagoCon.ForeColor = System.Drawing.SystemColors.Highlight
        Me.LblPagoCon.Location = New System.Drawing.Point(15, 301)
        Me.LblPagoCon.Name = "LblPagoCon"
        Me.LblPagoCon.Size = New System.Drawing.Size(77, 15)
        Me.LblPagoCon.TabIndex = 5
        Me.LblPagoCon.Text = "Pago Con :"
        '
        'DgvDetalle
        '
        Me.DgvDetalle.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvDetalle.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvDetalle.DefaultCellStyle = DataGridViewCellStyle2
        Me.DgvDetalle.Location = New System.Drawing.Point(6, 89)
        Me.DgvDetalle.Name = "DgvDetalle"
        Me.DgvDetalle.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvDetalle.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvDetalle.Size = New System.Drawing.Size(459, 200)
        Me.DgvDetalle.TabIndex = 4
        '
        'lblFechaHora
        '
        Me.lblFechaHora.AutoSize = True
        Me.lblFechaHora.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaHora.ForeColor = System.Drawing.SystemColors.Highlight
        Me.lblFechaHora.Location = New System.Drawing.Point(15, 60)
        Me.lblFechaHora.Name = "lblFechaHora"
        Me.lblFechaHora.Size = New System.Drawing.Size(91, 15)
        Me.lblFechaHora.TabIndex = 3
        Me.lblFechaHora.Text = "Fecha y Hora"
        '
        'LblCliente
        '
        Me.LblCliente.AutoSize = True
        Me.LblCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCliente.ForeColor = System.Drawing.SystemColors.Highlight
        Me.LblCliente.Location = New System.Drawing.Point(15, 45)
        Me.LblCliente.Name = "LblCliente"
        Me.LblCliente.Size = New System.Drawing.Size(187, 15)
        Me.LblCliente.TabIndex = 2
        Me.LblCliente.Text = "Cliente : Publico en General"
        '
        'lblfolioDetalle
        '
        Me.lblfolioDetalle.AutoSize = True
        Me.lblfolioDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfolioDetalle.ForeColor = System.Drawing.SystemColors.Highlight
        Me.lblfolioDetalle.Location = New System.Drawing.Point(15, 30)
        Me.lblfolioDetalle.Name = "lblfolioDetalle"
        Me.lblfolioDetalle.Size = New System.Drawing.Size(87, 15)
        Me.lblfolioDetalle.TabIndex = 1
        Me.lblfolioDetalle.Text = "Folio: 00000"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = Global.AcFishhouse.My.Resources.Resources.whatsapp
        Me.PictureBox1.Location = New System.Drawing.Point(333, 32)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(18, 17)
        Me.PictureBox1.TabIndex = 13
        Me.PictureBox1.TabStop = False
        '
        'FrmHistorialVentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1129, 394)
        Me.Controls.Add(Me.ScHistorial)
        Me.Controls.Add(Me.LblHist)
        Me.Name = "FrmHistorialVentas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Historial de Ventas"
        Me.ScHistorial.Panel1.ResumeLayout(False)
        Me.ScHistorial.Panel1.PerformLayout()
        Me.ScHistorial.Panel2.ResumeLayout(False)
        CType(Me.ScHistorial, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ScHistorial.ResumeLayout(False)
        Me.pnlFiltroFEcha.ResumeLayout(False)
        Me.pnlFiltroFEcha.PerformLayout()
        CType(Me.DgvTickets, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GbDetalleTicket.ResumeLayout(False)
        Me.GbDetalleTicket.PerformLayout()
        CType(Me.DgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LblHist As Label
    Friend WithEvents ScHistorial As SplitContainer
    Friend WithEvents lblFiltro As Label
    Friend WithEvents TxtBuscarTicket As TextBox
    Friend WithEvents DgvTickets As DataGridView
    Friend WithEvents pnlFiltroFEcha As Panel
    Friend WithEvents DtpFiltro As DateTimePicker
    Friend WithEvents LbldelDia As Label
    Friend WithEvents BtnHoy As Button
    Friend WithEvents GbDetalleTicket As GroupBox
    Friend WithEvents DgvDetalle As DataGridView
    Friend WithEvents lblFechaHora As Label
    Friend WithEvents LblCliente As Label
    Friend WithEvents lblfolioDetalle As Label
    Friend WithEvents LblPagoCon As Label
    Friend WithEvents TxtTotal As TextBox
    Friend WithEvents LblCambio As Label
    Friend WithEvents TxtPagoConDetalle As TextBox
    Friend WithEvents BtnImprimir As Button
    Friend WithEvents TxtNumW As TextBox
    Friend WithEvents LblTel As Label
    Friend WithEvents BtnEnviarWs As Button
    Friend WithEvents PictureBox1 As PictureBox
End Class
