Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Drawing.Drawing2D
Public Class VentasForm
    Private ReadOnly connStr As String =
                            ConfigurationManager.
                            ConnectionStrings("MiConexion").
                            ConnectionString

    Private dtProductos As New DataTable()

    Private _mixtoController As ToggleControlsController

    Public Sub New()
        InitializeComponent()

        ' 1) Instancia el controller con el RadioButton y los controles
        _mixtoController = New ToggleControlsController(
            RBMixto,
            lblMixEfe,
            LblMixTc,
            NuDEfe,
            NudTC
        )
    End Sub


    Private Sub VentasForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' 1) Cargar productos desde BD
        Using cn As New SqlConnection(connStr),
              da As New SqlDataAdapter("dbo.sp_Productos_Inventario", cn)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.Fill(dtProductos)
        End Using

        ' 2) Configurar el combo
        With cboProducto
            .DataSource = dtProductos
            .DisplayMember = "DESCRIPCION"
            .ValueMember = "CODIGOBARRA"
            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .IntegralHeight = False
            .MaxDropDownItems = 17
            .SelectedIndex = -1
            .Text = String.Empty

        End With



        'Dim dt = New DataTable()
        'Using cn As New SqlConnection(connStr),
        ' da As New SqlDataAdapter("SELECT	Codigo AS 'CdBarras', 
        '                                    CASE WHEN activo = 0 
        '	                                THEN '(BAJA)' + '-' + Descripcion 
        '                                   ELSE Descripcion + ' ' + '( $' + CAST(Precio AS varchar) + ' )'  END AS 'DesProducto' ,
        '                                  Precio			AS 'PreVenta' , 
        '                                 Existencia      AS 'EXISTENCIAS'
        '                        FROM Productos 
        '                           ORDER BY Descripcion , Codigo ", cn)
        'da.Fill(dt)
        'End Using

        'Dim acs As New AutoCompleteStringCollection()
        'For Each r As DataRow In dt.Rows
        'acs.Add($"{r("Codigo")} | {r("Descripcion")}")
        'Next
        'cboProducto.AutoCompleteCustomSource = acs

        ' También lo puedes usar como dropdown

        'cboProducto.DataSource = dt
        'cboProducto.DisplayMember = "Descripcion"
        'cboProducto.ValueMember = "Codigo"
        'cboProducto.AutoCompleteMode = AutoCompleteMode.SuggestAppend





        Me.KeyPreview = True



    End Sub

    Private Sub ToolStripLabel2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStripLabel1_Click(sender As Object, e As EventArgs) Handles tsbF3Producto.Click

        Using f As New FrmBusquedaProductos()
            If f.ShowDialog() = DialogResult.OK Then
                AgregarLineaDesdeModal(f.ProductoSeleccionado)
            End If
            FormatearDtgVenta()

        End Using


    End Sub

    Private Sub VentasForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F3 Then
            tsbF3Producto.PerformClick()
        End If
    End Sub

    Private Sub AgregarLineaDesdeModal(drv As DataRowView)
        Dim dr = DataGridView1.Rows(DataGridView1.Rows.Add())
        dr.Cells("IdProducto").Value = drv("IdProd")
        dr.Cells("CdBarras").Value = drv("CODIGOBARRA")
        dr.Cells("DesProducto").Value = drv("Descripcion")
        dr.Cells("PreVenta").Value = drv("PRECIOPUB")
        dr.Cells("Cantidad").Value = 1D
        dr.Cells("ImporteVen").Value = drv("PRECIOPUB") * 1D
        dr.Cells("Existencia").Value = drv("EXISTENCIAS")

        'FormatearDtgVenta()

        ' With DataGridView1.Columns("ImporteVen")
        ' 1) Alinea en el centro
        '.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        ' 2) Pinta el texto de verde
        '.DefaultCellStyle.ForeColor = Color.Green

        '' 3) Aplica formato de moneda con dos decimales
        '.DefaultCellStyle.Format = "C2"
        'End With

        recalcularTotales(LblDTotal) ' Actualiza LblDTotal, LblGranTotal, etc.
    End Sub

    Private Sub recalcularTotales(lblDTotal As Label)
        Dim total As Decimal = 0D
        For Each row As DataGridViewRow In DataGridView1.Rows
            If Not row.IsNewRow Then
                total += Convert.ToDecimal(row.Cells("ImporteVen").Value)
            End If
        Next
        lblDTotal.Text = total.ToString("C2")  ' Formatea como moneda

        Dim totalCantidad As Decimal = 0D
        For Each row As DataGridViewRow In DataGridView1.Rows
            If Not row.IsNewRow Then
                totalCantidad += Convert.ToDecimal(row.Cells("Cantidad").Value)
            End If
        Next

        ' Asigna al label (sin formato decimal si quieres entero)
        LblCantPro.Text = totalCantidad.ToString("N0")


    End Sub

    Private Sub FormatearDtgVenta()
        With DataGridView1
            ' 1) Auto‐ajusta todas las columnas al contenido
            ' .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            ' 2) Centra los encabezados
            ' .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            ' 3) Formatea ImporteVen: verde, centrado, moneda
            If .Columns.Contains("ImporteVen") Then
                With .Columns("ImporteVen")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .DefaultCellStyle.ForeColor = Color.Green
                    .DefaultCellStyle.Format = "C2"
                End With
            End If
        End With
    End Sub
    Private Sub DataGridView1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) _
    Handles DataGridView1.CellEndEdit

        With DataGridView1
            ' Si editaste la columna "Cantidad"
            If .Columns(e.ColumnIndex).Name = "Cantidad" Then
                Dim row = .Rows(e.RowIndex)
                Dim precio As Decimal = Convert.ToDecimal(row.Cells("PreVenta").Value)
                Dim cantidad As Decimal = Convert.ToDecimal(row.Cells("Cantidad").Value)
                row.Cells("ImporteVen").Value = precio * cantidad

                ' Reajusta tamaño si es necesario
                .AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)

                ' Y actualiza totales de la venta
                recalcularTotales(LblDTotal)
            End If
        End With
    End Sub
    Private Sub DataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) _
    Handles DataGridView1.CellValueChanged
        ' Reúsa el mismo bloque de cálculo si lo deseas...
        With DataGridView1
            ' Si editaste la columna "Cantidad"
            If .Columns(e.ColumnIndex).Name = "Cantidad" Then
                Dim row = .Rows(e.RowIndex)
                Dim precio As Decimal = Convert.ToDecimal(row.Cells("PreVenta").Value)
                Dim cantidad As Decimal = Convert.ToDecimal(row.Cells("Cantidad").Value)
                row.Cells("ImporteVen").Value = precio * cantidad

                ' Reajusta tamaño si es necesario
                .AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)

                ' Y actualiza totales de la venta
                recalcularTotales(LblDTotal)
            End If
        End With
    End Sub

    Private Sub DataGridView1_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles DataGridView1.RowPostPaint

        ' Número de renglón = índice + 1
        Dim numero As String = (e.RowIndex + 1).ToString()

        ' Calcula el tamaño del número para centrarlo
        Dim size As SizeF = e.Graphics.MeasureString(numero, Me.Font)

        ' Dibuja el número en el RowHeader
        e.Graphics.DrawString(
            numero,
            Me.Font,
            SystemBrushes.ControlText,
            e.RowBounds.Location.X + 10,
            e.RowBounds.Location.Y + (e.RowBounds.Height - size.Height) / 2
        )

    End Sub
    Private Sub CalcularCambio()
        Dim total As Decimal
        Dim pagado As Decimal
        Dim cambio As Decimal

        ' 1) Parseamos el total desde el label (que está en formato moneda)
        If Not Decimal.TryParse(LblDTotal.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, total) Then
            total = 0D
        End If

        ' 2) Parseamos lo que ingresó el usuario en pago
        If Not Decimal.TryParse(TxtPago.Text, NumberStyles.Any, CultureInfo.CurrentCulture, pagado) Then
            pagado = 0D
        End If

        ' 3) Hacemos la resta
        cambio = pagado - total

        ' 4) Mostramos en el label formateado como moneda
        LblDCambio.Text = cambio.ToString("C2", CultureInfo.CurrentCulture)
    End Sub

    Private Sub TxtPago_Leave(sender As Object, e As EventArgs) Handles TxtPago.Leave
        CalcularCambio()
    End Sub

    Private Sub TxtPago_TextChanged(sender As Object, e As EventArgs) Handles TxtPago.TextChanged
        CalcularCambio()
    End Sub

    Private Sub BtnCobro_Click(sender As Object, e As EventArgs) Handles BtnCobro.Click
        ' 0) Validamos antes de todo
        If Not ValidateSale() Then
            Return
        End If

        CalcularCambio()
        GuardarVenta()
        FrmHistorialVentas.Show()


    End Sub

    Private Sub cboProducto_TextChanged(sender As Object, e As EventArgs) Handles cboProducto.TextChanged
        BtnEnter.Enabled = Not String.IsNullOrWhiteSpace(cboProducto.Text)
        If cboProducto.AutoCompleteCustomSource.Contains(cboProducto.Text) Then
            BtnEnter.PerformClick()
        End If
    End Sub

    Private Sub cboProducto_KeyDown(sender As Object, e As KeyEventArgs) Handles cboProducto.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            AgregarProducto()
        End If
    End Sub

    Private Sub BtnEnter_Click(sender As Object, e As EventArgs) Handles BtnEnter.Click
        AgregarProducto()
    End Sub
    Private Sub AgregarProducto()
        Dim codigoSeleccionado As String = ""

        If String.IsNullOrWhiteSpace(cboProducto.Text) Then
            MessageBox.Show("Por favor ingresa o selecciona un producto.",
                            "Información faltante",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)
            cboProducto.Focus()
            Return
        End If
        ' Si el usuario eligió de la lista, ValueMember estará lleno
        If cboProducto.SelectedIndex >= 0 Then
            codigoSeleccionado = cboProducto.SelectedValue.ToString()
        Else
            ' Si escribió libremente, tomamos el texto
            codigoSeleccionado = cboProducto.Text.Trim()
        End If

        ' 6.1) Buscamos el DataRow correspondiente
        Dim filas = dtProductos.Select(
            $"CODIGOBARRA = '{codigoSeleccionado.Replace("'", "''")}' 
             OR DESCRIPCION LIKE '%{codigoSeleccionado.Replace("'", "''")}%'")
        If filas.Length = 0 Then
            MessageBox.Show("Producto no encontrado.", "Aviso",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim prod As DataRow = filas(0)

        ' 6.2) Agregamos nuevo renglón al grid
        Dim idx = DataGridView1.Rows.Add()
        Dim row = DataGridView1.Rows(idx)
        row.Cells("IdProducto").Value = prod("IdProd")
        row.Cells("CdBarras").Value = prod("CODIGOBARRA")
        row.Cells("DesProducto").Value = prod("DESCRIPCION")
        row.Cells("PreVenta").Value = prod("PRECIOPUB")
        row.Cells("Cantidad").Value = 1D
        row.Cells("ImporteVen").Value = prod("PRECIOPUB") * 1D
        row.Cells("Existencia").Value = prod("EXISTENCIAS")

        ' 6.3) Aplica formateo y recalcula totales
        FormatearDtgVenta()
        recalcularTotales(LblDTotal)

        ' 6.4) Limpia y resitúa el foco
        cboProducto.Text = ""
        cboProducto.Focus()
    End Sub

    Private Sub GuardarVenta()
        Dim total As Decimal = Decimal.Parse(LblDTotal.Text, Globalization.NumberStyles.Currency)
        Dim usuario = Environment.UserName
        Dim ventaID As Integer
        Dim folio As Integer
        Dim metodo As String
        Dim pagoEf, pagoTc, pagoTd, pagoTr, pagoTras, cambio As Decimal
        Dim esMixto As Boolean
        ' … resto de recolección de datos …

        ' Determina el método y asigna montos
        If RbEfectivo.Checked Then
            metodo = "EFECTIVO"
            pagoEf = total
        ElseIf RBCredito.Checked Then
            metodo = "TCREDITO"
            pagoTc = total 'Decimal.Parse(txtPagoCon.Text)
        ElseIf RBDebito.Checked Then
            metodo = "TDEBITO"
            pagoTd = total 'Decimal.Parse(txtPagoCon.Text)	
        ElseIf RBTransfer.Checked Then
            metodo = "TRANSFER"
            pagoTras = total 'Decimal.Parse(txtPagoCon.Text)		
        ElseIf RBMixto.Checked Then
            metodo = "MIXTO"
            esMixto = True
            pagoEf = NuDEfe.Value
            pagoTc = NudTC.Value
            ' … otros métodos …
        End If


        If esMixto = True Then
            cambio = (pagoEf + pagoTc) - total
        Else
            cambio = LblDCambio.Text
        End If

        '   Dim cambio = If(esMixto,
        '                  (pagoEf + pagoTc) - total,
        ' Decimal.Parse(LblCambio.Text))


        Using cn As New SqlConnection(connStr)
            cn.Open()

            ' 1) Inicia la transacción
            Using tr As SqlTransaction = cn.BeginTransaction()
                Try
                    ' 2.1) Inserta cabecera
                    Using cmdCab As New SqlCommand("dbo.sp_Ventas_InsertarCabecera", cn, tr)
                        cmdCab.CommandType = CommandType.StoredProcedure
                        cmdCab.Parameters.AddWithValue("@Usuario", usuario)
                        cmdCab.Parameters.AddWithValue("@TotalVenta", total)
                        cmdCab.Parameters.AddWithValue("@MetodoPago", metodo)
                        cmdCab.Parameters.AddWithValue("@PagoEfectivo", pagoEf)
                        cmdCab.Parameters.AddWithValue("@PagoTCredito", pagoTc)
                        cmdCab.Parameters.AddWithValue("@PagoTDebito", pagoTd)
                        cmdCab.Parameters.AddWithValue("@PagoTransfer", pagoTras)
                        cmdCab.Parameters.AddWithValue("@PagoMixto", esMixto)
                        cmdCab.Parameters.AddWithValue("@Cambio", cambio)

                        ' … resto de parámetros …
                        Dim pVentaID As New SqlParameter("@VentaID", SqlDbType.Int) With {.Direction = ParameterDirection.Output}
                        Dim pFolio As New SqlParameter("@Folio", SqlDbType.Int) With {.Direction = ParameterDirection.Output}
                        cmdCab.Parameters.Add(pVentaID)
                        cmdCab.Parameters.Add(pFolio)

                        cmdCab.ExecuteNonQuery()
                        ventaID = CInt(pVentaID.Value)
                        folio = CInt(pFolio.Value)
                    End Using

                    ' 2.2) Inserta detalle y actualiza stock
                    For Each row As DataGridViewRow In DataGridView1.Rows
                        If row.IsNewRow Then Continue For

                        Using cmdDet As New SqlCommand("dbo.sp_Ventas_InsertarDetalle", cn, tr)
                            cmdDet.CommandType = CommandType.StoredProcedure
                            cmdDet.Parameters.AddWithValue("@VentaID", ventaID)
                            cmdDet.Parameters.AddWithValue("@ProductoID", CInt(row.Cells("IdProducto").Value))
                            cmdDet.Parameters.AddWithValue("@CodigoBarra", row.Cells("CdBarras").Value)
                            cmdDet.Parameters.AddWithValue("@Descripcion", row.Cells("DesProducto").Value)
                            cmdDet.Parameters.AddWithValue("@PrecioUnitario", CDec(row.Cells("PreVenta").Value))
                            cmdDet.Parameters.AddWithValue("@Cantidad", CDec(row.Cells("Cantidad").Value))
                            cmdDet.Parameters.AddWithValue("@Importe", CDec(row.Cells("ImporteVen").Value))
                            ' … resto de parámetros …
                            cmdDet.ExecuteNonQuery()
                        End Using
                    Next

                    ' 3) Si todo fue bien, confirma
                    tr.Commit()
                    MessageBox.Show($"Venta {folio} guardada.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    IniciarNuevaVenta()
                Catch ex As Exception
                    ' 4) Si algo falló, deshace
                    tr.Rollback()
                    MessageBox.Show("Error al guardar la venta: " & ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    Private Sub IniciarNuevaVenta()
        ' Limpia grid, labels, pagos, y muestra el siguiente folio
        DataGridView1.Rows.Clear()
        LblCantPro.Text = "0"
        LblDTotal.Text = FormatCurrency(0D)
        TxtPago.Clear()
        LblDCambio.Text = Nothing

        ' Actualiza el label de folio consultando la secuencia
        Using cn As New SqlConnection(connStr),
              cmd As New SqlCommand("SELECT NEXT VALUE FOR dbo.Seq_FolioVenta", cn)
            cn.Open()
            Dim nextFolio = CInt(cmd.ExecuteScalar())
            Lblticket.Text = nextFolio.ToString()
        End Using
        cboProducto.Focus()
    End Sub

    Private Sub LblDTotal_Click(sender As Object, e As EventArgs) Handles LblDTotal.Click

    End Sub

    Private Sub BtnHistorial_Click(sender As Object, e As EventArgs) Handles BtnHistorial.Click
        FrmHistorialVentas.Show()
        ' Dim frmHist As New FrmHistorialVentas()
        'frmHist.MdiParent = Me
        'frm.WindowState = FormWindowState.Maximized    ' Opcional: maximiza el hijo
        'frmHist.Show()




    End Sub

    ''' <summary>
    ''' Valida que:
    ''' 1) Al menos un método de pago esté seleccionado.
    ''' 2) El total sea mayor a 0.
    ''' 3) Haya al menos un producto en la grilla.
    ''' 4) Los montos de pago sean correctos según el método elegido.
    ''' </summary>
    ''' <returns>True si todo es válido; False si hay algún error (y muestra un mensaje).</returns>
    Private Function ValidateSale() As Boolean
        ' 1) Método de pago seleccionado
        If Not (RbEfectivo.Checked OrElse
            RBCredito.Checked OrElse
            RBDebito.Checked OrElse
            RBTransfer.Checked OrElse
            RBMixto.Checked) Then
            MessageBox.Show("Debes seleccionar al menos un método de pago.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        ' 2) Total mayor a 0
        Dim total As Decimal
        If Not Decimal.TryParse(LblDTotal.Text,
                            Globalization.NumberStyles.Currency,
                            Globalization.CultureInfo.CurrentCulture,
                            total) OrElse total <= 0D Then
            MessageBox.Show("El total de la venta debe ser mayor a cero.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        ' 3) Al menos un producto en el grid
        If DataGridView1.Rows.Cast(Of DataGridViewRow).
         Count(Function(r) Not r.IsNewRow) = 0 Then

            MessageBox.Show("Debe haber al menos un producto en la venta.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If


        ' 4) Validar montos de pago según método
        ' If RbEfectivo.Checked Then
        ' Pago en efectivo igual al total
        'If NuDEfe.Value < total Then
        'MessageBox.Show("El monto en efectivo debe cubrir el total de la venta.",
        '                   "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'NuDEfe.Focus()
        'Return False
        'End If
        'elseIf RBCredito.Checked Then
        'If NuDEfe.Value < total Then
        'MessageBox.Show("El monto en tarjeta de crédito debe cubrir el total.",
        '                   "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'nudTCredito.Focus()
        'Return False
        'End If
        'ElseIf rbTDebito.Checked Then
        'If nudTDebito.Value < total Then
        'MessageBox.Show("El monto en tarjeta de débito debe cubrir el total.",
        '                   "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'nudTDebito.Focus()
        'Return False
        'End If
        'ElseIf RBTransfer.Checked Then
        'If nudTransfer.Value < total Then
        'MessageBox.Show("El monto en transferencia debe cubrir el total.",
        '                   "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'nudTransfer.Focus()
        'Return False
        'End If
        'ElseIf RBMixto.Checked Then
        ' En mixto, sumamos efectivo + TC
        'Dim suma = nudEfectivo.Value + nudTCredito.Value + nudTDebito.Value + nudTransfer.Value
        'If suma < total Then
        'MessageBox.Show("La suma de los montos ingresados en mixto debe cubrir el total.",
        '                   "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'nudEfectivo.Focus()
        'Return False
        'End If
        'End If


        Return True
    End Function


End Class