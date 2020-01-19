Public MustInherit Class EulerClassOneProperty(Of T, V)
    Private _a As T
    Private _answer As V

    Public Property a As T
        Get
            Return _a
        End Get
        Set(ByVal value As T)
            _a = value
            _answer = Calculate(_a)
        End Set
    End Property

    Public ReadOnly Property answer As V
        Get
            Return _answer
        End Get
    End Property

    Sub New(ByVal a As T)
        _a = a
        _answer = Calculate(_a)
    End Sub

    Protected MustOverride Function Calculate(ByVal a As T)
End Class


Public MustInherit Class EulerClassTwoProperties(Of T, U, V)
    Private _a As T
    Private _b As U
    Private _answer As V

    Public Property a As T
        Get
            Return _a
        End Get
        Set(ByVal value As T)
            _a = value
            _answer = Calculate(_a, _b)
        End Set
    End Property

    Public Property b As U
        Get
            Return _b
        End Get
        Set(ByVal value As U)
            _b = value
            _answer = Calculate(_a, _b)
        End Set
    End Property

    Public ReadOnly Property answer As V
        Get
            Return _answer
        End Get
    End Property

    Sub New(ByVal a As T, ByVal b As U)
        _a = a
        _b = b
        _answer = Calculate(_a, _b)
    End Sub

    Protected MustOverride Function Calculate(ByVal a As T, ByVal b As U)
End Class
