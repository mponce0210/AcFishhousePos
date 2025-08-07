Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Public Class FrmHistorialVentas
    Private ReadOnly connStr As String =
                            ConfigurationManager.
                            ConnectionStrings("MiConexion").
                            ConnectionString

    Dim dtTickets = New DataTable()
    Private bsTickets As New BindingSource()

    Private Sub FrmHistorialVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Using da As New SqlDataAdapter("dbo.sp_HistorialVentas_Listar", connStr)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.AddWithValue("@SearchTerm", TxtBuscarTicket.Text.Trim())
            da.SelectCommand.Parameters.AddWithValue("@Fecha", DtpFiltro.Value.Date)
            dtTickets.Clear()
            da.Fill(dtTickets)
        End Using
        DgvTickets.DataSource = dtTickets

        dtTickets = New DataTable()
        bsTickets.DataSource = dtTickets
        DgvTickets.DataSource = bsTickets

        AddHandler TxtBuscarTicket.TextChanged, AddressOf FiltroCambiado
        AddHandler DtpFiltro.ValueChanged, AddressOf FiltroCambiado
        AddHandler BtnHoy.Click, AddressOf BtnHoy_Click

        ' 3) Primera carga
        CargarTickets()

        FormatearHistorial()
    End Sub

    Private Sub dgvTickets_SelectionChanged(sender As Object, e As EventArgs) _
    Handles DgvTickets.SelectionChanged
        If DgvTickets.CurrentRow Is Nothing Then Exit Sub
        Dim ventaID = CInt(DgvTickets.CurrentRow.Cells("Ticket").Value)
        CargarDetalle(ventaID)
    End Sub

    Private Sub CargarDetalle(ventaID As Integer)
        Dim dtDetalle = New DataTable()

        Using da As New SqlDataAdapter("dbo.sp_HistorialVentas_Detalle", connStr)
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.AddWithValue("@VentaID", ventaID)
            dtDetalle.Clear()
            da.Fill(dtDetalle)
        End Using
        DgvDetalle.DataSource = dtDetalle
    End Sub

    Private Sub FormatearHistorial()
        ' 1) Ajusta el Panel1 al ancho del grid Tickets + un poco de margen
        ScHistorial.SplitterDistance = DgvTickets.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) + 40

        ' 2) Encabezados de dgvTickets alineados centro
        With DgvTickets
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            ' 3) Datos centrados, importe en verde y centrado
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If .Columns.Contains("Importe") Then
                With .Columns("Importe")
                    .DefaultCellStyle.ForeColor = Color.Green
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .DefaultCellStyle.Format = "C2"
                End With
            End If
        End With

        ' 4) Haz Panel2 más ancho (opcionalmente: deja menos espacio para Panel1)
        ScHistorial.SplitterDistance = ScHistorial.Width \ 2   ' mitad y mitad

        ' 5) Actualiza el título del GroupBox con el número de ticket seleccionado
        Dim ventaID As Integer = 0
        If DgvTickets.CurrentRow IsNot Nothing Then
            Dim cellValue = DgvTickets.CurrentRow.Cells("Ticket").Value
            If Not IsNothing(cellValue) AndAlso Not IsDBNull(cellValue) Then
                Integer.TryParse(cellValue.ToString(), ventaID)
            End If
        End If
        GbDetalleTicket.Text = $"Ticket {ventaID}"

        ' 6) Actualiza lblFolioDetalle
        Dim folioText = "000000"
        If DgvTickets.CurrentRow IsNot Nothing Then
            Dim fval = DgvTickets.CurrentRow.Cells("Folio").Value
            If Not IsDBNull(fval) Then folioText = fval.ToString()
        End If
        lblfolioDetalle.Text = $"Folio: {folioText}"

        ' 7) Actualiza lblFechaHora con la fecha real de la venta
        If DgvTickets.CurrentRow IsNot Nothing Then
            Dim dtVal = DgvTickets.CurrentRow.Cells("Fecha").Value
            If Not IsDBNull(dtVal) Then
                Dim d As Date = CDate(dtVal)
                lblFechaHora.Text = d.ToString("dd 'de' MMMM yyyy hh:mm tt")
            Else
                lblFechaHora.Text = ""
            End If
        Else
            lblFechaHora.Text = ""
        End If

        ' 8) Oculta la columna de línea en el detalle si existe
        If DgvDetalle.Columns.Contains("Linea") Then
            DgvDetalle.Columns("Linea").Visible = False
        End If

        ' 9) Centra los encabezados de dgvDetalle
        DgvDetalle.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        ' 10) Alineaciones y color en dgvDetalle
        With DgvDetalle
            If .Columns.Contains("Cant") Then
                .Columns("Cant").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
            If .Columns.Contains("Descripcion") Then
                .Columns("Descripcion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End If
            If .Columns.Contains("Importe") Then
                With .Columns("Importe")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .DefaultCellStyle.ForeColor = Color.Green
                    .DefaultCellStyle.Format = "C2"
                End With
            End If

            If .Columns.Contains("Descripcion") Then
                Dim colDesc = .Columns("Descripcion")

                ' 2) Alineación de encabezado y de celda
                colDesc.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                colDesc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

                ' 3) Ajusta el ancho para que encaje al contenido
                colDesc.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

                ' 4) Muestra la columna
                .FirstDisplayedScrollingColumnIndex = colDesc.Index
            End If
            'Dim colDesc = .Columns("Descripcion")

            ' 2) Alineación de encabezado y de celda
            'colDesc.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            'colDesc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            ' 3) Ajusta el ancho para que quepa exactamente el texto visible
            'colDesc.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

            ' 4) (Opcional) Si luego quieres volver a un modo Fill,
            '    puedes almacenar el ancho resultante y luego:
            'Dim w As Integer = colDesc.Width
            'colDesc.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            'colDesc.Width = w

            ' 5) Asegúrate de que la columna esté en pantalla si necesitas desplazar:
            '.FirstDisplayedScrollingColumnIndex = colDesc.Index



        End With
    End Sub

    Private Sub CargarTickets()
        Dim searchTerm As String = TxtBuscarTicket.Text.Trim()
        ' Usa DBNull.Value si la caja está vacía
        ' 1) Param SearchTerm o DBNull
        Dim paramSearch As Object =
        If(String.IsNullOrEmpty(searchTerm),
           DBNull.Value,
           CType(searchTerm, Object))

        ' 2) Param Fecha o DBNull
        Dim paramFecha As Object =
        If(DtpFiltro.Checked,         ' asegúrate de que dtpFiltro.ShowCheckBox = True
           CType(DtpFiltro.Value.Date, Object),
           DBNull.Value)

        dtTickets.Clear()
        Using cn As New SqlConnection(connStr),
              da As New SqlDataAdapter("dbo.sp_HistorialVentas_Listar", cn)

            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.AddWithValue("@SearchTerm", paramSearch)
            da.SelectCommand.Parameters.AddWithValue("@Fecha", paramFecha)

            da.Fill(dtTickets)
        End Using

        ' Selecciona la primera fila (si existe) para disparar el detalle
        If DgvTickets.Rows.Count > 0 Then
            DgvTickets.Rows(0).Selected = True
            DgvTickets.CurrentCell = DgvTickets.Rows(0).Cells("Ticket")
        End If

        FormatearHistorial()
    End Sub

    Private Sub FiltroCambiado(sender As Object, e As EventArgs)
        CargarTickets()

    End Sub

    Private Sub BtnHoy_Click(sender As Object, e As EventArgs)
        DtpFiltro.Value = DateTime.Today
        CargarTickets()
    End Sub

    Private Sub BtnImprimir_Click(sender As Object, e As EventArgs) Handles BtnImprimir.Click

        Call GenerarYGuardarTicketPDF()
        Dim rutaPdf = GenerarYGuardarTicketPDF()
        MessageBox.Show($"Ticket guardado en:{vbCrLf}{rutaPdf}",
                        "PDF Generado", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Function GenerarYGuardarTicketPDF() As String
        ' 1) Define rutas
        Dim baseDir = Path.Combine(Application.StartupPath, "ticketsACFH")
        Dim fechaCarp = DateTime.Now.ToString("yyyyMMdd")
        Dim folderPath = Path.Combine(baseDir, fechaCarp)
        If Not Directory.Exists(folderPath) Then
            Directory.CreateDirectory(folderPath)
        End If

        'Dim folio = lblfolioDetalle.Text
        'Dim timeStamp = DateTime.Now.ToString("HHmmss")
        'Dim fileName = $"Ticket_{folio}_{timeStamp}.pdf"
        'Dim pdfPath = Path.Combine(folderPath, fileName)

        ' 1) Obtén el folio como cadena limpia
        Dim folioRaw As String = lblfolioDetalle.Text    ' "Folio: 6"
        Dim folioNum As String = folioRaw.Replace("Folio:", "").Trim()
        ' Ahora folioNum = "6"

        ' 2) Construye el nombre de archivo
        Dim timeStamp As String = DateTime.Now.ToString("HHmmss")
        Dim fileName As String = $"Ticket_{folioNum}_{timeStamp}.pdf"

        ' 3) Asegúrate de que folderPath exista
        If Not Directory.Exists(folderPath) Then
            Directory.CreateDirectory(folderPath)
        End If

        ' 4) Combina sin caracteres inválidos
        Dim pdfPath As String = Path.Combine(folderPath, fileName)


        ' 2) Prepara el documento
        Dim doc As New Document(PageSize.A6, 10, 10, 10, 10)
        Using fs = New FileStream(pdfPath, FileMode.Create, FileAccess.Write, FileShare.None)
            Dim writer = PdfWriter.GetInstance(doc, fs)
            doc.Open()

            ' Fuente monoespacio
            Dim fontTitle = FontFactory.GetFont(FontFactory.COURIER_BOLD, 12)
            Dim fontNorm = FontFactory.GetFont(FontFactory.COURIER, 8)

            ' Encabezado
            doc.Add(New Paragraph("ACUARIO FISH HOUSE", fontTitle))
            doc.Add(New Paragraph($"Folio: {folioNum}", fontNorm))
            doc.Add(New Paragraph($"Fecha: {DateTime.Now:dd/MM/yyyy HH:mm}", fontNorm))
            doc.Add(New Paragraph(New String("-"c, 32), fontNorm))

            ' Columnas del detalle
            Dim tabla As New PdfPTable({1.0F, 4.0F, 2.0F}) With {.WidthPercentage = 100}
            tabla.AddCell(New PdfPCell(New Phrase("C", fontNorm)))
            tabla.AddCell(New PdfPCell(New Phrase("Descripción", fontNorm)))
            tabla.AddCell(New PdfPCell(New Phrase("Importe", fontNorm)))

            ' Líneas del DataGridView1
            For Each r As DataGridViewRow In DgvDetalle.Rows
                If r.IsNewRow Then Continue For
                tabla.AddCell(New PdfPCell(New Phrase(r.Cells("Cant").Value.ToString(), fontNorm)))
                tabla.AddCell(New PdfPCell(New Phrase(r.Cells("Descripcion").Value.ToString(), fontNorm)))
                tabla.AddCell(New PdfPCell(New Phrase(
                    Convert.ToDecimal(r.Cells("Importe").Value).ToString("C2"),
                    fontNorm)))
            Next

            doc.Add(tabla)
            doc.Add(New Paragraph(New String("-"c, 32), fontNorm))

            ' Totales
            ' doc.Add(New Paragraph($"TOTAL: {LblGranTotal.Text}", fontNorm))
            ' doc.Add(New Paragraph($"Pago con: {txtPagoCon.Text}", fontNorm))
            'doc.Add(New Paragraph($"Cambio : {LblDCambio.Text}", fontNorm))

            doc.Close()
        End Using

        Return pdfPath
    End Function


End Class