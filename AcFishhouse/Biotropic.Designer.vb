<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Biotropic
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
        Me.components = New System.ComponentModel.Container()
        Me.Lblbio = New System.Windows.Forms.Label()
        Me.BioGrid = New System.Windows.Forms.DataGridView()
        Me.LblBuscar = New System.Windows.Forms.Label()
        Me.RdoMarca = New System.Windows.Forms.RadioButton()
        Me.RdoBarras = New System.Windows.Forms.RadioButton()
        Me.RdoDesc = New System.Windows.Forms.RadioButton()
        Me.CmbMarca = New System.Windows.Forms.ComboBox()
        Me.TxtBus = New System.Windows.Forms.TextBox()
        Me.RdoDesMarca = New System.Windows.Forms.RadioButton()
        Me.BtnBuscar = New System.Windows.Forms.Button()
        Me.OrderGrid = New System.Windows.Forms.DataGridView()
        Me.BtnAgregar = New System.Windows.Forms.Button()
        Me.BtnBorrar = New System.Windows.Forms.Button()
        Me.BtnGuardarPedido = New System.Windows.Forms.Button()
        Me.CmbLista = New System.Windows.Forms.ComboBox()
        Me.Lnlorder = New System.Windows.Forms.Label()
        Me.ChkCerrarOrden = New System.Windows.Forms.CheckBox()
        Me.BtnInicio = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolTip2 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.BioGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OrderGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Lblbio
        '
        Me.Lblbio.AutoSize = True
        Me.Lblbio.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblbio.ForeColor = System.Drawing.Color.Black
        Me.Lblbio.Location = New System.Drawing.Point(235, 27)
        Me.Lblbio.Name = "Lblbio"
        Me.Lblbio.Size = New System.Drawing.Size(366, 31)
        Me.Lblbio.TabIndex = 0
        Me.Lblbio.Text = "PRODUCTOS BIOTROPIC"
        Me.Lblbio.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'BioGrid
        '
        Me.BioGrid.AllowUserToOrderColumns = True
        Me.BioGrid.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BioGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.BioGrid.Location = New System.Drawing.Point(37, 196)
        Me.BioGrid.Name = "BioGrid"
        Me.BioGrid.Size = New System.Drawing.Size(1291, 266)
        Me.BioGrid.TabIndex = 1
        '
        'LblBuscar
        '
        Me.LblBuscar.AutoSize = True
        Me.LblBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBuscar.Location = New System.Drawing.Point(33, 122)
        Me.LblBuscar.Name = "LblBuscar"
        Me.LblBuscar.Size = New System.Drawing.Size(152, 20)
        Me.LblBuscar.TabIndex = 2
        Me.LblBuscar.Text = "Buscar Producto :"
        '
        'RdoMarca
        '
        Me.RdoMarca.AutoSize = True
        Me.RdoMarca.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RdoMarca.Location = New System.Drawing.Point(206, 70)
        Me.RdoMarca.Name = "RdoMarca"
        Me.RdoMarca.Size = New System.Drawing.Size(96, 20)
        Me.RdoMarca.TabIndex = 3
        Me.RdoMarca.TabStop = True
        Me.RdoMarca.Text = "Por Marca"
        Me.RdoMarca.UseVisualStyleBackColor = True
        '
        'RdoBarras
        '
        Me.RdoBarras.AutoSize = True
        Me.RdoBarras.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RdoBarras.Location = New System.Drawing.Point(206, 100)
        Me.RdoBarras.Name = "RdoBarras"
        Me.RdoBarras.Size = New System.Drawing.Size(147, 20)
        Me.RdoBarras.TabIndex = 4
        Me.RdoBarras.TabStop = True
        Me.RdoBarras.Text = "Codigo de Barras"
        Me.RdoBarras.UseVisualStyleBackColor = True
        '
        'RdoDesc
        '
        Me.RdoDesc.AutoSize = True
        Me.RdoDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RdoDesc.Location = New System.Drawing.Point(206, 126)
        Me.RdoDesc.Name = "RdoDesc"
        Me.RdoDesc.Size = New System.Drawing.Size(136, 20)
        Me.RdoDesc.TabIndex = 5
        Me.RdoDesc.TabStop = True
        Me.RdoDesc.Text = "Por Descripcion"
        Me.RdoDesc.UseVisualStyleBackColor = True
        '
        'CmbMarca
        '
        Me.CmbMarca.FormattingEnabled = True
        Me.CmbMarca.Location = New System.Drawing.Point(410, 84)
        Me.CmbMarca.Name = "CmbMarca"
        Me.CmbMarca.Size = New System.Drawing.Size(258, 21)
        Me.CmbMarca.TabIndex = 6
        '
        'TxtBus
        '
        Me.TxtBus.Location = New System.Drawing.Point(410, 124)
        Me.TxtBus.Name = "TxtBus"
        Me.TxtBus.Size = New System.Drawing.Size(258, 20)
        Me.TxtBus.TabIndex = 7
        '
        'RdoDesMarca
        '
        Me.RdoDesMarca.AutoSize = True
        Me.RdoDesMarca.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RdoDesMarca.Location = New System.Drawing.Point(206, 152)
        Me.RdoDesMarca.Name = "RdoDesMarca"
        Me.RdoDesMarca.Size = New System.Drawing.Size(167, 20)
        Me.RdoDesMarca.TabIndex = 8
        Me.RdoDesMarca.TabStop = True
        Me.RdoDesMarca.Text = "Descripcion y Marca"
        Me.RdoDesMarca.UseVisualStyleBackColor = True
        '
        'BtnBuscar
        '
        Me.BtnBuscar.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.BtnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBuscar.ForeColor = System.Drawing.Color.White
        Me.BtnBuscar.Location = New System.Drawing.Point(410, 160)
        Me.BtnBuscar.Name = "BtnBuscar"
        Me.BtnBuscar.Size = New System.Drawing.Size(102, 30)
        Me.BtnBuscar.TabIndex = 9
        Me.BtnBuscar.Text = "BUSCAR"
        Me.BtnBuscar.UseVisualStyleBackColor = False
        '
        'OrderGrid
        '
        Me.OrderGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.OrderGrid.Location = New System.Drawing.Point(39, 474)
        Me.OrderGrid.Name = "OrderGrid"
        Me.OrderGrid.Size = New System.Drawing.Size(877, 145)
        Me.OrderGrid.TabIndex = 10
        '
        'BtnAgregar
        '
        Me.BtnAgregar.BackColor = System.Drawing.SystemColors.HotTrack
        Me.BtnAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAgregar.ForeColor = System.Drawing.Color.White
        Me.BtnAgregar.Location = New System.Drawing.Point(940, 475)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(103, 29)
        Me.BtnAgregar.TabIndex = 11
        Me.BtnAgregar.Text = "Agregar"
        Me.BtnAgregar.UseVisualStyleBackColor = False
        '
        'BtnBorrar
        '
        Me.BtnBorrar.BackColor = System.Drawing.SystemColors.HotTrack
        Me.BtnBorrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBorrar.ForeColor = System.Drawing.Color.White
        Me.BtnBorrar.Location = New System.Drawing.Point(940, 545)
        Me.BtnBorrar.Name = "BtnBorrar"
        Me.BtnBorrar.Size = New System.Drawing.Size(103, 29)
        Me.BtnBorrar.TabIndex = 12
        Me.BtnBorrar.Text = "Limpiar"
        Me.BtnBorrar.UseVisualStyleBackColor = False
        '
        'BtnGuardarPedido
        '
        Me.BtnGuardarPedido.BackColor = System.Drawing.SystemColors.HotTrack
        Me.BtnGuardarPedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGuardarPedido.ForeColor = System.Drawing.Color.White
        Me.BtnGuardarPedido.Location = New System.Drawing.Point(940, 510)
        Me.BtnGuardarPedido.Name = "BtnGuardarPedido"
        Me.BtnGuardarPedido.Size = New System.Drawing.Size(103, 29)
        Me.BtnGuardarPedido.TabIndex = 13
        Me.BtnGuardarPedido.Text = "Grabar"
        Me.BtnGuardarPedido.UseVisualStyleBackColor = False
        '
        'CmbLista
        '
        Me.CmbLista.FormattingEnabled = True
        Me.CmbLista.Location = New System.Drawing.Point(1072, 515)
        Me.CmbLista.Name = "CmbLista"
        Me.CmbLista.Size = New System.Drawing.Size(255, 21)
        Me.CmbLista.TabIndex = 14
        '
        'Lnlorder
        '
        Me.Lnlorder.AutoSize = True
        Me.Lnlorder.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lnlorder.Location = New System.Drawing.Point(1068, 483)
        Me.Lnlorder.Name = "Lnlorder"
        Me.Lnlorder.Size = New System.Drawing.Size(129, 20)
        Me.Lnlorder.TabIndex = 15
        Me.Lnlorder.Text = "Buscar Orden :"
        '
        'ChkCerrarOrden
        '
        Me.ChkCerrarOrden.AutoSize = True
        Me.ChkCerrarOrden.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkCerrarOrden.Location = New System.Drawing.Point(1203, 484)
        Me.ChkCerrarOrden.Name = "ChkCerrarOrden"
        Me.ChkCerrarOrden.Size = New System.Drawing.Size(109, 19)
        Me.ChkCerrarOrden.TabIndex = 16
        Me.ChkCerrarOrden.Text = "Cerrar Orden"
        Me.ChkCerrarOrden.UseVisualStyleBackColor = True
        '
        'BtnInicio
        '
        Me.BtnInicio.BackColor = System.Drawing.SystemColors.HotTrack
        Me.BtnInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnInicio.ForeColor = System.Drawing.Color.White
        Me.BtnInicio.Location = New System.Drawing.Point(940, 590)
        Me.BtnInicio.Name = "BtnInicio"
        Me.BtnInicio.Size = New System.Drawing.Size(103, 29)
        Me.BtnInicio.TabIndex = 17
        Me.BtnInicio.Text = "Re-Iniciar"
        Me.BtnInicio.UseVisualStyleBackColor = False
        Me.BtnInicio.UseWaitCursor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1340, 25)
        Me.ToolStrip1.TabIndex = 18
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'Biotropic
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1340, 704)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.BtnInicio)
        Me.Controls.Add(Me.ChkCerrarOrden)
        Me.Controls.Add(Me.Lnlorder)
        Me.Controls.Add(Me.CmbLista)
        Me.Controls.Add(Me.BtnGuardarPedido)
        Me.Controls.Add(Me.BtnBorrar)
        Me.Controls.Add(Me.BtnAgregar)
        Me.Controls.Add(Me.OrderGrid)
        Me.Controls.Add(Me.BtnBuscar)
        Me.Controls.Add(Me.RdoDesMarca)
        Me.Controls.Add(Me.TxtBus)
        Me.Controls.Add(Me.CmbMarca)
        Me.Controls.Add(Me.RdoDesc)
        Me.Controls.Add(Me.RdoBarras)
        Me.Controls.Add(Me.RdoMarca)
        Me.Controls.Add(Me.LblBuscar)
        Me.Controls.Add(Me.BioGrid)
        Me.Controls.Add(Me.Lblbio)
        Me.Name = "Biotropic"
        Me.Text = "Biotropic"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.BioGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OrderGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Lblbio As Label
    Friend WithEvents BioGrid As DataGridView
    Friend WithEvents LblBuscar As Label
    Friend WithEvents RdoMarca As RadioButton
    Friend WithEvents RdoBarras As RadioButton
    Friend WithEvents RdoDesc As RadioButton
    Friend WithEvents CmbMarca As ComboBox
    Friend WithEvents TxtBus As TextBox
    Friend WithEvents RdoDesMarca As RadioButton
    Friend WithEvents BtnBuscar As Button
    Friend WithEvents OrderGrid As DataGridView
    Friend WithEvents BtnAgregar As Button
    Friend WithEvents BtnBorrar As Button
    Friend WithEvents BtnGuardarPedido As Button
    Friend WithEvents CmbLista As ComboBox
    Friend WithEvents Lnlorder As Label
    '  Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbExportExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ChkCerrarOrden As CheckBox
    Friend WithEvents BtnInicio As Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolTip2 As ToolTip
End Class

