''' <summary>
''' Performs a long division calculation, limited only to the number of characters allowed in a string object.
''' </summary>
''' <remarks></remarks>
Public Class LongAddition
    Implements IEulerTwoProperties(Of String, String, String)
    Private _a As String
    Private _b As String
    Private _answer As String
    Public Property a As String Implements IEulerTwoProperties(Of String, String, String).a
        Get
            Return _a
        End Get
        Set(ByVal value As String)
            _a = value
            _answer = Calculate(_a, _b)
        End Set
    End Property

    Public ReadOnly Property answer As String Implements IEulerTwoProperties(Of String, String, String).answer
        Get
            Return _answer
        End Get
    End Property

    Public Property b As String Implements IEulerTwoProperties(Of String, String, String).b
        Get
            Return _b
        End Get
        Set(ByVal value As String)
            _b = value
            _answer = Calculate(_a, _b)
        End Set
    End Property

    ''' <summary>
    ''' Performs a long division calculation, limited only to the number of characters allowed in a string object.
    ''' </summary>
    ''' <param name="a">The first number needed to perform the calculation.</param>
    ''' <param name="b">The second number needed to perform the calculation.</param>
    ''' <remarks></remarks>
    Sub New(ByVal a As String, ByVal b As String)
        _a = a
        _b = b
        _answer = Calculate(_a, _b)
    End Sub

    Public Function Calculate(ByVal a As String, ByVal b As String) As Object Implements IEulerTwoProperties(Of String, String, String).Calculate
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

        Dim answer As String = Nothing

        For i = 0 To a.Count - 1
            answer = answer & array(2, i)
        Next

        Return answer
    End Function
End Class
