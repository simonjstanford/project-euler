Public Class Problemx
    '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    'Euler Projects Problem 61:
    'Find the sum of the only ordered set of six cyclic 4-digit numbers for which each polygonal type: 
    'triangle, square, pentagonal, hexagonal, heptagonal, and octagonal, is represented by a different number in the set.
    '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    Private Sub Problem36_Load(ByVal sender As System.Object, ByVal ee As System.EventArgs) Handles MyBase.Load
        Dim answer As Integer 'the variable to hold the accumulating answer
        Dim StartTime As String = Now 'variable used to hold the start time

        For a = 1000 To 9999 '6 seperate for loops for each of the numbers
            If IsTriangle(a) = True Or IsSquare(a) = True Or IsPentagonal(a) = True Or IsHexagonal(a) = True Or IsHeptagonal(a) = True Or IsOctagonal(a) = True Then 'first, check and only allow the script to continue if the number is one of the types needed
                For b = 1000 To 9999
                    If a.ToString.Substring(2, 2) = b.ToString.Substring(0, 2) And a <> b Then 'and check to see if the next number is cyclical.
                        If IsTriangle(b) = True Or IsSquare(b) = True Or IsPentagonal(b) = True Or IsHexagonal(b) = True Or IsHeptagonal(b) = True Or IsOctagonal(b) = True Then
                            For c = 1000 To 9999
                                If b.ToString.Substring(2, 2) = c.ToString.Substring(0, 2) And a <> c And b <> c Then
                                    If IsTriangle(c) = True Or IsSquare(c) = True Or IsPentagonal(c) = True Or IsHexagonal(c) = True Or IsHeptagonal(c) = True Or IsOctagonal(c) = True Then
                                        For d = 1000 To 9999
                                            If c.ToString.Substring(2, 2) = d.ToString.Substring(0, 2) And a <> d And b <> d And c <> d Then
                                                If IsTriangle(d) = True Or IsSquare(d) = True Or IsPentagonal(d) = True Or IsHexagonal(d) = True Or IsHeptagonal(d) = True Or IsOctagonal(d) = True Then
                                                    For e = 1000 To 9999
                                                        If d.ToString.Substring(2, 2) = e.ToString.Substring(0, 2) And a <> e And b <> e And c <> e And d <> e Then
                                                            If IsTriangle(e) = True Or IsSquare(e) = True Or IsPentagonal(e) = True Or IsHexagonal(e) = True Or IsHeptagonal(e) = True Or IsOctagonal(e) = True Then
                                                                For f = 1000 To 9999
                                                                    If e.ToString.Substring(2, 2) = f.ToString.Substring(0, 2) And a <> f And b <> f And c <> f And d <> f And e <> f Then
                                                                        If f.ToString.Substring(2, 2) = a.ToString.Substring(0, 2) Then 'remember to check if the last number cycles round to the first.
                                                                            If IsTriangle(f) = True Or IsSquare(f) = True Or IsPentagonal(f) = True Or IsHexagonal(f) = True Or IsHeptagonal(f) = True Or IsOctagonal(f) = True Then

                                                                                Dim foundTriangle As Boolean = False 'values used a flags to determine if all the different types of numbers are in the collection of 6 numbers
                                                                                Dim foundSquare As Boolean = False
                                                                                Dim foundPent As Boolean = False
                                                                                Dim foundHex As Boolean = False
                                                                                Dim foundHept As Boolean = False
                                                                                Dim foundOct As Boolean = False

                                                                                Dim n As Integer = a + b + c + d + e + f

                                                                                'with each number, check to see which type of number it is and flag the corresponding value
                                                                                If IsTriangle(a) = True And foundTriangle = False Then 'hexagonal numbers are always triangular numbers. this and the hex test below simply tests for 2 triangular numbers, and marks one of them as hex
                                                                                    foundTriangle = True
                                                                                ElseIf IsSquare(a) = True Then
                                                                                    foundSquare = True
                                                                                ElseIf IsPentagonal(a) = True Then
                                                                                    foundPent = True
                                                                                ElseIf IsTriangle(a) = True And foundTriangle = True Then 'this test is not very accurate - all hex numbers are triangular , but only some triangular numbers are hex. this, however, is the simplist way to do it.
                                                                                    foundHex = True
                                                                                ElseIf IsHeptagonal(a) = True Then
                                                                                    foundHept = True
                                                                                ElseIf IsOctagonal(a) = True Then
                                                                                    foundOct = True
                                                                                End If


                                                                                If IsTriangle(b) = True And foundTriangle = False Then
                                                                                    foundTriangle = True
                                                                                ElseIf IsSquare(b) = True Then
                                                                                    foundSquare = True
                                                                                ElseIf IsPentagonal(b) = True Then
                                                                                    foundPent = True
                                                                                ElseIf IsTriangle(b) = True And foundTriangle = True Then
                                                                                    foundHex = True
                                                                                ElseIf IsHeptagonal(b) = True Then
                                                                                    foundHept = True
                                                                                ElseIf IsOctagonal(b) = True Then
                                                                                    foundOct = True
                                                                                End If


                                                                                If IsTriangle(c) = True And foundTriangle = False Then
                                                                                    foundTriangle = True
                                                                                ElseIf IsSquare(c) = True Then
                                                                                    foundSquare = True
                                                                                ElseIf IsPentagonal(c) = True Then
                                                                                    foundPent = True
                                                                                ElseIf IsTriangle(c) = True And foundTriangle = True Then
                                                                                    foundHex = True
                                                                                ElseIf IsHeptagonal(c) = True Then
                                                                                    foundHept = True
                                                                                ElseIf IsOctagonal(c) = True Then
                                                                                    foundOct = True
                                                                                End If

                                                                                If IsTriangle(d) = True And foundTriangle = False Then
                                                                                    foundTriangle = True
                                                                                ElseIf IsSquare(d) = True Then
                                                                                    foundSquare = True
                                                                                ElseIf IsPentagonal(d) = True Then
                                                                                    foundPent = True
                                                                                ElseIf IsTriangle(d) = True And foundTriangle = True Then
                                                                                    foundHex = True
                                                                                ElseIf IsHeptagonal(d) = True Then
                                                                                    foundHept = True
                                                                                ElseIf IsOctagonal(d) = True Then
                                                                                    foundOct = True
                                                                                End If


                                                                                If IsTriangle(e) = True And foundTriangle = False Then
                                                                                    foundTriangle = True
                                                                                ElseIf IsSquare(e) = True Then
                                                                                    foundSquare = True
                                                                                ElseIf IsPentagonal(e) = True Then
                                                                                    foundPent = True
                                                                                ElseIf IsTriangle(e) = True And foundTriangle = True Then
                                                                                    foundHex = True
                                                                                ElseIf IsHeptagonal(e) = True Then
                                                                                    foundHept = True
                                                                                ElseIf IsOctagonal(e) = True Then
                                                                                    foundOct = True
                                                                                End If


                                                                                If IsTriangle(f) = True And foundTriangle = False Then
                                                                                    foundTriangle = True
                                                                                ElseIf IsSquare(f) = True Then
                                                                                    foundSquare = True
                                                                                ElseIf IsPentagonal(f) = True Then
                                                                                    foundPent = True
                                                                                ElseIf IsTriangle(f) = True And foundTriangle = True Then
                                                                                    foundHex = True
                                                                                ElseIf IsHeptagonal(f) = True Then
                                                                                    foundHept = True
                                                                                ElseIf IsOctagonal(f) = True Then
                                                                                    foundOct = True
                                                                                End If

                                                                                If foundTriangle = True And foundSquare = True And foundPent = True And foundHex = True And foundHept = True And foundOct = True Then
                                                                                    MsgBox(a & vbCrLf & b & vbCrLf & c & vbCrLf & d & vbCrLf & e & vbCrLf & f & vbCrLf & n) 'if all the flags are true, this could be the answer so display it. 
                                                                                End If

                                                                            End If
                                                                        End If
                                                                    End If
                                                                Next
                                                            End If
                                                        End If
                                                    Next
                                                End If
                                            End If
                                        Next
                                    End If
                                End If
                            Next
                        End If
                    End If
                Next
            End If
        Next

        For Each x In list
            answer += x & vbCrLf
        Next

        MsgBox(answer)
        txtAnswer.Text = answer 'print answer
        txtTime.Text = DateTime.Now.Subtract(StartTime).TotalSeconds 'substract the start time from the time now to find the duration in seconds that the script took to complete
    End Sub


    Function IsTriangle(ByVal n As Int64)
        Dim x As Double = Math.Sqrt((n * 8) + 1) 'calculate to see if it a triangular number. A number is triangular if the square root of (n*8) + 1 is an integer
        Dim y As Int64 = x 'create an integer variable and place the result of the above in it.

        If x = y Then 'compare integer and double to see if they are the same
            Return True 'if they are, then it is a triangular number
        Else
            Return False
        End If

    End Function

    Function IsSquare(ByVal n As Int64)
        Dim x As Double = Math.Sqrt(n)
        Dim y As Int64 = x

        If x = y Then
            Return True
        Else
            Return False
        End If
    End Function

    Function IsPentagonal(ByVal n As Int64)
        Dim x As Double = (Math.Sqrt((24 * n) + 1) + 1) / 6 'a number is pentagonal if the result of √((24*n)+1) + 1 / 6 is an integer
        Dim y As Int64 = x 'create an integer variable and place the result of the above in it.

        If x = y Then 'compare the integer and double to see if they are the same
            Return True 'if they are, then it is a pentagonal number
        Else
            Return False
        End If

    End Function

    Function IsHexagonal(ByVal n As Int64)
        Dim x As Double = (Math.Sqrt((8 * n) + 1) + 1) / 4  'a number is hexagonal if the result of √((8*n)+1) + 1 / 4 is an integer
        Dim y As Int64 = x 'create an integer variable and put the double variable in it

        If x = y Then 'compare the two
            Return True 'if they are the same, n is a hexagonal number
        Else
            Return False
        End If
    End Function

    Function IsHeptagonal(ByVal n As Int64)
        For i = 1 To n
            If (i * ((5 * i) - 3)) / 2 = n Then Return True
        Next
        Return False
    End Function

    Function IsOctagonal(ByVal n As Int64)
        For i = 1 To n
            If i * ((3 * i) - 2) = n Then Return True
        Next
        Return False
    End Function

End Class
