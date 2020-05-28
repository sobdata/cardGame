Public Class jugador

    Private id As Integer
    Private mano As New List(Of carta)

    Public Sub New(inID As Integer)
        Me.setID(inID)
    End Sub

    Public Function getID() As Integer
        Return Me.id
    End Function

    Public Sub setID(inID As Integer)
        Me.id = inID
    End Sub

    Public Sub setMano(cantidad As Integer, baraja As Object)
        If Me.mano Is Nothing = False Then
            Me.mano.Clear()
        End If


        For i As Integer = 0 To cantidad - 1
            Me.mano.Add(baraja.repartirCarta)
        Next

    End Sub

    Public Function getMano() As List(Of carta)
        Return mano
    End Function

    Public Function getManoString() As String
        Dim manoString As String = ""
        Dim count As Integer = 1

        For Each carta As carta In Me.mano
            manoString += carta.toText(count)
            count += 1
        Next

        Return "Mano: " & manoString & "Total: " & calcularMano()

    End Function

    Public Function calcularMano() As Integer
        Dim totalValor As Integer = 0

        For Each carta As carta In Me.mano
            totalValor += carta.getNumero
        Next

        Return totalValor

    End Function

End Class