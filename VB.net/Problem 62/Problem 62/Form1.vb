Public Class Problemx
    '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    'Euler Projects Problem 62:
    'The cube, 41063625 (345^(3)), can be permuted to produce two other cubes: 56623104 (384^(3)) and 66430125 (405^(3)). 
    'In fact, 41063625 is the smallest cube which has exactly three permutations of its digits which are also cube.
    'Find the smallest cube for which exactly five permutations of its digits are cube.
    '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    Private Sub Problem36_Load(ByVal sender As System.Object, ByVal ee As System.EventArgs) Handles MyBase.Load
        Dim answer As Integer 'the variable to hold the accumulating answer
        Dim StartTime As String = Now 'variable used to hold the start time

        Dim Cubes As New List(Of Int64)
        For i = 1 To 9999 'get the cubes of all numbers between 1 and 9999 - this is arbitrary
            Dim n As Int64 = Math.Pow(i, 3)
            Cubes.Add(n) 'add add them to the list
        Next

        For a = 0 To Cubes.Count - 1 'go through the numbers, and find 5 that are all permuatations:
            For b = 0 To Cubes.Count - 1
                If IsPermutation(Cubes(a), Cubes(b)) = True And a <> b Then 'find a number in the list that is a permutation of a
                    For c = 0 To Cubes.Count - 1
                        If IsPermutation(Cubes(b), Cubes(c)) = True And a <> c And b <> c Then 'find a number in the list that is a permutation of b
                            For d = 0 To Cubes.Count - 1
                                If IsPermutation(Cubes(c), Cubes(d)) = True And a <> d And b <> d And c <> d Then 'find a number in the list that is a permutation of c
                                    For e = 0 To Cubes.Count - 1
                                        If IsPermutation(Cubes(d), Cubes(e)) = True And a <> e And b <> e And c <> e And d <> e Then 'find a number in the list that is a permutation of d
                                            'MsgBox(Cubes(a) & vbCrLf & Cubes(b) & vbCrLf & Cubes(c) & vbCrLf & Cubes(d) & vbCrLf & Cubes(e)) 'if the script has got to this point, it has found the answer
                                            answer = a
                                            txtAnswer.Text = answer 'print answer
                                            txtTime.Text = DateTime.Now.Subtract(StartTime).TotalSeconds 'substract the start time from the time now to find the duration in seconds that the script took to complete
                                            Exit Sub
                                        End If
                                    Next
                                End If
                            Next
                        End If
                    Next
                End If
            Next
        Next
    End Sub


    Function IsPermutation(ByVal a As String, ByVal b As String) 'determines if two variables have exactly the same digits in them
        If a.Count <> b.Count Then 'if the two numbers don't have the same amount of digits, then they aren't permutations
            Return False 'so return false
        Else
            Dim listA As New List(Of Integer) 'the list to hold string a
            Dim listB As New List(Of Integer) 'the list to hold string b

            For i = 0 To a.Count - 1
                listA.Add(a.Substring(i, 1)) 'place each digit from a in the list
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
