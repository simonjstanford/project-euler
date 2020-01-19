Imports System.IO
Public Class Form1
    'using the technique of taking numbers out of a list, breaking them down and putting them into an array, this script uses long addition to find the first number in the fibonacci
    'sequence that has 1000 digits
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim list As New List(Of String)
        list.Add(1) 'put first two numbers in list
        list.Add(1)
        Dim b As String = list(0).ToString 'make first list item = 0

        Do Until list.Last.Count = 1000 'continue script until the last list item has 1000 digits
            Dim a As String = list.Last ' make a = last list item
            Dim array(2, a.Count) As Integer 'create an array for long addtion

            Do Until a.Count = b.Count 'had problems with putting numbers into the correct cell in the array when b had less digits than a
                If b.Count < a.Count Then 'to stop this, this part places leading 0's on b until they are the same length
                    b = b.Insert(0, "0")
                End If
            Loop

            For i = 0 To a.Count - 1
                array(1, i) = a.Substring(i, 1) 'add last two list items to row 0 and row 1 of array
                array(0, i) = b.Substring(i, 1)
            Next

            For i = a.Count - 1 To 0 Step -1 'working backwards calculate long division. 
                array(2, i) += array(1, i) + array(0, i) 'note that += is necessary as otherwise the calculations will overwrite each other
                If i <> 0 Then 'if it is not column 0 then carry over numbers higher than 9
                    If array(2, i) > 9 Then
                        Dim largerNumber As Integer = i - 1 'get the next column in the sequence
                        Dim CarryOver As Integer = Math.Floor(array(2, i) / 10) 'divide the number more than 9 by 10 to get the amount to carry over
                        array(2, i) = array(2, i) Mod 10 'mod the number more than 9 to get the remainder to stay behind
                        array(2, largerNumber) += CarryOver 'add the carryover to the next cell along. note += is necessary as otherwise the calculations will overwrite each other
                    End If
                End If
            Next


            'when finished, put each cell value together in a string
            Dim accumulate As String
            For i = 0 To a.Count - 1
                accumulate += array(2, i).ToString 'add each cell in the bottom row together in a string to get the 
            Next
            list.Add(accumulate) 'add string as the last item on the list
            accumulate = Nothing 'make accumulate nothing ready for the next loop
            b = a 'make b = a. this makes the last list item the one before last, ready for the next loop
        Loop

        TextBox1.Text = list.Count 'print answer when finished.

    End Sub

End Class

