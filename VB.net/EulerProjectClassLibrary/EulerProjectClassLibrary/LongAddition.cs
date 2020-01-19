using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EulerProjectClassLibrary
{
    /// <summary>
    /// Performs a long division calculation, limited only to the number of characters allowed in a string object.
    /// </summary>
    /// <remarks></remarks>
    public class LongAddition : EulerClassTwoProperties<string, string, string>
    {
        /// <summary>
        /// Performs a long division calculation, limited only to the number of characters allowed in a string object.
        /// </summary>
        /// <param name="a">The first number needed to perform the calculation.</param>
        /// <param name="b">The second number needed to perform the calculation.</param>
        /// <remarks></remarks>
        public LongAddition(string a, string b)
            : base(a, b)
        {
        }

        protected override string Calculate(string a, string b)
        {
            while (a.Length != b.Length) //'insert leading 0's onto the start of the shortest number to ensure they fit into the array
            {
                if (a.Length < b.Length) {a = a.Insert(0, "0"); }
                if (b.Length < a.Length) {b = b.Insert(0, "0"); }
              
            }

            int[,] array = new int[3, a.Length]; //create array

            for (int i = 0; i <= a.Length -1; i++) //place digits into array
            {
                array[0, i] = Convert.ToInt32(a.Substring(i, 1));
                array[1, i] = Convert.ToInt32(b.Substring(i, 1));
            }

            for (int i = a.Length - 1; i >= 0; i--) //calculate long division, starting from the back
            {
                array[2, i] += array[0, i] + array[1, i];
                if (i != 0) //if not the far left column, place the remainder in the next column to the left
                {
                    if (array[2, i] > 9)
                    {
                        array[2, i - 1] += Convert.ToInt32(Math.Floor((double)(array[2, i] / 10)));
                        array[2, i] = array[2, i] % 10;
                    }
                }
            }

            string answer = null;

            for (int i = 0; i <= a.Length - 1; i++ )
            {
                answer += array[2, i].ToString();
            }

            return answer;
        }
    }
}
