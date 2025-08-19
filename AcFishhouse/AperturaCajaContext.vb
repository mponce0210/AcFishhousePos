
' ===== AperturaCajaContext.vb (Module o Class estática) =====
Public Module AperturaCajaContext
        Public Property IdAperturaActual As Integer = 0
        Public Property Usuario As String = ""
        Public Property Terminal As String = ""
        Public Property FechaHora As DateTime = DateTime.MinValue
        Public Property MontoInicial As Decimal = 0D

        Public ReadOnly Property AperturaActiva As Boolean
            Get
                Return IdAperturaActual > 0
            End Get
        End Property

        Public Sub Limpiar()
            IdAperturaActual = 0 : Usuario = "" : Terminal = ""
            FechaHora = DateTime.MinValue : MontoInicial = 0D
        End Sub
    End Module

