Public Class Problemx
    'Euler Projects Problem x:
    '
    '
    '
    Private Sub Problem36_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim answer As Integer 'the variable to hold the accumulating answer
        Dim StartTime As String = Now 'variable used to hold the start time

        For n = 1 To 10000
            Dim a As Double = Math.Sqrt(n)
            Dim b As Integer = a
            If a <> b Then
                Dim period As Integer
                Dim sequence As String

                For i = n To 1 Step -1
                    If i * i <= n Then
                        period = i
                        Exit For
                    End If
                Next

                sequence = period
                Dim test1 As String = 1 / (Math.Sqrt(n) - period)
                Dim z As Integer = Math.Floor(1 / (Math.Sqrt(n) - period))
                Dim array(n + 10) As Integer
                Dim NumberOfDigits As Integer = 0
                Dim lowestNumber As Integer = 10000
                Dim LowestLocation As Integer = 10

                Do Until sequence.Count >= 1000
                    Dim found As Boolean = False
                    For x = n To 1 Step -1
                        For y = n To 1 Step -1
                            Dim test2 As String = z + ((Math.Sqrt(n) - x) / y)
                            'MsgBox(test1 & vbCrLf & test2 & vbCrLf & x & vbCrLf & y)
                            If test1.Substring(0, 10) = test2.Substring(0, 10) Then
                                'MsgBox(x & vbCrLf & y & vbCrLf & z)
                                test1 = y / (Math.Sqrt(n) - x)
                                z = Math.Floor(y / (Math.Sqrt(n) - x))
                                sequence = sequence & z
                                array(z) += 1
                                found = True
                                Exit For
                            End If
                        Next
                        If found = True Then Exit For
                    Next
                Loop
                'MsgBox(n & vbCrLf & sequence)


                For i = 0 To array.Count - 1 'find the repeating number that has the smallest amount of total numbers.
                    If array(i) > 10 Then
                        'MsgBox(i & vbCrLf & array(i))
                        If array(i) < lowestNumber Then LowestLocation = i
                    End If
                Next

                For i = 0 To array.Count - 1 'use this number to divide the other numbers to get the number of numbers in one repeat
                    If array(i) > 10 Then
                        array(i) = array(i) / array(LowestLocation)
                        NumberOfDigits += array(i)
                    End If
                Next

                'MsgBox(NumberOfDigits)
                If NumberOfDigits Mod 2 <> 0 Then answer += 1
            End If
        Next



        txtAnswer.Text = answer 'print answer
        txtTime.Text = DateTime.Now.Subtract(StartTime).TotalSeconds 'substract the start time from the time now to find the duration in seconds that the script took to complete
    End Sub
End Class
