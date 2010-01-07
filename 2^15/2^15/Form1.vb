Imports System.IO
Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim list As New List(Of String)
        Dim counter As Integer = 0

        list.Add(2)

        Do Until counter > 998
            Dim a As String = list.Item(counter)
            Dim array(2, a.Count) As Integer

            For i = 0 To a.Count - 1
                array(0, i) = a.Substring(i, 1)
            Next


            For i = a.Count - 1 To 0 Step -1
                array(1, i) += array(0, i) * 2
                If i <> 0 Then
                    If array(1, i) > 9 Then
                        Dim largerNumber As Integer = i - 1
                        Dim CarryOver As Integer = Math.Floor(array(1, i) / 10)
                        array(1, i) = array(1, i) Mod 10
                        array(1, largerNumber) += CarryOver
                    Else
                    End If
                End If
            Next

            Dim accumulate As String
            For i = 0 To a.Count - 1
                accumulate += array(1, i).ToString
            Next
            list.Add(accumulate)
            counter += 1
            'MsgBox(accumulate)
            accumulate = Nothing
        Loop

        Dim j As String = list.Last.ToString
        'MsgBox(j)
        Dim answer As Integer
        For i = 0 To j.Count - 1
            answer += j.Substring(i, 1)
        Next


        TextBox1.Text = answer
    End Sub
End Class
