using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EulerProjectClassLibrary
{
    /// <summary>
    /// Performs a long multiplication calculation using two numbers, limited to both the number of characters allowed in a string object (a) and the number of digits allowed in a integar object (b).
    /// </summary>
    public class LongMultiplication :  EulerClassTwoProperties<string, int, string>
    {
            /// <summary>
            /// Performs a long multiplication calculation using two numbers, limited to both the number of characters allowed in a string object (a) and the number of digits allowed in a integar object (b).
            /// </summary>
            ///  <param name="a">The larger number.</param>
            ///  <param name="b">The smaller number.</param>
            ///  <remarks></remarks>
        public LongMultiplication(string a, int b)
            : base(a, b)
        { }

        protected override string Calculate(string a, int b)
        {
            int[,] array = new int[2, a.Length]; //create array with 2 rows and size equal to the number of digits in n

            for (int i = 0; i <= a.Length - 1; i++ )
            {
                array[0, i] = Convert.ToInt32( a.Substring(i, 1)); //place each number in a seperate cell on the first row
            }

            for (int i = a.Length - 1; i >= 0; i--) //working from the back, begin long multiplication
            {
                array[1, i] += array[0, i] * b; //times each cell by the second number (b) and place the result in the cell below
                if (i != 0) //carry over numbers higher than 10 if it is not the cell on the far left
                {
                    if (array[1, i] > 9) //if value is greater than 9...
                    {
                        int x = i - 1; //get cell number of cell to the left of the current cell (the higher value)
                        int c = Convert.ToInt32 (Math.Floor((double)(array[1, i] / 10))); //the carry over
                        array[1, i] = array[1, i] % 10; //keep only the digits below 10 in the current cell
                        array[1, x] = c; //and move the rest to the cell to the left
                    }
                }
            }

            string answer = null;
            for (int i = 0; i <= a.Length - 1; i++)
            {
                answer += array[1, i].ToString(); //and join together the answer
            }
            return answer;
        }
    }
}
