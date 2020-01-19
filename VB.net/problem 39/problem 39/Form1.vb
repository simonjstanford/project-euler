Public Class Problem39
    Private Sub Problem39_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim answer As Integer = 0 'the variable to hold the accumulating answer
        Dim StartTime As String = Now 'variable used to hold the start time
        Dim array(1000) 'the array to hold the number of combinations for each parimeter length

        For x = 1 To 1000
            For y = 1 To 1000
                For z = 1 To 1000
                    Dim n As Integer = x + y + z 'add each side length together
                    If n <= 1000 Then 'if the perimeter length is 1000 or less:
                        If (z * z) = ((y * y) + (x * x)) Then 'find out if the triangle would be a right angle.
                            array(n) += 1 'if it is, add 1 to the array location that equals the array combination
                        End If
                    End If
                Next
            Next
        Next

        For i = 1 To array.Count - 1
            If array(i) > answer Then answer = i 'run through each item in the array, if it is the biggest so far, make the answer that array location
        Next

        txtAnswer.Text = answer 'print answer
        txtTime.Text = DateTime.Now.Subtract(StartTime).TotalSeconds 'substract the start time from the time now to find the duration in seconds that the script took to complete
    End Sub
End Class
