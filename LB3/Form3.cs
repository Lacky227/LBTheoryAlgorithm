using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LBTheoryAlgorithm
{
    public partial class Form3 : Form1
    {
        private myArray2 array2;
        public Form3()
        {
            InitializeComponent();
        }

        protected override myArray GenArr(int N, int t)
        {
            var array2 = new myArray2(N, t);
            BubbleSort = array2.CountInversionsBruteForce;
            InsertionSort = array2.CountInversionsDivideAndConquer;
            return array2;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            array2 = (myArray2)GenArr(n, t);

            if (radioButton4.Checked)
            {
                BubbleSort.Invoke();
            }
            else if (radioButton5.Checked)
            {
                InsertionSort.Invoke();
            }
            richTextBox2.Text = "Inversion count: " + array2.inversionCount.ToString();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
