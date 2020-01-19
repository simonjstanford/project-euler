Public Class Problemx
    'Euler Projects Problem x:
    '
    '
    '
    Private Sub Problem36_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim answer As Integer 'the variable to hold the accumulating answer
        Dim StartTime As String = Now 'variable used to hold the start time


        'code


        txtAnswer.Text = answer 'print answer
        txtTime.Text = DateTime.Now.Subtract(StartTime).TotalSeconds 'substract the start time from the time now to find the duration in seconds that the script took to complete
    End Sub
End Class
