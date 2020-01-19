using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EulerProjectClassLibrary
{
    /// <summary>
    /// Uses long division to divide the number given to it by 1
    /// </summary>
    /// <remarks></remarks>
    public class LongDivisionDivideOne : EulerClassOneProperty <int, string>
    {
        /// <summary>
        /// Uses long division to divide the number given to it by 1.
        /// </summary>
        /// <param name="a">The number used to divide 1</param>
        /// <remarks>Uses the CalcGoesInto.Calculate function</remarks>
        public LongDivisionDivideOne(int a) : base(a)
        {
        }


        protected override string Calculate(int a)
        {
            bool IsFirst = false; //boolean value to check whether the start of the script has found a multiple of 10 to divide by
            int Remainder = 0; //the remainder of the long division process
            string answer = string.Empty; //the answer. A space is added instead of 'Nothing', as 'Nothing forces an error at the beginning of the loop when it tries to count how many elements it has

            while (answer.Length <= 3000) //for each number, do until 3000 decimal places have been found
            {
                //the following loop deals with finding the first number to divide by
                int FirstDivider = 1;
                while (IsFirst == false) //do until a number is found that the divisor goes into
                {
                    if (a > FirstDivider) //if the divisor is bigger than the first number
                    {
                        answer += "0"; //add a "0" onto the answer
                        FirstDivider = FirstDivider * 10; //and times the first number by 10 - ie get the next 0 and check that by starting the loop again
                    }
                    else
                    {
                        IsFirst = true; //if the divisor goes into the numer, change this variable to True to stop the loop looking
                        GoesInto calc = new GoesInto(a, FirstDivider);
                        answer = answer + calc.answer; //and run the function to see how many times the divisor goes into the number and add it to the answer
                        Remainder = FirstDivider % a; //then take the remainder from putting the divisor into the number and assign it to the variable. This number is then carried down.
                    }
                }
                Remainder = Remainder * 10; //times the carry down by ten
                GoesInto calc2 = new GoesInto(a, Remainder);
                answer += calc2.answer; //work out how many times the number being tested goes into the carrydown * 10
                GoesInto calc3 = new GoesInto(a, Remainder);
                int x = Convert.ToInt32(calc3.answer) * a; //times how many times the number goes into the remainder by the number itself
                Remainder = Remainder - x; //and substract it from the remainder * 10 to create the new remainder, and the loop starts again.
            }

            answer = answer.Insert(1, ".");
            return answer;
        }


    }
}
