Public Class Form1
    'Euler Project Problem 28:
    'What is the sum of the numbers on the diagonals in a 1001 by 1001 spiral?
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'DECLARATIONS
        '********************************************
        Dim intAnswer As Int64 = 1 'total accumulated answer
        Dim n As Int64 = 0 'current number
        Dim x As Integer = 1 'the accumulated number to add onto x to get the next number in the sequence
        Dim y As Integer = 2 'each corner of the spiral
        Dim s As Integer = 1001 'size of spiral
        Dim counter As Integer = 2  'counts the number of steps taken. Used to stop the do loop at the outside of the spiral

        'BODY
        '********************************************
        Do Until y > 9 'do the script until 2 has been added to y 3 times, for each corner of the spiral 
            x = y
            n = x + 1
            intAnswer += n ' add the second number in the sequence.  The first number (1) has already been added when creating the variable - and only needs adding once

            Do Until counter = ((s / 2) + 0.5) 'do until it has reached the end of the sprial. This is just over half of the array length
                x += 8 'add 8 on to accumulating amount
                n += x 'add this new accumulated amount to the previous total to get the next number
                intAnswer += n 'add the new total onto all the others to get the updated answer
                counter += 1
            Loop
            y += 2 'add 2 to y to get the beginning of the next sequence
            counter = 2 'return the counter back to 2 (it is not one, because 1 is only counted once.
        Loop

        TextBox1.Text = intAnswer 'print answer

    End Sub
End Class
