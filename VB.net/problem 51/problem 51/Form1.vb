Public Class Problem51
    ''//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    'Euler Project Problem 51:
    'By replacing the 1^(st) digit of *3, it turns out that six of the nine possible values: 13, 23, 43, 53, 73, and 83, are all prime.
    'By replacing the 3^(rd) and 4^(th) digits of 56**3 with the same digit, this 5-digit number is the first example having seven primes among the ten generated numbers, 
    'yielding the family: 56003, 56113, 56333, 56443, 56663, 56773, and 56993. Consequently 56003, being the first member of this family, is the smallest prime with this property.
    'Find the smallest prime which, by replacing part of the number (not necessarily adjacent digits) with the same digit, is part of an eight prime value family.
    '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    Dim StartTime As String = Now 'start date, used to calculate time taken.
    Dim list As New List(Of Integer) 'the list to hold the primes in
    Private Sub Problem51_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim list As New List(Of Integer)
        list = GetPrimes(999999) 'get all primes under 1 million

        Dim List2 As New List(Of Integer)
        Dim list3 As New List(Of Integer)
        Dim list4 As New List(Of Integer)
        Dim list5 As New List(Of Integer)
        Dim list6 As New List(Of Integer)

        For Each n As String In list
            If n.Count = 2 Then 'put each prime into lists depending on the number of characters in it.
                List2.Add(n)
            ElseIf n.Count = 3 Then
                list3.Add(n)
            ElseIf n.Count = 4 Then
                list4.Add(n)
            ElseIf n.Count = 5 Then
                list5.Add(n)
            ElseIf n.Count = 6 Then
                list6.Add(n)
            End If
        Next


        For Each n In list6 'check all 6 digit primes. Only check these, and change 3 numbers
            Dim a As Integer = n.ToString.Substring(0, 1) 'place each character into a different variable
            Dim b As Integer = n.ToString.Substring(1, 1)
            Dim c As Integer = n.ToString.Substring(2, 1)
            Dim d As Integer = n.ToString.Substring(3, 1)
            Dim e2 As Integer = n.ToString.Substring(4, 1)
            Dim f As Integer = n.ToString.Substring(5, 1)

            Dim aTest As Integer = -1 'create the variables to hold the character position of duplicate numbers
            Dim bTest As Integer = -1
            Dim cTest As Integer = -1

            If a = 1 Then 'for each digit, check to see if it is the number one. If true, place character location in the next empty variable
                If aTest = -1 Then
                    aTest = 0
                ElseIf bTest = -1 Then
                    bTest = 0
                Else
                    cTest = 0
                End If
            End If
            If b = 1 Then
                If aTest = -1 Then
                    aTest = 1
                ElseIf bTest = -1 Then
                    bTest = 1
                Else
                    cTest = 1
                End If
            End If
            If c = 1 Then
                If aTest = -1 Then
                    aTest = 2
                ElseIf bTest = -1 Then
                    bTest = 2
                Else
                    cTest = 2
                End If
            End If
            If d = 1 Then
                If aTest = -1 Then
                    aTest = 3
                ElseIf bTest = -1 Then
                    bTest = 3
                Else
                    cTest = 3
                End If
            End If
            If e2 = 1 Then
                If aTest = -1 Then
                    aTest = 4
                ElseIf bTest = -1 Then
                    bTest = 4
                Else
                    cTest = 4
                End If
            End If
            If f = 1 Then
                If aTest = -1 Then
                    aTest = 5
                ElseIf bTest = -1 Then
                    bTest = 5
                Else
                    cTest = 5
                End If
            End If

            Dim x As Integer = 1 'the variable used to replace the duplicate numbers with the next number
            Dim counter As Integer = 1 'the variable to count the number of primes created
            If aTest <> -1 And bTest <> -1 And cTest <> -1 Then 'if there is 3 matching numbers:
                Do Until x > 9 'change all the duplicate numbers until you reach 9
                    Dim test As String = String.Empty 'the variable to joing together the number after changing it.
                    Dim array(n.ToString.Count - 1) 'the array used to change the number
                    For i = 0 To n.ToString.Count - 1
                        array(i) = n.ToString.Substring(i, 1) 'place each digit in the array
                    Next

                    array(aTest) = x 'increase the duplicate number values by 1
                    array(bTest) = x
                    array(cTest) = x

                    For Each s As String In array
                        test = test & s 'join back together the new number
                    Next

                    If IsPrime(test) = True Then counter += 1 'if this number is prime, then increase the prime count by one
                    x += 1 'increase x by one and start the loop again
                Loop
            End If

            If counter = 9 Then MsgBox(n & vbCrLf & counter) 'if the counter reaches the desired number of primes, show the first. This should only be 8, but for some reason only works on 9
        Next

        txtTime.Text = DateTime.Now.Subtract(StartTime).TotalSeconds 'substract the start time from the time now to find the duration in seconds that the script took to complete
    End Sub

    Function IsPrime(ByVal n As Integer)
        If n = 1 Then Return False '1 is not a primary number so return false
        For i = 2 To Math.Sqrt(n) 'check every number between 2 and the square root
            If n Mod i = 0 Then Return False 'if a divisor is found then n is not a prime
        Next
        Return True 'if n passes all the tests then it is prime
    End Function

    Function GetPrimes(ByVal n As Integer)
        Dim list As New List(Of Integer) 'create the list to hold all the primes
        For i = 1 To n Step 2 'check all odd numbers
            If IsPrime(i) = True Then list.Add(i) 'if the number reports as prime then add to list
        Next
        Return list 'and return the list
    End Function



End Class


