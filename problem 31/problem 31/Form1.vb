Public Class Form1 'Euler Project Problem 31: How many different ways can £2 be made using any number of coins?

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim n As Integer 'used to calculate the total of the coin permutation
        Dim counter As Integer = 0 'counts the number of permutations that equal 200

        'this recursive for loop checks every combination of all the coins to see if they add up to £2.
        For p1 = 0 To 200 Step 1 'the pennies
            'Dim complete = p1 / 2 '''''''''''''''''''''''''''''
            'If complete = 25 Then MsgBox("25% complete") ''''''
            'If complete = 50 Then MsgBox("50% complete") ''''''
            'If complete = 75 Then MsgBox("75% complete") ''''''
            'If complete = 90 Then MsgBox("90% complete") ''''''all used to see how far through the script is
            For p2 = 0 To 200 Step 2 'the 2ps
                For p5 = 0 To 200 Step 5 '5ps
                    For p10 = 0 To 200 Step 10 '10ps
                        For p20 = 0 To 200 Step 20 '20ps
                            For p50 = 0 To 200 Step 50 ' 50ps
                                For p100 = 0 To 200 Step 100 '£1s
                                    For p200 = 0 To 200 Step 200 '£2s
                                        n = p1 + p2 + p5 + p10 + p20 + p50 + p100 + p200 'add up all the values in this recursion. As 'step' is being used the variable for the for loop represents the value of the coin
                                        If n = 200 Then
                                            counter += 1 'if the total is 200 then increase counter by one, and the for loop starts again.
                                            'MsgBox("1p: " & p1 & vbCrLf & "2p: " & p2 & vbCrLf & "5p: " & p5 & vbCrLf & "10p: " & p10 & vbCrLf & "20p: " & p20 & vbCrLf & "50p: " & p50 & vbCrLf & "£1: " & p100 & vbCrLf & "£2: " & p200)
                                        End If
                                    Next
                                Next
                            Next
                        Next
                    Next
                Next
            Next
        Next
        MsgBox(counter) 'display the anser
    End Sub
End Class
