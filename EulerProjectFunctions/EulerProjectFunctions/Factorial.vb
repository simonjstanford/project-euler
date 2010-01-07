''' <summary>
''' Method of calculating the factorial (n!) of a non negative number that cant blow the int limit.
''' </summary>
''' <remarks></remarks>
Public Class Factorial
    Inherits EulerClassOneProperty(Of Integer, String)

    ''' <summary>
    ''' Method of calculating the factorial of a non negative number that cant blow the int limit.
    ''' </summary>
    ''' <param name="n">The number to calculate the factorial of.</param>
    ''' <remarks></remarks>
    Sub New(ByVal n As Integer)
        MyBase.New(n)
    End Sub

    Protected Overrides Function Calculate(ByVal n As Integer) As Object
        Dim list As New List(Of String)
        Dim counter As Integer = 3

        If n = 0 Then Return 1 'if n is any of these values, return the respective answer, as the function begins calculating after this.
        If n = 1 Then Return 1
        If n = 2 Then Return 2

        'add items to list, take item from list and put into array. For each cell in the array carry out long multiplication, then add result to current 
        'value of cell.  If cell is not 0 and > 9 then carry over.
        list.Add(1) 'add the first two entries into the list to multiply together
        list.Add(2)

        Do Until counter > n 'multiply together until the counter has reached n, the desired amount
            Dim TimesBy As Integer = counter - 2
            Dim a As String = list.Item(TimesBy)
            Dim array(2, a.Count) As Integer

            'add last list item to row 0 of array
            For i = 0 To a.Count - 1
                array(0, i) = a.Substring(i, 1)
            Next

            'working from the back, carry out long multiplication and add to current cell value: Times each cell value by the next number in the sequence
            For i = a.Count - 1 To 0 Step -1
                array(1, i) += (array(0, i) * counter)
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
            Dim accumulate As String = Nothing
            For i = 0 To a.Count - 1
                accumulate += array(1, i).ToString
            Next
            'add string as the last item on the list
            list.Add(accumulate)
            'increase counter and start again
            counter += 1
            accumulate = Nothing
        Loop

        Return list.Last.ToString
    End Function
End Class
