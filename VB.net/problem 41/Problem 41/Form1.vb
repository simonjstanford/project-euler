Public Class Problem41
    Private Sub Problem41_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim counter As Integer = 3 'the current number to add onto the permutations
        Dim list As New List(Of String) 'the current list of permutations
        Dim total As New List(Of Integer) 'the total list of all pandigital numbers
        list.Add(12) 'add the first two permutations to both the lists
        list.Add(21)
        total.Add(12)
        total.Add(21)


        Do Until counter > 9 'do until the counter has got to nine.
            Dim array(list.Count - 1, Factorial(counter) / list.Count) As String 'the number of rows is -1 of the total in the previously created list. the columns is the factorial of the current number divided into the number of rows.
            Dim t As Integer = list.Count 'store the current total of previous permutations

            For i = 0 To t - 1 'add the previous permutations to the first column of the array
                array(i, 0) = list(i)
            Next

            list.Clear() 'clear the list

            'now create the next permutations. add the current number to each position in the number. e.g. 312 132 123, 321 231 213
            For i = 0 To t - 1 'the current row
                For j = 1 To Factorial(counter) / t 'the current column
                    array(i, j) = array(i, 0).Insert(j - 1, counter) 'add the current number into the specified position. The position is specified by j -1. J would start at 0, but the original number is needed for all other permutations.
                    list.Add(array(i, j)) 'add the result to the list for the next permutation
                    total.Add(array(i, j)) 'add the result to the list of all pandigital
                Next
            Next

            counter += 1 'increase counter by 1 and start the loop again.
        Loop

        total.Sort()

        MsgBox(total.Last)

        For i = total.Count - 1 To 0 Step -1 'starting with the highest, find the first prime and return that as the answer.
            If IsPrime(total(i)) = True Then MsgBox(total(i))
        Next

    End Sub

    Function Factorial(ByVal n As Integer)
        Dim counter As Integer = 1
        Dim answer As Integer = 1

        Do Until counter > n
            answer = answer * counter
            counter += 1
        Loop

        Return answer
    End Function

    Function IsPrime(ByVal n As Integer)
        Dim list As New List(Of Integer) 'the list to hold the numbers divisable by n

        If n Mod 3 = 0 Or n Mod 5 = 0 Or n Mod 7 = 0 Then Return False

        If n = 1 Then Return False 'in this script, this line of code is necessary as it is possible that one would be tested, and 1 is not a prime number

        For i = 2 To Math.Floor(Math.Sqrt(n)) 'test all numbers after one and before the square root of the number tested
            If n Mod i = 0 Then list.Add(i) 'if it is divisable by one of these numbers add it to the list
        Next

        If list.Count = 0 Then 'if there is no divisable numbers then it is a prime
            Return True
        Else
            Return False
        End If
    End Function
End Class
