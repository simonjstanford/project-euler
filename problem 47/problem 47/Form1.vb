Public Class Problem47
    '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    'Euler Projects Problem 47:
    'The first two consecutive numbers to have two distinct prime factors are:
    '14 = 2 × 7
    '15 = 3 × 5
    'The first three consecutive numbers to have three distinct prime factors are:
    '644 = 2² × 7 × 23
    '645 = 3 × 5 × 43
    '646 = 2 × 17 × 19.
    'Find the first four consecutive integers to have four distinct primes factors. What is the first of these numbers?
    '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim n As Integer = 10 'the current number to check
        Dim answer As New List(Of Integer) 'the list of answers. When the count reaches the max variable, the sub stops
        Dim max As Integer = 4 'the number of consecutive numbers you are looking for.  Is also the variable used for the number of prime factors you are looking for

        Do 'run until the answer is found
            Dim x As Integer = n 'the variable to divide down to find the primes.  Initially, make it n
            Dim list As New List(Of Integer) 'the list that hold the distinct prime factors.
            Dim lastNumber As Integer = 0 'the variable to hold the last prime factor to prevent duplicate variables being entered

            For a = 2 To n / 2 'starting at 2 (1 is not a prime) run the loop
                If IsPrime(a) = True Then 'if a is a prime then check it
                    Do Until x Mod a <> 0 'if a goes into x (taken from n)
                        x = x / a 'divide it
                        If a <> lastNumber Then list.Add(a) 'and if not already in the list, add it.
                        lastNumber = a 'then make a the new previous number
                    Loop 'and continue the loop. The script will keep on trying to divide the current value of x by 2 until it cant. Then it will not on to 3, then 5 etc. until x = 1
                End If
            Next

            If list.Count = max Then 'when finished with a number, check to see how many different primes have been used. If it matches the variable max, 
                answer.Add(n) 'add it to the list of answers
                If answer.Count = max Then Exit Do 'if the list of answers is equal to max, we have found our answer, so exit the loop
            Else
                answer.Clear() 'if it doesn't equal max, then it is not the answer, and we haven't found 4 in a row, so clear the list...
            End If
            n += 1 'add 1 to n and start the loop again.
        Loop

        For Each a As Integer In answer
            MsgBox(a) 'finally show the four answers.
        Next
    End Sub

    Function IsPrime(ByVal n As Integer)
        If n = 1 Then Return False '1 is not a primary number so return false
        For i = 2 To Math.Sqrt(n) 'check every number between 2 and the square root
            If n Mod i = 0 Then Return False 'if a divisor is found then n is not a prime
        Next
        Return True 'if n passes all the tests then it is prime
    End Function
End Class
