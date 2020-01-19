Public Class SquareRoot
    Private _FirstNumber As Integer
    Private _sequence As New List(Of Integer)
    Private _NumberToTest As Integer
    Private _remainder As Decimal

    Public Property NumberToTest As Integer
        Get
            Return _NumberToTest
        End Get
        Set(ByVal value As Integer)
            _NumberToTest = value
        End Set
    End Property

    Public Property FirstNumber As Integer
        Get
            Return _FirstNumber
        End Get
        Set(ByVal value As Integer)
            _FirstNumber = value
        End Set
    End Property

    Public Property Sequence As List(Of Integer)
        Get
            Return _sequence
        End Get
        Set(ByVal value As List(Of Integer))
            _sequence = value
        End Set
    End Property

    Public Property Remainder As Decimal
        Get
            Return _remainder
        End Get
        Set(ByVal value As Decimal)
            _remainder = value
        End Set
    End Property

    Public Sub New(ByVal N As Integer)
        NumberToTest = N
    End Sub

    Public Sub GetFirstNumber()
        FirstNumber = Math.Floor(Math.Sqrt(NumberToTest))
    End Sub

    Public Sub GetRemainder(ByVal X As Decimal, ByVal Y As Decimal)
        Remainder = X - Y
    End Sub

    Public Sub SimplifyFraction()
        Dim numerator As ULong = Me.Remainder.ToString.Substring(2, 14)
        Dim denominator As ULong = 10000000000000
        'Console.WriteLine(numerator & vbCrLf & denominator)










    End Sub

    Private Function LongMultiplication(ByVal n As String, ByVal p As Integer)
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
End Class
