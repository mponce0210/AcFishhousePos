Imports System.Configuration
Imports System.Data.SqlClient
Public Class FrmBusquedaProductos
    Private ReadOnly connStr As String =
        ConfigurationManager.
            ConnectionStrings("MiConexion").
            ConnectionString
    Public Property ProductoSeleccionado As DataRowView
    Private bsProductos As New BindingSource()

    Private Sub FrmBusquedaProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load



        'CargarProductos()
        'CargarCategorias()
    End Sub

    Private Sub CargarProductos(Optional ByVal categoryId As Integer = 0, Optional ByVal filtro As String = "")
        'Dim dt As New DataTable()
        'Using cn As New SqlConnection(connStr),
        'da As New SqlDataAdapter("dbo.sp_Productos_Inventario", cn)
        'da.SelectCommand.CommandType = CommandType.StoredProcedure
        'da.Fill(dt)
        'End Using

        'bsProductos.DataSource = dt
        'dgvProductos.DataSource = bsProductos

        Dim dt As New DataTable()
        'bsProductos.DataSource = dt
        '  Dim bs As New BindingSource()


        Try
            Using cn As New SqlConnection(connStr),
              cmd As New SqlCommand("dbo.sp_Productos_Inventario_Buscar", cn)

                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = categoryId
                cmd.Parameters.Add("@Filtro", SqlDbType.NVarChar, 100).Value = filtro

                Using da As New SqlDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using

            'bs.DataSource = dt
            bsProductos.DataSource = dt
            dgvProductos.DataSource = bsProductos

        Catch ex As Exception
            MessageBox.Show("Error al cargar productos: " & ex.Message, "Productos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


        dgvProductos.Columns("costoprov").Visible = False
        dgvProductos.Columns("CategoriaId").Visible = False

        With dgvProductos
            ' Columna Descripcion: alinear al centro
            If .Columns.Contains("Descripcion") Then
                .Columns("Descripcion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End If

            ' Columna PrecioPub: alinear, color y negrita
            If .Columns.Contains("PRECIOPUB") Then
                With .Columns("PRECIOPUB").DefaultCellStyle
                    .Alignment = DataGridViewContentAlignment.MiddleCenter
                    .ForeColor = Color.DarkGreen
                    .Font = New Font(dgvProductos.Font, FontStyle.Bold)
                End With
            End If
        End With




    End Sub

    Private Sub txtFiltro_TextChanged(sender As Object, e As EventArgs) _
       Handles txtFiltro.TextChanged

        'AplicarFiltros()
        AplicarFiltrosServer()

        '  Dim f = TxtFiltro.Text.Replace("'", "''")
        ' If f = "" Then
        'bsProductos.RemoveFilter()
        'Else
        'bsProductos.Filter = $"CodigoBarra LIKE '%{f}%' OR Descripcion LIKE '%{f}%'"
        'End If
    End Sub

    Private Sub dgvProductos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductos.CellDoubleClick
        ' If e.RowIndex < 0 Then Exit Sub
        ' ProductoSeleccionado = DirectCast(bsProductos.Current, DataRowView)

        If e.RowIndex < 0 Then Exit Sub

        Dim drv As DataRowView = TryCast(dgvProductos.Rows(e.RowIndex).DataBoundItem, DataRowView)
        If drv Is Nothing Then Exit Sub

        ProductoSeleccionado = drv

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub CargarCategorias()
        Dim dt As New DataTable()

        Try
            Using cn As New SqlConnection(connStr),
              cmd As New SqlCommand("
                SELECT 0 AS CategoryID, '-- Todas --' AS Description
                UNION ALL
                SELECT CategoryID, Description
                FROM dbo.Categories
                ORDER BY Description", cn)

                cn.Open()
                dt.Load(cmd.ExecuteReader())
            End Using

            With CmbCat
                .DataSource = dt
                .ValueMember = "CategoryID"
                .DisplayMember = "Description"
                .SelectedValue = 0 ' Selecciona "Todas"
            End With

        Catch ex As Exception
            MessageBox.Show("Error al cargar categorías: " & ex.Message, "Categorías", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub AplicarFiltros()
        Dim partes As New List(Of String)

        ' Texto
        Dim f As String = TxtFiltro.Text.Trim().Replace("'", "''")
        If f <> "" Then
            ' Usa los nombres de columna tal como vienen del SP
            partes.Add($"(CODIGOBARRA LIKE '%{f}%' OR Descripcion LIKE '%{f}%')")
        End If

        ' Categoría
        If CmbCat.SelectedIndex >= 0 AndAlso CmbCat.SelectedValue IsNot Nothing Then
            Dim cat As Integer = CInt(CmbCat.SelectedValue)
            If cat > 0 Then
                partes.Add($"(CategoryID = {cat})")
            End If
            ' Si cat = 0 => "Todas", no se agrega condición
        End If

        ' Aplicar
        If partes.Count = 0 Then
            bsProductos.RemoveFilter()
        Else
            bsProductos.Filter = String.Join(" AND ", partes)
        End If
    End Sub

    Private Sub CmbCat_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles CmbCat.SelectionChangeCommitted
        'AplicarFiltros()
        AplicarFiltrosServer()
    End Sub

    Private Sub AplicarFiltrosServer()
        ' Declaramos variable local
        Dim catId As Integer = 0

        ' Tomamos el valor de la combo
        If CmbCat.SelectedValue IsNot Nothing AndAlso IsNumeric(CmbCat.SelectedValue) Then
            catId = CInt(CmbCat.SelectedValue)
        End If

        ' Tomamos el texto del filtro
        Dim texto As String = TxtFiltro.Text.Trim()

        ' Llamamos a la carga desde el SP
        CargarProductos(catId, texto)
    End Sub

    Private Sub FrmBusquedaProductos_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        InicializarPantalla()
    End Sub


    Private Sub InicializarPantalla()
        CargarCategorias()
        CargarProductos() ' todo sin filtros
    End Sub



End Class