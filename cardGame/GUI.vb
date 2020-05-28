Imports System.IO
Public Class GUI
    Dim rutaDatos As String = "..\..\..\datos.txt"

    Dim rutaImg As String = Strings.Left(My.Computer.FileSystem.CurrentDirectory, My.Computer.FileSystem.CurrentDirectory.Length - 9)

    Dim baraja As New baraja

    Dim jugador As New List(Of jugador)

    Dim max As Integer = 0

    Dim ganador(3) As String

    Dim palo() As String = {"C", "D", "H", "S"}

    Private Sub GUI_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        For i As Integer = 0 To 3
            jugador.Add(New jugador(i))
        Next

        j1Score.Text = "PartidasG: " & getDato(0)
        j2Score.Text = "PartidasG: " & getDato(1)
        j3Score.Text = "PartidasG: " & getDato(2)
        j4Score.Text = "PartidasG: " & getDato(3)

    End Sub

    Private Sub btnNuevaPartidad_Click(sender As Object, e As EventArgs) Handles btnNuevaPartidad.Click
        baraja.Baraja()
        baraja.barajar()

        For i As Integer = 0 To 3
            jugador(i).setMano(5, baraja)
        Next

        max = 0

        For i As Integer = 0 To 3
            If jugador(i).calcularMano >= max Then
                max = jugador(i).calcularMano
            End If
        Next

        For i As Integer = 0 To 3
            If jugador(i).calcularMano = max Then
                guardarDato(1, jugador(i).getID)
                ganador(i) = "1"
            Else
                ganador(i) = "0"
            End If
        Next

        If ganador(0) = "1" Then
            j1Resultado.BackColor = Color.Green
        Else
            j1Resultado.BackColor = Color.Red
        End If

        If ganador(1) = "1" Then
            j2Resultado.BackColor = Color.Green
        Else
            j2Resultado.BackColor = Color.Red
        End If

        If ganador(2) = "1" Then
            j3Resultado.BackColor = Color.Green
        Else
            j3Resultado.BackColor = Color.Red
        End If

        If ganador(3) = "1" Then
            j4Resultado.BackColor = Color.Green
        Else
            j4Resultado.BackColor = Color.Red
        End If

        j1Resultado.Text = "Score: " & jugador(0).calcularMano
        j2Resultado.Text = "Score: " & jugador(1).calcularMano
        j3Resultado.Text = "Score: " & jugador(2).calcularMano
        j4Resultado.Text = "Score: " & jugador(3).calcularMano

        j1Score.Text = "PartidasG: " & getDato(0)
        j2Score.Text = "PartidasG: " & getDato(1)
        j3Score.Text = "PartidasG: " & getDato(2)
        j4Score.Text = "PartidasG: " & getDato(3)

        setPictureBox()

    End Sub

    Private Sub btnBorrarDatos_Click(sender As Object, e As EventArgs) Handles btnBorrarDatos.Click
        clearData()

        j1Score.Text = "PartidasG: " & getDato(0)
        j2Score.Text = "PartidasG: " & getDato(1)
        j3Score.Text = "PartidasG: " & getDato(2)
        j4Score.Text = "PartidasG: " & getDato(3)

        j1c1.Image = My.Resources.B
        j1c2.Image = My.Resources.B
        j1c3.Image = My.Resources.B
        j1c4.Image = My.Resources.B
        j1c5.Image = My.Resources.B

        j2c1.Image = My.Resources.B
        j2c2.Image = My.Resources.B
        j2c3.Image = My.Resources.B
        j2c4.Image = My.Resources.B
        j2c5.Image = My.Resources.B

        j3c1.Image = My.Resources.B
        j3c2.Image = My.Resources.B
        j3c3.Image = My.Resources.B
        j3c4.Image = My.Resources.B
        j3c5.Image = My.Resources.B

        j4c1.Image = My.Resources.B
        j4c2.Image = My.Resources.B
        j4c3.Image = My.Resources.B
        j4c4.Image = My.Resources.B
        j4c5.Image = My.Resources.B

        j1Resultado.Text = ""
        j2Resultado.Text = ""
        j3Resultado.Text = ""
        j4Resultado.Text = ""

        j1Resultado.BackColor = Color.Transparent
        j2Resultado.BackColor = Color.Transparent
        j3Resultado.BackColor = Color.Transparent
        j4Resultado.BackColor = Color.Transparent

    End Sub

    Public Sub guardarDato(dato As Integer, id As Integer)
        'check if file exixts
        If My.Computer.FileSystem.FileExists(rutaDatos) = False Then
            My.Computer.FileSystem.WriteAllText(rutaDatos, "0" & vbCrLf & "0" & vbCrLf & "0" & vbCrLf & "0" & vbCrLf, False)
        End If

        'save data in specific line
        Dim datos() As String = System.IO.File.ReadAllLines(rutaDatos)

        'add old data to new for total
        Dim total As Integer = dato + getDato(id)

        datos(id) = total.ToString

        System.IO.File.WriteAllLines(rutaDatos, datos)
    End Sub

    Public Function getDato(id As Integer) As Integer
        Return CInt(File.ReadLines(rutaDatos)(id))
    End Function

    Public Sub clearData()
        My.Computer.FileSystem.WriteAllText(rutaDatos, "0" & vbCrLf & "0" & vbCrLf & "0" & vbCrLf & "0" & vbCrLf, False)
    End Sub

    Public Sub setPictureBox()


        j1c1.Image = Image.FromFile(rutaImg & "img\" & jugador(0).getMano(0).getNumero.ToString & palo(jugador(0).getMano(0).getPalo - 1) & ".png")
        j1c1.Refresh()
        j1c2.Image = Image.FromFile(rutaImg & "img\" & jugador(0).getMano(1).getNumero.ToString & palo(jugador(0).getMano(1).getPalo - 1) & ".png")
        j1c2.Refresh()
        j1c3.Image = Image.FromFile(rutaImg & "img\" & jugador(0).getMano(2).getNumero.ToString & palo(jugador(0).getMano(2).getPalo - 1) & ".png")
        j1c3.Refresh()
        j1c4.Image = Image.FromFile(rutaImg & "img\" & jugador(0).getMano(3).getNumero.ToString & palo(jugador(0).getMano(3).getPalo - 1) & ".png")
        j1c4.Refresh()
        j1c5.Image = Image.FromFile(rutaImg & "img\" & jugador(0).getMano(4).getNumero.ToString & palo(jugador(0).getMano(4).getPalo - 1) & ".png")
        j1c5.Refresh()

        j2c1.Image = Image.FromFile(rutaImg & "img\" & jugador(1).getMano(0).getNumero.ToString & palo(jugador(1).getMano(0).getPalo - 1) & ".png")
        j2c1.Refresh()
        j2c2.Image = Image.FromFile(rutaImg & "img\" & jugador(1).getMano(1).getNumero.ToString & palo(jugador(1).getMano(1).getPalo - 1) & ".png")
        j2c2.Refresh()
        j2c3.Image = Image.FromFile(rutaImg & "img\" & jugador(1).getMano(2).getNumero.ToString & palo(jugador(1).getMano(2).getPalo - 1) & ".png")
        j2c3.Refresh()
        j2c4.Image = Image.FromFile(rutaImg & "img\" & jugador(1).getMano(3).getNumero.ToString & palo(jugador(1).getMano(3).getPalo - 1) & ".png")
        j2c4.Refresh()
        j2c5.Image = Image.FromFile(rutaImg & "img\" & jugador(1).getMano(4).getNumero.ToString & palo(jugador(1).getMano(4).getPalo - 1) & ".png")
        j2c5.Refresh()

        j3c1.Image = Image.FromFile(rutaImg & "img\" & jugador(2).getMano(0).getNumero.ToString & palo(jugador(2).getMano(0).getPalo - 1) & ".png")
        j1c1.Refresh()
        j3c2.Image = Image.FromFile(rutaImg & "img\" & jugador(2).getMano(1).getNumero.ToString & palo(jugador(2).getMano(1).getPalo - 1) & ".png")
        j1c2.Refresh()
        j3c3.Image = Image.FromFile(rutaImg & "img\" & jugador(2).getMano(2).getNumero.ToString & palo(jugador(2).getMano(2).getPalo - 1) & ".png")
        j1c3.Refresh()
        j3c4.Image = Image.FromFile(rutaImg & "img\" & jugador(2).getMano(3).getNumero.ToString & palo(jugador(2).getMano(3).getPalo - 1) & ".png")
        j1c4.Refresh()
        j3c5.Image = Image.FromFile(rutaImg & "img\" & jugador(2).getMano(4).getNumero.ToString & palo(jugador(2).getMano(4).getPalo - 1) & ".png")
        j1c5.Refresh()

        j4c1.Image = Image.FromFile(rutaImg & "img\" & jugador(3).getMano(0).getNumero.ToString & palo(jugador(3).getMano(0).getPalo - 1) & ".png")
        j1c1.Refresh()
        j4c2.Image = Image.FromFile(rutaImg & "img\" & jugador(3).getMano(1).getNumero.ToString & palo(jugador(3).getMano(1).getPalo - 1) & ".png")
        j1c2.Refresh()
        j4c3.Image = Image.FromFile(rutaImg & "img\" & jugador(3).getMano(2).getNumero.ToString & palo(jugador(3).getMano(2).getPalo - 1) & ".png")
        j1c3.Refresh()
        j4c4.Image = Image.FromFile(rutaImg & "img\" & jugador(3).getMano(3).getNumero.ToString & palo(jugador(3).getMano(3).getPalo - 1) & ".png")
        j1c4.Refresh()
        j4c5.Image = Image.FromFile(rutaImg & "img\" & jugador(3).getMano(4).getNumero.ToString & palo(jugador(3).getMano(4).getPalo - 1) & ".png")
        j1c5.Refresh()

    End Sub



End Class