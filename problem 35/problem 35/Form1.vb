Public Class Problem35
    'Euler Projects Problem 35: 
    'The number, 197, is called a circular prime because all rotations of the digits: 197, 971, and 719, are themselves prime.
    'There are thirteen such primes below 100: 2, 3, 5, 7, 11, 13, 17, 31, 37, 71, 73, 79, and 97.
    'How many circular primes are there below one million?
    Private Sub Problem35_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim list As New List(Of Integer) 'the list to count the different permutations
        Dim answer As Integer 'the accumulating final answer

        For i = 2 To 1000 'test the numbers from 2 to 1 million. 1 is not part of the question.
            If i Mod 2 <> 0 Or i Mod 3 <> 0 Or i Mod 5 <> 0 Then 'if the number is not divisable by 2, 3 or 5 then run test.
                If IsPrime(i) = True Then 'if i is a prime then run test
                    Dim counter As Integer = 0 'variable used to count the number of rotations that are primes
                    Dim n As String = i 'variable used to create each rotation:
                    n = n.Remove(n.Count - 1, 1) 'remove the last digit
                    Dim x As Integer = i.ToString.Substring(i.ToString.Count - 1, 1) 'take the last digit from i
                    n = n.Insert(0, x) 'and then insert it at the front of n
                    list.Add(n) 'this is the first rotation, and add to the list


                    Do Until n = i 'create the other rotations. run this do loop until the number matches the original number
                        x = n.ToString.Substring(n.ToString.Count - 1, 1) 'copy the last digit from n
                        n = n.Remove(n.Count - 1, 1) 'remove the last digit from n
                        n = n.Insert(0, x) 'insert the last digit onto the front of n
                        list.Add(n) 'add this to the loop
                    Loop

                    For Each number As Integer In list 'now check each number in the list to see if this is a prime
                        If number Mod 2 <> 0 Or i Mod 3 <> 0 Or i Mod 5 <> 0 Then 'only if the number is not divisable by 2, 3 or 5
                            If IsPrime(number) = True Then counter += 1 'if a rotation is a prime, increase counter by 1.
                        End If
                    Next

                    If counter = list.Count Then answer += 1 'if counter is equal to list.count then all the rotations are prime, so add one to the final answer

                    list.Clear() 'clear the list and start again.

                End If
            End If

        Next

        TextBox1.Text = answer 'display the answer
    End Sub


    Function IsPrime(ByVal n As Integer)
        Dim list As New List(Of Integer)

        For i = 2 To Math.Sqrt(n) 'test all numbers after one and before half of the number tested
            If n Mod i = 0 Then list.Add(i) 'if it is divisable by one of these numbers add it to the list
        Next

        If list.Count = 0 Then 'if there is no divisable numbers then it is a prime
            Return True
        Else
            Return False
        End If
    End Function
End Class
