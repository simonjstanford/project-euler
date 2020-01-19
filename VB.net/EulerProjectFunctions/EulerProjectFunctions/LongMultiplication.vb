''' <summary>
''' Performs a long multiplication calculation using two numbers, limited to both the number of characters allowed in a string object (n) and the number of digits allowed in a integar object (p).
''' </summary>
''' <remarks></remarks>
Public Class LongMultiplication
    Implements IEulerTwoProperties(Of String, Integer, String)
    Private _a As String
    Private _b As String
    Private _answer As String

    Public Property a As String Implements IEulerTwoProperties(Of String, Integer, String).a
        Get
            Return _a
        End Get
        Set(ByVal value As String)
            _a = value
            _answer = Calculate(_a, _b)
        End Set
    End Property

    Public ReadOnly Property answer As String Implements IEulerTwoProperties(Of String, Integer, String).answer
        Get
            Return _answer
        End Get
    End Property

    Public Property b As Integer Implements IEulerTwoProperties(Of String, Integer, String).b
        Get
            Return _b
        End Get
        Set(ByVal value As Integer)
            _b = value
            _answer = Calculate(_a, _b)
        End Set
    End Property

    ''' <summary>
    ''' Performs a long multiplication calculation using two numbers, limited to both the number of characters allowed in a string object (n) and the number of digits allowed in a integar object (p).
    ''' </summary>
    ''' <param name="a">The larger number.</param>
    ''' <param name="b">The smaller number.</param>
    ''' <remarks></remarks>
    Sub New(ByVal a As String, ByVal b As integer)
        _a = a
        _b = b
        _answer = Calculate(_a, _b)
    End Sub

    Public Function Calculate(ByVal n As String, ByVal p As Integer) As Object Implements IEulerTwoProperties(Of String, Integer, String).Calculate
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

        Dim answer As String = Nothing 'create the string to hold the answer
        For i = 0 To n.Count - 1
            answer += array(1, i).ToString 'and join together the answer
        Next

        Return answer
    End Function
End Class
