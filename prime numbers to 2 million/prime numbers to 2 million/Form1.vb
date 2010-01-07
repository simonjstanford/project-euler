Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim counter As Integer = 3
        Dim total As Int64 = 0
        Dim tester As Integer = 1
        Dim testLimit As Integer = 2000000

        Do Until counter > 2000000
            If counter Mod 2 = 0 Or counter Mod 3 = 0 Or counter Mod 5 = 0 Or counter Mod 7 = 0 Then
                counter += 2
            Else
                Dim tempList As New List(Of Int64)
                Do Until tempList.Count = 2 Or tester > Math.Sqrt(counter)
                    If counter Mod tester = 0 Then tempList.Add(tester)
                    tester += 1
                Loop
                If tempList.Count = 1 Then
                    total += counter
                End If
                tester = 1
                counter += 2
            End If
        Loop
        MsgBox(total + 17)
    End Sub
End Class

