Imports System.IO
Public Class Form1
    'this script takes all the permutations found in script "Problem 24" and places a "0" first at the beginning, then each position in from the beginning in turn
    'these ammended numbers are then added to a list, the list sorted and the 1,000,000th number found
    'this  algorithm will, in theory, work without the need of the previous script:
    'take 9 and 8, and make as many combinations you can with it, ie 9-8, 8-9. then take the next number (7) and run this script - place it in all positions of both permutations of 9-8: 798, 978, 987, 789, 879, 897
    'the amount of permuations for each successive go is equal to the factorial of the number of digits used - ie 1 *2 * 3 = 6.
    'thus, by doing this in turn from 9-0, you will find the answer.
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim WholeFile As String = readFile("C:\Users\Simon\Documents\My Dropbox\Scripts\permutations.txt")
        'carriage returns were replaced with commas because the split function of the string did not work properly with carriage returns
        WholeFile = WholeFile.Replace(vbCrLf, Chr(44))
        Dim SplitArray() = WholeFile.Split(Chr(44))
        Dim list As New List(Of String)

        'j is the position in the string of numbers you want to place 0
        For j = 0 To 9
            'i is the position in the array of the string you want to ammend
            For i = 0 To 362879
                Dim strNumber As String = SplitArray(i)
                'insert the 0 at the position dictated by j
                strNumber = strNumber.Insert(j, "0")
                'add this number to the list
                list.Add(strNumber)
            Next
        Next
        'when finished, sort the list and display the answer
        list.Sort()
        TextBox1.Text = list(999999)


    End Sub

    'function to read file created from project "Problem 24"
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
