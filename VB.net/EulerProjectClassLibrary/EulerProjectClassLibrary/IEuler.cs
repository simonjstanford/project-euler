using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EulerProjectClassLibrary
{
    interface IEulerOneProperty<T, V>
    {
        T a { get; set; }
        V answer { get; }
        V Calculate(T a);

    }

    interface IEulerTwoProperties<T, U, V>
    {
        T a { get; set; }
        U b { get; set; }
        V answer { get; }
        V Calculate(T a, U b);
    }
}
