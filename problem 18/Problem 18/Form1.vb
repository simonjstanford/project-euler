Imports System.IO
Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim columns As Integer = 14
        Dim rows As Integer = 14

        Dim array(rows, columns) As Integer
        Dim highestNumber As Integer = 0
        Dim WholeNumber As String = readFile("C:\Users\Simon\Documents\My Dropbox\Scripts\triangle.txt")
        Dim counter As Integer = 0

        WholeNumber = WholeNumber.Replace(" ", String.Empty)
        WholeNumber = WholeNumber.Replace(vbCrLf, String.Empty)
        WholeNumber = WholeNumber.Replace(",", String.Empty)
        'MsgBox(WholeNumber)

        For r = 0 To rows
            For c = 0 To columns
                array(r, c) = WholeNumber.Substring(counter, 2)
                counter += 2
                'MsgBox(array(r, c))
            Next
        Next


        For r = 0 To rows
            For c = 0 To columns
                If array(r, c) = 0 Then
                Else
                    Dim left As Integer = 0
                    Dim up As Integer = 0
                    If c <> 0 Then left = array(r, c) + array(r - 1, c - 1)
                    If r <> 0 Then up = array(r, c) + array(r - 1, c)
                    If left > up Then array(r, c) = left
                    If up > left Then array(r, c) = up
                    If array(r, c) = 0 Then array(r, c) = 0
                    If array(r, c) > highestNumber Then highestNumber = array(r, c)
                End If
                'MsgBox(array(r, c))
            Next
        Next
        MsgBox(highestNumber)

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
