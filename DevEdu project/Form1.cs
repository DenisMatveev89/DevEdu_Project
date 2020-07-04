using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Shapes;
using Color = System.Drawing.Color;

namespace DevEdu_project
{
    public partial class BetterThanPhotoshop : Form
    {
        Line line = new Line();
       

        Color currentColor = Color.Black;
        private bool mousePress;
        string ToolButton; //кнопка выбора инструмента рисования

        Point CurrentPoint;
        Point PrevPoint;

        public BetterThanPhotoshop()
        {
            InitializeComponent();
        }

        private void BetterThanPhotoshop_Load(object sender, EventArgs e)
        {
            StaticBitmap.Bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            CurrentPoint = e.Location;
            PrevPoint = e.Location;
            mousePress = true;
        }

        private void pictureBox_MouseMove_1(object sender, MouseEventArgs e)
        {
            
            if (mousePress)
            {
                switch (ToolButton)
                {
                    case "pencil":
                        PrevPoint = CurrentPoint;
                        CurrentPoint = e.Location;
                        pictureBox1.Image = line.DrawLine(PrevPoint.X, PrevPoint.Y, CurrentPoint.X, CurrentPoint.Y, currentColor);
                        StaticBitmap.Update();
                        break;

                    case "line":
                        CurrentPoint = e.Location;
                        pictureBox1.Image = line.DrawLine(PrevPoint.X, PrevPoint.Y, CurrentPoint.X, CurrentPoint.Y, currentColor);
                        break;

                    case "ellips":
                        //эллипс
                        break;

                    case "rectangle":
                        //прямоугольник
                        break;

                    case "square":
                        //квадрат
                        break;

                    case "arbirtrary triangle":
                        //произвольный треугольник по трем точкам
                        break;

                    case "isosceles triangle":
                        //равнобедренный треугольник по одной из граней
                        break;

                    case "right triangle":
                        //прямоугольный треугольник по гипотенузе
                        break;
                }
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            CurrentPoint = e.Location;
            mousePress = false;
            StaticBitmap.Update();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #region ToolBox
        private void Pencil_Click(object sender, EventArgs e)
        {
            ToolButton = "pencil";
        }

        private void LineButton_Click(object sender, EventArgs e)
        {
            ToolButton = "line";
        }

        private void EllipseButton_Click(object sender, EventArgs e)
        {
            ToolButton = "ellips";
        }

        private void RectangleDropDownButton1_Click(object sender, EventArgs e)
        {
            ToolButton = "rectangle";
        }

        private void rectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolButton = "rectangle";
        }

        private void squareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolButton = "square";
        }

        private void triangleDropDownButton1_Click(object sender, EventArgs e)
        {
            ToolButton = "arbirtrary triangle"; //произвольный треугольник по трем точкам
        }

        private void arbitraryTriangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolButton = "arbirtrary triangle"; //произвольный треугольник по трем точкам
        }

        private void isoscelesTriangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolButton = "isosceles triangle"; //равнобедренный треугольник по одной из граней
        }

        private void rightTriangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolButton = "right triangle"; //прямоугольный треугольник по гипотенузе
        }
        #endregion
     
        #region Color
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            currentColor = Color.Red;
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            currentColor = Color.Black;
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            currentColor = Color.Green;
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            currentColor = Color.Yellow;
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            currentColor = Color.Blue;
        }
        #endregion
    }
}

