Public Class AboutBox
    Private Sub AboutBox_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lblNombreSistema.Text = "FishHouse POS"
        lblVersion.Text = "Versión: " & Application.ProductVersion
        lblEmpresa.Text = "© 2025 Acuario Fish House"
        LblSist.Text = "Sistema de ventas y control de inventario para el Acuario."
        lblmke.Text = "Desarrollado por: ING.MIKE PONCE"
    End Sub
End Class