Public Class Problem50
    '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    'Euler Project Problem 50:
    'The prime 41, can be written as the sum of six consecutive primes:
    '41 = 2 + 3 + 5 + 7 + 11 + 13
    'This is the longest sum of consecutive primes that adds to a prime below one-hundred.
    'The longest sum of consecutive primes below one-thousand that adds to a prime, contains 21 terms, and is equal to 953.
    'Which prime, below one-million, can be written as the sum of the most consecutive primes?
    '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    Dim StartTime As String = Now 'start date, used to calculate time taken.
    Dim list As New List(Of Integer) 'the list to hold the primes in
    Private Sub Problem50_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim limit As Integer = 1000000 'the limit of both the highest value prime found and the for catch in the for loop to exit if the accumulating value goes over
        Dim HighestJumps As Integer = 0 'the highest number of jumps found so far
        Dim answer As Integer 'the answer found so far
        Dim Prev As Integer 'the previous answer
        Dim jumps As Integer = 0 'the number of current jumps
        Dim x As Integer = 0 'the accumulating current answer
        list = GetPrimes(limit)

        For j = 0 To list.Count - 1 'start adding the numbers together from the lowest prime (2) and work upwards. This is the beginning point
            For i = j To list.Count - 1 'add each item in the list after the start point together
                Prev = x 'store the previous answer. The previous answer is used as x may go over the limit
                x += list(i) 'add the next item in the list onto x
                jumps += 1 'and increase the jumps by one

                If IsPrime(Prev) = True Then 'if prev is true:
                    If jumps > HighestJumps Then 'and this is the highest number of jumps found so far,
                        HighestJumps = jumps 'make highests jumps this number
                        answer = Prev 'and make the answer the current prev value
                    End If
                End If
                If x > limit Then Exit For 'if x is above the limit, then exit the for loop. The script will then start again, beginning on prime number higher
            Next
            x = 0 'return both the accumulating value and jumps to 0 for accuracy
            jumps = 0
        Next
        txtAnswer.Text = answer 'display the answer
        txtTime.Text = DateTime.Now.Subtract(StartTime).TotalSeconds 'substract the start time from the time now to find the duration in seconds that the script took to complete
    End Sub

    Function IsPrime(ByVal n As Integer)
        If n = 1 Then Return False '1 is not a primary number so return false
        For i = 2 To Math.Sqrt(n) 'check every number between 2 and the square root
            If n Mod i = 0 Then Return False 'if a divisor is found then n is not a prime
        Next
        Return True 'if n passes all the tests then it is prime
    End Function

    Function GetPrimes(ByVal n As Integer)
        Dim list As New List(Of Integer) 'create the list to hold all the primes
        For i = 1 To n Step 2 'check all odd numbers
            If IsPrime(i) = True Then list.Add(i) 'if the number reports as prime then add to list
        Next
        Return list 'and return the list
    End Function
End Class
