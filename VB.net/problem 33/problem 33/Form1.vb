Public Class Problem34
    'Euler Projects Problem 34:
    'The fraction ^(49)/_(98) is a curious fraction, as an inexperienced mathematician in attempting to simplify it may incorrectly believe that ^(49)/_(98) = ^(4)/_(8), which is correct, is obtained by cancelling the 9s.
    'We shall consider fractions like, ^(30)/_(50) = ^(3)/_(5), to be trivial examples.
    'There are exactly four non-trivial examples of this type of fraction, less than one in value, and containing two digits in the numerator and denominator.
    'If the product of these four fractions is given in its lowest common terms, find the value of the denominator.
    Private Sub Problem34_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Numerator As Integer = 1 'the number above the fraction line. Variable used to store the answer.  given value of one to make the first multiplication work
        Dim denominator As Integer = 1 'the number below the fraction line. Variable used to store the answer.  given value of one to make the first multiplication work

        For a = 1 To 9 'the numerator
            For b = 1 To 9 'the denominator
                If b > a Then 'only test whilst b > a, as otherwise the number would be more than 1 and not part of the question
                    For x = 1 To 9 'recurse through numbers to be added to b
                        For z = 1 To 9 'recurse through numbers to be added to a.  Both ignore 0 as that will create a 'trivial example'
                            Dim ax As Integer = a.ToString & z 'add z to a
                            Dim xb As Integer = x & b.ToString 'add z to b
                            If xb / ax = b / a And x = z Then 'divide the original number and the created number by each other. If they produce the same value and the added numbers match (to remove the errors and non trival examples)
                                ' MsgBox(ax & "/" & xb)
                                Numerator = Numerator * ax 'time the number found with all other previous numbers found
                                denominator = denominator * xb 'time the number found with all other previous numbers found
                            End If
                        Next
                    Next
                End If
            Next
        Next

        MsgBox(ReduceFraction(Numerator, denominator)) 'reduce the fraction to it's simplist form.



    End Sub

    Function ReduceFraction(ByVal a As Integer, ByVal b As Integer)
        Dim list As New List(Of Integer)
        'this function takes two numbers, and finds all numbers between 1 and half of b that go into both.  
        'It puts them into a list and the last item in the list is the furthest the fraction can be reduced.
        For i = 2 To b / 2
            If b Mod i = 0 And a Mod i = 0 Then list.Add(b / i)
        Next

        Return list.Last
    End Function


End Class
