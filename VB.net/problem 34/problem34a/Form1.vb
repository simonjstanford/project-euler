Public Class Problem34
    'Euler Projects Problem 34:
    '145 is a curious number, as 1! + 4! + 5! = 1 + 24 + 120 = 145.
    'Find the sum of all numbers which are equal to the sum of the factorial of their digits.
    'Note: as 1! = 1 and 2! = 2 are not sums they are not included.
    Private Sub Problem34_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim answer As Integer 'the accumulating number
        Dim f As Integer 'the total sum of the factorial of digits for each number (a)

        For a = 3 To 1000000 'from 3 because question states 1 and 2 don't count, limit is an arbitrary number
            For b = 0 To a.ToString.Count - 1 'for loop to break apart number a. Counts the number of digits in a and creates as many substrings
                f += Factorial(a.ToString.Substring(b, 1)) 'uses the substrings to run the Factorial function and accumulate the answer
                If f = a Then answer += a 'if the answer (f) is the same as the number tested (a) then add it to the final answer
            Next
            f = 0 'return f to 0 for the next loop and start again
        Next

        TextBox1.Text = answer

    End Sub

    Function Factorial(ByVal n As Integer)
        Dim x As Integer = 1 'the accumulating factorial. Given value of 1 to get accurate results from first recursion
        For i = 1 To n 'for each number within the number given...
            x = x * i '...multiply it with every other number so far
        Next
        Return x
    End Function


End Class
