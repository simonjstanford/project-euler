Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Size As Integer = 20
        Dim array(Size, Size) As Int64
        Dim r As Integer = 1

        'assign value 1 to every element on the grid's top and left hand side
        For i = 0 To Size
            array(i, 0) = 1
        Next
        For i = 0 To Size
            array(0, i) = 1
        Next

        'add together value of cells to the left and top to find answer
        Do Until r > Size
            For i = 1 To Size
                array(r, i) = array(r, i - 1) + array(r - 1, i)
            Next
            r += 1
        Loop

        'the final cell has the answer
        TextBox1.Text = array(Size, Size)
    End Sub
End Class
