Public Class Problem48
    '////////////////////////////////////////////////////////////////////////////////////
    'Euler Project Problem 48:
    'The series, 1^(1) + 2^(2) + 3^(3) + ... + 10^(10) = 10405071317.
    'Find the last ten digits of the series, 1^(1) + 2^(2) + 3^(3) + ... + 1000^(1000).
    '////////////////////////////////////////////////////////////////////////////////////
    Private Sub Problem48_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim answer As String = 0

        For a = 1 To 1000
            Dim n As String = Power(a, a)
            answer = LongAddition(answer, n)
        Next

        TextBox1.Text = answer.Substring(answer.Count - 10, 10)



    End Sub

    Function LongMultiplication(ByVal n As String, ByVal p As Integer)
        Dim array(1, n.Count) As Integer 'create array with 2 rows and size equal to the number of digits in n

        For i = 0 To n.Count - 1
            array(0, i) = n.Substring(i, 1) 'place each number in a seperate cell on the first row
        Next

        For i = n.Count - 1 To 0 Step -1 'working from the back, begin long multiplication
            array(1, i) += array(0, i) * p 'times each cell by the power (p) and place the result in the cell below
            If i <> 0 Then 'carry over numbers higher than 10 if it is not the cell on the far left
                If array(1, i) > 9 Then 'if value is greater than 9...
                    Dim x As Integer = i - 1 'get cell number of cell to the left of the current cell (the higher value)
                    Dim c As Integer = Math.Floor(array(1, i) / 10)
                    array(1, i) = array(1, i) Mod 10 'keep only the last digit in the current cell
                    array(1, x) = c 'and move the rest to the cell to the left
                End If
            End If
        Next

        Dim answer As String 'create the string to hold the answer
        For i = 0 To n.Count - 1
            answer += array(1, i).ToString 'and join together the answer
        Next

        Return answer

    End Function

    Function Power(ByVal a As String, ByVal p As String)
        Dim n As String = a
        Dim counter As Integer = 1
        Do Until counter = a
            n = LongMultiplication(n, p)
            counter += 1
        Loop
        Return n
    End Function

    Function LongAddition(ByVal a As String, ByVal b As String)
        Do Until a.Count = b.Count 'place leading zeros at the start of the shortest number to stop an error in the array
            If a.Count < b.Count Then
                a = a.Insert(0, 0)
            End If
            If b.Count < a.Count Then
                b = b.Insert(0, 0)
            End If
        Loop

        Dim array(2, a.Count) As Integer 'create array with 3 rows and size equal to the number of digits in 

        For i = 0 To a.Count - 1
            array(0, i) = a.Substring(i, 1) 'place each number in a seperate cell on the first row
            array(1, i) = b.Substring(i, 1) 'place each number in a seperate cell on the second row
        Next

        For i = a.Count - 1 To 0 Step -1 'working from the back, begin long addition
            array(2, i) += array(0, i) + array(1, i) 'add each cell in the column together and place the result in the cell below
            If i <> 0 Then 'carry over numbers higher than 10 if it is not the cell on the far left
                If array(2, i) > 9 Then 'if value is greater than 9...
                    Dim x As Integer = i - 1 'get cell number of cell to the left of the current cell (the higher value)
                    Dim c As Integer = Math.Floor(array(2, i) / 10) 'find the carry over
                    array(2, i) = array(2, i) Mod 10 'keep only the last digit in the current cell
                    array(2, x) = c 'and move the rest to the cell to the left
                End If
            End If
        Next

        Dim answer As String 'create the string to hold the answer
        For i = 0 To a.Count - 1
            answer += array(2, i).ToString 'and join together the answer
        Next

        Return answer
    End Function

End Class
