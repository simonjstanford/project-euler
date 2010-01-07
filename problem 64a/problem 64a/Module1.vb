Module Module1

    Sub Main()
        Dim N As New SquareRoot(23)

        'get the integer part of the square root
        N.GetFirstNumber()

        'subtract it from the square root
        N.GetRemainder(Math.Sqrt(N.NumberToTest), N.FirstNumber)
        'if the difference is 0, stop
        If N.Remainder = 0 Then
            'exit script
        End If

        N.SimplifyFraction()


        Console.WriteLine(N.Remainder)




        Console.ReadKey()

    End Sub

End Module
