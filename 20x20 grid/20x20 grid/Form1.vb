Imports System.IO
Public Class Form1
    Dim array(20, 20) As Integer
    Dim HighestNumber As Int64

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim WholeNumber As String = readFile("C:\Users\Simon\Documents\My Dropbox\20x20.txt")
        WholeNumber = WholeNumber.Replace(" ", String.Empty)
        WholeNumber = WholeNumber.Replace(vbCrLf, String.Empty)

        'MsgBox(WholeNumber)
        Dim a As Integer = 0
        Dim rowCount As Integer = 0

        Do Until rowCount > 19
            For i = 0 To 19
                Dim tempHolder As String
                Dim b As Integer = a + 1
                tempHolder = WholeNumber.Chars(a) + WholeNumber.Chars(b)
                tempHolder = Convert.ToInt32(tempHolder)
                array(rowCount, i) = tempHolder
                a += 2
            Next
            rowCount += 1
        Loop



        Dim list As New List(Of Integer)
        rowCount = 0
        Do Until rowCount > 19
            For i = 0 To 19
                list.Add(CalculateAll(rowCount, i))
            Next
            rowCount += 1
        Loop

        list.Sort()
        MsgBox(list.Last)

    End Sub

    Function CalculateAll(ByVal r As Integer, ByVal c As Integer)
        Dim highest As Int64 = 0
        Dim list As New List(Of Integer)

        Try
            list.Add(CalculateTotalDown(r, c))
        Catch ex As Exception
            Exit Try
        End Try

        Try
            list.Add(CalculateTotalLeft(r, c))
        Catch ex As Exception
            Exit Try
        End Try

        Try
            list.Add(CalculateTotalNE(r, c))
        Catch ex As Exception
            Exit Try
        End Try

        Try
            list.Add(CalculateTotalNW(r, c))
        Catch ex As Exception
            Exit Try
        End Try

        Try
            list.Add(CalculateTotalRight(r, c))
        Catch ex As Exception
            Exit Try
        End Try

        Try
            list.Add(CalculateTotalSE(r, c))
        Catch ex As Exception
            Exit Try
        End Try

        Try
            list.Add(CalculateTotalSW(r, c))
        Catch ex As Exception
            Exit Try
        End Try

        Try
            list.Add(CalculateTotalUp(r, c))
        Catch ex As Exception
            Exit Try
        End Try

        list.Sort()
        Return list.Last

    End Function

    Function CalculateTotalRight(ByVal r As Integer, ByVal c As Integer)
        Dim total As Int64

        total = array(r, c) * array(r, c + 1) * array(r, c + 2) * array(r, c + 3)

        Return total
    End Function

    Function CalculateTotalLeft(ByVal r As Integer, ByVal c As Integer)
        Dim total As Int64

        total = array(r, c) * array(r, c - 1) * array(r, c - 2) * array(r, c - 3)

        Return total
    End Function

    Function CalculateTotalDown(ByVal r As Integer, ByVal c As Integer)
        Dim total As Int64

        total = array(r, c) * array(r + 1, c) * array(r + 2, c) * array(r + 3, c)

        Return total
    End Function

    Function CalculateTotalUp(ByVal r As Integer, ByVal c As Integer)
        Dim total As Int64

        total = array(r, c) * array(r - 1, c) * array(r - 2, c) * array(r - 3, c)

        Return total
    End Function

    Function CalculateTotalNE(ByVal r As Integer, ByVal c As Integer)
        Dim total As Int64

        total = array(r, c) * array(r - 1, c + 1) * array(r - 2, c + 2) * array(r - 3, c + 3)

        Return total
    End Function

    Function CalculateTotalNW(ByVal r As Integer, ByVal c As Integer)
        Dim total As Int64

        total = array(r, c) * array(r - 1, c - 1) * array(r - 2, c - 2) * array(r - 3, c - 3)

        Return total
    End Function

    Function CalculateTotalSE(ByVal r As Integer, ByVal c As Integer)
        Dim total As Int64

        total = array(r, c) * array(r + 1, c + 1) * array(r + 2, c + 2) * array(r + 3, c + 3)

        Return total
    End Function

    Function CalculateTotalSW(ByVal r As Integer, ByVal c As Integer)
        Dim total As Int64

        total = array(r, c) * array(r + 1, c - 1) * array(r + 2, c - 2) * array(r + 3, c - 3)

        Return total
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
