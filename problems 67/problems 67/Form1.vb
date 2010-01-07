Imports System.IO
Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim columns As Integer = 99
        Dim rows As Integer = 99

        Dim array(rows, columns) As Int64
        Dim highestNumber As Int64 = 0
        Dim WholeNumber As String = readFile("C:\Users\Simon\Documents\My Dropbox\Scripts\67.csv")
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

        For r = rows - 1 To 0 Step -1
            For c = 0 To columns
                If array(r, c) <> 0 Then
                    Dim bottom As Int64 = array(r + 1, c)
                    Dim right As Int64 = 0
                    If c <> columns Then right = array(r + 1, c + 1)
                    If bottom > right Then array(r, c) += bottom Else array(r, c) += right
                End If
            Next
        Next
        MsgBox(array(0, 0))

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
