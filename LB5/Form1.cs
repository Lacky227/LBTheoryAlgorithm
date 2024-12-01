using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace LB5
{
    public partial class Form1 : Form
    {
        private int[,] points;
        public Form1()
        {
            InitializeComponent();
            SetupChart();
        }

        private void SetupChart()
        {
            chart1.ChartAreas.Clear();
            chart1.Series.Clear();

            var chartArea = new ChartArea("MainArea")
            {
                AxisX =
            {
                Minimum = 0,
                Maximum = 100000,
                Interval = 20000,
                MajorGrid = { Enabled = false }
            },
                AxisY =
            {
                Minimum = 0,
                Maximum = 100000,
                Interval = 20000,
                MajorGrid = { Enabled = false }
            }
            };

            chart1.ChartAreas.Add(chartArea);

            var pointsSeries = new Series("Points")
            {
                ChartType = SeriesChartType.FastPoint,
                MarkerStyle = MarkerStyle.Circle,
                Color = Color.Blue,
                MarkerSize = 8,
                IsVisibleInLegend = false
            };

            var linesSeries = new Series("Lines")
            {
                ChartType = SeriesChartType.Line,
                Color = Color.Red,
                BorderWidth = 2,
                IsVisibleInLegend = false
            };

            chart1.Series.Add(pointsSeries);
            chart1.Series.Add(linesSeries);
        }

        private void LoadPointsFromFile(string filePath)
        {
            points = Calculation.LoadPoints(filePath);

            chart1.Series["Points"].Points.Clear();
            var pointsDisplay = new StringBuilder();

            foreach (var point in points.Cast<int>().Select((value, index) => new { value, index }).Where(p => p.index % 2 == 0))
            {
                int x = points[point.index / 2, 0];
                int y = points[point.index / 2, 1];
                pointsDisplay.AppendLine($"{x} {y}");
                chart1.Series["Points"].Points.AddXY(x, y);
            }

            richTextBox1.Text = pointsDisplay.ToString();
        }

        private void DisplayLines(int[,] lines)
        {
            chart1.Series["Lines"].Points.Clear();

            foreach (var lineIndex in Enumerable.Range(0, lines.GetLength(0)))
            {
                for (var i = 0; i < 8; i += 2)
                {
                    chart1.Series["Lines"].Points.AddXY(lines[lineIndex, i], lines[lineIndex, i + 1]);
                }
                chart1.Series["Lines"].Points.AddXY(double.NaN, double.NaN);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = @"Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    LoadPointsFromFile(openFileDialog.FileName);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (points == null || points.Length == 0)
            {
                MessageBox.Show("Load points first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int[,] lines = radioButton1.Checked ? Calculation.BruteForceLines(points) : Calculation.IntelectualLines(points);

            DisplayLines(lines);
        }
    }
}
