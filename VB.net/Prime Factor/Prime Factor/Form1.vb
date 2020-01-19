Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Number As Decimal = 600851475143
        Dim counter As Int64 = 1
        Dim Primes As New List(Of Int64)
        Dim factors As New List(Of Int64)
        Do Until counter > Number / 10000000
            Dim tempList As New List(Of Int64)
            For i = 1 To counter
                If counter Mod i = 0 Then tempList.Add(i)
            Next
            If tempList.Count <= 2 Then Primes.Add(counter)
            counter += 1
        Loop
        For i = 0 To UBound(Primes.ToArray)
            If Number Mod Primes.Item(i) = 0 Then
                factors.Add(Primes.Item(i))
            End If
        Next
        'For i = 0 To UBound(factors.ToArray)
        MsgBox(factors.Last)

        'Next

    End Sub
End Class
