Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Answer As Integer = 1
        Dim b As Integer = 1
        Dim list As New List(Of Integer)

        Do Until b > 20
            If Answer Mod b = 0 Then
                list.Add(Answer)
                b += 1
            Else
                list.Clear()
                Answer += 1
                b = 1
            End If
        Loop
        MsgBox(list.Last.ToString)
    End Sub
End Class
