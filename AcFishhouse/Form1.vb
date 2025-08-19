

Imports System.Data.SqlClient
Imports System.Configuration

Public Class mainForm
    Public Property UserRole As Integer
    Private _aperturaSolicitada As Boolean = False
    Private _inicioEvaluado As Boolean = False

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

    Private Sub mainForm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If _aperturaSolicitada Then Return
        _aperturaSolicitada = True

        RefrescarStatus()

        ' 1) ¿Hay apertura ABIERTA de esta terminal?
        If CargarAperturaAbiertaPorTerminal() Then
            ' Ya hay apertura activa -> ir directo a Dinero en Caja
            MessageBox.Show(
            $"Ya existe una apertura ABIERTA desde {AperturaCajaContext.FechaHora:dd/MM/yyyy HH:mm}." &
            Environment.NewLine &
            "Continuaremos con esa apertura y podrás registrar movimientos.",
            "Apertura detectada", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Using f As New FrmDineroenCaja()
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog(Me)
            End Using

            RefrescarStatus()

        Else
            ' 2) No hay apertura -> solicitarla
            Using f As New FrmAperturaCaja()
                f.StartPosition = FormStartPosition.CenterParent
                If f.ShowDialog(Me) <> DialogResult.OK Then
                    ' Si no abrió, no permitimos operar
                    Me.Close()
                    Return
                End If
            End Using

            ' 3) Recomendado: abrir Dinero en Caja tras crearla
            Using f As New FrmDineroenCaja()
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog(Me)
            End Using
            RefrescarStatus()
        End If

        ' (Opcional) actualiza barra de estado con la apertura/terminal


    End Sub

    Private Sub MostrarAperturaDeCaja()
        Using f As New FrmAperturaCaja()
            ' Centrar respecto al MDI
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)    ' El owner es el MDI
        End Using

        ' Si canceló y no hay apertura, cierra el MDI (o vuelve a pedir)
        If Not AperturaCajaContext.AperturaActiva Then
            MessageBox.Show("Debes abrir turno para continuar.", "POS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()   ' o: MostrarAperturaDeCaja() para insistir
            'Else
            ' (Opcional) habilita menús / toolbars ahora que hay apertura
            '   HabilitarMenus(True)
        End If
    End Sub

    Private Sub DINEROENCAJAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DINEROENCAJAToolStripMenuItem.Click
        Dim frm As New FrmDineroenCaja()
        frm.MdiParent = Me
        '  frm.WindowState = FormWindowState.Maximized    ' Opcional: maximiza el hijo
        frm.Show()
    End Sub

    Private Function CargarAperturaAbiertaPorTerminal() As Boolean
        Dim dt As New DataTable()
        Using cn As New SqlConnection(connStr),
          cmd As New SqlCommand("dbo.sp_AperturaCaja_GetAbiertaPorTerminal", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@TerminalName", Environment.MachineName)
            Using da As New SqlDataAdapter(cmd)
                da.Fill(dt)
            End Using
        End Using

        If dt.Rows.Count = 0 Then
            AperturaCajaContext.Limpiar()
            Return False
        End If

        Dim r = dt.Rows(0)
        AperturaCajaContext.IdAperturaActual = CInt(r("IdAperturaCaja"))
        AperturaCajaContext.Usuario = CStr(r("UsuarioAperturaName"))
        AperturaCajaContext.Terminal = CStr(r("TerminalName"))
        AperturaCajaContext.FechaHora = CDate(r("FechaHoraApertura"))
        AperturaCajaContext.MontoInicial = CDec(r("MontoInicial"))
        Return True
    End Function
    Private Sub RefrescarStatus()
        Dim dt As New DataTable()
        Using cn As New SqlConnection(connStr),
          cmd As New SqlCommand("dbo.sp_StatusPOS_Lite", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@TerminalName", Environment.MachineName)
            'cmd.Parameters.AddWithValue("@Username", UsuarioContext.Username)
            cmd.Parameters.AddWithValue("@Username", Environment.MachineName)
            Using da As New SqlDataAdapter(cmd)
                da.Fill(dt)
            End Using
        End Using

        If dt.Rows.Count = 0 Then
            ' Fallback mínimo
            tssUsuario.Text = $"Usuario:"
            tssCaja.Text = "Caja: SIN APERTURA"
            tssTerminal.Text = $"Terminal: {Environment.MachineName}"
            tssObs.Text = "Obs: —"
            tssUltAct.Text = "Últ. act.: —"
            tssAfirme.Text = "Afirme: no configurada"
            tssRiesgo.Text = ""
            tssCaja.ForeColor = Color.Gray
            tssRiesgo.ForeColor = SystemColors.ControlText
            Return
        End If

        Dim r = dt.Rows(0)

        Dim usuario As String = CStr(r("Usuario"))
        Dim estadoCaja As String = CStr(r("EstadoCaja"))
        Dim idApert As String = If(IsDBNull(r("IdAperturaCaja")), "—", r("IdAperturaCaja").ToString())
        Dim fechaApert As String = If(IsDBNull(r("FechaApertura")), "—", CDate(r("FechaApertura")).ToString("dd/MM HH:mm"))
        Dim terminal As String = CStr(r("TerminalName"))
        Dim obs As String = If(IsDBNull(r("ObservacionesApertura")), "—", CStr(r("ObservacionesApertura")))
        Dim ultAct As String = If(IsDBNull(r("UltimaActividad")), "—", CDate(r("UltimaActividad")).ToString("HH:mm"))

        Dim meta As Decimal = If(IsDBNull(r("MetaMensual")), 0D, CDec(r("MetaMensual")))
        Dim acum As Decimal = If(IsDBNull(r("AcumuladoMes")), 0D, CDec(r("AcumuladoMes")))
        Dim restante As Decimal = If(IsDBNull(r("Restante")), 0D, CDec(r("Restante")))
        Dim diasRest As Integer = If(IsDBNull(r("DiasRestantesMes")), 0, CInt(r("DiasRestantesMes")))
        Dim riesgo As Boolean = Not IsDBNull(r("RiesgoPenalizacion")) AndAlso CBool(r("RiesgoPenalizacion"))

        ' Pinta etiquetas
        tssUsuario.Text = $"Usuario: {usuario}"
        tssCaja.Text = $"Caja: {estadoCaja} — Apertura #{idApert} — {fechaApert}"
        tssTerminal.Text = $"Terminal: {terminal}"
        tssObs.Text = $"Obs: {obs}"
        tssUltAct.Text = $"Últ. act.: {ultAct}"

        If meta > 0D Then
            tssAfirme.Text = $"Afirme: {acum.ToString("c2")} / Meta {meta.ToString("c2")} — Restan {restante.ToString("c2")} — {diasRest} días"
        Else
            tssAfirme.Text = "Afirme: meta no configurada"
        End If

        ' Colores de estado
        Select Case estadoCaja.ToUpperInvariant()
            Case "ABIERTA" : tssCaja.ForeColor = Color.DarkGreen
            Case "CERRADA" : tssCaja.ForeColor = Color.Firebrick
            Case Else : tssCaja.ForeColor = Color.Gray
        End Select

        If riesgo Then
            tssRiesgo.Text = "¡Riesgo de penalización AFIRME!"
            tssRiesgo.ForeColor = Color.Firebrick
        Else
            tssRiesgo.Text = ""
            tssRiesgo.ForeColor = SystemColors.ControlText
        End If
    End Sub


End Class
