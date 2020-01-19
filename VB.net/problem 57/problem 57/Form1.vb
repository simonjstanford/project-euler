Public Class Problemx
    '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    'Euler Projects Problem 57:
    'It is possible to show that the square root of two can be expressed as an infinite continued fraction.
    '√ 2 = 1 + 1/(2 + 1/(2 + 1/(2 + ... ))) = 1.414213...
    'By expanding this for the first four iterations, we get:
    '1 + 1/2 = 3/2 = 1.5
    '1 + 1/(2 + 1/2) = 7/5 = 1.4
    '1 + 1/(2 + 1/(2 + 1/2)) = 17/12 = 1.41666...
    '1 + 1/(2 + 1/(2 + 1/(2 + 1/2))) = 41/29 = 1.41379...
    'The next three expansions are 99/70, 239/169, and 577/408, but the eighth expansion, 1393/985, is the first example
    'where the number of digits in the numerator exceeds the number of digits in the denominator.
    'In the first one-thousand expansions, how many fractions contain a numerator with more digits than denominator?
    '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    Private Sub Problem36_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim answer As Integer 'the variable to hold the accumulating answer
        Dim StartTime As String = Now 'variable used to hold the start time

        'this script works by calculating what the next fractions will be using the formula (p + 2q)/(p + q). p is the number above the line, q is the number below.
        Dim p As String = 3 'set the first values
        Dim q As String = 2
        Dim counter As Integer = 1 'and set the counter to 1

        Do Until counter > 1000 'do until counter reaches 1000
            Dim p2 As String = LongAddition(p, LongMultiplication(q, 2)) 'use the formula above with the long addition/multiplication functions to find the next values of p and q
            Dim q2 As String = LongAddition(p, q)
            If p2.ToString.Count > q2.ToString.Count Then answer += 1 'if p2 is greater than q2, increase answer by one
            p = p2 'make the new variables the old variables, increase the counter and start the loop again.
            q = q2
            counter += 1
        Loop

        txtAnswer.Text = answer 'print answer
        txtTime.Text = DateTime.Now.Subtract(StartTime).TotalSeconds 'substract the start time from the time now to find the duration in seconds that the script took to complete
    End Sub

    Function LongAddition(ByVal a As String, ByVal b As String)

        Do Until a.Count = b.Count  'insert leading 0's onto the start of the shortest number to ensure they fit into the array
            If a.Count < b.Count Then a = a.Insert(0, "0")
            If a.Count > b.Count Then b = b.Insert(0, "0")
        Loop

        Dim array(2, a.Count - 1) As Integer 'create array

        For i = 0 To a.Count - 1 'place digits into array
            array(0, i) = a.Substring(i, 1)
            array(1, i) = b.Substring(i, 1)
        Next

        For i = a.Count - 1 To 0 Step -1 'calculate long division, starting from the back
            array(2, i) += array(0, i) + array(1, i)
            'MsgBox(array(2, i))
            If i <> 0 Then 'if not the far left column, place the remainder in the next column to the left
                If array(2, i) > 9 Then
                    array(2, i - 1) += Math.Floor(array(2, i) / 10)
                    array(2, i) = array(2, i) Mod 10
                End If
            End If
        Next

        Dim answer As String

        For i = 0 To a.Count - 1
            answer = answer & array(2, i)
        Next

        Return answer
    End Function

    Function LongMultiplication(ByVal n As String, ByVal p As Integer)
        Dim array(1, n.Count) As Integer 'create array with 2 rows and size equal to the number of digits in n

        For i = 0 To n.Count - 1
            array(0, i) = n.Substring(i, 1) 'place each number in a seperate cell on the first row
        Next

        For i = n.Count - 1 To 0 Step -1 'working from the back, begin long multiplication
            array(1, i) += array(0, i) * p 'times each cell by the power (p) and place the result in the cell below
            If i <> 0 Then 'carry over numbers higher than 10 if it is not the cell on the far left
                If array(1, i) > 9 Then 'if value is greater than 9...
                    Dim x As Integer = i - 1 'get cell number of cell to the left of the current cell (the higher value)
                    Dim c As Integer = Math.Floor(array(1, i) / 10)
                    array(1, i) = array(1, i) Mod 10 'keep only the last digit in the current cell
                    array(1, x) = c 'and move the rest to the cell to the left
                End If
            End If
        Next

        Dim answer As String 'create the string to hold the answer
        For i = 0 To n.Count - 1
            answer += array(1, i).ToString 'and join together the answer
        Next

        Return answer

    End Function

End Class
