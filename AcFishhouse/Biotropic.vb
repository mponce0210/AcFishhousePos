Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Windows.Forms
Imports Excel = Microsoft.Office.Interop.Excel

Public Class Biotropic

    Private connStr As String = ConfigurationManager _
        .ConnectionStrings("MiConexion").ConnectionString
    Private dt As DataTable
    Private dtOrder As DataTable
    Private bs As BindingSource
    Private _suppressEvents As Boolean = False

    Private Sub rdoMarca_CheckedChanged(sender As Object, e As EventArgs) Handles RdoMarca.CheckedChanged
        If RdoMarca.Checked Then
            CmbMarca.Enabled = True
            TxtBus.Enabled = False
        End If
    End Sub

    Private Sub rdodesc_CheckedChanged(sender As Object, e As EventArgs) Handles RdoDesc.CheckedChanged
        If RdoDesc.Checked Then
            CmbMarca.Enabled = False
            TxtBus.Enabled = True
            TxtBus.Focus()
        End If
    End Sub

    Private Sub rdobarras_CheckedChanged(sender As Object, e As EventArgs) Handles RdoBarras.CheckedChanged
        If RdoBarras.Checked Then
            CmbMarca.Enabled = False
            TxtBus.Enabled = True
            TxtBus.Focus()

        End If
    End Sub
    Private Sub Biotropic_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        '  AddHandler tsbExportExcel.Click, AddressOf tsbExportExcel_Click

        ' Seleccionar "Por Marca" por defecto
        RdoMarca.Checked = True
        CmbMarca.Enabled = True
        TxtBus.Enabled = False
        RdoBarras.Checked = False
        RdoDesc.Checked = False

        Dim chk As New DataGridViewCheckBoxColumn()
        chk.Name = "sel"
        chk.HeaderText = ""
        chk.Width = 30
        BioGrid.Columns.Insert(0, chk)

        ' 1) Define la consulta
        'Dim sql As String = "SELECT * FROM dbo.Biotropic"
        Dim sql As String = "select	BioPreAct	
		                            ,BioCodigoAlterno	
		                            ,'$' + ''+ Cast(BioMayoreo as varchar) as BioMayoreo
                                    ,dbo.ufn_CalcPrecioVenta(BioMayoreo, 51.00) as PrecioVta
		                            ,BioDescripcionProd	
		                            ,CodigoBarras	
		                            ,IdProdServicio	
                                    ,BioMarca	
                                    ,BioObservaciones
                              from [dbo].[Biotropic]"

        ' 2) Crea el adaptador y el DataTable
        Dim dt As New DataTable()

        Using cn As New SqlConnection(connStr),
              adapter As New SqlDataAdapter(sql, cn)

            ' 3) Llena el DataTable
            adapter.Fill(dt)
        End Using

        ' 4) Asigna al grid
        BioGrid.DataSource = dt
        GridFormatter.FormatCurrencyColumn(BioGrid, "BioMayoreo", 9.0F)
        GridFormatter.FormatCurrencyColumn(BioGrid, "PrecioVta", 9.0F)

        ' — 2) Enlaza al grid con BindingSource —
        bs = New BindingSource()
        bs.DataSource = dt
        BioGrid.DataSource = bs
        BioGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill



        With BioGrid
            ' 1) Formato moneda y alineación
            '.Columns("BioMayoreo").DefaultCellStyle.Format = "C2"
            .ReadOnly = False
            .Columns("BioMayoreo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter


            ' 2) Alineación de otras columnas numéricas (si las hay)
            .Columns("BioPreAct").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("CodigoBarras").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("IDProdServicio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            ' 3) Ancho de columnas (usando FillWeight para AutoSizeColumnsMode = Fill)
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            ' Ajusta el peso relativo de cada columna; mientras mayor FillWeight, más ancho
            .Columns("BioDescripcionProd").FillWeight = 200   ' más ancho
            .Columns("BioObservaciones").FillWeight = 200   ' más ancho
            .Columns("BioMayoreo").FillWeight = 80    ' algo más estrecho
            .Columns("BioMarca").FillWeight = 60
            .Columns("CodigoBarras").FillWeight = 70
            .Columns("IDProdServicio").FillWeight = 70
            .Columns("BioPreAct").FillWeight = 60

            ' 4) Si prefieres ancho fijo en lugar de FillWeight:
            '.Columns("Descripción").Width   = 300
            '.Columns("Observaciones").Width = 300
            ' 2) Asegúrate de que la columna de checkboxes exista y sea tipo CheckBox
            Dim chkCol = TryCast(.Columns("sel"), DataGridViewCheckBoxColumn)
            If chkCol IsNot Nothing Then
                ' 3) Permite edición SOLO en esa columna
                chkCol.ReadOnly = False

                ' 4) Opcional: centra el checkbox
                chkCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End If

            ' 5) Ajusta el modo de edición para que responda al clic
            .EditMode = DataGridViewEditMode.EditOnEnter

            If BioGrid.Columns.Contains("sel") Then
                CType(BioGrid.Columns("sel"), DataGridViewCheckBoxColumn).ReadOnly = False
            End If

            ' 5) Alineación de texto
            .Columns("BioDescripcionProd").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns("BioObservaciones").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With


        BioGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        BioGrid.ReadOnly = False ' Cambia a False si quieres permitir edición

        ' (Opcional) Ajustar encabezados para mayor claridad
        With BioGrid.Columns
            .Item("BioPreAct").HeaderText = "PreAct"
            .Item("BioCodigoAlterno").HeaderText = "Código Alterno"
            .Item("BioMayoreo").HeaderText = "Mayoreo"
            .Item("BioDescripcionProd").HeaderText = "Descripción"
            .Item("CodigoBarras").HeaderText = "Cód.Barras"
            .Item("IdProdServicio").HeaderText = "IDServicio"
            .Item("BioMarca").HeaderText = "Marca"
            .Item("BioObservaciones").HeaderText = "Observaciones"
        End With

        ' — 3) Llena cmbMarca con valores distintos —
        Dim marcas = dt.AsEnumerable() _
                       .Select(Function(r) r.Field(Of String)("BioMarca")) _
                       .Distinct() _
                       .Where(Function(m) Not String.IsNullOrWhiteSpace(m)) _
                       .OrderBy(Function(m) m) _
                       .ToList()

        CmbMarca.DataSource = marcas
        CmbMarca.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        CmbMarca.AutoCompleteSource = AutoCompleteSource.ListItems
        CmbMarca.DropDownStyle = ComboBoxStyle.DropDown

        ' — 4) Maneja el Enter para filtrar —
        AddHandler CmbMarca.KeyDown, AddressOf cmbMarca_KeyDown

        EjecutarFiltro(0, "", "")
        InitOrderGrid()
        LoadOrdersCombo()
    End Sub

    Private Sub cmbMarca_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            Dim criterio = CmbMarca.Text.Replace("'", "''").Trim()
            If criterio = "" Then
                bs.RemoveFilter()
            Else
                bs.Filter = $"BioMarca = '{criterio}'"
            End If
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) _
            Handles BtnBuscar.Click

        Dim term = TxtBus.Text.Trim().Replace("'", "''")
        Dim marca = If(CmbMarca.SelectedItem?.ToString(), "")
        Dim type As Integer

        If RdoBarras.Checked Then
            type = 1
        ElseIf RdoDesc.Checked Then
            type = 2
        ElseIf RdoDesMarca.Checked Then
            type = 3
        ElseIf RdoMarca.Checked Then
            type = 4
        Else
            type = 0
        End If

        EjecutarFiltro(type, term, marca)
    End Sub

    Private Sub EjecutarFiltro(filterType As Integer, term As String, marca As String)
        Dim dt As New DataTable()

        Using cn As New SqlConnection(connStr),
              cmd As New SqlCommand("dbo.usp_FilterBiotropic", cn)

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@FilterType", filterType)
            cmd.Parameters.AddWithValue("@Term", term)
            cmd.Parameters.AddWithValue("@Marca", marca)

            Dim adapter As New SqlDataAdapter(cmd)
            adapter.Fill(dt)
        End Using

        BioGrid.DataSource = dt
        FormatearGrid()
    End Sub

    Private Sub FormatearGrid()
        With BioGrid
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            ' Aquí puedes repetir los formatos que ya habías definido:
            .Columns("BioMayoreo").DefaultCellStyle.Format = "C2"
            .Columns("BioMayoreo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("PrecioVta").DefaultCellStyle.Format = "C2"
            .Columns("PrecioVta").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("PrecioVta").DefaultCellStyle.ForeColor = Color.Blue
            .Columns("BioDescripcionProd").FillWeight = 200
            .Columns("BioObservaciones").FillWeight = 200

        End With
    End Sub

    Private Sub CargarMarcas()
        ' Supongamos que dtMarcas ya lo llenaste antes o al vuelo:
        Dim dtMarcas As New DataTable()
        Using cn As New SqlConnection(connStr),
              cmd As New SqlCommand("   SELECT DISTINCT BioMarca 
                                        From dbo.Biotropic 
                                        WHERE BioMarca IS NOT NULL
                                        Order by 1 Asc", cn)
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(dtMarcas)
        End Using

        CmbMarca.DataSource = dtMarcas
        CmbMarca.DisplayMember = "BioMarca"
        CmbMarca.ValueMember = "BioMarca"
        CmbMarca.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        CmbMarca.AutoCompleteSource = AutoCompleteSource.ListItems
        CmbMarca.DropDownStyle = ComboBoxStyle.DropDown
    End Sub


    Public Class GridFormatter

        ''' <summary>
        ''' Formatea una columna de DataGridView con estilo bold, centrado, tamaño aumentado y formato moneda.
        ''' </summary>
        ''' <param name="grid">El DataGridView a formatear.</param>
        ''' <param name="columnName">El nombre de la columna a formatear.</param>
        ''' <param name="fontSize">Tamaño de fuente (por defecto 12).</param>
        Public Shared Sub FormatCurrencyColumn(grid As DataGridView, columnName As String, Optional fontSize As Single = 9.0F)
            If grid.Columns.Contains(columnName) Then
                Dim col = grid.Columns(columnName)
                With col.DefaultCellStyle
                    .Format = "C2"  ' Formato moneda
                    .Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Font = New Font(grid.Font.FontFamily, fontSize, FontStyle.Bold)
                End With
                ' También puedes formatear la cabecera si quieres
                col.HeaderCell.Style.Font = New Font(grid.Font.FontFamily, fontSize, FontStyle.Bold)
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            Else
                Throw New ArgumentException($"La columna '{columnName}' no existe en el DataGridView.")
            End If
        End Sub

    End Class

    Private Sub RdoDesMarca_CheckedChanged(sender As Object, e As EventArgs) Handles RdoDesMarca.CheckedChanged
        If RdoDesMarca.Checked Then
            CmbMarca.Enabled = True
            TxtBus.Enabled = True
            TxtBus.Focus()

        End If
    End Sub
    Private Sub InitOrderGrid()
        dtOrder = New DataTable()
        dtOrder.Columns.Add("BioCodigoAlterno", GetType(String))
        dtOrder.Columns.Add("OrderID", GetType(Integer))
        dtOrder.Columns.Add("BioMarca", GetType(String))
        dtOrder.Columns.Add("BioDescripcionProd", GetType(String))
        dtOrder.Columns.Add("Quantity", GetType(Integer))
        dtOrder.Columns.Add("PriceMayoreo", GetType(Decimal))
        dtOrder.Columns.Add("PriceSugerido", GetType(Decimal))
        dtOrder.Columns.Add("SumaMay", GetType(Decimal))

        OrderGrid.DataSource = dtOrder
        OrderGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        GridFormatter.FormatCurrencyColumn(OrderGrid, "PriceMayoreo", 9.0F) ', "es-MX")
        GridFormatter.FormatCurrencyColumn(OrderGrid, "PriceSugerido", 9.0F) ' , "es-MX")
        'GridFormatter.FormatCurrencyColumn(OrderGrid, "SumaMay", 9.0F)
        ' (Opcional) Centrar texto en otras columnas
        OrderGrid.Columns("Quantity").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        OrderGrid.Columns("BioDescripcionProd").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        OrderGrid.Columns("OrderID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter


    End Sub

    Private Sub BtnAgregar_Click(sender As Object, e As EventArgs) Handles BtnAgregar.Click
        ' Asegura que cualquier edición pendiente (el checkbox) se confirme
        If BioGrid.IsCurrentCellInEditMode Then
            BioGrid.EndEdit()
        End If

        For Each row As DataGridViewRow In BioGrid.Rows
            If Not row.IsNewRow AndAlso Convert.ToBoolean(row.Cells("sel").Value) Then
                ' Lee los valores
                Dim cod = row.Cells("BioCodigoAlterno").Value.ToString()
                Dim Marca = row.Cells("BioMarca").Value.ToString()
                Dim desc = row.Cells("BioDescripcionProd").Value.ToString()
                Dim cost = Convert.ToDecimal(row.Cells("BioMayoreo").Value)
                Dim suger = Convert.ToDecimal(row.Cells("PrecioVta").Value)
                Dim qty = 1

                ' Evita duplicados
                If dtOrder.Select($"BioCodigoAlterno = '{cod.Replace("'", "''")}'").Length = 0 Then
                    ' Construye la fila por nombre de columna
                    Dim nr = dtOrder.NewRow()
                    nr("BioCodigoAlterno") = cod
                    nr("BioMarca") = Marca
                    nr("BioDescripcionProd") = desc
                    nr("Quantity") = qty
                    nr("PriceMayoreo") = cost
                    nr("PriceSugerido") = suger
                    ' Si quieres la suma también:
                    nr("SumaMay") = cost * qty

                    'dtOrder.Rows.Add(nr)
                    dtOrder.Rows.InsertAt(nr, 0)
                End If
            End If
        Next

        ' Limpia las selecciones para la siguiente ronda
        ClearAllSelections()

        'Y llevamos el scroll del grid a la fila 0
        If OrderGrid.Rows.Count > 0 Then
            OrderGrid.FirstDisplayedScrollingRowIndex = 0
            OrderGrid.CurrentCell = OrderGrid.Rows(0).Cells("BioCodigoAlterno")
        End If
    End Sub


    Private Sub BtnGuardarPedido_Click(sender As Object, e As EventArgs) Handles BtnGuardarPedido.Click

        ' Si no hay pedido seleccionado → es uno nuevo
        If CmbLista.SelectedIndex < 0 Then
            CrearNuevaOrdenConLineas()
        Else
            GuardarLineasExistentes()
        End If



        'If dtOrder.Rows.Count = 0 Then
        'MessageBox.Show("No hay líneas para guardar.")
        'Return
        'End If

        'If OrderGrid.DataSource IsNot Nothing AndAlso CType(OrderGrid.DataSource, DataTable).Rows.Count > 0 _
        'AndAlso CmbLista.SelectedIndex >= 0 Then

        ' MessageBox.Show("No se puede grabar: estás viendo un pedido ya guardado.",
        '                "Advertencia",
        'MessageBoxButtons.OK,
        'MessageBoxIcon.Warning)
        'Return
        'End If

        ' 1) Comprueba que haya una orden seleccionada
        ' If CmbLista.SelectedIndex < 0 Then
        'MessageBox.Show("Primero selecciona o crea un pedido.", "Atención",
        'MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        'Return
        'End If

        ' 2) Recupera el estado Closed de la orden seleccionada
        'Dim drv As DataRowView = CType(CmbLista.SelectedItem, DataRowView)
        'Dim isClosed As Boolean = Convert.ToBoolean(drv("Closed"))

        ' 3) Si está cerrada, la bloqueamos; si está abierta, seguimos
        'If isClosed Then
        'MessageBox.Show("No se puede grabar: este pedido está cerrado.",
        '               "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'Return
        'End If

        'Dim orderID As Integer

        'Using cn As New SqlConnection(connStr),
        'cmdOrder As New SqlCommand("dbo.usp_SaveOrder", cn)

        'cn.Open()
        'cmdOrder.CommandType = CommandType.StoredProcedure
        'cmdOrder.Parameters.AddWithValue("@CreatedBy", Environment.UserName)
        'Dim pOrderID = cmdOrder.Parameters.Add("@OrderID", SqlDbType.Int)
        'pOrderID.Direction = ParameterDirection.Output

        'cmdOrder.ExecuteNonQuery()
        'orderID = Convert.ToInt32(pOrderID.Value)

        ' Guardar cada línea
        'For Each r As DataRow In dtOrder.Rows
        'Using cmdLine As New SqlCommand("dbo.usp_SaveOrderLine", cn)
        'cmdLine.CommandType = CommandType.StoredProcedure
        'cmdLine.Parameters.AddWithValue("@OrderID", orderID)
        'cmdLine.Parameters.AddWithValue("@BioMarca", r("BioMarca"))
        'cmdLine.Parameters.AddWithValue("@BioCodigoAlterno", r("BioCodigoAlterno"))
        'cmdLine.Parameters.AddWithValue("@BioDescripcionProd", r("BioDescripcionProd"))
        'cmdLine.Parameters.AddWithValue("@Quantity", r("Quantity"))
        'cmdLine.Parameters.AddWithValue("@PriceMayoreo", r("PriceMayoreo"))
        'cmdLine.Parameters.AddWithValue("@PriceSugerido", r("PriceSugerido"))
        'cmdLine.ExecuteNonQuery()
        'End Using
        'Next
        'End Using

        'MessageBox.Show($"Pedido #{orderID} guardado con {dtOrder.Rows.Count} líneas.")
        'dtOrder.Clear()
        ' GuardarLineas(dtOrder, Convert.ToInt32(drv("OrderID")))

        'MessageBox.Show("Pedido guardado correctamente.", "OK",
        'MessageBoxButtons.OK, MessageBoxIcon.Information)


    End Sub
    Private Sub ClearAllSelections()
        ' Solo aplica si existe la columna "sel"
        If BioGrid.Columns.Contains("sel") Then
            For Each row As DataGridViewRow In BioGrid.Rows
                ' Asegúrate de no tocar la fila nueva
                If Not row.IsNewRow Then
                    row.Cells("sel").Value = False
                End If
            Next
        End If
    End Sub

    Private Sub BtnBorrar_Click(sender As Object, e As EventArgs) Handles BtnBorrar.Click
        ' Limpia el grid de detalles
        'OrderGrid.DataSource = Nothing
        _suppressEvents = True
        CmbLista.SelectedIndex = -1
        ChkCerrarOrden.Checked = False
        _suppressEvents = False

        ' Limpia todas las filas de dtOrder
        dtOrder.Clear()

        ' Asegura que orderGrid siga vinculado a dtOrder
        OrderGrid.DataSource = dtOrder

        ' Opcional: restablece encabezados, formatos, etc.
        OrderGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill




    End Sub

    Private Sub LoadOrdersCombo()
        _suppressEvents = True

        Dim dt As New DataTable()
        Using cn As New SqlConnection(connStr),
              cmd As New SqlCommand("dbo.usp_GetOrdersList", cn)
            cmd.CommandType = CommandType.StoredProcedure
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(dt)

        End Using

        CmbLista.DisplayMember = "DisplayText"
        CmbLista.ValueMember = "OrderID"
        CmbLista.DataSource = dt
        CmbLista.SelectedIndex = -1

        _suppressEvents = False

        ' Manejar Enter para filtrar
        AddHandler CmbLista.KeyDown, AddressOf cmbLista_KeyDown
    End Sub
    Private Sub cmbLista_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter AndAlso CmbLista.SelectedIndex >= 0 Then
            e.Handled = True
            Dim orderID = Convert.ToInt32(CmbLista.SelectedValue)
            LoadOrderLines(orderID)
        End If
    End Sub

    Private Sub LoadOrderLines(orderID As Integer)
        Dim dt As New DataTable()
        Using cn As New SqlConnection(connStr),
          cmd As New SqlCommand("dbo.usp_GetOrderLines", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@OrderID", orderID)
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(dt)
        End Using

        dtOrder.Clear()
        For Each r As DataRow In dt.Rows
            Dim nr = dtOrder.NewRow()
            nr("BioCodigoAlterno") = r("BioCodigoAlterno")
            nr("OrderID") = r("OrderID")             ' ← ponemos aquí
            nr("BioMarca") = r("BioMarca")
            nr("BioDescripcionProd") = r("BioDescripcionProd")
            nr("Quantity") = r("Quantity")
            nr("PriceMayoreo") = r("PriceMayoreo")
            nr("PriceSugerido") = r("PriceSugerido")
            nr("SumaMay") = Convert.ToDecimal(r("Quantity")) * Convert.ToDecimal(r("PriceMayoreo"))
            dtOrder.Rows.Add(nr)
        Next



        ' OrderGrid.DataSource = dt
        'OrderGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        ' (Reaplica formato si lo tenías: p.ej. moneda, centrado, etc.)
    End Sub
    Public Sub ExportGridToExcel(grid As DataGridView)
        ' 1) Crea la instancia de Excel y un nuevo libro
        Dim xlApp As New Excel.Application
        Dim wb As Excel.Workbook = xlApp.Workbooks.Add(Type.Missing)
        Dim ws As Excel.Worksheet = CType(wb.ActiveSheet, Excel.Worksheet)

        Try
            ws.Name = "OrderLines"

            ' 2) Escribe encabezados
            For colIndex As Integer = 0 To grid.Columns.Count - 1
                ws.Cells(1, colIndex + 1) = grid.Columns(colIndex).HeaderText
            Next

            ' 3) Escribe datos fila por fila
            For rowIndex As Integer = 0 To grid.Rows.Count - 1
                For colIndex As Integer = 0 To grid.Columns.Count - 1
                    ws.Cells(rowIndex + 2, colIndex + 1) =
                        If(grid.Rows(rowIndex).Cells(colIndex).Value IsNot Nothing,
                           grid.Rows(rowIndex).Cells(colIndex).Value.ToString(), "")
                Next
            Next

            ' 4) Autofit columnas
            ws.Columns.AutoFit()

            ' 5) Muestra Excel al usuario
            xlApp.Visible = True

        Catch ex As Exception
            MessageBox.Show("Error al exportar a Excel: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            wb.Close(False)
            xlApp.Quit()
        End Try
    End Sub

    Private Sub cmbLista_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbLista.SelectedIndexChanged
        If _suppressEvents Then Return

        If CmbLista.SelectedIndex >= 0 Then
            Dim drv = CType(CmbLista.SelectedItem, DataRowView)
            Dim closed = Convert.ToBoolean(drv("Closed"))

            _suppressEvents = True        ' <<< suprimir mientras ajustamos UI
            ChkCerrarOrden.Checked = closed
            _suppressEvents = False

            ' Deshabilita o habilita botones y grid según el estado
            SetOrderEditable(Not closed)
            LoadOrderLines(Convert.ToInt32(drv("OrderID")))
        End If
    End Sub

    Private Sub SetOrderEditable(isEditable As Boolean)
        ' Si está cerrado, no puedes agregar ni grabar
        BtnAgregar.Enabled = isEditable
        BtnGuardarPedido.Enabled = isEditable
        BtnBorrar.Enabled = isEditable

        ' Y bloquea edición directa del grid de líneas
        OrderGrid.ReadOnly = Not isEditable
    End Sub

    Private Sub chkCerrarOrden_CheckedChanged(sender As Object, e As EventArgs) Handles ChkCerrarOrden.CheckedChanged

        If _suppressEvents Then Return

        If CmbLista.SelectedIndex < 0 Then Return

        Dim orderID = Convert.ToInt32(CmbLista.SelectedValue)
        Dim newStatus = ChkCerrarOrden.Checked

        ' Invoca el SP para actualizar Closed
        Using cn As New SqlConnection(connStr),
          cmd As New SqlCommand("dbo.usp_UpdateOrderStatus", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@OrderID", orderID)
            cmd.Parameters.AddWithValue("@Closed", newStatus)
            cn.Open()
            cmd.ExecuteNonQuery()
        End Using

        ' Refresca la lista de órdenes para que muestre "(CERRADO)"
        _suppressEvents = True
        LoadOrdersCombo()
        CmbLista.SelectedValue = orderID
        _suppressEvents = False

        ' Ajusta la UI
        SetOrderEditable(Not newStatus)
        MessageBox.Show(If(newStatus, "Pedido cerrado. Ya no se puede editar.", "Pedido abierto. Puede editarse."),
                    "Estado de orden", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub CrearNuevaOrdenConLineas()
        ' 1) Generar cabecera
        Dim newOrderID As Integer
        Using cn As New SqlConnection(connStr),
              cmd As New SqlCommand("dbo.usp_SaveOrder", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@CreatedBy", Environment.UserName)
            Dim pOut = cmd.Parameters.Add("@OrderID", SqlDbType.Int)
            pOut.Direction = ParameterDirection.Output

            cn.Open()
            cmd.ExecuteNonQuery()
            newOrderID = Convert.ToInt32(pOut.Value)
        End Using

        ' 2) Insertar líneas via SP modificado
        Try
            GuardarLineas(dtOrder, newOrderID)
            MessageBox.Show($"Pedido #{newOrderID} creado y líneas guardadas.", "Listo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadOrdersCombo()                ' Refrescar combo para ver el nuevo ID
            CmbLista.SelectedValue = newOrderID
        Catch ex As SqlException
            MessageBox.Show("Error guardando líneas: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Private Sub GuardarLineasExistentes()
        Dim drv = CType(CmbLista.SelectedItem, DataRowView)
        Dim orderID = Convert.ToInt32(drv("OrderID"))

        Try
            GuardarLineas(dtOrder, orderID)
            MessageBox.Show($"Líneas agregadas a la orden {orderID}.", "Listo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As SqlException
            ' Aquí capturamos el RAISERROR de SQL y lo mostramos
            MessageBox.Show(ex.Message, "No se pudo insertar",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
        LoadOrderLines(orderID)

    End Sub

    Private Sub GuardarLineas(orderTable As DataTable, orderID As Integer)
        Using cn As New SqlConnection(connStr)
            cn.Open()
            For Each row As DataRow In orderTable.Rows
                Using cmd As New SqlCommand("dbo.usp_SaveOrderLine", cn)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@OrderID", orderID)
                    cmd.Parameters.AddWithValue("@BioMarca", row("BioMarca"))
                    cmd.Parameters.AddWithValue("@BioCodigoAlterno", row("BioCodigoAlterno"))
                    cmd.Parameters.AddWithValue("@BioDescripcionProd", row("BioDescripcionProd"))
                    cmd.Parameters.AddWithValue("@Quantity", row("Quantity"))
                    cmd.Parameters.AddWithValue("@PriceMayoreo", row("PriceMayoreo"))
                    cmd.Parameters.AddWithValue("@PriceSugerido", row("PriceSugerido"))
                    cmd.ExecuteNonQuery()
                End Using
            Next
        End Using
    End Sub


End Class