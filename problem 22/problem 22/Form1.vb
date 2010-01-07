Imports System.IO

Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'read file
        Dim WholeFile As String = readFile("C:\Users\Simon\Documents\My Dropbox\Scripts\names.txt")
        'take out the quotation marks
        WholeFile = WholeFile.Replace(Chr(34), String.Empty)
        'split the string by commas and put into array
        Dim names() = WholeFile.Split(",")
        Dim answer As Int64 = 0
        'sort the array by alphabetical order
        Array.Sort(names)

        'run loop for each name in array
        For i = 0 To UBound(names)
            Dim strName As String = names(i)
            Dim Converter(strName.Count)
            Dim counter As Integer = 0

            For j = 0 To strName.Count - 1
                'convert each letter in the name to its number using the ChangeToNumber function, and add it to the counter
                Converter(j) = ChangeToNumber(strName.Substring(j, 1))
                counter += Converter(j)
            Next
            'multiply the number by its position in the list (+1 because the array starts at 0)
            'then add to the answer
            answer += counter * (i + 1)
            'MsgBox(answer)
        Next
        'when finished, print answer
        TextBox1.Text = answer
    End Sub

    Function ChangeToNumber(ByVal Letter As String)
        Dim number As String = 0

        If Letter = "A" Then number = 1
        If Letter = "B" Then number = 2
        If Letter = "C" Then number = 3
        If Letter = "D" Then number = 4
        If Letter = "E" Then number = 5
        If Letter = "F" Then number = 6
        If Letter = "G" Then number = 7
        If Letter = "H" Then number = 8
        If Letter = "I" Then number = 9
        If Letter = "J" Then number = 10
        If Letter = "K" Then number = 11
        If Letter = "L" Then number = 12
        If Letter = "M" Then number = 13
        If Letter = "N" Then number = 14
        If Letter = "O" Then number = 15
        If Letter = "P" Then number = 16
        If Letter = "Q" Then number = 17
        If Letter = "R" Then number = 18
        If Letter = "S" Then number = 19
        If Letter = "T" Then number = 20
        If Letter = "U" Then number = 21
        If Letter = "V" Then number = 22
        If Letter = "W" Then number = 23
        If Letter = "X" Then number = 24
        If Letter = "Y" Then number = 25
        If Letter = "Z" Then number = 26

        Return number

    End Function

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
