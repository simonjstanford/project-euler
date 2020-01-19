Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim counter As Int64 = 1
        Dim counter2 As Int64 = 1
        Dim total As Int64 = 0
        Dim list As New List(Of Integer)


        Do Until list.Count = 50000
            total += counter
            counter += 1
            list.Add(total)
        Loop

        For Each triangle As Integer In list
            Dim list2 As New List(Of Integer)
            ' Dim limit As Integer = Math.Sqrt(triangle)
            For i = 1 To triangle 
                If triangle Mod i = 0 Then list2.Add(i)
                If list2.Count = 500 Then MsgBox(triangle) 'Else MsgBox(list2.Count)
            Next
        Next
    End Sub
End Class