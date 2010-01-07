using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EulerProjectClassLibrary
{
    /// <summary>
    /// Method of calculating the factorial (n!) of a non negative number that cant blow the int limit.
    /// </summary>
    public class Factorial : EulerClassOneProperty<int, string >
    {
        /// <summary>
        /// Method of calculating the factorial (n!) of a non negative number that cant blow the int limit.
        /// </summary>
        /// <param name="n">The number to calculate the factorial of.</param>
        public Factorial(int n) : base (n)
        {
        }

        protected override string Calculate(int n)
            {
            string answer = "1"; //the string to hold the accumulating answer
            int counter = 2; //the int to times the previous answer by to get the next answer

            while (counter <= n) //do until counter reaches the number specified
            {
                LongMultiplication calculate = new LongMultiplication(answer, counter); //calculate long multiplication of the current answer with the next number in the sequence
                answer = calculate.answer; //transfer this new answer to the answer string
                counter++; //increase the counter by one and start again
            }
            return answer;
            }
    }

}
