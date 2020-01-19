Imports System.IO
Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim list As New List(Of String)
        Dim counter As Integer = 3

        'add items to list, take item from list and put into array. For each cell in the array carry out long multiplication, then add result to current 
        'value of cell.  If cell is not 0 and > 9 then carry over.
        list.Add(1)
        list.Add(2)

        Do Until counter > 100
            Dim TimesBy As Integer = counter - 2
            Dim a As String = list.Item(TimesBy)
            Dim array(2, a.Count) As Integer

            'add last list item to row 0 of array
            For i = 0 To a.Count - 1
                array(0, i) = a.Substring(i, 1)
            Next

            'working from the back, carry out long multiplication and add to current cell value: Times each cell value by the next number in the sequence
            For i = a.Count - 1 To 0 Step -1
                array(1, i) += (array(0, i) * counter)
                'if column is not 0 then carry over number higher than 9
                If i <> 0 Then
                    If array(1, i) > 9 Then
                        Dim largerNumber As Integer = i - 1
                        Dim CarryOver As Integer = Math.Floor(array(1, i) / 10)
                        array(1, i) = array(1, i) Mod 10
                        array(1, largerNumber) += CarryOver
                    End If
                End If
            Next

            'when finished, put each cell value together in a string
            Dim accumulate As String
            For i = 0 To a.Count - 1
                accumulate += array(1, i).ToString
            Next
            'add string as the last item on the list
            list.Add(accumulate)
            'increase counter and start again
            counter += 1
            'MsgBox(accumulate)
            accumulate = Nothing
        Loop

        'MsgBox(list.Last.ToString)

        'add up all digits of the result of 100! (100*99*98*97....) to give the final answer
        Dim j As String = list.Last.ToString
        'MsgBox(j)
        Dim answer As Integer
        For i = 0 To j.Count - 1
            answer += j.Substring(i, 1)
        Next


        TextBox1.Text = answer
    End Sub
End Class
