using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EulerProjectClassLibrary
{
    /// <summary>
    /// Calculates the power of a number.
    /// </summary>
    /// <remarks></remarks>
    public class PowerOf : EulerClassTwoProperties <string, int, string>
    {
        /// <summary>
        /// Calculates the power of a number.
        /// </summary>
        /// <param name="a">The number to calculate the power of.</param>
        /// <param name="b">The power to use.</param>
        /// <remarks></remarks>
        public PowerOf(string a, int b) : base(a, b)
        {
        }

        protected override string Calculate(string a, int b)
        {
            string n = a;
            int counter = 2;

            while (counter <= b)
            {
                int[,] array = new int[3, n.Length]; //the array to carry out the calculation

                for (int i = 0; i <= n.Length - 1; i++)
                {
                    array[0, i] = Convert.ToInt32(n.Substring(i, 1)); //add last list item to row 0 of array
                }

                //working from the back, carry out long multiplication and add to current cell value: Times each cell value by the next number in the sequence
                for (int i = n.Length - 1; i >= 0; i--)
                {
                    array[1, i] += (array[0, i] * Convert.ToInt32(a)); //***this is the change that makes it calculate powers. times n by the original value (a), not (b) which the number of times the orginal value has to timed by itself.
                    //if column is not 0 then carry over number higher than 9
                    if (i != 0)
                    {
                        if (array[1, i] > 9)
                        {
                            int largerNumber = i - 1;
                            int CarryOver = Convert.ToInt32(Math.Floor((double)(array[1, i] / 10)));
                            array[1, i] = array[1, i] % 10;
                            array[1, largerNumber] += CarryOver;
                        }
                    }
                }

                //when finished, put each cell value together in a string
                string tempAnswer = string.Empty;
                for (int i = 0; i <= n.Length - 1; i++)
                {
                    tempAnswer += array[1, i].ToString();
                }
                n = string.Empty;
                n = tempAnswer;
                counter++;
            }

            return n;
        }
    }
}
