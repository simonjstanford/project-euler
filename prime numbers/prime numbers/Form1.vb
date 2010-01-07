Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Number As Decimal = 10001
        Dim counter As Int64 = 1
        Dim Primes As New List(Of Int64)
        Dim factors As New List(Of Int64)
        Dim total As Int64 = 0

        Do Until counter > 10
            Dim tempList As New List(Of Int64)
            If counter Mod 2 = 0 Then
                counter += 1
            Else
                For i = 1 To counter
                    If counter Mod i = 0 Then tempList.Add(i)
                    If tempList.Count = 2 Then Primes.Add(counter)
                    counter += 1
                Next
            End If
        Loop

        For Each primeNumber As Int64 In Primes
            total += primeNumber
        Next
        MsgBox(total)

    End Sub
End Class

