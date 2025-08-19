Imports System.Configuration
Imports System.Data.SqlClient
Public Class FrmDineroenCaja

    Private connStr As String = ConfigurationManager.
        ConnectionStrings("MiConexion").ConnectionString


    Private Sub CargarCatalogo()
        Dim dt As New DataTable()
        Using cn As New SqlConnection(connStr),
              cmd As New SqlCommand("
             SELECT IdMovimiento, CONCAT(Nombre,' (',Tipo,')') AS Nombre
             FROM dbo.CatDineroEnCaja WHERE Activo=1 ORDER BY Nombre", cn)
            cn.Open() : dt.Load(cmd.ExecuteReader())
        End Using
        cmbMovimiento.DataSource = dt
        cmbMovimiento.ValueMember = "IdMovimiento"
        cmbMovimiento.DisplayMember = "Nombre"
    End Sub
    Private Sub CargarMovimientos()
        Dim dt As New DataTable()
        Using cn As New SqlConnection(connStr),
              cmd As New SqlCommand("dbo.sp_DineroEnCaja_Listar", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@IdAperturaCaja", AperturaCajaContext.IdAperturaActual)
            Using da As New SqlDataAdapter(cmd)
                da.Fill(dt)
            End Using
        End Using
        dgvMovs.DataSource = dt

        ' Totales
        Using cn As New SqlConnection(connStr),
              cmd As New SqlCommand("dbo.sp_DineroEnCaja_Sumatoria", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@IdAperturaCaja", AperturaCajaContext.IdAperturaActual)
            cn.Open()
            Using r = cmd.ExecuteReader()
                If r.Read() Then
                    LblTotIng.Text = Convert.ToDecimal(If(r("TotalIngresos"), 0)).ToString("$#,##0.00")
                    LbltotSal.Text = Convert.ToDecimal(If(r("TotalSalidas"), 0)).ToString("$#,##0.00")
                End If
            End Using
        End Using
    End Sub


    Private Sub dgvMovs_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvMovs.KeyDown

        Dim usuario = Environment.UserName

        If e.KeyCode = Keys.Delete AndAlso dgvMovs.CurrentRow IsNot Nothing Then
            Dim id As Integer = CInt(dgvMovs.CurrentRow.Cells("IdDineroCaja").Value)
            If MessageBox.Show("¿Anular el movimiento seleccionado?", "Dinero en Caja", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                Using cn As New SqlConnection(connStr),
                      cmd As New SqlCommand("dbo.sp_DineroEnCaja_Anular", cn)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@IdDineroCaja", id)
                    cmd.Parameters.AddWithValue("@Usuario", usuario)
                    cn.Open() : cmd.ExecuteNonQuery()
                End Using
                CargarMovimientos()
            End If
        End If
    End Sub

    Private Sub FrmDineroenCaja_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not AperturaCajaContext.AperturaActiva Then
            MessageBox.Show("No hay apertura activa.", "Dinero en Caja") : Close() : Return
        End If
        CargarCatalogo()
        CargarMovimientos()
        CargarResumenVentas()
        ActualizarSumatorias()
        nudMonto.DecimalPlaces = 2 : nudMonto.Minimum = 0.01D : nudMonto.Maximum = 10000000D


    End Sub

    Private Sub BtnAgregar_Click(sender As Object, e As EventArgs) Handles BtnAgregar.Click
        If cmbMovimiento.SelectedValue Is Nothing Then
            MessageBox.Show("Selecciona un movimiento.") : Return
        End If
        If nudMonto.Value <= 0 Then
            MessageBox.Show("Monto debe ser mayor a 0.") : Return
        End If

        Dim usuario = Environment.UserName

        Using cn As New SqlConnection(connStr),
              cmd As New SqlCommand("dbo.sp_DineroEnCaja_Agregar", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@IdAperturaCaja", AperturaCajaContext.IdAperturaActual)
            cmd.Parameters.AddWithValue("@IdCatMovimiento", CInt(cmbMovimiento.SelectedValue))
            cmd.Parameters.AddWithValue("@Monto", nudMonto.Value)
            cmd.Parameters.AddWithValue("@Usuario", usuario)         ' o tu usuario
            cmd.Parameters.AddWithValue("@TerminalName", AperturaCajaContext.Terminal)
            cmd.Parameters.AddWithValue("@Comentarios", If(String.IsNullOrWhiteSpace(Txtcomentarios.Text), DBNull.Value, Txtcomentarios.Text.Trim()))
            Dim pOut As New SqlParameter("@IdDineroCaja", SqlDbType.Int) With {.Direction = ParameterDirection.Output}
            cmd.Parameters.Add(pOut)

            cn.Open()
            cmd.ExecuteNonQuery()
        End Using

        nudMonto.Value = 0.01D
        Txtcomentarios.Clear()
        CargarMovimientos()
        CargarResumenVentas()
        ActualizarSumatorias()
    End Sub

    Private Sub CargarResumenVentas()
        Dim dt As New DataTable()
        Using cn As New SqlConnection(connStr),
          cmd As New SqlCommand("dbo.sp_VentasCabecera_ResumenApertura", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@IdAperturaCaja", AperturaCajaContext.IdAperturaActual)
            Using da As New SqlDataAdapter(cmd)
                da.Fill(dt)
            End Using
        End Using

        ' Formato seguro (solo si la columna existe)
        dgvResumenVentas.AutoGenerateColumns = True
        dgvResumenVentas.DataSource = dt

        Dim cols() As String = {
                                 "TotalEfectivo", "TotalTCredito", "TotalTDebito",
                                    "TotalTransfer", "TotalVentas"}

        For Each colName As String In cols
            Dim c = dgvResumenVentas.Columns(colName)
            If c IsNot Nothing Then
                c.DefaultCellStyle.Format = "c2"
                c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
        Next

        Dim cNum = dgvResumenVentas.Columns("NumVentas")
        If cNum IsNot Nothing Then
            cNum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End If
    End Sub

    Private Sub ActualizarSumatorias()
        Dim dt As New DataTable()
        Using cn As New SqlConnection(connStr),
          cmd As New SqlCommand("dbo.sp_Caja_ResumenApertura", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@IdAperturaCaja", AperturaCajaContext.IdAperturaActual)
            Using da As New SqlDataAdapter(cmd)
                da.Fill(dt)
            End Using
        End Using

        If dt.Rows.Count = 0 Then
            ' Resetea etiquetas si no hay datos
            lblTotals.Text = 0D.ToString("c2")
            LbltotSal.Text = 0D.ToString("c2")
            LblDebito.Text = 0D.ToString("c2")
            lblCredito.Text = 0D.ToString("c2")
            LblTran.Text = 0D.ToString("c2")
            lbltotalVenta.Text = 0D.ToString("c2")
            If Me.Controls.ContainsKey("lblVentasEfec") Then lblVentasEfec.Text = 0D.ToString("c2")
            If Me.Controls.ContainsKey("lblTotalCaja") Then lblTotalCaja.Text = 0D.ToString("c2")
            If Me.Controls.ContainsKey("LblDebito") Then LblDebito.Text = "0"
            If Me.Controls.ContainsKey("lblCredito") Then lblCredito.Text = "0"
            If Me.Controls.ContainsKey("LblTran") Then LblTran.Text = "0"
            If Me.Controls.ContainsKey("lbltotalVenta") Then lbltotalVenta.Text = "0"
            Exit Sub
        End If

        Dim r = dt.Rows(0)
        Dim ingresos As Decimal = If(IsDBNull(r("TotalIngresos")), 0D, CDec(r("TotalIngresos")))
        Dim salidas As Decimal = If(IsDBNull(r("TotalSalidas")), 0D, CDec(r("TotalSalidas")))
        Dim vEfec As Decimal = If(IsDBNull(r("VentasEfectivo")), 0D, CDec(r("VentasEfectivo")))
        Dim totalCaja As Decimal = If(IsDBNull(r("TotalCaja")), 0D, CDec(r("TotalCaja")))
        Dim pdebito As Decimal = If(IsDBNull(r("PagotDebito")), 0D, CDec(r("PagotDebito")))
        Dim pcredito As Decimal = If(IsDBNull(r("PagotCredito")), 0D, CDec(r("PagotCredito")))
        Dim ptransfer As Decimal = If(IsDBNull(r("Pagotransfer")), 0D, CDec(r("PagoTransfer")))
        Dim totalVenta As Decimal = If(IsDBNull(r("TotalVenta")), 0D, CDec(r("TotalVenta")))

        ' Pinta cifras en tus etiquetas
        lblTotals.Text = ingresos.ToString("c2")
        LbltotSal.Text = salidas.ToString("c2")
        LblDebito.Text = pdebito.ToString("c2")
        lblCredito.Text = pcredito.ToString("c2")
        LblTran.Text = ptransfer.ToString("c2")
        lbltotalVenta.Text = totalVenta.ToString("c2")



        If Me.Controls.ContainsKey("lblVentasEfec") Then
            lblVentasEfec.Text = vEfec.ToString("c2")
        End If
        If Me.Controls.ContainsKey("lblTotalCaja") Then
            lblTotalCaja.Text = totalCaja.ToString("c2")
        End If

        ' Estética opcional
        lblTotals.ForeColor = Color.DarkGreen
        LbltotSal.ForeColor = Color.Firebrick
    End Sub


End Class