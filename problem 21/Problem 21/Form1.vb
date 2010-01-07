Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim a As Integer = 1
        Dim answer As Integer = 0

        'loop through all numbers up to 10000, checking with NumberOfDividors functions
        Do Until a > 10000
            Dim b As Integer
            Dim SecondNumber As Integer
            'check for number of dividors of a
            b = NumberOfDividors(a)
            'using the number just calculated, check the number of dividors for b
            SecondNumber = NumberOfDividors(b)
            'if the number of dividors for a and b are the same, but a and b are not the same, add them to the answer
            If a = SecondNumber And a <> b Then answer += a + b
            'add 1 to the number to check and start again
            a += 1
        Loop
        'the final answer is the number collected through the loop divided by 2, as this would have duplicated all the calculations
        'eg. would have tests 220 and got 284, then tested 284 and got 220. they would have all been added to the list
        TextBox1.Text = answer / 2

    End Sub

    Function NumberOfDividors(ByVal number As Integer)
        Dim dividor As Integer = 1
        Dim tempAnswer As Integer = 0

        Do Until dividor > number / 2
            If number Mod dividor = 0 Then
                tempAnswer += dividor
                'MsgBox(dividor)
            End If
            dividor += 1
        Loop

        Return tempAnswer

    End Function

End Class
