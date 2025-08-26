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
        FormatearGrids()

    End Sub

    Private Sub dgvTickets_SelectionChanged(sender As Object, e As EventArgs) _
    Handles DgvTickets.SelectionChanged
        ' If DgvTickets.CurrentRow Is Nothing Then Exit Sub

        ' 1) Si el grid está vacío o no hay fila actual, no hagas nada
        If DgvTickets Is Nothing OrElse DgvTickets.Rows.Count = 0 Then Exit Sub
        If DgvTickets.CurrentRow Is Nothing OrElse DgvTickets.CurrentRow.IsNewRow Then Exit Sub

        'Dim ventaID = CInt(DgvTickets.CurrentRow.Cells("Ticket").Value)
        Dim obj = DgvTickets.CurrentRow.Cells("Ticket").Value
        Dim ventaID As Integer
        If obj Is Nothing OrElse obj Is DBNull.Value _
       OrElse Not Integer.TryParse(obj.ToString(), ventaID) Then
            ' (Opcional) limpia detalle si quieres
            'LimpiarDetalle()
            'DgvTickets.AllowUserToAddRows = False
            Exit Sub
        End If


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
        'Dim ventaID As Integer = 0
        'If DgvTickets.CurrentRow IsNot Nothing Then
        'Dim cellValue = DgvTickets.CurrentRow.Cells("Ticket").Value
        'If Not IsNothing(cellValue) AndAlso Not IsDBNull(cellValue) Then
        'Integer.TryParse(cellValue.ToString(), ventaID)
        'End If
        'End If
        'GbDetalleTicket.Text = $"Ticket {ventaID}"

        ' 6) Actualiza lblFolioDetalle
        'Dim folioText = "000000"
        'If DgvTickets.CurrentRow IsNot Nothing Then
        'Dim fval = DgvTickets.CurrentRow.Cells("Folio").Value
        'If Not IsDBNull(fval) Then folioText = fval.ToString()
        'End If
        'lblfolioDetalle.Text = $"Folio: {folioText}"

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

        'Call GenerarYGuardarTicketPDF()
        'Call GenerarTicketPDF_EstiloTienda()
        'Dim rutaPdf = GenerarYGuardarTicketPDF()

        Dim rutaPdf = GenerarTicketPDF_EstiloTienda()
        MessageBox.Show($"Ticket guardado en:{vbCrLf}{rutaPdf}",
                        "PDF Generado", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Call SeleccionarEnExplorador(rutaPdf)

        If File.Exists(rutaPdf) Then
            Process.Start(New ProcessStartInfo(rutaPdf) With {.UseShellExecute = True})
        End If

        Call AbrirWhatsAppWeb(TxtNumW.Text, rutaPdf)


        TxtNumW.Text = Nothing

        'Call AbrirPdf(rutaPdf)

        ' Dim ruta = GenerarTicketPDF_EstiloTienda()
        ' Process.Start(New ProcessStartInfo(ruta) With {.UseShellExecute = True})

    End Sub

    Private Function GenerarYGuardarTicketPDF() As String
        ' 1) Define rutas
        'Dim baseDir = Path.Combine(Application.StartupPath, "ticketsACFH")
        Dim baseDir As String = "C:\TicketsACFH"
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

    Private Sub DgvTickets_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DgvTickets.RowEnter
        ' Obtiene la fila que acaba de entrar
        Dim row = DgvTickets.Rows(e.RowIndex)
        If row.IsNewRow Then Return

        ' 1) Ticket (para el GroupBox)
        Dim ticketId As Integer
        If Not Integer.TryParse(row.Cells("Ticket").Value?.ToString(), ticketId) Then
            ticketId = 0
        End If
        GbDetalleTicket.Text = $"Ticket {ticketId}"

        ' 2) Folio
        Dim folioVal = row.Cells("Folio").Value?.ToString()
        If String.IsNullOrEmpty(folioVal) Then folioVal = "000000"
        lblfolioDetalle.Text = $"Folio: {folioVal}"

        ' 3) Fecha y hora
        Dim fechaVal As DateTime
        If DateTime.TryParse(row.Cells("Fecha").Value?.ToString(), fechaVal) Then
            lblFechaHora.Text = fechaVal.ToString("dd 'de' MMMM yyyy hh:mm tt")
        Else
            lblFechaHora.Text = String.Empty
        End If

        ' 4) Total de la venta
        Dim importe As Decimal
        If Decimal.TryParse(row.Cells("Importe").Value?.ToString(), importe) Then
            TxtTotal.Text = importe.ToString("C2")
        Else
            TxtTotal.Clear()
        End If

        ' 5) Limpia el campo de Pago Con
        TxtPagoConDetalle.Clear()

        ' 6) Y ahora, si tienes lógica para recargar el detalle:
        CargarDetalle(ticketId)

        ' (Opcional) si quieres volver a formatear el grid detalle:
        FormatearHistorial()
        FormatearGrids()
    End Sub

    Private Sub FormatearGrids()
        ' 1) Define las fuentes

        Dim fontHeader As New System.Drawing.Font("Segoe UI", 8, System.Drawing.FontStyle.Bold)
        Dim fontCell As New System.Drawing.Font("Segoe UI", 8, System.Drawing.FontStyle.Regular)

        ' 1) Define las fuentes
        'Dim fontHeader As New Font("Segoe UI", 10, FontStyle.Bold)
        'Dim fontCell As New Font("Segoe UI", 9, FontStyle.Regular)

        ' 2) Aplica a dgvTickets
        With DgvTickets
            .EnableHeadersVisualStyles = False
            .ColumnHeadersDefaultCellStyle.Font = fontHeader
            .DefaultCellStyle.Font = fontCell
            ' (Opcional) ajusta altura de fila para que entre bien la celda
            .RowTemplate.Height = Math.Max(.RowTemplate.Height, CInt(fontCell.GetHeight() + 8))
        End With

        ' 3) Aplica a dgvDetalle
        With DgvDetalle
            .EnableHeadersVisualStyles = False
            .ColumnHeadersDefaultCellStyle.Font = fontHeader
            .DefaultCellStyle.Font = fontCell
            .RowTemplate.Height = Math.Max(.RowTemplate.Height, CInt(fontCell.GetHeight() + 8))
        End With
    End Sub

    Private Sub EnviarPorWhatsApp(numeroCliente As String)
        ' Número con prefijo internacional, sin "+" ni espacios, por ejemplo: "5215512345678"
        Dim texto = Uri.EscapeDataString(
        $"Hola, le comparto su ticket folio {GbDetalleTicket.Text}.")
        Dim url = $"https://api.whatsapp.com/send?phone={numeroCliente}&text={texto}"

        Process.Start(New ProcessStartInfo(url) With {.UseShellExecute = True})
    End Sub

    Private Sub BtnEnviarWs_Click(sender As Object, e As EventArgs) Handles BtnEnviarWs.Click
        'Call EnviarPorWhatsApp(TxtNumW.Text)
        Dim f As New FrmWhatsapp
        ' f.MdiParent = Me              ' <- esta línea lo hace hijo del MDI
        'f.StartPosition = FormStartPosition.CenterParent  ' o Manual
        'f.WindowState = FormWindowState.Maximized         ' opcional: que llene el área
        f.Show()
    End Sub

    Private Function GenerarTicketPDF_EstiloTienda() As String
        ' ==== 1) Carpeta destino ====
        Dim baseDir As String = "C:\TicketsACFH"
        Dim fechaCarp As String = DateTime.Now.ToString("yyyyMMdd")
        Dim folderPath = Path.Combine(baseDir, fechaCarp)
        If Not Directory.Exists(folderPath) Then
            Directory.CreateDirectory(folderPath)
        End If

        ' ==== 2) Nombre de archivo ====
        Dim folioNum As String = lblfolioDetalle.Text.Replace("Folio:", "").Trim() ' <- ajusta si tu lbl trae otro formato
        Dim timeStamp As String = DateTime.Now.ToString("HHmmss")
        Dim fileName As String = $"Ticket_{folioNum}_{timeStamp}.pdf"
        Dim pdfPath As String = Path.Combine(folderPath, fileName)

        ' ==== 3) Documento 80 mm (≈ 226.8 pt) ====
        Dim ticketWidth As Single = 226.8F   ' 80 mm
        Dim ticketHeight As Single = 800.0F  ' alto libre
        Dim pageRect As New Rectangle(ticketWidth, ticketHeight)
        Dim doc As New Document(pageRect, 12, 12, 10, 10) ' márgenes

        Using fs = New FileStream(pdfPath, FileMode.Create, FileAccess.Write, FileShare.None)
            Dim writer = PdfWriter.GetInstance(doc, fs)
            doc.Open()

            ' ==== 4) Fuentes monoespacio ====
            Dim fTitle = FontFactory.GetFont(FontFactory.COURIER_BOLD, 12)
            Dim fBold = FontFactory.GetFont(FontFactory.COURIER_BOLD, 8)
            Dim fNorm = FontFactory.GetFont(FontFactory.COURIER, 8)

            ' ==== 5) Logo (opcional) ====
            Try
                ' opción A: desde Resources

                ' Si el recurso es una imagen .NET (Bitmap, PNG, JPG)…
                Dim bmp As System.Drawing.Image = My.Resources.removebg2   ' <— tu recurso
                Using ms As New MemoryStream()
                    ' Guarda el recurso en memoria como PNG
                    bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
                    ms.Position = 0

                    ' Crea la imagen para iTextSharp desde el byte[]
                    Dim logo As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(ms.ToArray())
                    logo.ScaleToFit(80.0F, 50.0F)
                    logo.Alignment = iTextSharp.text.Element.ALIGN_LEFT
                    logo.SpacingAfter = 6.0F
                    doc.Add(logo)
                End Using

            Catch
                ' opción B: desde archivo (descomenta y ajusta ruta si quieres)
                'Dim logo As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance("C:\ruta\logo.png")
                'logo.ScaleToFit(80.0F, 50.0F) : logo.Alignment = Element.ALIGN_LEFT : logo.SpacingAfter = 6.0F
                'doc.Add(logo)
            End Try

            ' ==== 6) Encabezado ====
            doc.Add(New Paragraph("ACUARIO FISH HOUSE", fTitle))
            doc.Add(New Paragraph("Ave. Real de Cumbres #707 altos C.P. 64346", fNorm))
            doc.Add(New Paragraph("Col. Real de Cumbres Mty, NL", fNorm))
            doc.Add(New Paragraph("Tel: 81 1936 9169", fNorm))
            doc.Add(New Paragraph(New String("-"c, 54), fNorm))
            doc.Add(New Paragraph($"Folio: {folioNum}", fNorm))
            doc.Add(New Paragraph($"Fecha: {DateTime.Now:dd/MM/yyyy HH:mm}", fNorm))
            doc.Add(New Paragraph(New String("-"c, 54), fNorm))
            doc.Add(Chunk.Newline)

            ' ==== 7) Encabezados “tabla” sin bordes ====
            Dim tabla As New PdfPTable(3) With {
                .WidthPercentage = 100
            }
            tabla.SetWidths(New Single() {1.0F, 4.4F, 1.6F}) ' Cant, Descripción, Importe

            ' Celdas de encabezado
            tabla.AddCell(New PdfPCell(New Phrase("Cant.", fBold)) With {.Border = Rectangle.NO_BORDER})
            tabla.AddCell(New PdfPCell(New Phrase("Descripción", fBold)) With {.Border = Rectangle.NO_BORDER})
            tabla.AddCell(New PdfPCell(New Phrase("Importe", fBold)) With {.Border = Rectangle.NO_BORDER, .HorizontalAlignment = Element.ALIGN_RIGHT})

            ' ==== 8) Renglones desde dgvDetalle ====
            Dim total As Decimal = 0D
            For Each r As DataGridViewRow In DgvDetalle.Rows
                If r.IsNewRow Then Continue For

                Dim cant As Decimal = 0D
                Dim desc As String = ""
                Dim imp As Decimal = 0D

                Decimal.TryParse(Convert.ToString(r.Cells("Cant").Value), cant)
                desc = Convert.ToString(r.Cells("Descripcion").Value)
                Decimal.TryParse(Convert.ToString(r.Cells("Importe").Value), imp)

                total += imp

                ' Cantidad
                tabla.AddCell(New PdfPCell(New Phrase(cant.ToString("0.##"), fNorm)) With {
                    .Border = Rectangle.NO_BORDER
                })
                ' Descripción (corta si es demasiado larga)
                Dim descMostrar = If(desc IsNot Nothing, desc, "")
                If descMostrar.Length > 42 Then descMostrar = descMostrar.Substring(0, 42)
                tabla.AddCell(New PdfPCell(New Phrase(descMostrar, fNorm)) With {
                    .Border = Rectangle.NO_BORDER
                })
                ' Importe
                tabla.AddCell(New PdfPCell(New Phrase(imp.ToString("$0.00"), fNorm)) With {
                    .Border = Rectangle.NO_BORDER,
                    .HorizontalAlignment = Element.ALIGN_RIGHT
                })
            Next

            doc.Add(tabla)
            doc.Add(Chunk.Newline)
            doc.Add(New Paragraph(New String("-"c, 54), fNorm))

            ' ==== 9) Totales / pago / cambio ====
            Dim pagoConTxt As String = TxtPagoConDetalle.Text.Trim()
            Dim pagoCon As Decimal = 0D
            Decimal.TryParse(pagoConTxt, pagoCon)
            Dim cambio As Decimal = Math.Max(0D, pagoCon - total)

            Dim pTotal As New Paragraph($"Total: {total.ToString("$0.00")}", fBold)
            pTotal.Alignment = Element.ALIGN_RIGHT
            doc.Add(pTotal)

            If pagoCon > 0D Then
                Dim pPago As New Paragraph($"Pago:  {pagoCon.ToString("$0.00")}", fNorm) With {.Alignment = Element.ALIGN_RIGHT}
                doc.Add(pPago)
                Dim pCambio As New Paragraph($"Cambio: {cambio.ToString("$0.00")}", fNorm) With {.Alignment = Element.ALIGN_RIGHT}
                doc.Add(pCambio)
            End If

            doc.Add(Chunk.Newline)

            ' ==== 10) Mensaje y enlaces ====
            doc.Add(New Paragraph("**Somos tu opción de confianza para representar", fNorm))
            doc.Add(New Paragraph("la naturaleza en tu acuario.**", fNorm))
            doc.Add(Chunk.Newline)

            Dim aSitio As New Anchor("www.acuariofishhouse.com", fNorm) With {.Reference = "https://www.acuariofishhouse.com"}
            doc.Add(aSitio)
            doc.Add(Chunk.Newline)
            doc.Add(Chunk.Newline)

            Dim aFb1 As New Anchor("Facebook: https://www.facebook.com/fish.house.mx", fNorm) With {.Reference = "https://www.facebook.com/fish.house.mx"}
            doc.Add(aFb1)
            doc.Add(Chunk.Newline)
            doc.Add(Chunk.Newline)

            Dim aFb2 As New Anchor("https://www.facebook.com/acuariosypecesmty", fNorm) With {.Reference = "https://www.facebook.com/acuariosypecesmty"}
            doc.Add(aFb2)
            doc.Add(Chunk.Newline)
            doc.Add(Chunk.Newline)

            Dim aWa As New Anchor("WhatsApp: 81 2647 5360", fNorm) With {.Reference = "https://wa.me/528126475360"}
            doc.Add(aWa)
            doc.Add(Chunk.Newline)

            Dim GAcuario As New Anchor("Garantia Politica a Acuarios", fNorm) With {.Reference = "https://tinyurl.com/Garantia-Pecera"}
            doc.Add(GAcuario)
            doc.Add(Chunk.Newline)

            Dim GFiltrosCas As New Anchor("Garantia Politica Filtros y Cascadas", fNorm) With {.Reference = "https://tinyurl.com/Garantia-Filtros-Cascadas"}
            doc.Add(GFiltrosCas)
            doc.Add(Chunk.Newline)
            doc.Add(Chunk.Newline)

            Dim GoogleOpinion As New Anchor("Tu Opinion es importante deja tu Reseña", fNorm) With {.Reference = "https://g.page/r/CSCBxzG2hvdzEBM/review"}
            doc.Add(GoogleOpinion)
            doc.Add(Chunk.Newline)
            doc.Add(Chunk.Newline)

            Dim gracias As New Paragraph("**** Gracias por su compra. Síganos en redes para promociones ****", fBold)
            gracias.Alignment = Element.ALIGN_CENTER
            doc.Add(gracias)

            doc.Close()
        End Using
        Return pdfPath

    End Function

    Private Sub SeleccionarEnExplorador(pdfPath As String)
        If File.Exists(pdfPath) Then
            Dim psi As New ProcessStartInfo With {
                .FileName = "explorer.exe",
                .Arguments = "/select,""" & pdfPath & """",
                .UseShellExecute = True
            }
            Process.Start(psi)
        End If
    End Sub

    Private Sub AbrirWhatsAppWeb(telefono As String, pdfPath As String)
        ' Tel. con código país, sin + ni espacios (p.ej. 5218123456789)
        If String.IsNullOrWhiteSpace(telefono) Then Exit Sub
        Dim msg = $"Hola, le compartimos su ticket de compra  {Path.GetFileName(pdfPath)}."
        Dim url = "https://api.whatsapp.com/send?phone=" & telefono &
                  "&text=" & Uri.EscapeDataString(msg)
        Process.Start(New ProcessStartInfo(url) With {.UseShellExecute = True})
    End Sub

End Class