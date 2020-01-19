Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim singles() As String = {"", "One", "two", "three", "four", "five", "six", "seven", "eight", "nine"}
        Dim teens() As String = {"Ten", "Eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"}
        Dim tens() As String = {"Ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"}
        Dim other As String = "and"
        Dim hundred As String = "hundredand"
        Dim thousand As String = "thousand"


        Dim counter As Integer
        Dim wholeString As String

        For i = 1 To UBound(singles)
            wholeString += singles(i)
        Next

        For i = 0 To UBound(teens)
            wholeString += teens(i)
        Next


        For j = 1 To UBound(tens)
            For i = 0 To UBound(singles)
                wholeString += tens(j) + singles(i)
            Next
        Next

        For i = 1 To UBound(singles)
            wholeString += singles(i) + "hundred"
        Next


        For j = 1 To UBound(singles)
            For i = 1 To UBound(singles)
                wholeString += singles(j) + "hundredand" + singles(i)
            Next
        Next

        For j = 1 To UBound(singles)
            For i = 0 To UBound(teens)
                wholeString += singles(j) + "hundredand" + teens(i)
            Next
        Next




        For k = 1 To UBound(singles)
            For i = 1 To UBound(tens)
                For j = 0 To UBound(singles)
                    wholeString += singles(k) + "hundredand" + tens(i) + singles(j)
                Next
            Next
        Next

        wholeString += "onethousand"


        TextBox1.Text = wholeString

        MsgBox(wholeString.Count)

    End Sub
End Class
