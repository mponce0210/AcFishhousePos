

Imports System.Data.SqlClient
Imports System.Configuration

Public Class mainForm
    Public Property UserRole As Integer
    Public Sub New()
        InitializeComponent()
    End Sub

    Private connStr As String = ConfigurationManager _
        .ConnectionStrings("MiConexion").ConnectionString



    Private Sub mainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub INVENTARIOFISHHOUSEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles INVENTARIOFISHHOUSEToolStripMenuItem.Click
        Dim frm As New InventarioForm()
        frm.MdiParent = Me
        frm.WindowState = FormWindowState.Maximized    ' Opcional: maximiza el hijo
        frm.Show()
    End Sub

    Private Sub BIOTROPICToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BIOTROPICToolStripMenuItem.Click

        Dim frm As New Biotropic()
        frm.MdiParent = Me
        frm.WindowState = FormWindowState.Maximized    ' Opcional: maximiza el hijo
        frm.Show()

    End Sub

    Private Sub tsbExit_Click(sender As Object, e As EventArgs) Handles tsbExit.Click
        Application.Exit()
    End Sub

    Private Sub tsbExportExcel_Click(sender As Object, e As EventArgs) Handles tsbExportExcel.Click
        Dim child = TryCast(Me.ActiveMdiChild, Biotropic)

        Dim bio As New Biotropic()
        bio.MdiParent = Me
        bio.Show()
        AddHandler tsbExportExcel.Click, Sub() bio.ExportGridToExcel(bio.OrderGrid)

        If child IsNot Nothing Then
            child.ExportGridToExcel(child.OrderGrid)
        Else
            MessageBox.Show("No hay ninguna ventana de Biotropic activa.", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub PToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PToolStripMenuItem.Click
        Dim frm As New VentasForm()
        frm.MdiParent = Me
        'frm.WindowState = FormWindowState.Maximized    ' Opcional: maximiza el hijo
        frm.Show()


    End Sub

    Private Sub TICKETToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TICKETToolStripMenuItem.Click

        Dim frm As New FrmHistorialVentas()
        frm.MdiParent = Me
        'frm.WindowState = FormWindowState.Maximized    ' Opcional: maximiza el hijo
        frm.Show()


    End Sub
End Class
