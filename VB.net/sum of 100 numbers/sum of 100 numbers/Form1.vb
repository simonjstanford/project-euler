Imports System.IO
Public Class Form1
    Dim wholefile As String = readFile("C:\Users\Simon\Documents\My Dropbox\100x50Digits.txt")
    Dim array(100, 49) As Integer

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        wholefile = wholefile.Replace(" ", String.Empty)
        wholefile = wholefile.Replace(vbCrLf, String.Empty)
        BuildArray()

        Dim counter As Integer = 0
        Dim rowCount As Integer = 0
        Dim answer As String

        Do Until rowCount > 99
            For i = 49 To 0 Step -1
                Calculate(rowCount, i, array(rowCount, i))
            Next
            rowCount += 1
        Loop

        For i = 0 To 9
            answer = answer + array(100, i).ToString
        Next
        TextBox1.Text = answer.Substring(0, 10)

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

    Sub BuildArray()
        Dim counter As Integer = 0
        Dim rowCount As Integer = 0
        Dim a As Integer = 0

        Do Until rowCount > 99
            For i = 0 To 49
                Dim tempHolder As String
                tempHolder = wholefile.Chars(a)
                tempHolder = Convert.ToInt32(tempHolder)
                array(rowCount, i) = tempHolder
                a += 1
            Next
            rowCount += 1
        Loop
    End Sub

    Sub Calculate(ByVal row As Integer, ByVal column As Integer, ByVal value As Integer)
        array(100, column) = array(100, column) + value
        If column <> 0 Then
            If array(100, column) > 9 Then
                Dim largerNumber As Integer = column - 1
                array(100, column) = array(100, column) Mod 10
                array(100, largerNumber) += 1
            End If
        End If
    End Sub

End Class
