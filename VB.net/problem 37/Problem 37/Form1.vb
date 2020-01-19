Public Class Problem37

    Private Sub Problem37_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim StartTime As String = Now 'start date, used to calculate time taken.
        Dim answer As Integer 'the accumulating answer
        Dim CountPrimes As Integer = 0 'counts the number of primes that the question is looking for

        For i = 11 To 1000000 Step 2 'only check even numbers. 3, 5 and 7 are not part of the answer.
            If i Mod 3 <> 0 Or i Mod 5 <> 0 Or i Mod 7 <> 0 Then 'only check numbers that aren't divisable by 3,5 and 7. Used to speed up script.
                If IsPrime(i) = True Then 'if i is prime:
                    Dim NumberOfPrimes As Integer 'variable to count the number of primes created from i
                    Dim NumberOfNumbers As Integer 'variable to count the number of numbers created from i
                    Dim test As Integer = i 'variable to reduce the number from right to left
                    Dim test2 As Integer = i 'variable to reduce the number from left to right

                    Do Until test.ToString.Count = 1 'reduce the number until there is only 1 left
                        test = test.ToString.Remove(test.ToString.Count - 1, 1) 'remove the last digit
                        If IsPrime(test) = True Then NumberOfPrimes += 1 'test if prime, if true then add to list of primes
                        NumberOfNumbers += 1 'add one to this variable, to later confirm if all the reduced numbers are prime
                    Loop


                    Do Until test2.ToString.Count = 1 'reduce the number until there is only 1 left
                        test2 = test2.ToString.Remove(0, 1) 'remove the first digit
                        If IsPrime(test2) = True Then NumberOfPrimes += 1 'test if prime, if true then add to list of primes
                        NumberOfNumbers += 1 'add one to this variable, to later confirm if all the reduced numbers are prime
                    Loop

                    If NumberOfNumbers = NumberOfPrimes Then 'check to see if all numbers created from i are prime. If true:
                        answer += i 'add the prime to i
                        CountPrimes += 1 'increase the number of primes found by one.
                    End If

                    NumberOfNumbers = 0 'reset the variables for the next loop
                    NumberOfPrimes = 0 'reset the variables for the next loop
                    If CountPrimes = 11 Then Exit For 'if 11 primes are found then exit
                End If
            End If
        Next
        txtAnswer.Text = answer 'display the answer
        txtTime.Text = DateTime.Now.Subtract(StartTime).TotalSeconds 'substract the start time from the time now to find the duration in seconds that the script took to complete
    End Sub

    Function IsPrime(ByVal n As Integer)
        Dim list As New List(Of Integer) 'the list to hold the numbers divisable by n

        If n = 1 Then Return False 'in this script, this line of code is necessary as it is possible that one would be tested, and 1 is not a prime number

        For i = 2 To Math.Floor(Math.Sqrt(n)) 'test all numbers after one and before the square root of the number tested
            If n Mod i = 0 Then list.Add(i) 'if it is divisable by one of these numbers add it to the list
        Next

        If list.Count = 0 Then 'if there is no divisable numbers then it is a prime
            Return True
        Else
            Return False
        End If
    End Function
End Class
