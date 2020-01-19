Imports System.IO
Public Class Problem42
    'Euler Projects Problem 42:
    'The n^(th) term of the sequence of triangle numbers is given by, t_(n) = ½n(n+1); so the first ten triangle numbers are:
    '1, 3, 6, 10, 15, 21, 28, 36, 45, 55, ...
    'By converting each letter in a word to a number corresponding to its alphabetical position and adding these values we form a word value. For example, the word value for SKY is 19 + 11 + 25 = 55 = t_(10). 
    'If the word value is a triangle number then we shall call the word a triangle word.
    'Using words.txt, a 16K text file containing nearly two-thousand common English words, how many are triangle words?
    Private Sub Problem42_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim answer As Integer 'the variable to hold the accumulating number
        Dim WholeFile As String = readFile("C:\Users\Simon\Documents\My Dropbox\PC\Scripts\words.txt") 'load the text file
        WholeFile = WholeFile.Replace(Chr(34), String.Empty) 'remove the quotation marks
        Dim SplitArray() = WholeFile.Split(Chr(44)) 'split into an array using the commas

        For Each Word As String In SplitArray 'for each word in the array
            Dim SplitWord() = Word.ToCharArray 'split into another array by characters
            Dim x As Integer 'create variable to add the numerical values
            For Each letter As String In SplitWord 'for each letter
                Select Case letter 'add the numerical value of the letter onto x
                    Case "A"
                        x += 1
                    Case "B"
                        x += 2
                    Case "C"
                        x += 3
                    Case "D"
                        x += 4
                    Case "E"
                        x += 5
                    Case "F"
                        x += 6
                    Case "G"
                        x += 7
                    Case "H"
                        x += 8
                    Case "I"
                        x += 9
                    Case "J"
                        x += 10
                    Case "K"
                        x += 11
                    Case "L"
                        x += 12
                    Case "M"
                        x += 13
                    Case "N"
                        x += 14
                    Case "O"
                        x += 15
                    Case "P"
                        x += 16
                    Case "Q"
                        x += 17
                    Case "R"
                        x += 18
                    Case "S"
                        x += 19
                    Case "T"
                        x += 20
                    Case "U"
                        x += 21
                    Case "V"
                        x += 22
                    Case "W"
                        x += 23
                    Case "X"
                        x += 24
                    Case "Y"
                        x += 25
                    Case "Z"
                        x += 26
                End Select
            Next
            Dim test As Double = Math.Sqrt((x * 8) + 1) 'then calculate to see if it a triangular number. A number is triangular if the square root of (n*8) + 1 is an integer
            Dim test2 As Integer = test 'create an integer variable and place the result of the above in it.

            If test = test2 Then answer += 1 'if the double and integer variable are the same it is a whole number and therefore a triangular number
            x = 0 'return x to 0 and begin the loop again
        Next

        TextBox1.Text = answer 'print the answer

    End Sub

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

End Class
