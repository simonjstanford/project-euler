Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim BeginDate As Date = DateTimePicker1.Text
        Dim counter As Integer = 0

        Do Until BeginDate > "31/12/2000"
            If BeginDate.DayOfWeek.ToString = "Sunday" Then counter += 1
            BeginDate = BeginDate.AddMonths(1)
        Loop

        MsgBox(counter)
    End Sub
End Class
