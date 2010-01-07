Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim a As Integer = 1
        Dim b As Integer = 0
        Dim c As Double
        Dim sum As Integer
        Dim answer As Integer

        Do Until a = 1000
            Do Until b > 1000
                c = Math.Sqrt((a * a) + (b * b))
                sum = a + b + c
                answer = a * b * c
                If a + b + c = 1000 Then
                    MsgBox(a.ToString + vbCrLf + b.ToString + vbCrLf + c.ToString + vbCrLf + sum.ToString + vbCrLf + answer.ToString)
                End If
                b += 1
            Loop
            If a < 1000 And b >= 1000 Then
                b = 1
                a += 1
            End If
        Loop


    End Sub
End Class
