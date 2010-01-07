''' <summary>
''' Determines if the given number is pandigital (contains all the numbers 0-9).
''' </summary>
''' <remarks></remarks>
Public Class IsPandigital
    Inherits EulerClassOneProperty(Of String, Boolean)

    ''' <summary>
    ''' Determines if the given number is pandigital (contains all the numbers 0-9).
    ''' </summary>
    ''' <param name="n">The number to test.</param>
    ''' <remarks></remarks>
    Sub New(ByVal n As String)
        MyBase.New(n)

    End Sub

    Protected Overrides Function Calculate(ByVal n As String) As Object
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
        Return False
    End Function 'Function to determine if n is pandigital
End Class
