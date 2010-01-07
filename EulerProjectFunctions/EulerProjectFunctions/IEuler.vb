''' <summary>
''' Inteface for Euler Classes with one property to run the calculation with and one for the answer.
''' </summary>
''' <typeparam name="T">The property type for the calculation.</typeparam>
''' <typeparam name="V">The property type for the answer</typeparam>
''' <remarks></remarks>
Public Interface IEulerOneProperty(Of T, V)
    Property a() As T
    ReadOnly Property answer() As V
    Function Calculate(ByVal a As T)


End Interface

''' <summary>
''' Inteface for Euler Classes with two properties to run the calculation with and one for the answer.
''' </summary>
''' <typeparam name="T">The first property type for the calculation.</typeparam>
''' <typeparam name="U">The second property type for the calculation.</typeparam>
''' <typeparam name="V">The property type for the answer</typeparam>
''' <remarks></remarks>
Public Interface IEulerTwoProperties(Of T, U, V)
    Property a() As T
    Property b() As U
    ReadOnly Property answer() As V
    Function Calculate(ByVal a As T, ByVal b As U)
End Interface

