Public Class ToggleControlsController

    Private ReadOnly _toggle As RadioButton
    Private ReadOnly _targets As Control()

    ''' <param name="toggle">El RadioButton que activa/desactiva.</param>
    ''' <param name="targets">Los controles a mostrar/ocultar.</param>
    Public Sub New(toggle As RadioButton, ParamArray targets As Control())
        _toggle = toggle
        _targets = targets

        ' Inicializa estado al cargar
        UpdateControls()

        ' Suscribe el evento
        AddHandler _toggle.CheckedChanged, AddressOf OnToggleChanged
    End Sub

    Private Sub OnToggleChanged(sender As Object, e As EventArgs)
        UpdateControls()
    End Sub

    Private Sub UpdateControls()
        Dim visible = _toggle.Checked
        For Each c In _targets
            c.Visible = visible
            c.Enabled = visible

            ' Si es un NumericUpDown y acabamos de activar: reinicia al mínimo
            If visible AndAlso TypeOf c Is NumericUpDown Then
                Dim nud = DirectCast(c, NumericUpDown)
                nud.Value = nud.Minimum
            End If

        Next
    End Sub


End Class
