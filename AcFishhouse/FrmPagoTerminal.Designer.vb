<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPagoTerminal
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
        Me.lbltotal = New System.Windows.Forms.Label()
        Me.cmbTerminal = New System.Windows.Forms.ComboBox()
        Me.lbterminal = New System.Windows.Forms.Label()
        Me.TxtReferencia = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtComentarios = New System.Windows.Forms.TextBox()
        Me.Btnguardar = New System.Windows.Forms.Button()
        Me.BtnCancelar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lbltotal
        '
        Me.lbltotal.AutoSize = True
        Me.lbltotal.Location = New System.Drawing.Point(86, 27)
        Me.lbltotal.Name = "lbltotal"
        Me.lbltotal.Size = New System.Drawing.Size(33, 15)
        Me.lbltotal.TabIndex = 0
        Me.lbltotal.Text = "Total"
        Me.lbltotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbTerminal
        '
        Me.cmbTerminal.ForeColor = System.Drawing.Color.DarkOliveGreen
        Me.cmbTerminal.FormattingEnabled = True
        Me.cmbTerminal.Location = New System.Drawing.Point(12, 91)
        Me.cmbTerminal.Name = "cmbTerminal"
        Me.cmbTerminal.Size = New System.Drawing.Size(188, 23)
        Me.cmbTerminal.TabIndex = 1
        '
        'lbterminal
        '
        Me.lbterminal.AutoSize = True
        Me.lbterminal.Location = New System.Drawing.Point(48, 61)
        Me.lbterminal.Name = "lbterminal"
        Me.lbterminal.Size = New System.Drawing.Size(113, 15)
        Me.lbterminal.TabIndex = 2
        Me.lbterminal.Text = "USO DE TERMINAL "
        Me.lbterminal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtReferencia
        '
        Me.TxtReferencia.Location = New System.Drawing.Point(15, 147)
        Me.TxtReferencia.Multiline = True
        Me.TxtReferencia.Name = "TxtReferencia"
        Me.TxtReferencia.Size = New System.Drawing.Size(185, 28)
        Me.TxtReferencia.TabIndex = 3
        Me.TxtReferencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(15, 117)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(185, 27)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "REFERENCIA TRANSACCION"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(15, 178)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(185, 27)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "COMENTARIOS"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtComentarios
        '
        Me.TxtComentarios.Location = New System.Drawing.Point(15, 208)
        Me.TxtComentarios.Multiline = True
        Me.TxtComentarios.Name = "TxtComentarios"
        Me.TxtComentarios.Size = New System.Drawing.Size(185, 39)
        Me.TxtComentarios.TabIndex = 6
        Me.TxtComentarios.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Btnguardar
        '
        Me.Btnguardar.Location = New System.Drawing.Point(23, 280)
        Me.Btnguardar.Name = "Btnguardar"
        Me.Btnguardar.Size = New System.Drawing.Size(79, 43)
        Me.Btnguardar.TabIndex = 7
        Me.Btnguardar.Text = "GUARDAR"
        Me.Btnguardar.UseVisualStyleBackColor = True
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Location = New System.Drawing.Point(124, 280)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(76, 43)
        Me.BtnCancelar.TabIndex = 8
        Me.BtnCancelar.Text = "CANCELAR"
        Me.BtnCancelar.UseVisualStyleBackColor = True
        '
        'FrmPagoTerminal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(223, 354)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.Btnguardar)
        Me.Controls.Add(Me.TxtComentarios)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtReferencia)
        Me.Controls.Add(Me.lbterminal)
        Me.Controls.Add(Me.cmbTerminal)
        Me.Controls.Add(Me.lbltotal)
        Me.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "FrmPagoTerminal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PAGO CON TERMINAL"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbltotal As Label
    Friend WithEvents cmbTerminal As ComboBox
    Friend WithEvents lbterminal As Label
    Friend WithEvents TxtReferencia As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtComentarios As TextBox
    Friend WithEvents Btnguardar As Button
    Friend WithEvents BtnCancelar As Button
End Class
