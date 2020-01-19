using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EulerProjectClassLibrary
{
    public abstract class EulerClassOneProperty<T, V>
    {
        private T _a;
        private V _answer;

        public T a
        {
            get { return _a; }
            set
            {
                _a = value;
                Calculate(a);
            }
        }

        public V answer
        {
            get { return _answer; }
        }

        public EulerClassOneProperty(T a)
        {
            _a = a;
            _answer = Calculate(_a);
        }

        protected abstract V Calculate(T a);
    }


    public abstract class EulerClassTwoProperties<T, U, V>
    {
        private T _a;
        private U _b;
        private V _answer;

        public T a
        {
            get { return _a; }
            set
            {
                _a = value;
                Calculate(a, b);
            }
        }

        public U b
        {
            get { return _b; }
            set
            {
                _b = value;
                Calculate(a, b);
            }
        }

        public V answer
        {
            get { return _answer; }
        }

        public EulerClassTwoProperties(T a, U b)
        {
            _a = a;
            _b = b;
            _answer = Calculate(a, b);
        }


        protected abstract V Calculate(T a, U b);

    }
}

