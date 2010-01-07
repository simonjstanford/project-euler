''' <summary>
''' Calculates how many times one number goes into another number.
''' </summary>
''' <remarks></remarks>
Public Class CalcGoesInto
    Inherits EulerClassTwoProperties(Of Integer, Integer, Integer)

    ''' <summary>
    '''  Calculates how many times one number goes into another number.
    ''' </summary>
    ''' <param name="divisor">The smaller number.</param>
    ''' <param name="element">The larger number.</param>
    ''' <remarks>This function is used in LongDivision.</remarks>
    Sub New(ByVal divisor As Integer, ByVal element As Integer)
        MyBase.New(divisor, element)
    End Sub

    Protected Overrides Function Calculate(ByVal divisor As Integer, ByVal element As Integer) As Object
        Dim GoesInto As Integer = 1 'the variable counting the number of times the number goes into it
        Dim total As Integer = divisor 'the increasing total to test it against
        Do Until total > element 'do until the total is greater than the number tested
            total += divisor 'add the divisor onto the total 
            GoesInto += 1 'and increase GoesInto by one.
        Loop
        Return GoesInto - 1 'The number returns is GoesInto -1 as the do loop automatically adds 1 onto the end before it checks to see if it is bigger than the number tested.
    End Function
End Class
