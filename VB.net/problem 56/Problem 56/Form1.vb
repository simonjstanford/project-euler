Public Class Problemx
    '//////////////////////////////////////////////////////////////////////////////////////////////////
    'Euler Projects Problem 56:
    'A googol (10^(100)) is a massive number: one followed by one-hundred zeros; 
    '100^(100) is almost unimaginably large: one followed by two-hundred zeros. 
    'Despite their size, the sum of the digits in each number is only 1.
    'Considering natural numbers of the form, a^(b), where a, b < 100, what is the maximum digital sum?
    '//////////////////////////////////////////////////////////////////////////////////////////////////
    Private Sub Problem36_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim answer As Integer = 0 'the variable to hold the accumulating answer
        Dim StartTime As String = Now 'variable used to hold the start time

        For a = 1 To 100
            For b = 1 To 100
                Dim n As String = PowerOf(a, b) 'get the power of a(b) and assign to n
                Dim x As Integer = 0
                For Each c In n.ToCharArray
                    x += c.ToString 'add each digit in n to x
                Next
                If x > answer Then answer = x 'if this is the highest so far, make this the answer
            Next
        Next

        txtAnswer.Text = answer 'print answer
        txtTime.Text = DateTime.Now.Subtract(StartTime).TotalSeconds 'substract the start time from the time now to find the duration in seconds that the script took to complete
    End Sub

    Function PowerOf(ByVal a As String, ByVal p As Integer)
        'function that calculates the power of a number: puts number into array. For each cell in the array carry out long multiplication as many times as required, then add result to current 
        'value of cell.  If cell is not 0 and > 9 then carry over.
        Dim n As String = a 'first of all, make n = a, as n will be the variable that is recursed through the function
        Dim counter As Integer = 2 'counts the number of recursions. starts at two, because the first recursion is for this.

        Do Until counter > p
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
