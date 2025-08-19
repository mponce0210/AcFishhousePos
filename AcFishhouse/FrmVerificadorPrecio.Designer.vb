<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmVerificadorPrecio
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
        Me.Gpo1 = New System.Windows.Forms.GroupBox()
        Me.TxtScan = New System.Windows.Forms.TextBox()
        Me.pnlVerificador = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.BtnCancelar = New System.Windows.Forms.Button()
        Me.BtnAgregar = New System.Windows.Forms.Button()
        Me.lblExist = New System.Windows.Forms.Label()
        Me.LblPrecio = New System.Windows.Forms.Label()
        Me.LblNombre = New System.Windows.Forms.Label()
        Me.NudCant = New System.Windows.Forms.NumericUpDown()
        Me.Gpo1.SuspendLayout()
        Me.pnlVerificador.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudCant, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Gpo1
        '
        Me.Gpo1.Controls.Add(Me.TxtScan)
        Me.Gpo1.Controls.Add(Me.pnlVerificador)
        Me.Gpo1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Gpo1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Gpo1.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Gpo1.Location = New System.Drawing.Point(12, 31)
        Me.Gpo1.Name = "Gpo1"
        Me.Gpo1.Size = New System.Drawing.Size(758, 381)
        Me.Gpo1.TabIndex = 0
        Me.Gpo1.TabStop = False
        Me.Gpo1.Text = "Verificador de Precios "
        '
        'TxtScan
        '
        Me.TxtScan.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtScan.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.TxtScan.Location = New System.Drawing.Point(26, 28)
        Me.TxtScan.Name = "TxtScan"
        Me.TxtScan.Size = New System.Drawing.Size(708, 39)
        Me.TxtScan.TabIndex = 0
        Me.TxtScan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'pnlVerificador
        '
        Me.pnlVerificador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlVerificador.Controls.Add(Me.PictureBox1)
        Me.pnlVerificador.Controls.Add(Me.BtnCancelar)
        Me.pnlVerificador.Controls.Add(Me.BtnAgregar)
        Me.pnlVerificador.Controls.Add(Me.lblExist)
        Me.pnlVerificador.Controls.Add(Me.LblPrecio)
        Me.pnlVerificador.Controls.Add(Me.LblNombre)
        Me.pnlVerificador.Controls.Add(Me.NudCant)
        Me.pnlVerificador.Location = New System.Drawing.Point(26, 63)
        Me.pnlVerificador.Name = "pnlVerificador"
        Me.pnlVerificador.Size = New System.Drawing.Size(708, 293)
        Me.pnlVerificador.TabIndex = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.AcFishhouse.My.Resources.Resources.removebg2
        Me.PictureBox1.Location = New System.Drawing.Point(21, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(158, 103)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 6
        Me.PictureBox1.TabStop = False
        '
        'BtnCancelar
        '
        Me.BtnCancelar.AutoSize = True
        Me.BtnCancelar.Location = New System.Drawing.Point(531, 242)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(144, 31)
        Me.BtnCancelar.TabIndex = 5
        Me.BtnCancelar.Text = "ESC - CANCELAR"
        Me.BtnCancelar.UseVisualStyleBackColor = True
        '
        'BtnAgregar
        '
        Me.BtnAgregar.AutoSize = True
        Me.BtnAgregar.Location = New System.Drawing.Point(21, 241)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(195, 31)
        Me.BtnAgregar.TabIndex = 4
        Me.BtnAgregar.Text = "F1 - AGREGAR A VENTA"
        Me.BtnAgregar.UseVisualStyleBackColor = True
        '
        'lblExist
        '
        Me.lblExist.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExist.Location = New System.Drawing.Point(276, 240)
        Me.lblExist.Name = "lblExist"
        Me.lblExist.Size = New System.Drawing.Size(201, 32)
        Me.lblExist.TabIndex = 3
        Me.lblExist.Text = "EXISTENCIAS"
        Me.lblExist.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblPrecio
        '
        Me.LblPrecio.Font = New System.Drawing.Font("Segoe UI", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPrecio.ForeColor = System.Drawing.Color.DarkOliveGreen
        Me.LblPrecio.Location = New System.Drawing.Point(153, 118)
        Me.LblPrecio.Name = "LblPrecio"
        Me.LblPrecio.Size = New System.Drawing.Size(408, 86)
        Me.LblPrecio.TabIndex = 2
        Me.LblPrecio.Text = "PRECIO"
        Me.LblPrecio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblNombre
        '
        Me.LblNombre.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNombre.Location = New System.Drawing.Point(196, 44)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(493, 45)
        Me.LblNombre.TabIndex = 1
        Me.LblNombre.Text = "NOMBRE"
        Me.LblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'NudCant
        '
        Me.NudCant.Location = New System.Drawing.Point(222, 244)
        Me.NudCant.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.NudCant.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudCant.Name = "NudCant"
        Me.NudCant.Size = New System.Drawing.Size(48, 29)
        Me.NudCant.TabIndex = 0
        Me.NudCant.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NudCant.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'FrmVerificadorPrecio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Gpo1)
        Me.KeyPreview = True
        Me.Name = "FrmVerificadorPrecio"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "VERIFICADOR DE PRECIOS"
        Me.Gpo1.ResumeLayout(False)
        Me.Gpo1.PerformLayout()
        Me.pnlVerificador.ResumeLayout(False)
        Me.pnlVerificador.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudCant, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Gpo1 As GroupBox
    Friend WithEvents pnlVerificador As Panel
    Friend WithEvents TxtScan As TextBox
    Friend WithEvents NudCant As NumericUpDown
    Friend WithEvents LblPrecio As Label
    Friend WithEvents LblNombre As Label
    Friend WithEvents lblExist As Label
    Friend WithEvents BtnCancelar As Button
    Friend WithEvents BtnAgregar As Button
    Friend WithEvents PictureBox1 As PictureBox
End Class
