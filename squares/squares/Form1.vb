Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim squaredNumber As Integer = 1
        Dim SumOfSquares As Integer
        Dim SquareOfSums As Integer

        Do Until squaredNumber > 100
            SumOfSquares += squaredNumber * squaredNumber
            SquareOfSums += squaredNumber
            squaredNumber += 1
        Loop

        MsgBox((SquareOfSums * SquareOfSums) - SumOfSquares)


    End Sub
End Class
