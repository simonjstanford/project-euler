Public Class Problemx
    '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    'Euler Projects Problem x:
    'What is the side length of the square spiral for which the ratio of primes along both diagonals first falls below 10%?
    '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    Private Sub Problem36_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim answer As Integer = 1 'the variable to hold the accumulating answer
        Dim StartTime As String = Now 'variable used to hold the start time

        'DECLARATIONS
        '********************************************
        Dim LeftUp As Integer = 1
        Dim RightUP As Integer = 1
        Dim leftDown As Integer = 1
        Dim RightDown As Integer = 1

        Dim n As Integer = 0 'the accumulating number to add on to the previous number to get the next
        Dim allNumbers As New List(Of Integer) 'the list of all the numbers found so far
        Dim list As New List(Of Integer) 'the list of all the numbers found in one loop. for speed, after these numbers are checked for prime, they are added to allNumbers. This means that numbers are checked if prime only once
        Dim CountPrimes As Integer = 0 'the total number of primes


        'BODY
        '********************************************
        allNumbers.Add(1) 'add 1 to the allNumbers list, as it is not prime.

        Do
            LeftUp += (n + 4) 'calculate the next number for each diagonal
            leftDown += (n + 6)
            RightUP += (n + 2)
            RightDown += (n + 8)

            list.Add(LeftUp) 'add each new number to the list
            list.Add(leftDown)
            list.Add(RightUP)
            list.Add(RightDown)

            answer += 2 'increase the size of the spiral. This is also the answer
            allNumbers.AddRange(list) 'add the current list to AllNumbers

            For Each x In list
                If IsPrime(x) = True Then CountPrimes += 1 'if the numbers found are prime, increase the CountPrimes by 1
            Next

            list.Clear() 'then clear the list

            Dim t As Integer = allNumbers.Count 'put each of these values into variables to calculate the percentage. It does not calculate it properly if you don't make seperate variables
            Dim s As Integer = CountPrimes
            Dim p As Decimal = (s / t) * 100

            If p <= 10 Then 'if a percentage is found that is below 10%:
                txtAnswer.Text = answer 'print answer
                txtTime.Text = DateTime.Now.Subtract(StartTime).TotalSeconds 'substract the start time from the time now to find the duration in seconds that the script took to complete
                Exit Sub 'exit sub
            End If

            n += 8 'increase n for the next loop
        Loop

    End Sub

    Function IsPrime(ByVal n As Integer)
        If n = 1 Then Return False '1 is not a primary number so return false
        For i = 2 To Math.Sqrt(n) 'check every number between 2 and the square root
            If n Mod i = 0 Then Return False 'if a divisor is found then n is not a prime
        Next
        Return True 'if n passes all the tests then it is prime
    End Function

End Class
