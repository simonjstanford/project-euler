Public Class Form1
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim answer As Int64 = 0
        Dim highestTerm As Int64 = 0

        For i = 1 To 1000000
            Dim numberOfTerms As Int64 = CalculateTerms(i)
            If numberOfTerms > highestTerm Then
                answer = i
                highestTerm = numberOfTerms
            End If
        Next
        TextBox1.Text = answer
    End Sub

    Function CalculateTerms(ByVal n As Int64)
        Dim list As New List(Of Int64)

        list.Add(n)
        Do Until n = 1
            If n Mod 2 = 0 Then
                n = n / 2
                list.Add(n)
            Else
                n = (n * 3) + 1
                list.Add(n)
            End If
        Loop
        Return list.Count
    End Function
End Class
