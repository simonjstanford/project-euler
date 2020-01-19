Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim list As New List(Of Integer)
        For i = 1 To 1000
            Dim dTest3 As Double
            Dim dTest5 As Double
            Dim iTest3 As Integer
            Dim iTest5 As Integer
            'divide i by 3, and assign to double and integar variables
            dTest3 = i / 3
            iTest3 = CInt(dTest3)
            'divide i by 5, and do the same
            dTest5 = i / 5
            iTest5 = CInt(dTest5)
            'test if both variables are the same on either division, and if so add to list
            If dTest3 = iTest3 Or dTest5 = iTest5 Then list.Add(i)
        Next

        Dim count As Integer = 0
        'then add items in list together
        For i = 0 To UBound(list.ToArray) - 1
            count += list(i)
        Next
        MsgBox(count)
    End Sub
End Class
