Public Class Problem46
    '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    'Euler Projects Problem 46:
    'It was proposed by Christian Goldbach that every odd composite number can be written as the sum of a prime and twice a square.
    '9 = 7 + 2×1^(2)
    '15 = 7 + 2×2^(2)
    '21 = 3 + 2×3^(2)
    '25 = 7 + 2×3^(2)
    '27 = 19 + 2×2^(2)
    '33 = 31 + 2×1^(2)
    'It turns out that the conjecture was false.
    'What is the smallest odd composite that cannot be written as the sum of a prime and twice a square?
    '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    Private Sub Problem46_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim n As Integer = 3 'integer to check
        Dim found As Boolean = False 'boolean variable that changes if no solution can be found. This signifies the answer.
        Dim StartTime As String = Now 'start date, used to calculate time taken.

        Do 'this loop terminates when the answer is found
            If IsComposite(n) = True Then 'if n is a composite number
                For i = 1 To n
                    If IsPrime(i) = True Then 'iterate through all prime numbers up to n
                        For s = 1 To n / 2 'and iterate trhough all numbers up to n
                            If n = i + (2 * (Math.Pow(s, 2))) Then 'and see if they add together (prime + (2*x^2)) to create n
                                'MsgBox(n & " = " & i & " + (2 * " & s & "^2)")
                                found = True 'if found, mark as true. this is necessary as there are several different ways numbers fit this formula
                            End If
                        Next
                    End If
                Next
            End If
            If found = False And IsComposite(n) = True Then 'if after going through every permutation of primes and squares and none have been found that match, and n is a composite:
                txtAnswer.Text = n 'n is the answer, so print it.
                txtTime.Text = DateTime.Now.Subtract(StartTime).TotalSeconds 'substract the start time from the time now to find the duration in seconds that the script took to complete
                Exit Sub 'then finish the sub
            End If
            n += 2 'add two to n so start again. Add 2 as you are only checking odd numbers.
            found = False 'then return found to false and start again.
        Loop

    End Sub

    Function IsComposite(ByVal n As Integer)
        If n = 1 Then Return False '1 is not a composite number so return false
        For i = 2 To Math.Sqrt(n) 'check every number between 2 and the square root
            If n Mod i = 0 Then Return True 'if a divisor is found then n is a composite number
        Next
        Return False 'else return false
    End Function

    Function IsPrime(ByVal n As Integer)
        If n = 1 Then Return False '1 is not a primary number so return false
        For i = 2 To Math.Sqrt(n) 'check every number between 2 and the square root
            If n Mod i = 0 Then Return False 'if a divisor is found then n is not a prime
        Next
        Return True 'if n passes all the tests then it is prime
    End Function
End Class
