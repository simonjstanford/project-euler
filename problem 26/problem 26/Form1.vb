Public Class Form1
    'Problem 26: Find the value of d < 1000 for which ^(1)/_(d) contains the longest recurring cycle in its decimal fraction part.
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '---------------------------------------------------------------------------------
        'Declarations
        '---------------------------------------------------------------------------------
        Dim answer As String 'contains final answer
        Dim MaxNumber As Integer = 0 'holds the count of the largest number of recurring digits. Used to find the answer

        '---------------------------------------------------------------------------------
        'Main Body
        '---------------------------------------------------------------------------------
        For i = 1 To 1000 'do until every number between 1 and 1000 have been divided by 1
            Dim n As String = LongDivision(i) 'use long division function to find fraction of 1/i
            Dim counter As Integer = 1 'used in the do loop as number of digits to put into substrings to check against each other
            Dim isReccuring As Boolean = False 'boolean value to mark a number as having a recurring digit.  Used to exit a for loop
            n = n.Replace(Chr(46), String.Empty) 'take away the decimal point
            n = n.TrimStart("0") 'trim the leading 0s
            n = n.TrimEnd("0") 'trim the ending 0s

            'do loop incrementally increases the number of digits to be check to see if they match, and the string is thus reacurring. 
            'e.g. with 142587142587 will check 8 to 7, then 87 to 25, then 587 to 142 until it reached 142587 to 142587 and finds a match.
            Do Until counter = 1500 'this number is arbitrary.  Tried to 500 to speed up script, but didn't work.  The final answer has a recurring string less than this number, so 500 was too small
                Dim NegativeCounter = counter - (counter * 2) 'used to get the negative number to go to in the follwoing for loop
                If n.Count > 100 Then 'another arbitrary number. Used to stop the script checking numbers for recurring digits when there is less than 100 digits in the answer to begin with.
                    For k = n.Count - counter To counter Step NegativeCounter 'starting at the end (minus the number of digits to be put in a string to be tested) check all numbers up to the total number of digits to be tested (because this loop takes the same number of digits again from infront of it)
                        Dim a As String = n.Substring(k, counter) 'take the first substring to be tested
                        Dim b As String = n.Substring(k - counter, counter) 'take the second substring to be tested from just before the first substring
                        Dim old As String = n 'only used when checking all the calculations in the rem'ed out msgbox below
                        If String.Compare(a, b) = 0 And k + counter = n.Count Then 'if both the strings match and the script is checking the end of the recurring number
                            n = n.Remove(k, counter) 'then remove the number that matches. *** this is probably not needed***
                            isReccuring = True 'and change the IsReccurring marker to true
                            If a.Count > MaxNumber Then 'if the number of digits in a that matches b is the biggest so far
                                MaxNumber = a.Count 'make MaxNumber the total number of digits in a.
                                answer = i 'and make the final answer this one
                                ListBox1.Items.Add(i) 'and add the answer to the listbox.  This is only for info purposes
                                'MsgBox("Divider: " & i & vbCrLf & "Reccuring Number: " & a & vbCrLf & "Length: " & a.Count & vbCrLf & "Original Calculation: " & old)
                            End If
                            Exit For 'and then exit this for loop.  This is important, as it stops the script finding the same numbers over and over... e.g. 33333333333 instead of 3
                        End If
                    Next
                End If
                If isReccuring = True Then Exit Do 'if the script has found a recurring number, then stop
                counter += 1 'else, increase the amount of numbers to be checked and start the loop again
            Loop
            isReccuring = False 'when finished with a number to be checked, change the boolean value back to false and start again, with a new number
        Next
        MsgBox(answer) 'finally, display the answer


    End Sub

    Function LongDivision(ByVal counter As Integer) 'function that uses long division to divide the number given to it (counter) by 1.
        'declarations
        Dim IsFirst As Boolean = False 'boolean value to check whether the start of the script has found a multiple of 10 to divide by
        Dim Remainder As Integer 'the remainder of the long division process
        Dim answer As String = String.Empty 'the answer. A space is added instead of 'Nothing', as 'Nothing forces an error at the beginning of the loop when it tries to count how many elements it has

        Do Until answer.Count = 3000 'for each number, do until 3000 decimal places have been found
            'the following loop deals with finding the first number to divide by.
            Dim FirstDivider As Integer = 1
            Do Until IsFirst = True 'do until a number is found that the divisor goes into
                If counter > FirstDivider Then 'if the divisor is bigger than the first njmber
                    answer += "0" 'add a "0" onto the answer
                    FirstDivider = FirstDivider * 10 'and times the first number by 10 - ie get the next 0 and check that by starting the loop again
                Else
                    IsFirst = True 'if the divisor goes into the numer, change this variable to True to stop the loop looking 
                    answer += Calculate(counter, FirstDivider).ToString 'and run the function to see how many times the divisor goes into the number and add it to the answer
                    Remainder = FirstDivider Mod counter ' then take the remainder from putting the divisor into the number and assign it to the variable. This number is then carried down.
                End If
            Loop
            Remainder = Remainder * 10 'times the carry down by ten
            answer += Calculate(counter, Remainder).ToString 'work out how many times the number being tested goes into the carrydown * 10
            Dim x As Integer = Calculate(counter, Remainder) * counter 'times how many times the number goes into the remainder by the number itself
            Remainder = Remainder - x 'and substract it from the remainder * 10 to create the new remainder, and the loop starts again.
        Loop
        answer = answer.Insert(1, ".")
        Return answer
    End Function

    Function Calculate(ByVal divisor As Integer, ByVal element As Integer)
        'this function calculates how many times the number tested goes into a specific number
        Dim GoesInto As Integer = 1 'the variable counting the number of times the number goes into it
        Dim total As Integer = divisor 'the increasing total to test it against
        Do Until total > element 'do until the total is greater than the number tested
            total += divisor 'add the divisor onto the total 
            GoesInto += 1 'and increase GoesInto by one.
        Loop
        Return GoesInto - 1 'returns GoesInto. This has to be -1 as the do loop automatically adds 1 onto the end before it checks to see if it is bigger than the number tested.
    End Function

End Class
