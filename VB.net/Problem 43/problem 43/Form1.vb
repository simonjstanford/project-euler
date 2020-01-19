Public Class Problem43
    '///////////////////////////////////////////////////////////////////////////////////////////////////////
    'Euler Projects Problem 43:
    'The number, 1406357289, is a 0 to 9 pandigital number because it is made up of each of the digits 0 to 9 in some order, but it also has a rather interesting sub-string divisibility property.
    'Let d_(1) be the 1^(st) digit, d_(2) be the 2^(nd) digit, and so on. In this way, we note the following:
    '    d_(2)d_(3)d_(4)=406 is divisible by 2
    '    d_(3)d_(4)d_(5)=063 is divisible by 3
    '    d_(4)d_(5)d_(6)=635 is divisible by 5
    '    d_(5)d_(6)d_(7)=357 is divisible by 7
    '    d_(6)d_(7)d_(8)=572 is divisible by 11
    '    d_(7)d_(8)d_(9)=728 is divisible by 13
    '    d_(8)d_(9)d_(10)=289 is divisible by 17
    'Find the sum of all 0 to 9 pandigital numbers with this property.
    '///////////////////////////////////////////////////////////////////////////////////////////////////////
    Private Sub Problem43_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim answer As Int64 'the accumulating answer
        Dim counter As Integer = 3 'the current number to add onto the permutations
        Dim list As New List(Of String) 'the current list of permutations
        list.Add(12) 'add the first two permutations to both the lists
        list.Add(21)

        Do Until counter > 10 'do until the counter has got to nine.
            Dim array(list.Count - 1, Factorial(counter) / list.Count) As String 'the number of rows is -1 of the total in the previously created list. the columns is the factorial of the current number divided into the number of rows.
            Dim t As Integer = list.Count 'store the current total of previous permutations
            Dim x As Integer = counter 'to add the 0, the for loop goes from 1 to 10. 
            If x = 10 Then x = 0 'this if statement turns 10 to 0, which is then added.

            For i = 0 To t - 1 'add the previous permutations to the first column of the array
                array(i, 0) = list(i)
            Next

            list.Clear() 'clear the list

            'now create the next permutations. add the current number to each position in the number. e.g. 312 132 123, 321 231 213
            For i = 0 To t - 1 'the current row
                For j = 1 To Factorial(counter) / t 'the current column
                    array(i, j) = array(i, 0).Insert(j - 1, x) 'add the current number into the specified position. The position is specified by j -1. J would start at 0, but the original number is needed for all other permutations.
                    If array(i, j).ToString.Substring(0, 1) <> 0 Then list.Add(array(i, j)) 'add the result to the list for the next permutation. As 0 is added on the last loop, this if statement will catch all 10 digit number beginning with 0 and disgard them as they don't count as they're only 8 digits.
                Next
            Next

            counter += 1 'increase counter by 1 and start the loop again.
        Loop

        For i = list.Count - 1 To 0 Step -1 'check each number found for the property specified in the question. If matches, add to the answer
            If CheckDivisable(list(i)) = True Then
                answer += list(i)
            End If
        Next

        TextBox1.Text = answer 'print answer

    End Sub

    Function CheckDivisable(ByVal n As String)
        'return false if any of the substrings are not divisable by the number stated
        If n.Substring(1, 3) Mod 2 <> 0 Then Return False
        If n.Substring(2, 3) Mod 3 <> 0 Then Return False
        If n.Substring(3, 3) Mod 5 <> 0 Then Return False
        If n.Substring(4, 3) Mod 7 <> 0 Then Return False
        If n.Substring(5, 3) Mod 11 <> 0 Then Return False
        If n.Substring(6, 3) Mod 13 <> 0 Then Return False
        If n.Substring(7, 3) Mod 17 <> 0 Then Return False

        Return True 'else, return true
    End Function

    Function Factorial(ByVal n As Integer)
        Dim counter As Integer = 1
        Dim answer As Integer = 1

        Do Until counter > n
            answer = answer * counter
            counter += 1
        Loop

        Return answer
    End Function
End Class

