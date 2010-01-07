Public Class Problem53
    '/////////////////////////////////////////////////////////////////////////////////////////////////////////
    'Euler Project Problem 53:
    'There are exactly ten ways of selecting three from five, 12345:
    '123, 124, 125, 134, 135, 145, 234, 235, 245, and 345
    'In combinatorics, we use the notation, ^(5)C_(3) = 10.
    'In general,
    '^(n)C_(r) = n! / r!(n−r)!
    'where r ≤ n, n! = n×(n−1)×...×3×2×1, and 0! = 1.
    'It is not until n = 23, that a value exceeds one-million: ^(23)C_(10) = 1144066.
    'How many, not necessarily distinct, values of  ^(n)C_(r), for 1 ≤ n ≤ 100, are greater than one-million?
    '/////////////////////////////////////////////////////////////////////////////////////////////////////////
    Private Sub Problem53_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim StartTime As String = Now 'start date, used to calculate time taken.
        Dim answer As Integer = 0

        ' MsgBox(Calculate(5, 3))

        For n = 1 To 100
            For r = 1 To n
                Dim a As String = Calculate(n, r)
                If a > 1000000 Then answer += 1
            Next
        Next

        txtAnswer.Text = answer 'display the answer
        txtTime.Text = DateTime.Now.Subtract(StartTime).TotalSeconds 'substract the start time from the time now to find the duration in seconds that the script took to complete
    End Sub

    Function Calculate(ByVal n As Integer, ByVal r As Integer)
        Dim answer As String
        If r > n Then Return -1 'r must be equal or less than n
        answer = Factorial(n) / (Factorial(r) * Factorial(n - r))
        Return answer
    End Function

    Function Factorial2(ByVal n As Int64)
        Dim x As Int64 = 1 'the accumulating factorial. Given value of 1 to get accurate results from first recursion
        If n = 0 Then Return 1
        For i = 1 To n 'for each number within the number given...
            x = x * i '...multiply it with every other number so far
        Next
        Return x
    End Function

    Function Factorial(ByVal n As Integer) 'this method of factorising is required, as otherwise the variable limits are blown.
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
            Dim accumulate As String
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
