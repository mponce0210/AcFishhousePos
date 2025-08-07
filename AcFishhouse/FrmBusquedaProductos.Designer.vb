<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmBusquedaProductos
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
        Me.TxtFiltro = New System.Windows.Forms.TextBox()
        Me.dgvProductos = New System.Windows.Forms.DataGridView()
        Me.lblBuscarPro = New System.Windows.Forms.Label()
        CType(Me.dgvProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtFiltro
        '
        Me.TxtFiltro.Location = New System.Drawing.Point(196, 54)
        Me.TxtFiltro.Name = "TxtFiltro"
        Me.TxtFiltro.Size = New System.Drawing.Size(684, 20)
        Me.TxtFiltro.TabIndex = 0
        Me.TxtFiltro.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dgvProductos
        '
        Me.dgvProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProductos.Location = New System.Drawing.Point(46, 99)
        Me.dgvProductos.Name = "dgvProductos"
        Me.dgvProductos.ReadOnly = True
        Me.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvProductos.Size = New System.Drawing.Size(967, 325)
        Me.dgvProductos.TabIndex = 1
        '
        'lblBuscarPro
        '
        Me.lblBuscarPro.AutoSize = True
        Me.lblBuscarPro.Font = New System.Drawing.Font("Arial Rounded MT Bold", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBuscarPro.ForeColor = System.Drawing.SystemColors.Highlight
        Me.lblBuscarPro.Location = New System.Drawing.Point(430, 9)
        Me.lblBuscarPro.Name = "lblBuscarPro"
        Me.lblBuscarPro.Size = New System.Drawing.Size(245, 32)
        Me.lblBuscarPro.TabIndex = 2
        Me.lblBuscarPro.Text = "Busqueda Rapida"
        '
        'FrmBusquedaProductos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1093, 450)
        Me.Controls.Add(Me.lblBuscarPro)
        Me.Controls.Add(Me.dgvProductos)
        Me.Controls.Add(Me.TxtFiltro)
        Me.Name = "FrmBusquedaProductos"
        Me.Text = "FrmBusquedaProductos"
        CType(Me.dgvProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TxtFiltro As TextBox
    Friend WithEvents dgvProductos As DataGridView
    Friend WithEvents lblBuscarPro As Label
End Class
