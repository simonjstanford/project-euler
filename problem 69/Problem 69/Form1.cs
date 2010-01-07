using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Euler_Problem_69
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

    public class PrimeNumberCalculations
    {
        public static List<int> PrimeNumberCalculations(int n)
        {
            List<int> List = new List<int>(); //create a list to hold all the primes
            int i = 0;
            for (i = 0; i <= n; i += 2)
            {
                if (IsPrime(n) == true) { List.Add(n);} //if IsPrime function returns true, then add number to list
            }
            return List;
        }

        public static bool IsPrime(int n)
        {
            int i = 0;
            if (n == 1) { return false; } //1 is not a primary number so return false
            for (i = 2; i <= Math.Sqrt(n); i++) //check every number between 2 and the square root
            {
                if (n % i == 0) { return false; } //if a divisor is found then n is not a prime
            }
            return true; //if n passes all the tests then it is prime

        }


        public static void Main
        {

        }



    }


}
