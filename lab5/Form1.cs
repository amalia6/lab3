using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab5
{
    public partial class Form1 : Form
    {
        public Graphics graph;

        int[] x = new int[1000];
        int[] y = new int[1000];
        int numOfCells = 10;
        int cellSize = 60;
        Point[,] neuroni = new Point[10, 10];

        public Form1()
        {
            InitializeComponent();
        }
        void Citire()
        {
            StreamReader sr = new StreamReader("punctuletze.txt");

            string[] line = new string[3];

            for (int i = 0; i < 1000; i++)
            {
                line = sr.ReadLine().Split(' ');
                x[i] = Convert.ToInt32(line[0]);
                y[i] = Convert.ToInt32(line[1]);

                graph.DrawRectangle(new Pen(Color.Black), x[i] + 300, y[i] + 300, 1, 1);
            }
        }
        void Grid()
        {
            for (int i = 0; i < numOfCells; i++)
            {
                // Vertical
                graph.DrawLine(new Pen(Color.Red), i * cellSize, 0, i * cellSize, numOfCells * cellSize);
                // Horizontal
                graph.DrawLine(new Pen(Color.Red), 0, i * cellSize, numOfCells * cellSize, i * cellSize);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            graph = panel1.CreateGraphics();

            Citire();

            Grid();

            graph.DrawLine(new Pen(Color.Black), new Point(0, 300), new Point(600, 300));
            graph.DrawLine(new Pen(Color.Black), new Point(300, 0), new Point(300, 600));

            for (int i = 0; i < numOfCells; i++)
            {
                for (int j = 0; j < numOfCells; j++)
                {
                    neuroni[i, j].X =  j * 60 - 3;  
                    neuroni[i, j].Y =  i * 60 - 3; //calc in pixeli!!!

                    graph.FillEllipse(new SolidBrush(Color.Blue), neuroni[i, j].X, neuroni[i, j].Y , 6, 6);
                }
            }


        }
    }
}
