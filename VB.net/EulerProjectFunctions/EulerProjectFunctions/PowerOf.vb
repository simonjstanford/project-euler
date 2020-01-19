''' <summary>
''' Calculates the power of a number.
''' </summary>
''' <remarks></remarks>
Public Class PowerOf
    Inherits EulerClassTwoProperties(Of String, Integer, String)

    ''' <summary>
    ''' Calculates the power of a number.
    ''' </summary>
    ''' <param name="a">The number to calculate the power of.</param>
    ''' <param name="p">The power to use.</param>
    ''' <remarks></remarks>
    Sub New(ByVal a As String, ByVal p As Integer)
        MyBase.New(a, p)
    End Sub


    Protected Overrides Function Calculate(ByVal a As String, ByVal p As Integer) As Object
        'Puts number into array. For each cell in the array carry out long multiplication as many times as required, then add result to current value of cell.  If cell is not 0 and > 9 then carry over.
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
