using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EulerProjectClassLibrary
{
    /// <summary>
    /// Calculates how many times one number goes into another number.
    /// </summary>
    /// <remarks></remarks>
    public class GoesInto : EulerClassTwoProperties<int, int, int>
    {
        /// <summary>
        /// Calculates how many times one number goes into another number.
        /// </summary>
        /// <param name="divisor">The smaller number.</param>
        /// <param name="element">The larger number.</param>
        /// <remarks>This function is used in LongDivision.</remarks>
        public GoesInto(int divisor, int element)
            : base(divisor, element)
        {
        }

        protected  override int Calculate(int a, int b)
        {
            int GoesInto = 1;
            int total = a;

            while (total <= b) //do until the total is greater than the number tested
            {
                total += a; //add the divisor onto the total
                GoesInto += 1; //and increase GoesInto by one.
            }
            return GoesInto - 1; // The number returns is GoesInto -1 as the do loop automatically adds 1 onto the end before it checks to see if it is bigger than the number tested.
        }


    }
}
