Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim a As Integer = 100
        Dim b As Integer = 100
        Dim c As Integer
        Dim forwardString As String
        Dim backwardsString As String
        Dim Palindromes As New List(Of Integer)

        Do Until a = 1000
            Do Until b = 1000
                c = a * b
                b += 1
                forwardString = c.ToString
                backwardsString = ReverseString(forwardString)
                If forwardString = backwardsString Then
                    'MsgBox(forwardString + vbCrLf + backwardsString)
                    Palindromes.Add(c)
                End If
            Loop
            If a < 1000 And b = 1000 Then b = 100
            a += 1
        Loop
        Palindromes.Sort()
        MsgBox(Palindromes.Last.ToString)
    End Sub

    Function ReverseString(ByVal targetString As String) As String
        Dim characters() As Char = targetString.ToCharArray
        Array.Reverse(characters)
        Return characters
    End Function
End Class
