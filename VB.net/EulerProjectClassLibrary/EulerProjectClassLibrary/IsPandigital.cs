using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EulerProjectClassLibrary
{
    /// <summary>
    /// Determines if the given number is pandigital (contains all the numbers 1-9).
    /// </summary>
    /// <remarks></remarks>
    public class IsPandigital : EulerClassOneProperty<string, bool>
    {
        /// <summary>
        /// Determines if the given number is pandigital (contains all the numbers 1-9).
        /// </summary>
        /// <param name="a">The number to test.</param>
        /// <remarks></remarks>
        public IsPandigital(string a) : base(a)
        {
        }

        protected override bool Calculate(string a)
        {
            List<string> list = new List<string>(); //list to hold each digit in number

            foreach (char digit in a.ToCharArray())
            {
                list.Add(digit.ToString());
            }

            list.Sort();

            if (list[0] == "1" & list[1] == "2" & list[2] == "3" & list[3] == "4" & list[4] == "5" & list[5] == "6" & list[6] == "7" & list[7] == "8" & list[8] == "9")
                return true;
            else
                return false;
        }


    }
}
