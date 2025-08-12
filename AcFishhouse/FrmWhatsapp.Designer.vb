<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmWhatsapp
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmWhatsapp))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BtnEnviar = New System.Windows.Forms.Button()
        Me.GroAdjuntar = New System.Windows.Forms.GroupBox()
        Me.LblAdjunta = New System.Windows.Forms.Label()
        Me.BtnAdjuntar = New System.Windows.Forms.Button()
        Me.TxtMsg = New System.Windows.Forms.TextBox()
        Me.TxtNumTel = New System.Windows.Forms.TextBox()
        Me.LblMensaje = New System.Windows.Forms.Label()
        Me.LblTel = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.BtnCerrar = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroAdjuntar.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BtnEnviar)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Controls.Add(Me.GroAdjuntar)
        Me.GroupBox1.Controls.Add(Me.TxtMsg)
        Me.GroupBox1.Controls.Add(Me.TxtNumTel)
        Me.GroupBox1.Controls.Add(Me.LblMensaje)
        Me.GroupBox1.Controls.Add(Me.LblTel)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.LawnGreen
        Me.GroupBox1.Location = New System.Drawing.Point(40, 40)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(748, 385)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "WhatsApp"
        '
        'BtnEnviar
        '
        Me.BtnEnviar.ForeColor = System.Drawing.Color.DarkOliveGreen
        Me.BtnEnviar.Location = New System.Drawing.Point(399, 172)
        Me.BtnEnviar.Name = "BtnEnviar"
        Me.BtnEnviar.Size = New System.Drawing.Size(329, 50)
        Me.BtnEnviar.TabIndex = 6
        Me.BtnEnviar.Text = "Abrir WhatsApp en Navegador"
        Me.BtnEnviar.UseVisualStyleBackColor = True
        '
        'GroAdjuntar
        '
        Me.GroAdjuntar.Controls.Add(Me.LblAdjunta)
        Me.GroAdjuntar.Controls.Add(Me.BtnAdjuntar)
        Me.GroAdjuntar.Location = New System.Drawing.Point(399, 57)
        Me.GroAdjuntar.Name = "GroAdjuntar"
        Me.GroAdjuntar.Size = New System.Drawing.Size(329, 96)
        Me.GroAdjuntar.TabIndex = 4
        Me.GroAdjuntar.TabStop = False
        Me.GroAdjuntar.Text = "Adjuntar Imagen"
        '
        'LblAdjunta
        '
        Me.LblAdjunta.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAdjunta.ForeColor = System.Drawing.Color.DarkOliveGreen
        Me.LblAdjunta.Location = New System.Drawing.Point(96, 60)
        Me.LblAdjunta.Name = "LblAdjunta"
        Me.LblAdjunta.Size = New System.Drawing.Size(227, 33)
        Me.LblAdjunta.TabIndex = 1
        '
        'BtnAdjuntar
        '
        Me.BtnAdjuntar.BackgroundImage = Global.AcFishhouse.My.Resources.Resources.disco
        Me.BtnAdjuntar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnAdjuntar.Image = CType(resources.GetObject("BtnAdjuntar.Image"), System.Drawing.Image)
        Me.BtnAdjuntar.Location = New System.Drawing.Point(6, 41)
        Me.BtnAdjuntar.Name = "BtnAdjuntar"
        Me.BtnAdjuntar.Size = New System.Drawing.Size(53, 49)
        Me.BtnAdjuntar.TabIndex = 0
        Me.BtnAdjuntar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BtnAdjuntar.UseVisualStyleBackColor = True
        '
        'TxtMsg
        '
        Me.TxtMsg.Location = New System.Drawing.Point(27, 191)
        Me.TxtMsg.Multiline = True
        Me.TxtMsg.Name = "TxtMsg"
        Me.TxtMsg.Size = New System.Drawing.Size(341, 128)
        Me.TxtMsg.TabIndex = 3
        '
        'TxtNumTel
        '
        Me.TxtNumTel.Location = New System.Drawing.Point(27, 76)
        Me.TxtNumTel.Name = "TxtNumTel"
        Me.TxtNumTel.Size = New System.Drawing.Size(341, 33)
        Me.TxtNumTel.TabIndex = 2
        Me.TxtNumTel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblMensaje
        '
        Me.LblMensaje.AutoSize = True
        Me.LblMensaje.ForeColor = System.Drawing.Color.DarkOliveGreen
        Me.LblMensaje.Location = New System.Drawing.Point(22, 153)
        Me.LblMensaje.Name = "LblMensaje"
        Me.LblMensaje.Size = New System.Drawing.Size(95, 25)
        Me.LblMensaje.TabIndex = 1
        Me.LblMensaje.Text = "Mensaje: "
        '
        'LblTel
        '
        Me.LblTel.AutoSize = True
        Me.LblTel.ForeColor = System.Drawing.Color.DarkOliveGreen
        Me.LblTel.Location = New System.Drawing.Point(22, 48)
        Me.LblTel.Name = "LblTel"
        Me.LblTel.Size = New System.Drawing.Size(195, 25)
        Me.LblTel.TabIndex = 0
        Me.LblTel.Text = "Numero de Telefono"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(474, 239)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(154, 124)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        '
        'BtnCerrar
        '
        Me.BtnCerrar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCerrar.Location = New System.Drawing.Point(639, 12)
        Me.BtnCerrar.Name = "BtnCerrar"
        Me.BtnCerrar.Size = New System.Drawing.Size(129, 42)
        Me.BtnCerrar.TabIndex = 2
        Me.BtnCerrar.Text = "CERRAR}"
        Me.BtnCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.BtnCerrar.UseVisualStyleBackColor = True
        '
        'FrmWhatsapp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.BtnCerrar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FrmWhatsapp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Envio a WhatsApp"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroAdjuntar.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents LblMensaje As Label
    Friend WithEvents LblTel As Label
    Friend WithEvents GroAdjuntar As GroupBox
    Friend WithEvents TxtMsg As TextBox
    Friend WithEvents TxtNumTel As TextBox
    Friend WithEvents LblAdjunta As Label
    Friend WithEvents BtnAdjuntar As Button
    Friend WithEvents BtnEnviar As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents BtnCerrar As Button
End Class
