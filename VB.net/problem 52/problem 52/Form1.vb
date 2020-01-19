Public Class Problem52
    '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    'Euler Project Problem 52:
    'It can be seen that the number, 125874, and its double, 251748, contain exactly the same digits, but in a different order.
    'Find the smallest positive integer, x, such that 2x, 3x, 4x, 5x, and 6x, contain the same digits.
    '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    Private Sub Problem52_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim StartTime As String = Now 'start date, used to calculate time taken
        Dim n As Integer = 1 'the number to check
        Do 'run do loop that checks if it passes the function at each multiplication. if it gets to the end, n is the answer. 
            If IsSameDigits(n, n * 2) = True Then
                If IsSameDigits(n, n * 3) = True Then
                    If IsSameDigits(n, n * 4) = True Then
                        If IsSameDigits(n, n * 5) = True Then
                            If IsSameDigits(n, n * 6) = True Then
                                Exit Do
                            End If
                        End If
                    End If
                End If
            End If
            n += 1
        Loop
        txtAnswer.Text = n 'display the answer
        txtTime.Text = DateTime.Now.Subtract(StartTime).TotalSeconds 'substract the start time from the time now to find the duration in seconds that the script took to complete
    End Sub

    Function IsSameDigits(ByVal a As String, ByVal b As String)
        Dim aTest As String 'variable used to place the reordered a value
        Dim bTest As String 'variable used to place the reordered b value
        Dim aList As New List(Of String) 'list to sort the values of a
        Dim bList As New List(Of String) 'list to sort the values of b

        If a.Count <> b.Count Then Return False 'if the length of a and b is not equal, then they do not have the same digits

        For i = 0 To a.Count - 1 'add each digit from a and b to the respective lists
            aList.Add(a.Substring(i, 1))
            bList.Add(b.Substring(i, 1))
        Next

        aList.Sort() 'sort both of them
        bList.Sort()

        For i = 0 To a.Count - 1
            aTest = aTest & aList(i) 'place the reordered numbers into the test variables
            bTest = bTest & bList(i)
        Next

        If aTest = bTest Then 'if the test variables match, they contain the same digits
            Return True
        Else
            Return False
        End If
    End Function

End Class
