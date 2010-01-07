Imports System.Threading
Public Class Problem40
    Dim Max As Integer = 1000000 'the number to run the test to. Also used for setting the maximum of the progress bar.
    Dim n As Integer = 2 'the current number being ran through the script. Also used for updating the progress bar.
    Dim answer As Integer 'the final answer
    Dim StartTime As String = Now 'variable used to hold the start time
    Dim d As String = "1" 'create the string variable that will hold the collection of numbers

    Private Sub Problem40_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim CalcThread As New Thread(AddressOf Calculate) 'create the worker thread

        ProgressBar.Minimum = 1 'set the minimum value of the progress bar
        ProgressBar.Maximum = Max 'set the maximum value of the progress bar
        ProgressBar.Step = Max 'set the number of steps in the progress bar

        CalcThread.Start() 'begin the worker thread

    End Sub

    Sub Calculate()

        Do Until d.Count > Max 'run a loop until the string has reached the required limit (1000000)
            d = d & n 'add the current number onto the string
            n += 1 'increase the current number by one and start the loop again.
        Loop

        answer = d.Substring(0, 1) * d.Substring(9, 1) * d.Substring(99, 1) * d.Substring(999, 1) * d.Substring(9999, 1) * d.Substring(99999, 1) * d.Substring(999999, 1) 'work out the answer required. All locations are -1 due to strings beginning at 0 not 1
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim x As Integer = d.Count 'every second update the value of the progress bar with n. The if statement is an error trap
        If x > Max Then
            ProgressBar.Value = Max
        Else
            ProgressBar.Value = x
        End If

        If ProgressBar.Value = Max Then 'if the script has got to the end:
            Dim time As String = DateTime.Now.Subtract(StartTime).TotalSeconds 'calculate the time taken to complete

            If time < 60 Then 'if under 1 min display the time in secs
                txtTime.Text = time
                lblTime.Text = "Time Taken (secs):"
            End If

            If time >= 60 And time < 3600 Then 'if under 1 hour and above 1 min display in mins
                txtTime.Text = time / 60
                lblTime.Text = "Time Taken (mins):"
            End If

            If time >= 3600 Then 'if above 1 hour display in hours
                txtTime.Text = time / 60
                lblTime.Text = "Time Taken (hours):"
            End If

            txtAnswer.Text = answer

            Timer1.Enabled = False

        End If
    End Sub
End Class
