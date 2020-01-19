using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace EulerProjectClassLibrary
{
    /// <summary>
    /// Performs a long subtraction calculation with two numbers.  Does not work when the answer will be negative.
    /// </summary>
    /// <remarks></remarks>
    public class LongSubtraction : EulerClassTwoProperties<string, string, string>
    {
        /// <summary>
        /// Performs a long subtraction calculation with two numbers.  Does not work when the answer will be negative.
        /// </summary>
        /// <param name="a">The larger number.</param>
        /// <param name="b">The smaller number.</param>
        /// <remarks></remarks>
        public LongSubtraction(string a, string b) : base(a, b)
        {
        }

        protected override string Calculate(string a, string b)
        {
            Debug.WriteLine("calculate function started");
            while (a.Length != b.Length) //insert leading 0's onto the start of the shortest number to ensure they fit into the array
            {
                if (a.Length < b.Length) { a = a.Insert(0, "0"); }
                if (b.Length < a.Length) { b = b.Insert(0, "0"); }
                Debug.WriteLine("Add zeros: " + "a: " + a.ToString() + " b: " + b.ToString());
            }

            int[,] array = new int[3, a.Length];

            for (int i = 0; i <= a.Length - 1; i++)
            {
                array[0, i] = Convert.ToInt32(a.Substring(i, 1));
                Debug.WriteLine("Add to array (a): " + a.Substring(i, 1));
                array[1, i] = Convert.ToInt32(b.Substring(i, 1));
                Debug.WriteLine("Add to array (b): " + b.Substring(i, 1));
            }

            for (int i = a.Length - 1; i >= 0; i--)
            {
                int x = array[0, i];
                int y = array[1, i];

                if (x > y) { array[2, i] += (x - y); }
                if (y > x)
                {
                    array[2, i] += 10 - (y - x);
                    if (i != 0)
                    {
                        array[2, i - 1] -= 1;
                    }
                }
            }

            string stranswer = null;
            for (int i = 0; i <= a.Length - 1; i++)
            {
                stranswer += array[2, i].ToString();
                Debug.WriteLine("answer: " + array[2, i].ToString());
            }

            stranswer = stranswer.TrimStart(Convert.ToChar("0"));
            Debug.WriteLine("final answer: " + stranswer);
            return stranswer;
        }

    }
}
