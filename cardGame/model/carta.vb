Public Class carta

    Private palo As Integer
    Private numero As Integer

    Public Sub New()
        Me.setNumero(0)
        Me.setPalo(0)
    End Sub

    Public Sub New(inPalo As Integer, inNumero As Integer)
        Me.setNumero(inNumero)
        Me.setPalo(inPalo)
    End Sub

    Public Sub New(inCarta As Object)
        Me.setNumero(inCarta.getNumero)
        Me.setPalo(inCarta.getPalo)
    End Sub

    Public Sub setNumero(inNumero As Integer)
        Me.numero = inNumero
    End Sub

    Public Sub setPalo(inPalo As Integer)
        Me.palo = inPalo
    End Sub

    Public Function getNumero() As Integer
        Return Me.numero
    End Function

    Public Function getPalo() As Integer
        Return Me.palo
    End Function

    Public Function toText(Optional numero As Integer = 1) As String

        Return "Carta" & numero & " ( " & Me.getNumero() & " , " & Me.getPalo() & " ) "

    End Function

    Public Overrides Function Equals(inCarta As Object) As Boolean

        If Me.getNumero() = inCarta.getNumero() And Me.getPalo() = inCarta.getPalo() Then
            Return True
        Else
            Return False
        End If

    End Function

End Class
