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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.Windows.Forms.DataVisualization.Charting;

namespace LBTheoryAlgorithm
{
    public partial class Form2 : Form1
    {
        private myArray1 array1;
        private myArray array;
        public Form2()
        {
            InitializeComponent();



            chart1.Series[0].Name = "Merge Sort";
            radioButton4.Text = "Sort Merge";
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            array1 = new myArray1(5000, 2);

            BubbleSort = new SortingDelegate(() => array1.MergeSort());
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            array1 = new myArray1(5000, 2);

            InsertionSort?.Invoke();

            BubbleSort = array1.MergeSort;

            BubbleSort?.Invoke();

           button1_Click(sender, e);
        }
    }
}
