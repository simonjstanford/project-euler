Public Class Problemx
    '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    'Euler Projects Problem 60:
    'The primes 3, 7, 109, and 673, are quite remarkable. By taking any two primes and concatenating them in any order the result will always be prime. 
    'For example, taking 7 and 109, both 7109 and 1097 are prime. The sum of these four primes, 792, represents the lowest sum for a set of four primes with this property.
    'Find the lowest sum for a set of five primes for which any two primes concatenate to produce another prime.
    '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    Private Sub Problem36_Load(ByVal sender As System.Object, ByVal eee As System.EventArgs) Handles MyBase.Load
        Dim answer As Integer = 0 'the variable to hold the accumulating answer
        Dim StartTime As String = Now 'variable used to hold the start time
        Dim list As New List(Of Integer) 'list to hold the prime numbers to check

        list = GetPrimes(10000) 'get all primes under 10000 - this is an arbitrary number

        For a = 0 To list.Count - 1 'get each number using a seperate for loop.  
            For b = 0 To list.Count - 1
                If IsPrime(list(a) & list(b)) = True Then 'To speed up the looping, instead of placing all the if statements at the end put them at the earliest opportunity 
                    If IsPrime(list(b) & list(a)) = True Then 'This means that each number created will only be checked once, whereas at the end every number is checked after each new permutation of any number
                        For c = 0 To list.Count - 1
                            If IsPrime(list(a) & list(c)) = True Then
                                If IsPrime(list(c) & list(a)) = True Then
                                    If IsPrime(list(b) & list(c)) = True Then
                                        If IsPrime(list(c) & list(b)) = True Then
                                            For d = 0 To list.Count - 1
                                                If IsPrime(list(a) & list(d)) = True Then
                                                    If IsPrime(list(d) & list(a)) = True Then
                                                        If IsPrime(list(b) & list(d)) = True Then
                                                            If IsPrime(list(d) & list(b)) = True Then
                                                                If IsPrime(list(c) & list(d)) = True Then
                                                                    If IsPrime(list(d) & list(c)) = True Then
                                                                        For e = 0 To list.Count - 1
                                                                            If IsPrime(list(a) & list(e)) = True Then
                                                                                If IsPrime(list(e) & list(a)) = True Then
                                                                                    If IsPrime(list(b) & list(e)) = True Then
                                                                                        If IsPrime(list(e) & list(b)) = True Then
                                                                                            If IsPrime(list(c) & list(e)) = True Then
                                                                                                If IsPrime(list(e) & list(c)) = True Then
                                                                                                    If IsPrime(list(d) & list(e)) = True Then
                                                                                                        If IsPrime(list(e) & list(d)) = True Then
                                                                                                            Dim n As Integer = list(a) + list(b) + list(c) + list(d) + list(e) 'add all the numbers together
                                                                                                            Select Case answer 'if it is the lowest found so far, make this the answer
                                                                                                                Case 0 'or if no answer has yet been found, make this the answer
                                                                                                                    answer = n
                                                                                                                Case n < answer
                                                                                                                    answer = n
                                                                                                            End Select
                                                                                                            MsgBox(list(a) & vbCrLf & list(b) & vbCrLf & list(c) & vbCrLf & list(d) & vbCrLf & list(e) & vbCrLf & n) 'also display each answer found when it appears.
                                                                                                        End If
                                                                                                    End If
                                                                                                End If
                                                                                            End If
                                                                                        End If
                                                                                    End If
                                                                                End If
                                                                            End If
                                                                        Next
                                                                    End If
                                                                End If
                                                            End If
                                                        End If
                                                    End If
                                                End If
                                            Next
                                        End If
                                    End If
                                End If
                            End If
                        Next
                    End If
                End If
            Next
        Next


        txtAnswer.Text = answer 'print answer
        txtTime.Text = DateTime.Now.Subtract(StartTime).TotalSeconds 'substract the start time from the time now to find the duration in seconds that the script took to complete
    End Sub

    Function IsPrime(ByVal n As Integer)
        If n = 1 Then Return False '1 is not a primary number so return false
        For i = 2 To Math.Sqrt(n) 'check every number between 2 and the square root
            If n Mod i = 0 Then Return False 'if a divisor is found then n is not a prime
        Next
        Return True 'if n passes all the tests then it is prime
    End Function

    Function GetPrimes(ByVal n As Integer) 'gets a list of primes up to a specified number. Uses IsPrimes function to retrieve all primes below 1 million in ~ 3 seconds
        Dim list As New List(Of Integer) 'create the list to hold all the primes
        For i = 1 To n Step 2 'check all odd numbers
            If IsPrime(i) = True Then list.Add(i) 'if the number reports as prime then add to list
        Next
        Return list 'and return the list
    End Function

    
End Class
