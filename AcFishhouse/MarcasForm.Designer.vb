<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MarcasForm
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
        Me.DgvMarcas = New System.Windows.Forms.DataGridView()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.lblbuscar = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnReFrescar = New System.Windows.Forms.Button()
        Me.Btneliminar = New System.Windows.Forms.Button()
        Me.BtnNuevo = New System.Windows.Forms.Button()
        CType(Me.DgvMarcas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DgvMarcas
        '
        Me.DgvMarcas.AllowUserToDeleteRows = False
        Me.DgvMarcas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvMarcas.Location = New System.Drawing.Point(24, 68)
        Me.DgvMarcas.Name = "DgvMarcas"
        Me.DgvMarcas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvMarcas.Size = New System.Drawing.Size(982, 359)
        Me.DgvMarcas.TabIndex = 0
        '
        'txtBuscar
        '
        Me.txtBuscar.Location = New System.Drawing.Point(56, 30)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(236, 20)
        Me.txtBuscar.TabIndex = 1
        '
        'lblbuscar
        '
        Me.lblbuscar.AutoSize = True
        Me.lblbuscar.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblbuscar.ForeColor = System.Drawing.SystemColors.Highlight
        Me.lblbuscar.Location = New System.Drawing.Point(124, 10)
        Me.lblbuscar.Name = "lblbuscar"
        Me.lblbuscar.Size = New System.Drawing.Size(89, 17)
        Me.lblbuscar.TabIndex = 2
        Me.lblbuscar.Text = "Buscar Marca"
        '
        'btnGuardar
        '
        Me.btnGuardar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.ForeColor = System.Drawing.SystemColors.Highlight
        Me.btnGuardar.Location = New System.Drawing.Point(311, 12)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(90, 38)
        Me.btnGuardar.TabIndex = 3
        Me.btnGuardar.Text = "GUARDAR"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnReFrescar
        '
        Me.btnReFrescar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReFrescar.ForeColor = System.Drawing.SystemColors.Highlight
        Me.btnReFrescar.Location = New System.Drawing.Point(407, 12)
        Me.btnReFrescar.Name = "btnReFrescar"
        Me.btnReFrescar.Size = New System.Drawing.Size(90, 38)
        Me.btnReFrescar.TabIndex = 4
        Me.btnReFrescar.Text = "REFRESH"
        Me.btnReFrescar.UseVisualStyleBackColor = True
        '
        'Btneliminar
        '
        Me.Btneliminar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btneliminar.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Btneliminar.Location = New System.Drawing.Point(599, 12)
        Me.Btneliminar.Name = "Btneliminar"
        Me.Btneliminar.Size = New System.Drawing.Size(90, 38)
        Me.Btneliminar.TabIndex = 5
        Me.Btneliminar.Text = "ELIMINAR"
        Me.Btneliminar.UseVisualStyleBackColor = True
        '
        'BtnNuevo
        '
        Me.BtnNuevo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNuevo.ForeColor = System.Drawing.SystemColors.Highlight
        Me.BtnNuevo.Location = New System.Drawing.Point(503, 12)
        Me.BtnNuevo.Name = "BtnNuevo"
        Me.BtnNuevo.Size = New System.Drawing.Size(90, 38)
        Me.BtnNuevo.TabIndex = 6
        Me.BtnNuevo.Text = "NUEVO"
        Me.BtnNuevo.UseVisualStyleBackColor = True
        '
        'MarcasForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1033, 450)
        Me.Controls.Add(Me.BtnNuevo)
        Me.Controls.Add(Me.Btneliminar)
        Me.Controls.Add(Me.btnReFrescar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.lblbuscar)
        Me.Controls.Add(Me.txtBuscar)
        Me.Controls.Add(Me.DgvMarcas)
        Me.Name = "MarcasForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CATALOGO DE MARCAS"
        CType(Me.DgvMarcas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DgvMarcas As DataGridView
    Friend WithEvents txtBuscar As TextBox
    Friend WithEvents lblbuscar As Label
    Friend WithEvents btnGuardar As Button
    Friend WithEvents btnReFrescar As Button
    Friend WithEvents Btneliminar As Button
    Friend WithEvents BtnNuevo As Button
End Class
