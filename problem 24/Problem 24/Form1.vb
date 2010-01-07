Imports System.IO
Public Class Form1
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim count As Int64 = 123456789
        Dim list As New List(Of Integer)
        Dim largeString As String

        'SaveTextToFile(largeString, "C:\Users\Simon\Documents\My Dropbox\permutations.txt")

        Do Until list.Count = 362880
            Dim strTest As String = count.ToString
            Dim a As Integer = strTest.Substring(0, 1)
            Dim b As Integer = strTest.Substring(1, 1)
            Dim c As Integer = strTest.Substring(2, 1)
            Dim d As Integer = strTest.Substring(3, 1)
            Dim f As Integer = strTest.Substring(4, 1)
            Dim g As Integer = strTest.Substring(5, 1)
            Dim h As Integer = strTest.Substring(6, 1)
            Dim i As Integer = strTest.Substring(7, 1)
            Dim j As Integer = strTest.Substring(8, 1)

            If strTest.IndexOf(a) = strTest.LastIndexOf(a) And a <> 0 And
                strTest.IndexOf(b) = strTest.LastIndexOf(b) And b <> 0 And
                strTest.IndexOf(c) = strTest.LastIndexOf(c) And c <> 0 And
                strTest.IndexOf(d) = strTest.LastIndexOf(d) And d <> 0 And
                strTest.IndexOf(f) = strTest.LastIndexOf(f) And f <> 0 And
                strTest.IndexOf(g) = strTest.LastIndexOf(g) And g <> 0 And
                strTest.IndexOf(h) = strTest.LastIndexOf(h) And h <> 0 And
                strTest.IndexOf(i) = strTest.LastIndexOf(i) And i <> 0 And
                strTest.IndexOf(j) = strTest.LastIndexOf(j) And j <> 0 Then
                If list.IndexOf(count) = -1 Then
                    list.Add(count)
                    largeString += count & vbCrLf
                    'MsgBox(count)
                End If

                If list.Count = 50000 Then MsgBox("50000 done")
                If list.Count = 100000 Then MsgBox("100000 done")
                If list.Count = 200000 Then MsgBox("200000 done")
                If list.Count = 300000 Then MsgBox("300000 done")

            End If
            count += 9
        Loop
        SaveTextToFile(largeString, "C:\Users\Simon\Documents\My Dropbox\permutations.txt")


        MsgBox(list.Last)

    End Sub

    Public Function SaveTextToFile(ByVal strData As String, ByVal FullPath As String, Optional ByVal ErrInfo As String = "") As Boolean
        Dim Contents As String
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
