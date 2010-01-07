
Public Class LongSubtraction
    Inherits EulerClassTwoProperties(Of String, String, String)

    ''' <summary>
    ''' Performs a long subtraction calculation with two numbers.  Does not work when the answer will be negative.
    ''' </summary>
    ''' <param name="a">The larger number.</param>
    ''' <param name="b">The smaller number.</param>
    ''' <remarks></remarks>
    Sub New(ByVal a As String, ByVal b As String)
        MyBase.New(a, b)
    End Sub

    Protected Overrides Function Calculate(ByVal a As String, ByVal b As String) As Object
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

        Dim answer As String = Nothing
        For i = 0 To a.Count - 1
            answer = answer & array(2, i)
        Next
        answer = answer.TrimStart("0")
        If answer = "" Then answer = 0
        Return answer
    End Function
End Class
