<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AboutBox
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
        Me.lblNombreSistema = New System.Windows.Forms.Label()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.lblEmpresa = New System.Windows.Forms.Label()
        Me.lblmke = New System.Windows.Forms.Label()
        Me.LblSist = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblNombreSistema
        '
        Me.lblNombreSistema.AutoSize = True
        Me.lblNombreSistema.Location = New System.Drawing.Point(0, 0)
        Me.lblNombreSistema.Name = "lblNombreSistema"
        Me.lblNombreSistema.Size = New System.Drawing.Size(39, 13)
        Me.lblNombreSistema.TabIndex = 0
        Me.lblNombreSistema.Text = "Label1"
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.Location = New System.Drawing.Point(0, 27)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(39, 13)
        Me.lblVersion.TabIndex = 1
        Me.lblVersion.Text = "Label1"
        '
        'lblEmpresa
        '
        Me.lblEmpresa.AutoSize = True
        Me.lblEmpresa.Location = New System.Drawing.Point(0, 56)
        Me.lblEmpresa.Name = "lblEmpresa"
        Me.lblEmpresa.Size = New System.Drawing.Size(39, 13)
        Me.lblEmpresa.TabIndex = 2
        Me.lblEmpresa.Text = "Label1"
        '
        'lblmke
        '
        Me.lblmke.AutoSize = True
        Me.lblmke.Font = New System.Drawing.Font("Bookman Old Style", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblmke.ForeColor = System.Drawing.SystemColors.Highlight
        Me.lblmke.Location = New System.Drawing.Point(12, 132)
        Me.lblmke.Name = "lblmke"
        Me.lblmke.Size = New System.Drawing.Size(60, 18)
        Me.lblmke.TabIndex = 4
        Me.lblmke.Text = "Label1"
        '
        'LblSist
        '
        Me.LblSist.AutoSize = True
        Me.LblSist.Location = New System.Drawing.Point(0, 86)
        Me.LblSist.Name = "LblSist"
        Me.LblSist.Size = New System.Drawing.Size(39, 13)
        Me.LblSist.TabIndex = 5
        Me.LblSist.Text = "Label1"
        '
        'AboutBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(348, 159)
        Me.Controls.Add(Me.LblSist)
        Me.Controls.Add(Me.lblmke)
        Me.Controls.Add(Me.lblEmpresa)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.lblNombreSistema)
        Me.Name = "AboutBox"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AboutBox"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblNombreSistema As Label
    Friend WithEvents lblVersion As Label
    Friend WithEvents lblEmpresa As Label
    Friend WithEvents lblmke As Label
    Friend WithEvents LblSist As Label
End Class
