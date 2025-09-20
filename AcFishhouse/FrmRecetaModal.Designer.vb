<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRecetaModal
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
        Me.txttitulo = New System.Windows.Forms.TextBox()
        Me.txtEspecie = New System.Windows.Forms.TextBox()
        Me.txtDiagnostico = New System.Windows.Forms.TextBox()
        Me.txtdosis = New System.Windows.Forms.TextBox()
        Me.Txtmedicamento = New System.Windows.Forms.TextBox()
        Me.txtFrecuencia = New System.Windows.Forms.TextBox()
        Me.numDuracion = New System.Windows.Forms.NumericUpDown()
        Me.txtcambiosAgua = New System.Windows.Forms.TextBox()
        Me.txtadvertencias = New System.Windows.Forms.TextBox()
        Me.txtNotasEspecialista = New System.Windows.Forms.TextBox()
        Me.BtnGuardar = New System.Windows.Forms.Button()
        Me.BtnPrevisualizar = New System.Windows.Forms.Button()
        Me.BtnPdf = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.wvPrev = New Microsoft.Web.WebView2.WinForms.WebView2()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        CType(Me.numDuracion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.wvPrev, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txttitulo
        '
        Me.txttitulo.Location = New System.Drawing.Point(35, 34)
        Me.txttitulo.Name = "txttitulo"
        Me.txttitulo.Size = New System.Drawing.Size(430, 20)
        Me.txttitulo.TabIndex = 0
        '
        'txtEspecie
        '
        Me.txtEspecie.Location = New System.Drawing.Point(35, 88)
        Me.txtEspecie.Name = "txtEspecie"
        Me.txtEspecie.Size = New System.Drawing.Size(188, 20)
        Me.txtEspecie.TabIndex = 1
        '
        'txtDiagnostico
        '
        Me.txtDiagnostico.Location = New System.Drawing.Point(229, 88)
        Me.txtDiagnostico.Multiline = True
        Me.txtDiagnostico.Name = "txtDiagnostico"
        Me.txtDiagnostico.Size = New System.Drawing.Size(236, 63)
        Me.txtDiagnostico.TabIndex = 2
        '
        'txtdosis
        '
        Me.txtdosis.Location = New System.Drawing.Point(35, 174)
        Me.txtdosis.Multiline = True
        Me.txtdosis.Name = "txtdosis"
        Me.txtdosis.Size = New System.Drawing.Size(188, 42)
        Me.txtdosis.TabIndex = 3
        '
        'Txtmedicamento
        '
        Me.Txtmedicamento.Location = New System.Drawing.Point(35, 131)
        Me.Txtmedicamento.Name = "Txtmedicamento"
        Me.Txtmedicamento.Size = New System.Drawing.Size(188, 20)
        Me.Txtmedicamento.TabIndex = 4
        '
        'txtFrecuencia
        '
        Me.txtFrecuencia.Location = New System.Drawing.Point(229, 174)
        Me.txtFrecuencia.Name = "txtFrecuencia"
        Me.txtFrecuencia.Size = New System.Drawing.Size(236, 20)
        Me.txtFrecuencia.TabIndex = 5
        '
        'numDuracion
        '
        Me.numDuracion.Location = New System.Drawing.Point(304, 200)
        Me.numDuracion.Name = "numDuracion"
        Me.numDuracion.Size = New System.Drawing.Size(39, 20)
        Me.numDuracion.TabIndex = 6
        '
        'txtcambiosAgua
        '
        Me.txtcambiosAgua.Location = New System.Drawing.Point(39, 239)
        Me.txtcambiosAgua.Multiline = True
        Me.txtcambiosAgua.Name = "txtcambiosAgua"
        Me.txtcambiosAgua.Size = New System.Drawing.Size(184, 36)
        Me.txtcambiosAgua.TabIndex = 7
        '
        'txtadvertencias
        '
        Me.txtadvertencias.Location = New System.Drawing.Point(35, 311)
        Me.txtadvertencias.Multiline = True
        Me.txtadvertencias.Name = "txtadvertencias"
        Me.txtadvertencias.Size = New System.Drawing.Size(220, 127)
        Me.txtadvertencias.TabIndex = 8
        '
        'txtNotasEspecialista
        '
        Me.txtNotasEspecialista.Location = New System.Drawing.Point(261, 311)
        Me.txtNotasEspecialista.Multiline = True
        Me.txtNotasEspecialista.Name = "txtNotasEspecialista"
        Me.txtNotasEspecialista.Size = New System.Drawing.Size(209, 127)
        Me.txtNotasEspecialista.TabIndex = 9
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Location = New System.Drawing.Point(99, 475)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(75, 23)
        Me.BtnGuardar.TabIndex = 10
        Me.BtnGuardar.Text = "Guardar"
        Me.BtnGuardar.UseVisualStyleBackColor = True
        '
        'BtnPrevisualizar
        '
        Me.BtnPrevisualizar.Location = New System.Drawing.Point(180, 475)
        Me.BtnPrevisualizar.Name = "BtnPrevisualizar"
        Me.BtnPrevisualizar.Size = New System.Drawing.Size(75, 23)
        Me.BtnPrevisualizar.TabIndex = 11
        Me.BtnPrevisualizar.Text = "Previsualizar"
        Me.BtnPrevisualizar.UseVisualStyleBackColor = True
        '
        'BtnPdf
        '
        Me.BtnPdf.Location = New System.Drawing.Point(261, 475)
        Me.BtnPdf.Name = "BtnPdf"
        Me.BtnPdf.Size = New System.Drawing.Size(75, 23)
        Me.BtnPdf.TabIndex = 12
        Me.BtnPdf.Text = "PDF"
        Me.BtnPdf.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(342, 475)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 13
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'wvPrev
        '
        Me.wvPrev.AllowExternalDrop = True
        Me.wvPrev.CreationProperties = Nothing
        Me.wvPrev.DefaultBackgroundColor = System.Drawing.Color.White
        Me.wvPrev.Location = New System.Drawing.Point(487, 34)
        Me.wvPrev.Name = "wvPrev"
        Me.wvPrev.Size = New System.Drawing.Size(714, 615)
        Me.wvPrev.TabIndex = 14
        Me.wvPrev.ZoomFactor = 1.0R
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label1.Location = New System.Drawing.Point(32, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(253, 17)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = " -Tamaño de Acuatio Lts / Gls - Nombre "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label2.Location = New System.Drawing.Point(32, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(135, 17)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Especie / Tipo de Pez"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label3.Location = New System.Drawing.Point(226, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(172, 17)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Diagnostico / Enfermedad: "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label4.Location = New System.Drawing.Point(36, 111)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 17)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Medicamento :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label5.Location = New System.Drawing.Point(36, 154)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 17)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Dosis :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label6.Location = New System.Drawing.Point(229, 154)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 17)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Frecuencia"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label7.Location = New System.Drawing.Point(229, 197)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 17)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "Duracion :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label8.Location = New System.Drawing.Point(36, 219)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(118, 17)
        Me.Label8.TabIndex = 22
        Me.Label8.Text = "Cambios de Agua:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label9.Location = New System.Drawing.Point(36, 291)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(97, 17)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "Advertencias : "
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label10.Location = New System.Drawing.Point(258, 291)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(135, 17)
        Me.Label10.TabIndex = 24
        Me.Label10.Text = "Instrucciones / Uso : "
        '
        'FrmRecetaModal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1213, 683)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.wvPrev)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.BtnPdf)
        Me.Controls.Add(Me.BtnPrevisualizar)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.txtNotasEspecialista)
        Me.Controls.Add(Me.txtadvertencias)
        Me.Controls.Add(Me.txtcambiosAgua)
        Me.Controls.Add(Me.numDuracion)
        Me.Controls.Add(Me.txtFrecuencia)
        Me.Controls.Add(Me.Txtmedicamento)
        Me.Controls.Add(Me.txtdosis)
        Me.Controls.Add(Me.txtDiagnostico)
        Me.Controls.Add(Me.txtEspecie)
        Me.Controls.Add(Me.txttitulo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRecetaModal"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "FrmRecetaModal"
        CType(Me.numDuracion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.wvPrev, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txttitulo As TextBox
    Friend WithEvents txtEspecie As TextBox
    Friend WithEvents txtDiagnostico As TextBox
    Friend WithEvents txtdosis As TextBox
    Friend WithEvents Txtmedicamento As TextBox
    Friend WithEvents txtFrecuencia As TextBox
    Friend WithEvents numDuracion As NumericUpDown
    Friend WithEvents txtcambiosAgua As TextBox
    Friend WithEvents txtadvertencias As TextBox
    Friend WithEvents txtNotasEspecialista As TextBox
    Friend WithEvents BtnGuardar As Button
    Friend WithEvents BtnPrevisualizar As Button
    Friend WithEvents BtnPdf As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents wvPrev As Microsoft.Web.WebView2.WinForms.WebView2
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
End Class
