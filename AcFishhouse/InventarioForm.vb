Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization
Imports System
Imports System.Windows.Forms

Public Class InventarioForm
    Private connStr As String = ConfigurationManager.
        ConnectionStrings("MiConexion").ConnectionString

    Private adapter As SqlDataAdapter
    Private ds As DataSet
    'Private bs As BindingSource
    Private bs As New BindingSource()
    Private dtInv As DataTable
    Private Sub InventarioForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Dim ds As New DataSet()
        'Using cn As New SqlConnection(connStr),
        'da As New SqlDataAdapter("dbo.sp_Productos_Listar", cn)

        'da.SelectCommand.CommandType = CommandType.StoredProcedure
        'da.Fill(ds, "Inventario")
        'End Using
        Dim fechahora As DateTime = DateTime.Now
        TSSFechahora.Text = fechahora.ToString("f", CultureInfo.InvariantCulture)

        ' dtInv = ds.Tables("Inventario")
        'bs.DataSource = dtInv
        ' bs = New BindingSource(dtInv, Nothing)
        'DtgInventario.DataSource = bs

        ' 2) Configura el DataTable y el BindingSource
        ' dtInv = ds.Tables("Inventario")
        'bs = New BindingSource(dtInv, Nothing)
        'DtgInventario.DataSource = bs

        CargarInventario()

        gbEdicion.Visible = False


        ' Cargas de combos  de Categorias y Edicion 

        CargarCategorias()      ' Para el filtro
        CargarCategoriasEdit()  ' Para el panel de edición
        CargarMarcas()      ' Para el filtro



        CargarMarcasEdit()  ' Para el panel de edición
        CargarProveedores()
        CargarProveedoresEdit()



        'CargarUnidadesMedida()
        CargarUnidadesMedidaEdit()
        ' FormatearDtgInventario()




        With DtgInventario.Columns
            If .Contains("CATEGID") Then .Item("CATEGID").Visible = False
            If .Contains("IdMarca") Then .Item("IdMarca").Visible = False
            If .Contains("IDUNIMED") Then .Item("IDUNIMED").Visible = False
            If .Contains("IdProveedor") Then .Item("IdProveedor").Visible = False
            If .Contains("IDPROD") Then .Item("IDPROD").Visible = False
        End With

        With DtgInventario
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
        End With



        ' 6) Inicializa el botón Buscar como AcceptButton (opcional)
        'Me.AcceptButton = BtnBuscar

    End Sub

    Private Sub CargarInventario()

        ' 1) Rellenar un DataSet local
        Dim dsLocal As New DataSet()
        Using cn As New SqlConnection(connStr),
          da As New SqlDataAdapter("dbo.sp_Productos_Listar", cn)

            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.Fill(dsLocal, "Inventario")
        End Using

        dtInv = dsLocal.Tables("Inventario")
        bs = New BindingSource(dtInv, Nothing)
        'bs.DataSource = dtInv
        DtgInventario.DataSource = bs

        ' 3) Formatear y ocultar columnas
        FormatearDtgInventario()
        With DtgInventario.Columns
            If .Contains("CATEGID") Then .Item("CATEGID").Visible = False
            If .Contains("IdMarca") Then .Item("IdMarca").Visible = False
            If .Contains("IDUNIMED") Then .Item("IDUNIMED").Visible = False
            If .Contains("IdProveedor") Then .Item("IdProveedor").Visible = False
            If .Contains("IDPROD") Then .Item("IDPROD").Visible = False
        End With

        ' 4) Actualizar barra de estado
        ActualizarStatus()
    End Sub

    Private Sub ActualizarStatus()
        ' Total de registros
        Dim total = dtInv.Rows.Count
        tsslTotal.Text = $"Registros: {total}"

        ' Cuenta filas con stock por debajo de mínimo
        Dim bajos = dtInv.AsEnumerable().
                 Count(Function(r) r.Field(Of Decimal)("Existencias") < r.Field(Of Decimal)("ExSMinimas"))
        TsslStockBajo.Text = $"Stock bajo: {bajos}"
    End Sub


    Private Sub FormatearDtgInventario()
        With DtgInventario
            ' 1) Auto-ajusta todas las columnas al contenido
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            .AutoResizeColumns()

            ' 2) Quitar cualquier formato numérico de la primera columna
            .Columns(0).DefaultCellStyle.Format = String.Empty

            ' 3) Negrita en COSTOPROV y PRECIOPUB
            .Columns("COSTOPROV").DefaultCellStyle.Font = New Font(.Font, FontStyle.Bold)
            .Columns("PRECIOPUB").DefaultCellStyle.Font = New Font(.Font, FontStyle.Bold)
            .Columns("PRECIOPUB").DefaultCellStyle.ForeColor = Color.DarkGreen
            .Columns("PRESUG").DefaultCellStyle.ForeColor = Color.Blue
            .Columns("PRESUG").DefaultCellStyle.Font = New Font(.Font, FontStyle.Bold)

            ' 4) Centrar la columna PRODUCTO
            .Columns("PRODUCTO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("COSTOPROV").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("PRECIOPUB").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("EXISTENCIAS").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("EXSMINIMAS").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("PRESUG").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        End With
    End Sub

    Private Sub AplicarFiltro()
        ' Sanitiza comillas simples
        Dim texto As String = txtbuscar.Text.Replace("'", "''").Trim()

        If String.IsNullOrEmpty(texto) Then
            ' Quita cualquier filtro existente
            bs.RemoveFilter()
        Else
            ' Filtra por código de barras o nombre de producto
            bs.Filter = String.Format(
                "CODIGOBAR LIKE '%{0}%' OR PRODUCTO LIKE '%{0}%'",
                texto)
        End If
    End Sub

    Private Sub CargarProveedores()
        Dim dt As New DataTable()
        Using cn As New SqlConnection(connStr),
              da As New SqlDataAdapter("
                  SELECT IdProveedor, Nombre 
                  FROM Proveedores 
                  ORDER BY Nombre", cn)
            da.Fill(dt)
        End Using

        With cboProveedor
            .DataSource = dt
            .ValueMember = "IdProveedor"
            .DisplayMember = "Nombre"
            .SelectedIndex = -1
        End With
    End Sub

    Private Sub CargarProveedoresEdit()
        Dim dt As New DataTable()
        Using cn As New SqlConnection(connStr),
              da As New SqlDataAdapter("
                  SELECT IdProveedor, Nombre 
                  FROM Proveedores 
                  ORDER BY Nombre", cn)
            da.Fill(dt)
        End Using

        With cboProveedorEdit
            .DataSource = dt
            .ValueMember = "IdProveedor"
            .DisplayMember = "Nombre"
            .SelectedIndex = -1
        End With
    End Sub
    Private Sub CargarUnidadesMedidaEdit()
        Dim dt As New DataTable()
        Using cn As New SqlConnection(connStr),
              da As New SqlDataAdapter("
                  SELECT IdUnidadMedida, Nombre 
                  FROM UnidadMedida 
                  ORDER BY Nombre", cn)
            da.Fill(dt)
        End Using

        With CboUnuidadMed
            .DataSource = dt
            .ValueMember = "IdUnidadMedida"
            .DisplayMember = "Nombre"
            .SelectedIndex = -1
        End With
    End Sub



    Private Sub CargarMarcas()
        Dim dt As New DataTable()
        Dim sql = "SELECT IdMarca, Nombre FROM dbo.Marcas ORDER BY Nombre"
        Using cn As New SqlConnection(connStr),
              da As New SqlDataAdapter(sql, cn)
            da.Fill(dt)
        End Using

        With CboMarca
            .DataSource = dt
            .ValueMember = "IdMarca"
            .DisplayMember = "Nombre"
            .SelectedIndex = -1
            .DrawMode = DrawMode.OwnerDrawFixed
        End With

        AddHandler CboMarca.DrawItem, AddressOf Combo_DrawItem
    End Sub
    Private Sub CargarMarcasEdit()
        Dim dt As New DataTable()
        Dim sql = "SELECT IdMarca, Nombre FROM dbo.Marcas ORDER BY Nombre"
        Using cn As New SqlConnection(connStr),
              da As New SqlDataAdapter(sql, cn)
            da.Fill(dt)
        End Using

        With CboMarcaEdit
            .DataSource = dt
            .ValueMember = "IdMarca"
            .DisplayMember = "Nombre"
            .SelectedIndex = -1
            .DrawMode = DrawMode.OwnerDrawFixed
        End With

        AddHandler CboMarcaEdit.DrawItem, AddressOf Combo_DrawItem
    End Sub


    Private Sub CargarCategorias()
        Dim dt As New DataTable()
        Dim sql = "SELECT CategoryID, Description FROM dbo.Categories ORDER BY Description"
        Using cn As New SqlConnection(connStr),
              da As New SqlDataAdapter(sql, cn)
            da.Fill(dt)
        End Using

        With CboCategoria
            .DataSource = dt
            .ValueMember = "CategoryID"
            .DisplayMember = "Description"
            .SelectedIndex = -1
        End With
    End Sub
    Private Sub CargarCategoriasEdit()
        Dim dt As New DataTable()
        Dim sql = "SELECT CategoryID, Description FROM dbo.Categories ORDER BY Description"
        Using cn As New SqlConnection(connStr),
              da As New SqlDataAdapter(sql, cn)
            da.Fill(dt)
        End Using

        With cboCatEdit
            .DataSource = dt
            .ValueMember = "CategoryID"
            .DisplayMember = "Description"
            .SelectedIndex = -1
        End With
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) _
            Handles btnguardar.Click


        Using cn As New SqlConnection(connStr)
            cn.Open()

            ' Recorremos solo filas añadidas o modificadas
            For Each row As DataRow In dtInv.Rows
                If row.RowState = DataRowState.Added OrElse
                   row.RowState = DataRowState.Modified Then

                    Using cmd As New SqlCommand("dbo.usp_SaveInventoryRow", cn)
                        cmd.CommandType = CommandType.StoredProcedure

                        ' Parámetros de entrada
                        cmd.Parameters.AddWithValue("@idProveedor",
                            If(row.IsNull("idProveedor"), 0, row("idProveedor")))
                        Dim sqlParameter = cmd.Parameters.AddWithValue("@Code", row("CodigoSku"))
                        cmd.Parameters.AddWithValue("@Product", row("Producto"))
                        cmd.Parameters.AddWithValue("@Category", row("Categoria"))
                        cmd.Parameters.AddWithValue("@Stock", row("Existencia"))
                        cmd.Parameters.AddWithValue("@Cost", row("Costo"))
                        cmd.Parameters.AddWithValue("@SalePrice", row("PrecioVenta"))

                        cmd.ExecuteNonQuery()
                    End Using

                    ' Marcar la fila como “aceptada” para no volver a procesar
                    row.AcceptChanges()
                End If
            Next
        End Using

        MessageBox.Show("Inventario actualizado correctamente.",
                        "OK", MessageBoxButtons.OK, MessageBoxIcon.Information)


    End Sub
    Private Sub Combo_DrawItem(sender As Object, e As DrawItemEventArgs)
        Dim cmb = DirectCast(sender, ComboBox)
        If e.Index < 0 Then Return

        ' Dibuja el fondo y el foco
        e.DrawBackground()

        ' Prepara formato centrado
        Using sf As New StringFormat()
            sf.Alignment = StringAlignment.Center
            sf.LineAlignment = StringAlignment.Center
            e.Graphics.DrawString(
                cmb.GetItemText(cmb.Items(e.Index)),
                e.Font,
                Brushes.Black,
                e.Bounds,
                sf)
        End Using

        e.DrawFocusRectangle()
    End Sub

    Private Sub BtnBuscar_Click(sender As Object, e As EventArgs) Handles BtnBuscar.Click, TsbBuscar.Click
        AplicarFiltro()
    End Sub
    Private Sub FrmInventario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.AcceptButton = BtnBuscar
        ' … aquí tus llamadas a CargarCombos(), CargarGrid(), etc.
    End Sub

    Private Sub BtnEditar_Click(sender As Object, e As EventArgs) Handles BtnEditar.Click, tsbEditar.Click

        ' 1) Verifica que haya una fila seleccionada
        If DtgInventario.SelectedRows.Count = 0 Then
            MessageBox.Show("Por favor selecciona un producto para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' 2) Obtén el DataRowView del BindingSource
        Dim drv As DataRowView = DirectCast(bs.Current, DataRowView)

        ' 3) Puebla cada control con los valores del registro
        lblid.Text = drv("IdProd").ToString()
        TxtCodigo.Text = drv("CodigoBar").ToString()
        TxtDescripcion.Text = drv("Producto").ToString()

        'cboCatEdit.SelectedValue = If(IsDBNull(drv("CATEGID")), Nothing, drv("CATEGID"))
        cboCatEdit.SelectedValue = If(IsDBNull(drv("CATEGID")), -1, drv("CATEGID"))
        'CboMarcaEdit.SelectedValue = If(IsDBNull(drv("IDMARCA")), Nothing, drv("IDMARCA"))
        CboMarcaEdit.SelectedValue = If(IsDBNull(drv("IDMARCA")), -1, drv("IDMARCA"))
        'CboUnuidadMed.SelectedValue = If(IsDBNull(drv("IDUNIMED")), Nothing, drv("IDUNIMED"))
        CboUnuidadMed.SelectedValue = If(IsDBNull(drv("IDUNIMED")), -1, drv("IDUNIMED"))
        'cboProveedorEdit.SelectedValue = If(IsDBNull(drv("IdPROVEEDOR")), Nothing, drv("IdPROVEEDOR"))
        cboProveedorEdit.SelectedValue = If(IsDBNull(drv("IdPROVEEDOR")), -1, drv("IdPROVEEDOR"))

        NudExistencia.Value = Convert.ToDecimal(drv("Existencias"))
        numMinimo.Value = Convert.ToDecimal(drv("ExSMinimas"))
        nudCosto.Value = Convert.ToDecimal(drv("CostoProv"))
        nudPrecio.Value = Convert.ToDecimal(drv("PrecioPub"))

        ChkActivo.Checked = Convert.ToBoolean(drv("Alta"))

        ' 4) Muestra el panel y enfoca en el primer campo
        gbEdicion.Visible = True
        TxtCodigo.Focus()
    End Sub

    Private Sub BtnRefrescar_Click(sender As Object, e As EventArgs)
        CargarInventario()
    End Sub

    Private Sub TlSBtnrefresh_Click(sender As Object, e As EventArgs) Handles TlSBtnrefresh.Click
        Call CargarInventario()
    End Sub

    Private Sub TStripBtnGrabar_Click(sender As Object, e As EventArgs) Handles TStripBtnGrabar.Click
        Try
            If MessageBox.Show("¿Estás seguro de guardar este producto?",
                       "Confirmar Guardado",
                       MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question) <> DialogResult.Yes Then
                Return
            End If

            ' 1) Captura valores desde los controles
            Dim idProd As Integer? = Nothing
            If Not String.IsNullOrEmpty(TxtDescripcion.Text) Then
                idProd = CInt(lblid.Text)
            End If

            Dim codigo As String = TxtCodigo.Text.Trim()
            Dim descripcion As String = TxtDescripcion.Text.Trim()
            Dim categoriaId As Object = If(cboCatEdit.SelectedIndex > -1, cboCatEdit.SelectedValue, DBNull.Value)
            Dim Cuantos As Decimal = NumCuantos.Value
            Dim existencia As Decimal = NudExistencia.Value
            Dim minimo As Decimal = numMinimo.Value
            Dim costo As Decimal = nudCosto.Value
            Dim precio As Decimal = nudPrecio.Value
            Dim activo As Boolean = ChkActivo.Checked
            Dim marcaId As Object = If(CboMarcaEdit.SelectedIndex > -1, CboMarcaEdit.SelectedValue, DBNull.Value)
            Dim unidadMed As Object = If(CboUnuidadMed.SelectedIndex > -1, CboUnuidadMed.SelectedValue, DBNull.Value)
            Dim proveedorId As Object = If(cboProveedorEdit.SelectedIndex > -1, cboProveedorEdit.SelectedValue, DBNull.Value)

            Using cn As New SqlConnection(connStr),
                  cmd As New SqlCommand("dbo.sp_Producto_Actualizar", cn)

                cmd.CommandType = CommandType.StoredProcedure

                ' Agrega parámetros
                cmd.Parameters.AddWithValue("@IdProducto", If(idProd.HasValue, idProd.Value, 0))
                cmd.Parameters.AddWithValue("@Codigo", codigo)
                cmd.Parameters.AddWithValue("@Descripcion", descripcion)
                cmd.Parameters.AddWithValue("@CategoriaId", categoriaId)
                cmd.Parameters.AddWithValue("@Existencia", existencia)
                cmd.Parameters.AddWithValue("@Minimo", minimo)
                cmd.Parameters.AddWithValue("@Costo", costo)
                cmd.Parameters.AddWithValue("@Precio", precio)
                cmd.Parameters.AddWithValue("@Activo", activo)
                cmd.Parameters.AddWithValue("@MarcaId", marcaId)
                cmd.Parameters.AddWithValue("@UnidadMedida", unidadMed)
                cmd.Parameters.AddWithValue("@ProveedorId", proveedorId)
                cmd.Parameters.AddWithValue("@Cuantos", Cuantos)

                cn.Open()
                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("Producto guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error al guardar producto: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        gbEdicion.Visible = False
        ' Refresca el grid y el estado
        CargarInventario()
        AplicarFiltro()
        'txtcuantos.Text = Nothing
        NumCuantos.Value = 0

        'End Sub
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        gbEdicion.Visible = False
    End Sub

    Private Sub BtnNuevo_Click(sender As Object, e As EventArgs) Handles BtnNuevo.Click
        ' 1) Limpia todos los campos
        lblid.Text = 0         ' Id vacío → SP hará INSERT
        TxtCodigo.Clear()
        TxtDescripcion.Clear()
        cboCatEdit.SelectedIndex = -1
        CboMarcaEdit.SelectedIndex = -1
        CboUnuidadMed.SelectedIndex = -1
        cboProveedorEdit.SelectedIndex = -1

        NudExistencia.Value = 0
        numMinimo.Value = 0
        nudCosto.Value = 0D
        nudPrecio.Value = 0D

        ChkActivo.Checked = True
        TxtCodigo.Focus()

        ' 2) Muestra el panel
        gbEdicion.Visible = True

        ' 3) Deselecciona cualquier fila en el grid
        DtgInventario.ClearSelection()
    End Sub

    Private Sub txtbuscar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtbuscar.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True      ' Evita el “ding” del sistema
            'BtnBuscar.PerformClick()
            AplicarFiltro()
            e.SuppressKeyPress = True ' Simula el clic en tu botón
        End If
    End Sub

    Private Sub TsbNuevo_Click(sender As Object, e As EventArgs) Handles TsbNuevo.Click

        BtnNuevo_Click(Nothing, Nothing)

    End Sub




End Class