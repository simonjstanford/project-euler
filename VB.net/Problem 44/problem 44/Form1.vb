Public Class Problem44

    Private Sub Problem44_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim answer As Integer = 1000000000



        For j = 1 To 10000000
            Dim testJ As Double = (Math.Sqrt((24 * j) + 1) + 1) / 6
            Dim testJ2 As Integer = testJ
            If testJ = testJ2 Then
                For k = 1 To 10000000
                    Dim testK As Double = (Math.Sqrt((24 * k) + 1) + 1) / 6
                    Dim testK2 As Integer = testK
                    If testK = testK2 Then
                        Dim addition As Double = (Math.Sqrt((24 * (j + k)) + 1) + 1) / 6
                        Dim addition2 As Integer = addition
                        If addition = addition2 Then
                            Dim x As Integer = k - j
                            If x < 0 Then x = x - (x * 2)
                            Dim subtraction As Double = (Math.Sqrt((24 * x) + 1) + 1) / 6
                            Dim subtraction2 As Integer = subtraction
                            Dim n As Double = k - j
                            If subtraction = subtraction2 Then
                                MsgBox(j & vbCrLf & k)
                                If n < answer Then
                                    answer = n
                                End If
                            End If
                        End If
                    End If
                Next
            End If
        Next

        MsgBox(answer)

    End Sub
End Class
