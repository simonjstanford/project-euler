Public Class Form1
    'Find the sum of all products whose multiplicand/multiplier/product identity can be written as a 1 through 9 pandigital. 
    'Some products can be obtained in more than one way so be sure to only include it once in your sum.
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim n As Int64 'the variable to calculate a * b
        Dim PotentialAnswers As New List(Of Int64) 'the list of potential answers, including duplicates
        Dim answer As New List(Of Int64) 'the list of answers, excluding duplicates
        Dim intAnswer As Int64 = 0 'the variable to add all the answers together

        For a As Int64 = 1 To 100000 'this is an arbitrary amount
            'the following if statement is used to speed up the script, providing answers to the questions at certain values of a. It worked when a = 10000
            If a = 1000 Or a = 10000 Or a = 100000 Or a = 1000000 Then
                PotentialAnswers.Sort() 'put the potential answers in order
                answer.Add(0) 'add an entry. 0 is entered, as it is doesn't make any difference to the final answer. Without this, the next for loop forces an error

                For Each number As Int64 In PotentialAnswers
                    If answer.Last <> number Then 'if the last answer checked is not the same as this one...
                        answer.Add(number) '...add it to the list of answers
                    End If
                Next

                For Each number As Int64 In answer
                    intAnswer += number 'then add all the answers together
                Next

                MsgBox("up to a = " & a & vbCrLf & intAnswer) 'display the total so far
                answer.Clear() 'then clear the list, so as not to carry them over to the next loop
                intAnswer = 0 'and make the final answer 0 again
            End If


            'the following code tests to see if a has any repeat numbers. if it does, it is not worth testing as it will not provide an answer
            Dim testList1 As New List(Of Int64)
            Dim testlist2 As New List(Of Int64)

            For i = 0 To a.ToString.Count - 1
                testList1.Add(a.ToString.Substring(i, 1)) 'break apart a, and add it to a list...
            Next

            testList1.Sort() '...sort the list

            If testList1.Count <> 1 Then 'if a was not a single number...
                testlist2.Add(testList1(0)) '...add the first digit to the second list. The for loop forces an error if this is not done
                For Each number As Int64 In testList1
                    If testlist2.Last <> number Then testlist2.Add(number) 'and then add each unique digit to the list
                Next
            End If


            If testList1.Count = testlist2.Count Or testList1.Count = 1 Then 'if both the lists are the same size, or a is only 1 digit...
                For b As Int64 = 1 To 10000 'this is an arbitrary amount
                    n = a * b '...times it by b then break apart a, b and n into the same list
                    Dim list As New List(Of String)
                    For i = 0 To a.ToString.Count - 1
                        list.Add(a.ToString.Substring(i, 1))
                    Next
                    For j = 0 To b.ToString.Count - 1
                        list.Add(b.ToString.Substring(j, 1))
                    Next
                    For k = 0 To n.ToString.Count - 1
                        list.Add(n.ToString.Substring(k, 1))
                    Next
                    list.Sort() 'sort the list
                    If list.Count = 9 Then 'and if the list has 9 digits in it
                        If list(0) = 1 And list(1) = 2 And list(2) = 3 And list(3) = 4 And list(4) = 5 And list(5) = 6 And list(6) = 7 And list(7) = 8 And list(8) = 9 Then 'and they are all unique
                            PotentialAnswers.Add(n) 'it is a pandigit number, so add it to the potential answers.  this is later filtered to remove any duplicates.
                            'MsgBox("a: " & a & vbCrLf & "b: " & b & vbCrLf & "n: " & n)
                        End If
                    End If
                Next
            End If
            testList1.Clear() 'clear the lists to stop any errors
            testlist2.Clear()
        Next

        PotentialAnswers.Sort() 'when finished, sort the potential answers

        answer.Add(0) 'add an entry. 0 is entered, as it is doesn't make any difference to the final answer. Without this, the next for loop forces an error

        For Each number As Int64 In PotentialAnswers
            If answer.Last <> number Then 'if the last answer checked is not the same as this one...
                answer.Add(number) '...then add it to the list of answers....
            End If
        Next

        For Each number As Int64 In answer
            intAnswer += number '...then add the answers together to give the final answer
        Next

        TextBox1.Text = intAnswer 'finally, display the answer
    End Sub

End Class
