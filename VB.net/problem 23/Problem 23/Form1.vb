Public Class Form1
    Dim list As New List(Of Integer)

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim answer As Integer
        'find all abundant numbers, and add them to the list
        FindAbundantNumbers()
        Dim counter As Integer = 1

        'run a loop that will check each number between 1 and 28123 in turn.  it takes one number from the list, then adds it in turn to every number in the list.
        'if the loop can find two numbers to add together that equal the number being checked, it can be written as the sum of two abandant numbers and so fails the test
        'this number is then added to the answer
        Do Until counter > 28123
            Dim a As Integer
            Dim b As Integer
            Dim SumOfAbundant As Boolean = False

            'get first number in the list
            For i = 0 To list.Count - 1
                'to speed up script, if the number in the list is greater than the number being checked, skip
                'also if by this point the scipt has found two abundant numbers that add together to get the number being checked, 
                'so the number has failed the check and the rest of the tests for that nubmer are skipped
                If list(i) > counter Then Exit For
                If SumOfAbundant = True Then Exit For
                'get second number in the list
                For j = 0 To list.Count - 1
                    'same as previous code to speed up script
                    If list(j) > counter Then Exit For
                    If SumOfAbundant = True Then Exit For
                    a = list(i)
                    b = list(j)
                    'check to see if two numbers in the list add up to number being checked
                    'if so, sumofAbundant is changed to true
                    If a + b = counter Then
                        SumOfAbundant = True
                        'MsgBox(counter)
                    End If
                    'loop round, and increase the second number by one and start again
                Next
                'loop roundm and increase the first number by one and start the whole process again.
            Next
            'if it passes the test, add the number to the answer
            If SumOfAbundant = False Then
                answer += counter
            End If
            'increase number tested by one, and start test again
            counter += 1
        Loop
        'when all numbers check, print answer.
        TextBox1.Text = answer

    End Sub

    Sub FindAbundantNumbers()
        'subroutine to find all abundant numbers between 1 and 28123
        Dim counter As Integer = 1
        Dim divisor As Integer = 1

        'do loop that increases the number to test by 1 each time
        Do Until counter > 28123
            Dim sumOfDivisors As Integer = 0
            'check each divisor in turn up to half the amount of the number being tested
            Do Until divisor > counter / 2
                'if there is no remainder of dividing divisor by counter then add the divisor to the sum of divisors
                If counter Mod divisor = 0 Then
                    sumOfDivisors += divisor
                End If
                'increase the divisor by one and start again
                divisor += 1
            Loop

            'after all divisors of a number are found, if the total sum of them is greater than the number itself then it is an abundant number
            'so add the number to the list of abundant numbers
            If sumOfDivisors > counter Then
                list.Add(counter)
                'MsgBox("counter: " & counter & vbCrLf & "sumOfDivisors: " & sumOfDivisors)
            End If
            'increase the number to check by 1 and return the divisor to 1 and start the loop again
            counter += 1
            divisor = 1
        Loop
    End Sub

End Class
