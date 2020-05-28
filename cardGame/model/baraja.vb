Public Class baraja

    Private cartas As New List(Of carta)

    Public Sub Baraja()
        If Me.cartas Is Nothing = False Then
            Me.cartas.Clear()
        End If

        For p As Integer = 1 To 4
            For n As Integer = 1 To 13
                Me.cartas.Add(New carta(p, n))
            Next
        Next

    End Sub

    Public Function getBaraja() As List(Of carta)
        Return Me.cartas
    End Function

    Public Sub barajar()
        'Fisher-Yates Shuffle
        Dim j As Integer
        Dim temp As carta
        Dim random As New Random()

        For i As Integer = 51 To 0 Step -1

            j = random.Next(0, i + 1)

            temp = Me.cartas(i)
            Me.cartas(i) = Me.cartas(j)
            Me.cartas(j) = temp
        Next i

    End Sub

    Public Overrides Function ToString() As String
        Dim barajaString As String = ""
        Dim count As Integer = 1

        For Each carta As carta In Me.cartas
            barajaString += carta.toText(count) & " | "
            count += 1
        Next carta

        Return barajaString
    End Function

    Public Function repartirCarta() As carta
        Dim range As Integer = Me.cartas.Count - 1
        Dim carta As New carta(Me.cartas(range))

        Me.cartas.RemoveAt(range)

        Return carta

    End Function

End Class
