<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAperturaCaja
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAperturaCaja))
        Me.lbltitulo = New System.Windows.Forms.Label()
        Me.lblInfoUsuario = New System.Windows.Forms.Label()
        Me.GrpDatos = New System.Windows.Forms.GroupBox()
        Me.BtnCancelar = New System.Windows.Forms.Button()
        Me.BtnAbrir = New System.Windows.Forms.Button()
        Me.TxtObs = New System.Windows.Forms.TextBox()
        Me.LblObs = New System.Windows.Forms.Label()
        Me.nudMontoInicial = New System.Windows.Forms.NumericUpDown()
        Me.lblMonto = New System.Windows.Forms.Label()
        Me.DtpApertura = New System.Windows.Forms.DateTimePicker()
        Me.LblFecha = New System.Windows.Forms.Label()
        Me.TxtTerminal = New System.Windows.Forms.TextBox()
        Me.LblTerminal = New System.Windows.Forms.Label()
        Me.TxtUsuario = New System.Windows.Forms.TextBox()
        Me.LblUsuario = New System.Windows.Forms.Label()
        Me.LblmontoGrande = New System.Windows.Forms.Label()
        Me.GrpDatos.SuspendLayout()
        CType(Me.nudMontoInicial, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbltitulo
        '
        Me.lbltitulo.AutoSize = True
        Me.lbltitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.lbltitulo.Font = New System.Drawing.Font("Segoe UI", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltitulo.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lbltitulo.Location = New System.Drawing.Point(0, 0)
        Me.lbltitulo.Name = "lbltitulo"
        Me.lbltitulo.Size = New System.Drawing.Size(249, 40)
        Me.lbltitulo.TabIndex = 0
        Me.lbltitulo.Text = "Apertura de Caja"
        Me.lbltitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblInfoUsuario
        '
        Me.lblInfoUsuario.AutoSize = True
        Me.lblInfoUsuario.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblInfoUsuario.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfoUsuario.ForeColor = System.Drawing.SystemColors.GrayText
        Me.lblInfoUsuario.Location = New System.Drawing.Point(0, 40)
        Me.lblInfoUsuario.Name = "lblInfoUsuario"
        Me.lblInfoUsuario.Size = New System.Drawing.Size(105, 15)
        Me.lblInfoUsuario.TabIndex = 1
        Me.lblInfoUsuario.Text = "usuario x treminal "
        '
        'GrpDatos
        '
        Me.GrpDatos.Controls.Add(Me.BtnCancelar)
        Me.GrpDatos.Controls.Add(Me.BtnAbrir)
        Me.GrpDatos.Controls.Add(Me.TxtObs)
        Me.GrpDatos.Controls.Add(Me.LblObs)
        Me.GrpDatos.Controls.Add(Me.nudMontoInicial)
        Me.GrpDatos.Controls.Add(Me.lblMonto)
        Me.GrpDatos.Controls.Add(Me.DtpApertura)
        Me.GrpDatos.Controls.Add(Me.LblFecha)
        Me.GrpDatos.Controls.Add(Me.TxtTerminal)
        Me.GrpDatos.Controls.Add(Me.LblTerminal)
        Me.GrpDatos.Controls.Add(Me.TxtUsuario)
        Me.GrpDatos.Controls.Add(Me.LblUsuario)
        Me.GrpDatos.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpDatos.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.GrpDatos.Location = New System.Drawing.Point(3, 76)
        Me.GrpDatos.Name = "GrpDatos"
        Me.GrpDatos.Size = New System.Drawing.Size(411, 315)
        Me.GrpDatos.TabIndex = 2
        Me.GrpDatos.TabStop = False
        Me.GrpDatos.Text = "Datos de Apertura "
        '
        'BtnCancelar
        '
        Me.BtnCancelar.BackColor = System.Drawing.Color.LightGray
        Me.BtnCancelar.Location = New System.Drawing.Point(271, 270)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(120, 31)
        Me.BtnCancelar.TabIndex = 13
        Me.BtnCancelar.Text = "Esc - Cancelar"
        Me.BtnCancelar.UseVisualStyleBackColor = False
        '
        'BtnAbrir
        '
        Me.BtnAbrir.BackColor = System.Drawing.Color.LightGreen
        Me.BtnAbrir.Location = New System.Drawing.Point(13, 270)
        Me.BtnAbrir.Name = "BtnAbrir"
        Me.BtnAbrir.Size = New System.Drawing.Size(120, 31)
        Me.BtnAbrir.TabIndex = 12
        Me.BtnAbrir.Text = "F5 - Abrir Turno"
        Me.BtnAbrir.UseVisualStyleBackColor = False
        '
        'TxtObs
        '
        Me.TxtObs.Location = New System.Drawing.Point(13, 185)
        Me.TxtObs.Multiline = True
        Me.TxtObs.Name = "TxtObs"
        Me.TxtObs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtObs.Size = New System.Drawing.Size(378, 58)
        Me.TxtObs.TabIndex = 11
        Me.TxtObs.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblObs
        '
        Me.LblObs.AutoSize = True
        Me.LblObs.ForeColor = System.Drawing.SystemColors.GrayText
        Me.LblObs.Location = New System.Drawing.Point(9, 162)
        Me.LblObs.Name = "LblObs"
        Me.LblObs.Size = New System.Drawing.Size(109, 20)
        Me.LblObs.TabIndex = 10
        Me.LblObs.Text = "Observaciones"
        Me.LblObs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'nudMontoInicial
        '
        Me.nudMontoInicial.DecimalPlaces = 2
        Me.nudMontoInicial.Location = New System.Drawing.Point(253, 122)
        Me.nudMontoInicial.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.nudMontoInicial.Name = "nudMontoInicial"
        Me.nudMontoInicial.Size = New System.Drawing.Size(138, 27)
        Me.nudMontoInicial.TabIndex = 9
        Me.nudMontoInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudMontoInicial.ThousandsSeparator = True
        '
        'lblMonto
        '
        Me.lblMonto.AutoSize = True
        Me.lblMonto.ForeColor = System.Drawing.SystemColors.GrayText
        Me.lblMonto.Location = New System.Drawing.Point(249, 96)
        Me.lblMonto.Name = "lblMonto"
        Me.lblMonto.Size = New System.Drawing.Size(157, 20)
        Me.lblMonto.TabIndex = 8
        Me.lblMonto.Text = "Fondo / Monto Inicial"
        Me.lblMonto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DtpApertura
        '
        Me.DtpApertura.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpApertura.Location = New System.Drawing.Point(13, 119)
        Me.DtpApertura.Name = "DtpApertura"
        Me.DtpApertura.ShowUpDown = True
        Me.DtpApertura.Size = New System.Drawing.Size(191, 27)
        Me.DtpApertura.TabIndex = 8
        '
        'LblFecha
        '
        Me.LblFecha.AutoSize = True
        Me.LblFecha.ForeColor = System.Drawing.SystemColors.GrayText
        Me.LblFecha.Location = New System.Drawing.Point(9, 96)
        Me.LblFecha.Name = "LblFecha"
        Me.LblFecha.Size = New System.Drawing.Size(99, 20)
        Me.LblFecha.TabIndex = 7
        Me.LblFecha.Text = "Fecha y Hora"
        Me.LblFecha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtTerminal
        '
        Me.TxtTerminal.Location = New System.Drawing.Point(253, 57)
        Me.TxtTerminal.Name = "TxtTerminal"
        Me.TxtTerminal.ReadOnly = True
        Me.TxtTerminal.Size = New System.Drawing.Size(138, 27)
        Me.TxtTerminal.TabIndex = 6
        '
        'LblTerminal
        '
        Me.LblTerminal.AutoSize = True
        Me.LblTerminal.ForeColor = System.Drawing.SystemColors.GrayText
        Me.LblTerminal.Location = New System.Drawing.Point(249, 34)
        Me.LblTerminal.Name = "LblTerminal"
        Me.LblTerminal.Size = New System.Drawing.Size(72, 20)
        Me.LblTerminal.TabIndex = 5
        Me.LblTerminal.Text = "Terminal "
        Me.LblTerminal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtUsuario
        '
        Me.TxtUsuario.Location = New System.Drawing.Point(13, 57)
        Me.TxtUsuario.Name = "TxtUsuario"
        Me.TxtUsuario.Size = New System.Drawing.Size(191, 27)
        Me.TxtUsuario.TabIndex = 4
        Me.TxtUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblUsuario
        '
        Me.LblUsuario.AutoSize = True
        Me.LblUsuario.ForeColor = System.Drawing.SystemColors.GrayText
        Me.LblUsuario.Location = New System.Drawing.Point(9, 34)
        Me.LblUsuario.Name = "LblUsuario"
        Me.LblUsuario.Size = New System.Drawing.Size(70, 20)
        Me.LblUsuario.TabIndex = 3
        Me.LblUsuario.Text = "Usuario :"
        Me.LblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblmontoGrande
        '
        Me.LblmontoGrande.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblmontoGrande.ForeColor = System.Drawing.Color.ForestGreen
        Me.LblmontoGrande.Location = New System.Drawing.Point(278, 9)
        Me.LblmontoGrande.Name = "LblmontoGrande"
        Me.LblmontoGrande.Size = New System.Drawing.Size(145, 31)
        Me.LblmontoGrande.TabIndex = 14
        Me.LblmontoGrande.Text = "Monto"
        Me.LblmontoGrande.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrmAperturaCaja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(435, 418)
        Me.Controls.Add(Me.LblmontoGrande)
        Me.Controls.Add(Me.GrpDatos)
        Me.Controls.Add(Me.lblInfoUsuario)
        Me.Controls.Add(Me.lbltitulo)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "FrmAperturaCaja"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Apertura de Caja - Inicio de Turno "
        Me.GrpDatos.ResumeLayout(False)
        Me.GrpDatos.PerformLayout()
        CType(Me.nudMontoInicial, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbltitulo As Label
    Friend WithEvents lblInfoUsuario As Label
    Friend WithEvents GrpDatos As GroupBox
    Friend WithEvents LblTerminal As Label
    Friend WithEvents TxtUsuario As TextBox
    Friend WithEvents LblUsuario As Label
    Friend WithEvents LblFecha As Label
    Friend WithEvents TxtTerminal As TextBox
    Friend WithEvents nudMontoInicial As NumericUpDown
    Friend WithEvents lblMonto As Label
    Friend WithEvents DtpApertura As DateTimePicker
    Friend WithEvents BtnCancelar As Button
    Friend WithEvents BtnAbrir As Button
    Friend WithEvents TxtObs As TextBox
    Friend WithEvents LblObs As Label
    Friend WithEvents LblmontoGrande As Label
End Class
