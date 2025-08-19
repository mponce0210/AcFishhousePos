<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDineroenCaja
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
        Me.lblCajaDinero = New System.Windows.Forms.Label()
        Me.nudMonto = New System.Windows.Forms.NumericUpDown()
        Me.cmbMovimiento = New System.Windows.Forms.ComboBox()
        Me.lblmonto = New System.Windows.Forms.Label()
        Me.LblComentarios = New System.Windows.Forms.Label()
        Me.Txtcomentarios = New System.Windows.Forms.TextBox()
        Me.BtnAgregar = New System.Windows.Forms.Button()
        Me.BtnCerrar = New System.Windows.Forms.Button()
        Me.dgvMovs = New System.Windows.Forms.DataGridView()
        Me.LblTotIng = New System.Windows.Forms.Label()
        Me.LbltotSal = New System.Windows.Forms.Label()
        Me.LblIngreso = New System.Windows.Forms.Label()
        Me.LblSalidas = New System.Windows.Forms.Label()
        Me.dgvResumenVentas = New System.Windows.Forms.DataGridView()
        Me.LblIngresos = New System.Windows.Forms.Label()
        Me.lblTotals = New System.Windows.Forms.Label()
        Me.lblTotSals = New System.Windows.Forms.Label()
        Me.lblVentasEfec = New System.Windows.Forms.Label()
        Me.lblTotalCaja = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LblDebito = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblCredito = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LblTran = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lbltotalVenta = New System.Windows.Forms.Label()
        CType(Me.nudMonto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvMovs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvResumenVentas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblCajaDinero
        '
        Me.lblCajaDinero.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblCajaDinero.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCajaDinero.ForeColor = System.Drawing.SystemColors.Highlight
        Me.lblCajaDinero.Location = New System.Drawing.Point(0, 0)
        Me.lblCajaDinero.Name = "lblCajaDinero"
        Me.lblCajaDinero.Size = New System.Drawing.Size(918, 34)
        Me.lblCajaDinero.TabIndex = 0
        Me.lblCajaDinero.Text = "Dinero en Caja"
        Me.lblCajaDinero.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'nudMonto
        '
        Me.nudMonto.DecimalPlaces = 2
        Me.nudMonto.Location = New System.Drawing.Point(78, 73)
        Me.nudMonto.Minimum = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.nudMonto.Name = "nudMonto"
        Me.nudMonto.Size = New System.Drawing.Size(120, 20)
        Me.nudMonto.TabIndex = 1
        Me.nudMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudMonto.Value = New Decimal(New Integer() {1, 0, 0, 131072})
        '
        'cmbMovimiento
        '
        Me.cmbMovimiento.FormattingEnabled = True
        Me.cmbMovimiento.Location = New System.Drawing.Point(26, 46)
        Me.cmbMovimiento.Name = "cmbMovimiento"
        Me.cmbMovimiento.Size = New System.Drawing.Size(411, 21)
        Me.cmbMovimiento.TabIndex = 2
        '
        'lblmonto
        '
        Me.lblmonto.AutoSize = True
        Me.lblmonto.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblmonto.ForeColor = System.Drawing.SystemColors.Highlight
        Me.lblmonto.Location = New System.Drawing.Point(23, 73)
        Me.lblmonto.Name = "lblmonto"
        Me.lblmonto.Size = New System.Drawing.Size(49, 17)
        Me.lblmonto.TabIndex = 3
        Me.lblmonto.Text = "Monto"
        '
        'LblComentarios
        '
        Me.LblComentarios.AutoSize = True
        Me.LblComentarios.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblComentarios.ForeColor = System.Drawing.SystemColors.Highlight
        Me.LblComentarios.Location = New System.Drawing.Point(204, 73)
        Me.LblComentarios.Name = "LblComentarios"
        Me.LblComentarios.Size = New System.Drawing.Size(89, 17)
        Me.LblComentarios.TabIndex = 4
        Me.LblComentarios.Text = "Comentarios "
        '
        'Txtcomentarios
        '
        Me.Txtcomentarios.Location = New System.Drawing.Point(288, 73)
        Me.Txtcomentarios.Multiline = True
        Me.Txtcomentarios.Name = "Txtcomentarios"
        Me.Txtcomentarios.Size = New System.Drawing.Size(261, 35)
        Me.Txtcomentarios.TabIndex = 5
        '
        'BtnAgregar
        '
        Me.BtnAgregar.BackColor = System.Drawing.Color.LightGreen
        Me.BtnAgregar.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAgregar.ForeColor = System.Drawing.SystemColors.Highlight
        Me.BtnAgregar.Location = New System.Drawing.Point(631, 450)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(113, 32)
        Me.BtnAgregar.TabIndex = 6
        Me.BtnAgregar.Text = "F5 - Agregar"
        Me.BtnAgregar.UseVisualStyleBackColor = False
        '
        'BtnCerrar
        '
        Me.BtnCerrar.BackColor = System.Drawing.Color.LightGreen
        Me.BtnCerrar.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCerrar.ForeColor = System.Drawing.SystemColors.Highlight
        Me.BtnCerrar.Location = New System.Drawing.Point(764, 450)
        Me.BtnCerrar.Name = "BtnCerrar"
        Me.BtnCerrar.Size = New System.Drawing.Size(113, 32)
        Me.BtnCerrar.TabIndex = 7
        Me.BtnCerrar.Text = "Esc - Cerrar"
        Me.BtnCerrar.UseVisualStyleBackColor = False
        '
        'dgvMovs
        '
        Me.dgvMovs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMovs.Location = New System.Drawing.Point(26, 305)
        Me.dgvMovs.Name = "dgvMovs"
        Me.dgvMovs.Size = New System.Drawing.Size(863, 129)
        Me.dgvMovs.TabIndex = 8
        '
        'LblTotIng
        '
        Me.LblTotIng.Font = New System.Drawing.Font("Segoe UI Black", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotIng.ForeColor = System.Drawing.Color.DarkGreen
        Me.LblTotIng.Location = New System.Drawing.Point(60, 146)
        Me.LblTotIng.Name = "LblTotIng"
        Me.LblTotIng.Size = New System.Drawing.Size(95, 30)
        Me.LblTotIng.TabIndex = 9
        Me.LblTotIng.Text = "Totals"
        Me.LblTotIng.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LbltotSal
        '
        Me.LbltotSal.Font = New System.Drawing.Font("Segoe UI Black", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbltotSal.ForeColor = System.Drawing.Color.Firebrick
        Me.LbltotSal.Location = New System.Drawing.Point(217, 146)
        Me.LbltotSal.Name = "LbltotSal"
        Me.LbltotSal.Size = New System.Drawing.Size(124, 30)
        Me.LbltotSal.TabIndex = 10
        Me.LbltotSal.Text = "TotSal"
        Me.LbltotSal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblIngreso
        '
        Me.LblIngreso.Font = New System.Drawing.Font("Segoe UI Black", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblIngreso.ForeColor = System.Drawing.SystemColors.Highlight
        Me.LblIngreso.Location = New System.Drawing.Point(37, 116)
        Me.LblIngreso.Name = "LblIngreso"
        Me.LblIngreso.Size = New System.Drawing.Size(146, 30)
        Me.LblIngreso.TabIndex = 11
        Me.LblIngreso.Text = "Ingresos desde Caja "
        Me.LblIngreso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblSalidas
        '
        Me.LblSalidas.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSalidas.ForeColor = System.Drawing.SystemColors.Highlight
        Me.LblSalidas.Location = New System.Drawing.Point(219, 120)
        Me.LblSalidas.Name = "LblSalidas"
        Me.LblSalidas.Size = New System.Drawing.Size(130, 21)
        Me.LblSalidas.TabIndex = 12
        Me.LblSalidas.Text = "$alidas de Caja"
        Me.LblSalidas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgvResumenVentas
        '
        Me.dgvResumenVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvResumenVentas.Location = New System.Drawing.Point(26, 192)
        Me.dgvResumenVentas.Name = "dgvResumenVentas"
        Me.dgvResumenVentas.Size = New System.Drawing.Size(863, 97)
        Me.dgvResumenVentas.TabIndex = 13
        '
        'LblIngresos
        '
        Me.LblIngresos.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblIngresos.ForeColor = System.Drawing.Color.DarkGreen
        Me.LblIngresos.Location = New System.Drawing.Point(60, 450)
        Me.LblIngresos.Name = "LblIngresos"
        Me.LblIngresos.Size = New System.Drawing.Size(123, 32)
        Me.LblIngresos.TabIndex = 14
        Me.LblIngresos.Text = "Ingresos $"
        Me.LblIngresos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LblIngresos.Visible = False
        '
        'lblTotals
        '
        Me.lblTotals.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotals.ForeColor = System.Drawing.Color.DarkGreen
        Me.lblTotals.Location = New System.Drawing.Point(1, 450)
        Me.lblTotals.Name = "lblTotals"
        Me.lblTotals.Size = New System.Drawing.Size(123, 32)
        Me.lblTotals.TabIndex = 15
        Me.lblTotals.Text = "lblTotals"
        Me.lblTotals.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblTotals.Visible = False
        '
        'lblTotSals
        '
        Me.lblTotSals.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotSals.ForeColor = System.Drawing.Color.DarkGreen
        Me.lblTotSals.Location = New System.Drawing.Point(12, 437)
        Me.lblTotSals.Name = "lblTotSals"
        Me.lblTotSals.Size = New System.Drawing.Size(123, 32)
        Me.lblTotSals.TabIndex = 16
        Me.lblTotSals.Text = "Label1"
        Me.lblTotSals.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblTotSals.Visible = False
        '
        'lblVentasEfec
        '
        Me.lblVentasEfec.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVentasEfec.ForeColor = System.Drawing.Color.DarkGreen
        Me.lblVentasEfec.Location = New System.Drawing.Point(643, 141)
        Me.lblVentasEfec.Name = "lblVentasEfec"
        Me.lblVentasEfec.Size = New System.Drawing.Size(123, 40)
        Me.lblVentasEfec.TabIndex = 17
        Me.lblVentasEfec.Text = "lblVentasEfec"
        Me.lblVentasEfec.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalCaja
        '
        Me.lblTotalCaja.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalCaja.ForeColor = System.Drawing.Color.DarkGreen
        Me.lblTotalCaja.Location = New System.Drawing.Point(362, 144)
        Me.lblTotalCaja.Name = "lblTotalCaja"
        Me.lblTotalCaja.Size = New System.Drawing.Size(123, 40)
        Me.lblTotalCaja.TabIndex = 18
        Me.lblTotalCaja.Text = "lblTotalCaja"
        Me.lblTotalCaja.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label1.Location = New System.Drawing.Point(355, 117)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(130, 29)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Total Ape. Caja"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label2.Location = New System.Drawing.Point(636, 112)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(130, 29)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Ventas Efectivo"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label3.Location = New System.Drawing.Point(3, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(130, 29)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "$ T.Debito"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblDebito
        '
        Me.LblDebito.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDebito.ForeColor = System.Drawing.Color.DarkGreen
        Me.LblDebito.Location = New System.Drawing.Point(10, 39)
        Me.LblDebito.Name = "LblDebito"
        Me.LblDebito.Size = New System.Drawing.Size(123, 40)
        Me.LblDebito.TabIndex = 22
        Me.LblDebito.Text = "Debito"
        Me.LblDebito.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblCredito)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.LblDebito)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.Highlight
        Me.GroupBox1.Location = New System.Drawing.Point(624, 25)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(280, 83)
        Me.GroupBox1.TabIndex = 23
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "TARJETAS"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label4.Location = New System.Drawing.Point(144, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(130, 29)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "$ T.Credito"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCredito
        '
        Me.lblCredito.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCredito.ForeColor = System.Drawing.Color.DarkGreen
        Me.lblCredito.Location = New System.Drawing.Point(142, 39)
        Me.lblCredito.Name = "lblCredito"
        Me.lblCredito.Size = New System.Drawing.Size(123, 40)
        Me.lblCredito.TabIndex = 24
        Me.lblCredito.Text = "Debito"
        Me.lblCredito.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label5.Location = New System.Drawing.Point(760, 112)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(130, 29)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "Transferencia"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblTran
        '
        Me.LblTran.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTran.ForeColor = System.Drawing.Color.DarkGreen
        Me.LblTran.Location = New System.Drawing.Point(766, 136)
        Me.LblTran.Name = "LblTran"
        Me.LblTran.Size = New System.Drawing.Size(123, 40)
        Me.LblTran.TabIndex = 25
        Me.LblTran.Text = "Trans"
        Me.LblTran.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label6.Location = New System.Drawing.Point(235, 451)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(130, 29)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "Mi Dia $$"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbltotalVenta
        '
        Me.lbltotalVenta.Font = New System.Drawing.Font("Verdana", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotalVenta.ForeColor = System.Drawing.Color.Blue
        Me.lbltotalVenta.Location = New System.Drawing.Point(338, 445)
        Me.lbltotalVenta.Name = "lbltotalVenta"
        Me.lbltotalVenta.Size = New System.Drawing.Size(168, 40)
        Me.lbltotalVenta.TabIndex = 27
        Me.lbltotalVenta.Text = "$total"
        Me.lbltotalVenta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrmDineroenCaja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(918, 494)
        Me.Controls.Add(Me.lbltotalVenta)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.LblTran)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblTotalCaja)
        Me.Controls.Add(Me.lblVentasEfec)
        Me.Controls.Add(Me.lblTotSals)
        Me.Controls.Add(Me.lblTotals)
        Me.Controls.Add(Me.LblIngresos)
        Me.Controls.Add(Me.dgvResumenVentas)
        Me.Controls.Add(Me.LblSalidas)
        Me.Controls.Add(Me.LblIngreso)
        Me.Controls.Add(Me.LbltotSal)
        Me.Controls.Add(Me.LblTotIng)
        Me.Controls.Add(Me.dgvMovs)
        Me.Controls.Add(Me.BtnCerrar)
        Me.Controls.Add(Me.BtnAgregar)
        Me.Controls.Add(Me.Txtcomentarios)
        Me.Controls.Add(Me.LblComentarios)
        Me.Controls.Add(Me.lblmonto)
        Me.Controls.Add(Me.cmbMovimiento)
        Me.Controls.Add(Me.nudMonto)
        Me.Controls.Add(Me.lblCajaDinero)
        Me.Name = "FrmDineroenCaja"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Dinero en Caja"
        CType(Me.nudMonto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvMovs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvResumenVentas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblCajaDinero As Label
    Friend WithEvents nudMonto As NumericUpDown
    Friend WithEvents cmbMovimiento As ComboBox
    Friend WithEvents lblmonto As Label
    Friend WithEvents LblComentarios As Label
    Friend WithEvents Txtcomentarios As TextBox
    Friend WithEvents BtnAgregar As Button
    Friend WithEvents BtnCerrar As Button
    Friend WithEvents dgvMovs As DataGridView
    Friend WithEvents LblTotIng As Label
    Friend WithEvents LbltotSal As Label
    Friend WithEvents LblIngreso As Label
    Friend WithEvents LblSalidas As Label
    Friend WithEvents dgvResumenVentas As DataGridView
    Friend WithEvents LblIngresos As Label
    Friend WithEvents lblTotals As Label
    Friend WithEvents lblTotSals As Label
    Friend WithEvents lblVentasEfec As Label
    Friend WithEvents lblTotalCaja As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents LblDebito As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents lblCredito As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents LblTran As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lbltotalVenta As Label
End Class
