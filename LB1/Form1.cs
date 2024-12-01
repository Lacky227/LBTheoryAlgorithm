using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace LBTheoryAlgorithm
{
    public partial class Form1 : Form
    {
        private myArray array;
        public delegate void SortingDelegate();
        public SortingDelegate BubbleSort;
        public SortingDelegate InsertionSort;

        public string nameSort {get; set;}

        public Form1()
        {
            InitializeComponent();

            BubbleSort = new SortingDelegate(() => array.Sort1());
            InsertionSort = new SortingDelegate(() => array.Sort2());
        }

        public string GetArrayAsString()
        {
            return string.Join(", ", array.A);
        }

        protected virtual myArray GenArr(int n, int t)
        {
            array = new myArray(n, t);
            BubbleSort = array.Sort1;
            InsertionSort = array.Sort2;
            return array;
        }
        protected int n;
        protected int t;
        public void button2_Click(object sender, EventArgs e)
        {
            n = (int)numericUpDown1.Value;

            if (radioButton1.Checked)
            {
                t = 1;
            }
            else if (radioButton2.Checked)
            {
                t = 2;
            }
            else if (radioButton3.Checked)
            {
                t = 3;
            }
            array = new myArray(n, t);
            richTextBox1.Text = "Array to be sorted:\n" + GetArrayAsString();


            if (radioButton4.Checked)
            {
                nameSort = "BubbleSort";
                BubbleSort?.Invoke();
            }
            else if (radioButton5.Checked)
            {
                nameSort = "InsertionSort";
                InsertionSort?.Invoke();
            }

            richTextBox2.Text = $"Array after sorting, sort name {nameSort}:\n" + GetArrayAsString();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();

            

            int start = 5;
            int end = 5000;
            int step = 500;
 
            Stopwatch sw = new Stopwatch();

            for (int i = start; i <= end; i += step)
            {
                myArray array1 = GenArr(i, t);

                sw.Restart();
                BubbleSort?.Invoke();
                sw.Stop();
                chart1.Series[0].Points.AddXY(i, sw.Elapsed.TotalMilliseconds);



                myArray array2 = GenArr(i, t);
                sw.Restart();
                InsertionSort?.Invoke();
                sw.Stop();
                chart1.Series[1].Points.AddXY(i, sw.Elapsed.TotalMilliseconds);
            }
        }
    }
}