Public Class Form1
    'Project Euler Problem 27:
    'Considering quadratics of the form:  n² + an + b, where |a| < 1000 and |b| < 1000 (where |n| is the modulus/absolute value of n  e.g. |11| = 11 and |−4| = 4)
    'Find the product of the coefficients, a and b, for the quadratic expression that produces the maximum number of primes for consecutive values of n, starting with n = 0.
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim NumberOfPrimes As Integer = 0
        Dim answer As Integer

        'for loop to go through every permutation of a and b between -1000 and 1000
        For a = -1000 To 1000
            For b = -1000 To 1000
                Dim tempList As New List(Of Integer)
                For n = 0 To 1000
                    Dim x As Integer = QuadEquation(n, a, b) 'find the answer to the equation
                    If IsPrime(x) = True Then 'use IsPrime function to see if it is a prime. if true...
                        tempList.Add(x) '...add the prime number to the list
                    Else
                        Exit For 'when the script reaches a number that is not a prime exit the for loop
                    End If
                Next
                If tempList.Count > NumberOfPrimes Then 'if the total number of primes found is more than the previous record...
                    NumberOfPrimes = tempList.Count ' then update this variable with the new max...
                    answer = a * b 'and calculate the potential answer
                    'ListBox1.Items.Add("a: " & a & "  b: " & b & "  #: " & NumberOfPrimes)
                End If
            Next
        Next
        MsgBox(answer) 'display the final answer
    End Sub

    Function IsPrime(ByVal n As Integer) 'finds the first 10000 primes, and puts them into a list

        Dim tempList As New List(Of Integer) 'create new list to hold all numbers n is divisable by

        For i = 2 To n / 2 'for loop to check what numbers n is divisable by. Starts at two because all numbers are divisable by 1. finishes a n /2 because a number larger than that will not be a divisor of n
            If n Mod i = 0 Then tempList.Add(i) 'if 0 is the remainder, add the number to the tempList
        Next

        If n <= 1 Then Return False 'if n is equal or less than 1, return false because they are all not primes and the function does not cope well with them
        If tempList.Count = 0 Then 'if the templist has no entries, the number is a prime
            Return True 'so return true
        Else
            Return False
        End If


    End Function

    Function QuadEquation(ByVal n As Integer, ByVal a As Integer, ByVal b As Integer)
        Dim x As Integer = (n * n) + (a * n) + b
        Return x
    End Function

End Class


