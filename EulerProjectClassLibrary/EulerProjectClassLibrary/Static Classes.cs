using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace EulerProjectClassLibrary
{
    /// <summary>
    /// A collection of functions for use in prime number calculations.
    /// </summary>
    /// <remarks></remarks>
    public class PrimeNumberCalculations
    {
        /// <summary>
        /// Determines if the given number is prime.
        /// </summary>
        /// <param name="n">The number to test.</param>
        /// <returns>Returns a boolean value.</returns>
        /// <remarks></remarks>
        public static bool IsPrime(int n)
        {
            if (n == 1) { return false; } //1 is not a primary number so return false
            for (int i = 2; i <= Math.Sqrt(n); i++) //check every number between 2 and the square root
            {
                if (n % i == 0) { return false; } //if a divisor is found then n is not a prime
            }
            return true; //if n passes all the tests then it is prime

        }

        /// <summary>
        /// Finds all primes up to a given number (n).
        /// </summary>
        /// <param name="n">The number to test up to.</param>
        /// <returns>Returns a List(Of Integer) collection containing all the prime numbers between 1 and n.</returns>
        /// <remarks>Uses IsPrimes function to retrieve all primes below 1 million in ~ 3 seconds.</remarks>
        public static List<int> GetPrimes(int n)
        {
            List<int> List = new List<int>(); //create a list to hold all the primes
            List.Add(2); //add 2 to the list as 2 is a prime but will not be tested in the following loop because it is step 2.

            for (int i = 1; i <= n; i += 2)
            {
                if (IsPrime(i) == true) { List.Add(i); } //if IsPrime function returns true, add the number to list
            }
            return List;
        }

        /// <summary>
        /// Determines if the given number is NOT prime.
        /// </summary>
        /// <param name="n">The number to test.</param>
        /// <returns>Returns a boolean value.</returns>
        /// <remarks></remarks>
        public static bool IsComposite(int n)
        {
            if (n == 1) { return false; } //1 is not a composite number so return false
            int i = 2;
            for (i = 2; i <= Math.Sqrt(n); i++) //check every number between 2 and the square root
            {
                if (n % i == 0) { return true; } //if a divisor is found then n is a composite number
            }
            return false; //if n passes all the test then it is a prime
        }
    }

    /// <summary>
    /// A collection of functions for use in permutation calculations.
    /// </summary>
    /// <remarks></remarks>
    public static class Permutations
    {
        /// <summary>
        /// Gets all the permutations of any given string.
        /// </summary>
        /// <param name="key">The string you want to find all the permutations of.</param>
        /// <returns>Returns a List(Of String) object containing all the different permutations of the key.</returns>
        /// <remarks>Uses the factorial function.</remarks>
        public static List<string> FindPermutations(string key)
        {
            List<string> original = new List<string>();

            for (int i = 2; i <= key.Length - 1; i++)
            {
                original.Add(key.Substring(i, 1));
            }

            int counter = 3;
            List<string> list = new List<string>(); //the current list of permutations
            list.Add(key.Substring(0, 1) + key.Substring(1, 1)); //add the first two permutations to both lists
            list.Add(key.Substring(1, 1) + key.Substring(0, 1));

            foreach (string k in original)
            {
                string[] array = new string[list.Count]; //the number of rows is the total in the previously created list. the columns is the factorial of the current number divided into the number of rows.
                int t = list.Count;

                for (int i = 0; i <= t - 1; i++)
                {
                    array[i] = list[i];
                }
                list.Clear(); //clear the list

                //now create the next permutations. add the current number to each position in the number. e.g. 312 132 123, 321 231 213
                for (int i = 0; i <= t - 1; i++) //the current row
                {
                    Factorial test2 = new Factorial(counter);
                    for (int j = 1; j <= Convert.ToInt32(test2.answer) / t; j++) //the current column
                    {
                        string NewPerm = array[i].Insert(j - 1, k).ToString();
                        list.Add(NewPerm); //add the result to the list for the next permutation.
                    }
                }
                counter++;
            }
            return list;
        }

        /// <summary>
        /// Determines if two variables have exactly the same digits in them
        /// </summary>
        /// <param name="a">First number to test.</param>
        /// <param name="b">Second number to test.</param>
        /// <returns>Returns a boolean value.</returns>
        /// <remarks></remarks>
        public static bool SameDigits(string a, string b)
        {
            if (a.Length != b.Length) //if the two numbers don't have the same amount of digits, then they aren't permutations
            {
                return false;
            }
            else
            {
                List<string> listA = new List<string>();
                List<string> listB = new List<string>();

                for (int i = 0; i <= a.Length - 1; i++)
                {
                    listA.Add((a.Substring(i, 1)));
                    listB.Add((b.Substring(i, 1)));
                }

                listA.Sort();
                listB.Sort();

                for (int i = 0; i <= a.Length - 1; i++)
                {
                    if (listA[i] != listB[i]) { return false; } //see if each level matches. If not, it is not a permutation
                }
            }
            return true; //if the two strings pass all the tests, then it is a permutation
        }
    }

    /// <summary>
    /// A collection of functions used to open and save text files.
    /// </summary>
    /// <remarks></remarks>
    public class ReadFile
    {
        /// <summary>
        /// Opens a text file.
        /// </summary>
        /// <param name="FullPath">The full path of the text file.</param>
        /// <returns>Returns a string object of the text file.</returns>
        /// <remarks></remarks>
        public static string Open(string FullPath, String ErrInfo = "")
        {
            string strContents;
            StreamReader objReader;

            try
            {
                objReader = new StreamReader(FullPath);
                strContents = objReader.ReadToEnd();
                objReader.Close();
                return strContents;
            }
            catch (Exception ex)
            {
                ErrInfo = ex.Message;
                return string.Empty ;
            }
        }

        public static bool SaveTextToFile(string strData, string FullPath, String ErrInfo = "")
        {
            bool bAns = false;
            StreamWriter objReader;

            try
            {
                objReader = new StreamWriter(FullPath);
                objReader.Write(strData);
                objReader.Close();
                bAns = true;
            }
            catch (Exception ex)
            {
                ErrInfo = ex.Message;
            }

            return bAns;
        }
    }
}

