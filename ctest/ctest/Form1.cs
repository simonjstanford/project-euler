using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EulerProjectClassLibrary;

namespace CTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            EulerProjectClassLibrary.ReadFile.Open test = new GoesInto(2, 20);
            MessageBox.Show(test.answer.ToString());


        }

    }
}
