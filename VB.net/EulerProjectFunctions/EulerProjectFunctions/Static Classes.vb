Imports System.IO 'import for readFile

''' <summary>
''' A collection of functions for use in prime number calculations.
''' </summary>
''' <remarks></remarks>
Public Class PrimeNumberCalculations
    ''' <summary>
    ''' Determines if the given number is prime.
    ''' </summary>
    ''' <param name="n">The number to test.</param>
    ''' <returns>Returns a boolean value.</returns>
    ''' <remarks></remarks>
    Public Shared Function IsPrime(ByVal n As Integer)
        If n = 1 Then Return False '1 is not a primary number so return false
        For i = 2 To Math.Sqrt(n) 'check every number between 2 and the square root
            If n Mod i = 0 Then Return False 'if a divisor is found then n is not a prime
        Next
        Return True 'if n passes all the tests then it is prime
    End Function

    ''' <summary>
    ''' Finds all primes up to a given number (n).
    ''' </summary>
    ''' <param name="n">The number to test up to.</param>
    ''' <returns>Returns a List(Of Integer) collection containing all the prime numbers between 1 and n.</returns>
    ''' <remarks>Uses IsPrimes function to retrieve all primes below 1 million in ~ 3 seconds.</remarks>
    Public Shared Function GetPrimes(ByVal n As Integer)
        Dim list As New List(Of Integer) 'create the list to hold all the primes
        For i = 1 To n Step 2 'check all odd numbers
            If IsPrime(i) = True Then list.Add(i) 'if the number reports as prime then add to list
        Next
        Return list 'and return the list
    End Function  'gets a list of primes up to a specified number. 

    ''' <summary>
    ''' Determines if the given number is NOT prime.
    ''' </summary>
    ''' <param name="n">The number to test.</param>
    ''' <returns>Returns a boolean value.</returns>
    ''' <remarks></remarks>
    Public Shared Function IsComposite(ByVal n As Integer)
        If n = 1 Then Return False '1 is not a composite number so return false
        For i = 2 To Math.Sqrt(n) 'check every number between 2 and the square root
            If n Mod i = 0 Then Return True 'if a divisor is found then n is a composite number
        Next
        Return False 'else return false
    End Function

End Class

''' <summary>
''' A collection of functions for use in permutation calculations.
''' </summary>
''' <remarks></remarks>
Public Class Permutations
    ''' <summary>
    ''' Gets all the permutations of any given string.
    ''' </summary>
    ''' <param name="key">The string you want to find all the permutations of.</param>
    ''' <returns>Returns a List(Of String) object containing all the different permutations of the key.</returns>
    ''' <remarks>Uses the factorial function.</remarks>
    Public Shared Function FindPermutations(ByVal key As String)
        Dim Original As New List(Of String)

        For i = 2 To key.Count - 1
            Original.Add(key.Substring(i, 1))
        Next

        Dim counter As Integer = 3
        Dim list As New List(Of String) 'the current list of permutations
        list.Add(key.Substring(0, 1) & key.Substring(1, 1)) 'add the first two permutations to both the lists
        list.Add(key.Substring(1, 1) & key.Substring(0, 1))

        For Each K In Original
            Dim test As New Factorial(counter)
            Dim array(list.Count - 1, test.answer / list.Count) As String 'the number of rows is -1 of the total in the previously created list. the columns is the factorial of the current number divided into the number of rows.
            Dim t As Integer = list.Count 'store the current total of previous permutations

            For i = 0 To t - 1 'add the previous permutations to the first column of the array
                array(i, 0) = list(i)
                'MsgBox(list(i))
            Next

            list.Clear() 'clear the list

            'now create the next permutations. add the current number to each position in the number. e.g. 312 132 123, 321 231 213
            For i = 0 To t - 1 'the current row
                Dim test2 As New Factorial(counter)
                For j = 1 To test2.answer / t 'the current column
                    array(i, j) = array(i, 0).Insert(j - 1, K) 'add the current number into the specified position. The position is specified by j -1. J would start at 0, but the original number is needed for all other permutations.
                    list.Add(array(i, j)) 'add the result to the list for the next permutation.
                Next
            Next
            counter += 1
        Next

        Return list
    End Function

    ''' <summary>
    ''' Determines if two variables have exactly the same digits in them
    ''' </summary>
    ''' <param name="a">First number to test.</param>
    ''' <param name="b">Second number to test.</param>
    ''' <returns>Returns a boolean value.</returns>
    ''' <remarks></remarks>
    Public Shared Function SameDigits(ByVal a As String, ByVal b As String)
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
End Class

''' <summary>
''' A collection of functions used to open and save text files.
''' </summary>
''' <remarks></remarks>
Public Class ReadFile
    ''' <summary>
    ''' Opens a text file.
    ''' </summary>
    ''' <param name="FullPath">The full path of the text file.</param>
    ''' <returns>Returns a string object of the text file.</returns>
    ''' <remarks></remarks>
    Public Shared Function Open(ByVal FullPath As String)
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

    ''' <summary>
    ''' Saves a string to a file.
    ''' </summary>
    ''' <param name="strData">The string to save.</param>
    ''' <param name="FullPath">The path to save to.</param>
    ''' <param name="ErrInfo">The string to copy error info to.</param>
    ''' <returns>Returns a boolean value indicating if save was successful or not.</returns>
    ''' <remarks></remarks>
    Public Shared Function SaveTextToFile(ByVal strData As String, ByVal FullPath As String, Optional ByVal ErrInfo As String = "") As Boolean
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
End Class


