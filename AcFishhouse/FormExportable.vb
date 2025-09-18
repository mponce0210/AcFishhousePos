Imports System.Windows.Forms
Imports ClosedXML.Excel

Public Class FormExportable
    Inherits Form

    ' >>>> OVERRIDE ESTOS DOS EN CADA FORM <<<<

    ' 1) Devuelve el DataGridView que quieres exportar
    Protected Overridable Function GridAExportar() As DataGridView
        Return Nothing
    End Function

    ' 2) Nombre base sugerido del archivo
    Protected Overridable ReadOnly Property NombreArchivoSugerido As String
        Get
            Return Me.Name & "_" & Date.Now.ToString("yyyyMMdd")
        End Get
    End Property

    ' --- Implementación común de exportación ---
    Public Sub ExportarAExcel()
        Dim dgv = GridAExportar()
        If dgv Is Nothing OrElse dgv.Rows.Count = 0 Then
            MessageBox.Show("No hay datos para exportar.", "Exportar a Excel",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Using sfd As New SaveFileDialog With {
            .Filter = "Excel (*.xlsx)|*.xlsx",
            .FileName = NombreArchivoSugerido & ".xlsx"
        }
            If sfd.ShowDialog() <> DialogResult.OK Then Exit Sub

            ' Pasamos el contenido visible del grid a un DataTable
            Dim dt As New DataTable()
            For Each col As DataGridViewColumn In dgv.Columns
                If col.Visible Then dt.Columns.Add(col.HeaderText)
            Next

            For Each row As DataGridViewRow In dgv.Rows
                If row.IsNewRow Then Continue For
                Dim vals(dt.Columns.Count - 1) As Object
                Dim i As Integer = 0
                For Each col As DataGridViewColumn In dgv.Columns
                    If col.Visible Then
                        vals(i) = row.Cells(col.Index).Value
                        i += 1
                    End If
                Next
                dt.Rows.Add(vals)
            Next

            ' Crear el Excel
            Using wb As New XLWorkbook()
                Dim ws = wb.AddWorksheet("Datos")
                ws.Cell(1, 1).InsertTable(dt, "Tabla", True)
                ws.Columns().AdjustToContents()
                wb.SaveAs(sfd.FileName)
            End Using

            MessageBox.Show("Archivo generado.", "Exportar a Excel",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Using
    End Sub

End Class
