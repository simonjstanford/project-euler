''' <summary>
''' Uses long division to divide the number given to it by 1
''' </summary>
''' <remarks></remarks>
Public Class LongDivisionDivideOne
    Inherits EulerClassOneProperty(Of Integer, String)

    ''' <summary>
    ''' Uses long division to divide the number given to it by 1.
    ''' </summary>
    ''' <param name="a">The number used to divide 1</param>
    ''' <remarks>Uses the CalcGoesInto.Calculate function</remarks>
    Sub New(ByVal a As String)
        MyBase.New(a)
    End Sub

    Protected Overrides Function Calculate(ByVal counter As Integer) As Object
        Dim IsFirst As Boolean = False 'boolean value to check whether the start of the script has found a multiple of 10 to divide by
        Dim Remainder As Integer 'the remainder of the long division process
        Dim answer As String = String.Empty 'the answer. A space is added instead of 'Nothing', as 'Nothing forces an error at the beginning of the loop when it tries to count how many elements it has

        Do Until answer.Count = 3000 'for each number, do until 3000 decimal places have been found
            'the following loop deals with finding the first number to divide by.
            Dim FirstDivider As Integer = 1
            Do Until IsFirst = True 'do until a number is found that the divisor goes into
                If counter > FirstDivider Then 'if the divisor is bigger than the first number
                    answer += "0" 'add a "0" onto the answer
                    FirstDivider = FirstDivider * 10 'and times the first number by 10 - ie get the next 0 and check that by starting the loop again
                Else
                    IsFirst = True 'if the divisor goes into the numer, change this variable to True to stop the loop looking 
                    Dim calc As New CalcGoesInto(counter, FirstDivider)
                    answer = answer & calc.answer 'and run the function to see how many times the divisor goes into the number and add it to the answer
                    Remainder = FirstDivider Mod counter ' then take the remainder from putting the divisor into the number and assign it to the variable. This number is then carried down.
                End If
            Loop
            Remainder = Remainder * 10 'times the carry down by ten
            Dim calc2 As New CalcGoesInto(counter, Remainder)
            answer = answer & calc2.answer  'work out how many times the number being tested goes into the carrydown * 10
            Dim calc3 As New CalcGoesInto(counter, Remainder)
            Dim x As Integer = Convert.ToInt32(calc3.answer) * counter 'times how many times the number goes into the remainder by the number itself
            Remainder = Remainder - x 'and substract it from the remainder * 10 to create the new remainder, and the loop starts again.
        Loop
        answer = answer.Insert(1, ".")
        Return answer
    End Function
End Class
