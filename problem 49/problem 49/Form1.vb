Public Class Problem49
    '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    'Euler Project Problem 49:
    'The arithmetic sequence, 1487, 4817, 8147, in which each of the terms increases by 3330, is unusual in two ways: 
    '(i) each of the three terms are prime, and, (ii) each of the 4-digit numbers are permutations of one another.
    'There are no arithmetic sequences made up of three 1-, 2-, or 3-digit primes, exhibiting this property, but there is one other 4-digit increasing sequence.
    'What 12-digit number do you form by concatenating the three terms in this sequence?
    '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    Private Sub Problem49_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim b As Integer 'the variable for the second number
        Dim c As Integer 'the variable for the thrid number

        For a = 1000 To 9999 'the variable for the first number
            For i = 1 To 5000 'the variable for adding to a to create b and c
                If IsPrime(a) = True Then 'if a is a prime...
                    b = a + i 'add i to a to create b
                    If IsPrime(b) = True And IsPermutation(a, b) = True Then 'if b is a prime, and b is a permutation of a then...
                        c = b + i '...add i to b to get c.
                        If IsPrime(c) = True And IsPermutation(c, b) = True Then 'if c is a prime, and c is a permutation of b then...
                            MsgBox(a & vbCrLf & b & vbCrLf & c) 'print the numbers. there are only two sets, one of which is in the question. The other is the answer.
                        End If
                    End If
                End If
            Next
        Next
    End Sub

    Function IsPrime(ByVal n As Integer)
        If n = 1 Then Return False '1 is not a primary number so return false
        For i = 2 To Math.Sqrt(n) 'check every number between 2 and the square root
            If n Mod i = 0 Then Return False 'if a divisor is found then n is not a prime
        Next
        Return True 'if n passes all the tests then it is prime
    End Function

    Function IsPermutation(ByVal a As String, ByVal b As String)
        If a.Count <> b.Count Then 'if the two numbers don't have the same amount of digits, then they aren't permutations
            Return False 'so return false
        Else
            Dim listA As New List(Of Integer) 'the list to hold string a
            Dim listB As New List(Of Integer) 'the list to hold string b

            For i = 0 To a.Count - 1
                listA.Add(a.Substring(i, 1)) 'place each digit from a in the list
            Next

            For i = 0 To b.Count - 1
                listB.Add(b.Substring(i, 1)) 'place each digit from b in the list
            Next

            listA.Sort() 'sort both the lists
            listB.Sort()

            For i = 0 To a.Count - 1
                If listA(i) <> listB(i) Then Return False 'and see if each level matches. If not, it is not a permutation
            Next
        End If

        Return True 'if the two strings pass all the tests, then it is a permutation

    End Function

End Class
