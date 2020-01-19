Public Class Problem38
    'Euler Projects Problem 38:
    'What is the largest 1 to 9 pandigital 9-digit number that can be formed as the concatenated product of an integer with (1,2, ... , n) where n > 1?
    Private Sub Problem38_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim StartTime As String = Now 'start date, used to calculate time taken.
        Dim answer As Integer 'hold the highest answer
        Dim total As String = "h" 'the total of the multiplications.  A starting value is placed in it to avoid an error in the do loop
        Dim x As Integer = 1 'the number to be timed by
        Dim multiplier As Integer = 1 'the multiplier

        Do Until x = 98765 'an arbitrary finish point
            Do Until total.Count > 9 'do until there is more than 9 digits in the number to be tested:
                total = total & x * multiplier 'times the two numbers together and add to string
                multiplier += 1 'increase the multiplier by one and start again
            Loop

            total = total.Remove(0, 1) 'remove the letter added to avoid the error

            If total.Count = 9 Then ' if there are 9 left:
                If IsPandigital(total) = True And total > answer Then answer = total 'test if pandigital and higher than previous answer. if so make this the current answer
            End If
            x += 1 'increase the number to be timed by one
            total = "h" 'return total to the original setting
            multiplier = 1 'return the multiplier to 1 and start again
        Loop


        txtAnswer.Text = answer 'display the final answer
        txtTime.Text = DateTime.Now.Subtract(StartTime).TotalSeconds 'substract the start time from the time now to find the duration in seconds that the script took to complete
    End Sub

    Function IsPandigital(ByVal n As String)
        'Function to determine if n is pandigital
        Dim list As New List(Of String) 'list to hold each digit in number

        For Each digit As String In n.ToArray 'add each digit to the list
            list.Add(digit)
        Next

        list.Sort() 'sort them

        For i = 1 To list.Count - 1 'for each number... (start at 1 not 0 as the next line refers to the previous number)
            If list(0) = 1 And list(1) = 2 And list(2) = 3 And list(3) = 4 And list(4) = 5 And list(5) = 6 And list(6) = 7 And list(7) = 8 And list(8) = 9 Then
                Return True
            else 
                Return False
            End If
        Next
    End Function

End Class
