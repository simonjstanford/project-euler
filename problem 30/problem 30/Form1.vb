Public Class Form1
    'Euler Project Problem 30: Find the sum of all the numbers that can be written as the sum of fifth powers of their digits.
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim answer As Integer 'the final answer, taken by accumulating the matching numbers

        For a = 2 To 1000000 'arbitrary limit - played with the script until it stopped finding more numbers. 1 is not tested, as the problem stipulates that 1 does not count.
            Dim y As Integer 'this variable is used to accumulate the powers of all the individual numbers
            For i = 0 To a.ToString.Count - 1 'this loop breaks apart the number and finds the power of each component seperately
                Dim x As String = a.ToString.Substring(i, 1)
                y += PowerOf(x, 5) '...then adds them together
            Next
            If y = a Then 'if the sum of the powers equals the number tested...
                answer += y '...add this number to the answer
            End If
            y = 0 'return y to 0 and restart the loop
        Next
        TextBox1.Text = answer 'finally, display the answer
    End Sub

    Function PowerOf(ByVal a As String, ByVal b As Integer)
        'function that calculates the power of a number: puts number into array. For each cell in the array carry out long multiplication as many times as required, then add result to current 
        'value of cell.  If cell is not 0 and > 9 then carry over.
        Dim n As String = a 'first of all, make n = a, as n will be the variable that is recursed through the function
        Dim counter As Integer = 2 'counts the number of recursions. starts at two, because the first recursion is for this.

        Do Until counter > b
            Dim array(2, n.Count) As Integer 'the array to carry out the calculation

            For i = 0 To n.Count - 1
                array(0, i) = n.Substring(i, 1)    'add last list item to row 0 of array
            Next

            'working from the back, carry out long multiplication and add to current cell value: Times each cell value by the next number in the sequence
            For i = n.Count - 1 To 0 Step -1
                array(1, i) += (array(0, i) * a) '***this is the change that makes it calculate powers. times n by the original value (a), not (b) which the number of times the orginal value has to timed by itself.
                'if column is not 0 then carry over number higher than 9
                If i <> 0 Then
                    If array(1, i) > 9 Then
                        Dim largerNumber As Integer = i - 1
                        Dim CarryOver As Integer = Math.Floor(array(1, i) / 10)
                        array(1, i) = array(1, i) Mod 10
                        array(1, largerNumber) += CarryOver
                    End If
                End If
            Next

            'when finished, put each cell value together in a string
            Dim tempAnswer As String = String.Empty
            For i = 0 To n.Count - 1
                tempAnswer += array(1, i).ToString
            Next
            n = String.Empty 'empty the string
            n = tempAnswer 'assign n the current answer, and start the loop again
            counter += 1
        Loop

        Return n
    End Function

End Class
