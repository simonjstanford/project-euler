Imports System.IO 'import for readFile & saveTextfile
Imports System.Threading 'import from progress bar/threading
Public Class Form1
    Dim StartTime As String = Now 'start date, used to calculate time taken.

    'Commands for progress bar/threading (more in form1_load):
    Dim CalcThread As New Thread(AddressOf IsPrime) 'create the worker thread. This is the function that calculates the answer, not the progress bar.
    Dim Max As Integer = 1000000 'the number to run the test to. Also used for setting the maximum of the progress bar.
    Dim answer As Integer 'the final answer
    Dim d As String = "1" 'create the string variable that will hold the collection of numbers


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Commands for readFile:
        Dim WholeNumber As String = readFile("C:\Users\Simon\Documents\My Dropbox\Scripts\67.csv")
        WholeNumber = WholeNumber.Replace(" ", String.Empty)
        WholeNumber = WholeNumber.Replace(vbCrLf, String.Empty)
        WholeNumber = WholeNumber.Replace(",", String.Empty)

        'command for saveTextFile:
        Dim largeString As String
        SaveTextToFile(largeString, "C:\Users\Simon\Documents\My Dropbox\permutations.txt")

        'Commands for GetPrimes:
        Dim list As New List(Of Integer)
        list = GetPrimes(999999) 'get all primes under 1 million


        'Commands for progress bar(more above):
        ProgressBar.Minimum = 1 'set the minimum value of the progress bar
        ProgressBar.Maximum = Max 'set the maximum value of the progress bar
        ProgressBar.Step = Max 'set the number of steps in the progress bar
        CalcThread.Start() 'begin the worker thread


        txtTime.Text = DateTime.Now.Subtract(StartTime).TotalSeconds 'substract the start time from the time now to find the duration in seconds that the script took to complete
    End Sub

    'Mathmatical calculations

    Function LongAddition(ByVal a As String, ByVal b As String)

        Do Until a.Count = b.Count  'insert leading 0's onto the start of the shortest number to ensure they fit into the array
            If a.Count < b.Count Then a = a.Insert(0, "0")
            If a.Count > b.Count Then b = b.Insert(0, "0")
        Loop

        Dim array(2, a.Count - 1) As Integer 'create array

        For i = 0 To a.Count - 1 'place digits into array
            array(0, i) = a.Substring(i, 1)
            array(1, i) = b.Substring(i, 1)
        Next

        For i = a.Count - 1 To 0 Step -1 'calculate long division, starting from the back
            array(2, i) += array(0, i) + array(1, i)
            'MsgBox(array(2, i))
            If i <> 0 Then 'if not the far left column, place the remainder in the next column to the left
                If array(2, i) > 9 Then
                    array(2, i - 1) += Math.Floor(array(2, i) / 10)
                    array(2, i) = array(2, i) Mod 10
                End If
            End If
        Next

        Dim answer As String

        For i = 0 To a.Count - 1
            answer = answer & array(2, i)
        Next

        Return answer
    End Function

    Function LongMultiplication(ByVal n As String, ByVal p As Integer)
        Dim array(1, n.Count) As Integer 'create array with 2 rows and size equal to the number of digits in n

        For i = 0 To n.Count - 1
            array(0, i) = n.Substring(i, 1) 'place each number in a seperate cell on the first row
        Next

        For i = n.Count - 1 To 0 Step -1 'working from the back, begin long multiplication
            array(1, i) += array(0, i) * p 'times each cell by the power (p) and place the result in the cell below
            If i <> 0 Then 'carry over numbers higher than 10 if it is not the cell on the far left
                If array(1, i) > 9 Then 'if value is greater than 9...
                    Dim x As Integer = i - 1 'get cell number of cell to the left of the current cell (the higher value)
                    Dim c As Integer = Math.Floor(array(1, i) / 10)
                    array(1, i) = array(1, i) Mod 10 'keep only the last digit in the current cell
                    array(1, x) = c 'and move the rest to the cell to the left
                End If
            End If
        Next

        Dim answer As String 'create the string to hold the answer
        For i = 0 To n.Count - 1
            answer += array(1, i).ToString 'and join together the answer
        Next

        Return answer

    End Function

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
                    answer += CalcGoesInto(counter, FirstDivider).ToString 'and run the function to see how many times the divisor goes into the number and add it to the answer
                    Remainder = FirstDivider Mod counter ' then take the remainder from putting the divisor into the number and assign it to the variable. This number is then carried down.
                End If
            Loop
            Remainder = Remainder * 10 'times the carry down by ten
            answer += CalcGoesInto(counter, Remainder).ToString 'work out how many times the number being tested goes into the carrydown * 10
            Dim x As Integer = CalcGoesInto(counter, Remainder) * counter 'times how many times the number goes into the remainder by the number itself
            Remainder = Remainder - x 'and substract it from the remainder * 10 to create the new remainder, and the loop starts again.
        Loop
        answer = answer.Insert(1, ".")
        Return answer
    End Function 'this function only divides 1 by the number given

    Function LongSubtraction(ByVal a As String, ByVal b As String)
        Do Until a.Count = b.Count  'insert leading 0's onto the start of the shortest number to ensure they fit into the array
            If a.Count < b.Count Then a = a.Insert(0, "0")
            If a.Count > b.Count Then b = b.Insert(0, "0")
        Loop

        Dim array(2, a.Count - 1) As Integer 'create array

        For i = 0 To a.Count - 1 'place digits into array
            array(0, i) = a.Substring(i, 1)
            array(1, i) = b.Substring(i, 1)
        Next

        For i = a.Count - 1 To 0 Step -1 'calculate long subtraction, starting from the back
            Dim x As Integer = array(0, i)
            Dim y As Integer = array(1, i)
            If x > y Then
                array(2, i) += x - y
            ElseIf y > x Then
                array(2, i) += 10 - (y - x)
                If i <> 0 Then
                    array(2, i - 1) -= 1
                End If
            End If
        Next

        Dim answer As String
        For i = 0 To a.Count - 1
            answer = answer & array(2, i)
        Next
        answer = answer.TrimStart("0")
        Return answer
    End Function

    Function CalcGoesInto(ByVal divisor As Integer, ByVal element As Integer)
        'this function calculates how many times the number tested goes into a specific number
        Dim GoesInto As Integer = 1 'the variable counting the number of times the number goes into it
        Dim total As Integer = divisor 'the increasing total to test it against
        Do Until total > element 'do until the total is greater than the number tested
            total += divisor 'add the divisor onto the total 
            GoesInto += 1 'and increase GoesInto by one.
        Loop
        Return GoesInto - 1 'returns GoesInto. This has to be -1 as the do loop automatically adds 1 onto the end before it checks to see if it is bigger than the number tested.
    End Function 'this function is used in LongDivision

    Function PowerOf(ByVal a As String, ByVal p As Integer)
        'function that calculates the power of a number: puts number into array. For each cell in the array carry out long multiplication as many times as required, then add result to current 
        'value of cell.  If cell is not 0 and > 9 then carry over.
        Dim n As String = a 'first of all, make n = a, as n will be the variable that is recursed through the function
        Dim counter As Integer = 2 'counts the number of recursions. starts at two, because the first recursion is for this.

        Do Until counter > p
            Dim array(2, n.Count) As Integer 'the array to carry out the calculation

            For i = 0 To n.Count - 1
                array(0, i) = n.Substring(i, 1)    'add last list item to row 0 of array
            Next

            'working from the back, carry out long multiplication and add to current cell value: Times each cell value by the next number in the sequence
            For i = n.Count - 1 To 0 Step -1
                array(1, i) += (array(0, i) * a) '***this is the change that makes it calculate powers. times n by the original value (a), not (b) which the number of times the orginal value has to timed by itself.
                'if column is not 0 then carry over number higher than 9
                If i <> 0 Then
                    If array(1, i) > 9 Then
                        Dim largerNumber As Integer = i - 1
                        Dim CarryOver As Integer = Math.Floor(array(1, i) / 10)
                        array(1, i) = array(1, i) Mod 10
                        array(1, largerNumber) += CarryOver
                    End If
                End If
            Next

            'when finished, put each cell value together in a string
            Dim tempAnswer As String = String.Empty
            For i = 0 To n.Count - 1
                tempAnswer += array(1, i).ToString
            Next
            n = String.Empty 'empty the string
            n = tempAnswer 'assign n the current answer, and start the loop again
            counter += 1
        Loop

        Return n
    End Function

    Function Factorial(ByVal n As Integer) 'method of calculating factorials that cant blow the int limit
        Dim list As New List(Of String)
        Dim counter As Integer = 3

        If n = 0 Then Return 1 'if n is any of these values, return the respective answer, as the function begins calculating after this.
        If n = 1 Then Return 1
        If n = 2 Then Return 2

        'add items to list, take item from list and put into array. For each cell in the array carry out long multiplication, then add result to current 
        'value of cell.  If cell is not 0 and > 9 then carry over.
        list.Add(1) 'add the first two entries into the list to multiply together
        list.Add(2)

        Do Until counter > n 'multiply together until the counter has reached n, the desired amount
            Dim TimesBy As Integer = counter - 2
            Dim a As String = list.Item(TimesBy)
            Dim array(2, a.Count) As Integer

            'add last list item to row 0 of array
            For i = 0 To a.Count - 1
                array(0, i) = a.Substring(i, 1)
            Next

            'working from the back, carry out long multiplication and add to current cell value: Times each cell value by the next number in the sequence
            For i = a.Count - 1 To 0 Step -1
                array(1, i) += (array(0, i) * counter)
                'if column is not 0 then carry over number higher than 9
                If i <> 0 Then
                    If array(1, i) > 9 Then
                        Dim largerNumber As Integer = i - 1
                        Dim CarryOver As Integer = Math.Floor(array(1, i) / 10)
                        array(1, i) = array(1, i) Mod 10
                        array(1, largerNumber) += CarryOver
                    End If
                End If
            Next

            'when finished, put each cell value together in a string
            Dim accumulate As String
            For i = 0 To a.Count - 1
                accumulate += array(1, i).ToString
            Next
            'add string as the last item on the list
            list.Add(accumulate)
            'increase counter and start again
            counter += 1
            accumulate = Nothing
        Loop

        Return list.Last.ToString
    End Function


    'Prime number calculations

    Function IsPrime(ByVal n As Integer)
        If n = 1 Then Return False '1 is not a primary number so return false
        For i = 2 To Math.Sqrt(n) 'check every number between 2 and the square root
            If n Mod i = 0 Then Return False 'if a divisor is found then n is not a prime
        Next
        Return True 'if n passes all the tests then it is prime
    End Function

    Function GetPrimes(ByVal n As Integer) 'gets a list of primes up to a specified number. Uses IsPrimes function to retrieve all primes below 1 million in ~ 3 seconds
        Dim list As New List(Of Integer) 'create the list to hold all the primes
        For i = 1 To n Step 2 'check all odd numbers
            If IsPrime(i) = True Then list.Add(i) 'if the number reports as prime then add to list
        Next
        Return list 'and return the list
    End Function

    Function IsComposite(ByVal n As Integer) 'function to determine if n is NOT a prime
        If n = 1 Then Return False '1 is not a composite number so return false
        For i = 2 To Math.Sqrt(n) 'check every number between 2 and the square root
            If n Mod i = 0 Then Return True 'if a divisor is found then n is a composite number
        Next
        Return False 'else return false
    End Function


    'Misc Functions

    Function FindPermutations(ByVal key As String)
        Dim Original As New List(Of String)

        For i = 2 To key.Count - 1
            Original.Add(key.Substring(i, 1))
        Next

        Dim counter As Integer = 3
        Dim list As New List(Of String) 'the current list of permutations
        list.Add(key.Substring(0, 1) & key.Substring(1, 1)) 'add the first two permutations to both the lists
        list.Add(key.Substring(1, 1) & key.Substring(0, 1))

        For Each K In Original
            Dim array(list.Count - 1, Factorial(counter) / list.Count) As String 'the number of rows is -1 of the total in the previously created list. the columns is the factorial of the current number divided into the number of rows.
            Dim t As Integer = list.Count 'store the current total of previous permutations

            For i = 0 To t - 1 'add the previous permutations to the first column of the array
                array(i, 0) = list(i)
                'MsgBox(list(i))
            Next

            list.Clear() 'clear the list

            'now create the next permutations. add the current number to each position in the number. e.g. 312 132 123, 321 231 213
            For i = 0 To t - 1 'the current row
                For j = 1 To Factorial(counter) / t 'the current column
                    array(i, j) = array(i, 0).Insert(j - 1, K) 'add the current number into the specified position. The position is specified by j -1. J would start at 0, but the original number is needed for all other permutations.
                    list.Add(array(i, j)) 'add the result to the list for the next permutation.
                Next
            Next
            counter += 1
        Next


        Return list
    End Function 'gets all the permutations of any given string/number. Uses the factorial function.

    Function GetPermutations()
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

        Return list
    End Function 'gets all the permutations of 1234567890. Uses the factorial function. Relatively fast.

    Function IsPandigital(ByVal n As String)
        'Function to determine if n is pandigital
        Dim list As New List(Of String) 'list to hold each digit in number

        For Each digit As String In n.ToArray 'add each digit to the list
            list.Add(digit)
        Next

        list.Sort() 'sort them

        For i = 1 To list.Count - 1 'for each number... (start at 1 not 0 as the next line refers to the previous number)
            If list(0) = 1 And list(1) = 2 And list(2) = 3 And list(3) = 4 And list(4) = 5 And list(5) = 6 And list(6) = 7 And list(7) = 8 And list(8) = 9 Then
                Return True
            Else
                Return False
            End If
        Next
    End Function

    Function IsPermutation(ByVal a As String, ByVal b As String) 'determines if two variables have exactly the same digits in them
        If a.Count <> b.Count Then 'if the two numbers don't have the same amount of digits, then they aren't permutations
            Return False 'so return false
        Else
            Dim listA As New List(Of Integer) 'the list to hold string a
            Dim listB As New List(Of Integer) 'the list to hold string b

            For i = 0 To a.Count - 1
                listA.Add(a.Substring(i, 1)) 'place each digit from a in the list
                listB.Add(b.Substring(i, 1)) 'place each digit from b in the list
            Next

            listA.Sort() 'sort both the lists
            listB.Sort()

            For i = 0 To a.Count - 1
                If listA(i) <> listB(i) Then Return False 'and see if each level matches. If not, it is not a permutation
            Next
        End If

        Return True 'if the two strings pass all the tests, then it is a permutation

    End Function 'good for telling if two numbers contain the same digits, but slow at finding all the permutations of a number.

    Function readFile(ByVal FullPath As String)
        Dim strContents As String
        Dim objReader As StreamReader

        Try
            objReader = New StreamReader(FullPath)
            strContents = objReader.ReadToEnd()
            objReader.Close()
            Return strContents
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function

    Public Function SaveTextToFile(ByVal strData As String, ByVal FullPath As String, Optional ByVal ErrInfo As String = "") As Boolean
        Dim bAns As Boolean = False
        Dim objReader As StreamWriter
        Try
            objReader = New StreamWriter(FullPath)
            objReader.Write(strData)
            objReader.Close()
            bAns = True
        Catch Ex As Exception
            ErrInfo = Ex.Message
        End Try
        Return bAns
    End Function

    Private Sub ProgressBarFunction(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
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
