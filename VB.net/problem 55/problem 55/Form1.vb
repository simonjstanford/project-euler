Public Class Problem55
    '//////////////////////////////////////////////////////
    'Euler Project Problem 55:
    'How many Lychrel numbers are there below ten-thousand?
    '//////////////////////////////////////////////////////
    Private Sub Problem55_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim answer As Integer = 0 'variable to hold the number of non-lychrel numbers
        For i = 1 To 10000 'check all numbers between 1 and 10000
            Dim counter As Integer = 0 'variable to hold the number of jumps
            Dim r As String 'variable for the reverse of i
            Dim n As String = i 'variable to hold the accumulating value of i + r
            Do Until counter = 50 'do until you have reached 50 jumps
                r = StrReverse(n.ToString) 'reverse n
                n = LongAddition(n, r) 'add n and r together
                If IsPalindrome(n) = True Then 'if the number is palidromic, add one to the answer and exit loop
                    answer += 1
                    Exit Do
                Else
                    counter += 1 'otherwise increase the number of jumps completed by 1 and start again.
                End If
            Loop
        Next

        MsgBox(10000 - answer) 'to find the number of lychrel numbers, minus the number found by the number tested.
    End Sub

    Function IsPalindrome(ByVal n As String)
        Dim r As String = StrReverse(n)
        'MsgBox(n & vbCrLf & r)

        If r = n Then Return True
        Return False
    End Function

    Function LongAddition(ByVal a As String, ByVal b As String)

        If a.Count < b.Count Then 'insert leading 0's onto the start of the shortest number to ensure they fit into the array
            Do Until a.Count = b.Count
                a = a.Insert(0, 0)
            Loop
        ElseIf b.Count > a.Count Then
            Do Until b.Count = b.Count
                b = b.Insert(0, 0)
            Loop
        End If

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

End Class
