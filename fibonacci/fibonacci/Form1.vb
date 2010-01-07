Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim A As Integer = 1
        Dim B As Integer = 2
        Dim C As Integer
        Dim list As New List(Of Integer)
        Dim dTest As Double
        Dim iTest As Integer
        Do Until C > 4000000
            C = GetFibonacciNumbers(A, B)
            A = B
            B = C
            dTest = C / 2
            iTest = CInt(dTest)
            If dTest = iTest Then list.Add(C)
            'MsgBox(C.ToString)
        Loop

        Dim count As Integer = 0
        'then add items in list together
        For i = 0 To UBound(list.ToArray)
            count += list(i)
        Next
        MsgBox(count + 2)
    End Sub

    Private Function GetFibonacciNumbers(ByVal a As Integer, ByVal b As Integer)
        Dim c As New Integer
        c = a + b
        Return c
    End Function
End Class
