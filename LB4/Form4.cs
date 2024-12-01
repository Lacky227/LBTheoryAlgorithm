using LBTheoryAlgorithm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LB4
{
    public partial class Form4 : Form1
    {
        private myArray3 array3;

        public Form4()
        {
            InitializeComponent();

            chart1.Series[0].LegendText = "QuickSort";
            chart1.Series[1].LegendText = "QuickSortRand";
        }

        protected override myArray GenArr(int N, int t)
        {
            array3 = new myArray3(N, t);
            BubbleSort = () => array3.QuickSortNutsAndBolts();
            InsertionSort = () => array3.SortNutsAndBoltsRandomized();
            return array3;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            array3 = (myArray3)GenArr(n, t);

            richTextBox1.Text = "Bolts:\n" + string.Join(", ", array3.Bolts);

            richTextBox2.Text = "Randomized Nuts:\n" + string.Join(", ", array3.Nuts);

            if (radioButton4.Checked)
            {
                BubbleSort.Invoke();
            }
            else if (radioButton5.Checked)
            {
                InsertionSort.Invoke();
            }

            richTextBox3.Text = "Sorted Bolts:\n" + string.Join(", ", array3.Bolts);
            richTextBox4.Text = "Sorted Nuts:\n" + string.Join(", ", array3.Nuts);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            array3 = (myArray3)GenArr(n, t);
        }
    }
}
