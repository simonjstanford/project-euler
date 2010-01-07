Imports System.IO
Public Class Problemx
    '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    'Euler Projects Problem 59:
    'Your task has been made easy, as the encryption key consists of three lower case characters. 
    'Using cipher1.txt (right click and 'Save Link/Target As...'), a file containing the encrypted ASCII codes, 
    'and the knowledge that the plain text must contain common English words, decrypt the message and find the sum of the ASCII values in the original text.
    '///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    Private Sub Problem36_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim StartTime As String = Now 'variable used to hold the start time
        Dim WholeNumber As String = readFile("C:\Users\Simon\Documents\My Dropbox\PC\Scripts\cipher1.txt")
        Dim Original As Array = WholeNumber.Split(",") 'split the original string based on commas and put in an array


        For a = 97 To 122 'recurse through every combination of three lower case letters. this is done by using their ascii codes, lower case only ranges from 97 - 122
            For b = 97 To 122
                For c = 97 To 122
                    Dim Key As New List(Of String) 'create a list to put each ascii code in to an entry
                    Do Until Key.Count >= Original.Length
                        Key.Add(a)
                        Key.Add(b)
                        Key.Add(c)
                    Loop

                    Dim Test As New List(Of String) 'create a list to put each ammended ascii code in to an entry
                    For i = 0 To Original.Length - 1
                        Dim t As String = Original(i) Xor Key(i) 'the decryption is done by xor'ing the two corresponding list items in each list
                        Test.Add(t)
                    Next


                    Dim testAnswer As String = String.Empty
                    Dim answer As Integer = 0 'the variable to hold the accumulating answer
                    For i = 0 To Test.Count - 1
                        testAnswer = testAnswer & Chr(Test(i)) 'go through the new list, change it to letters and place it in a string
                        answer += Test(i) 'at the same time add up the total to get the answer, if this is the correct key
                    Next

                    If testAnswer.Contains(" and ") = True Then 'if you find the word and (with surrounding blank spaces) then this should be the answer, so:
                        MsgBox(testAnswer & vbCrLf & "Key: " & Chr(a) & Chr(b) & Chr(c) & vbCrLf) 'display the converted text
                        txtAnswer.Text = answer 'put the answer in the text box
                        txtTime.Text = DateTime.Now.Subtract(StartTime).TotalSeconds 'substract the start time from the time now to find the duration in seconds that the script took to complete
                        Exit Sub 'and exit
                    End If
                Next
            Next
        Next
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
