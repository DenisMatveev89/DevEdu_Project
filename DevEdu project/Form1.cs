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
        Ellipse ellipse = new Ellipse();
        Triangle triangle = new Triangle();

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
                        StaticBitmap.Copy();
                        pictureBox1.Image = line.DrawLine(PrevPoint.X, PrevPoint.Y, CurrentPoint.X, CurrentPoint.Y, currentColor);
                        StaticBitmap.Update();
                        break;

                    case "line":
                        CurrentPoint = e.Location;
                        StaticBitmap.Copy();
                        pictureBox1.Image = line.DrawLine(PrevPoint.X, PrevPoint.Y, CurrentPoint.X, CurrentPoint.Y, currentColor);
                        break;

                    case "ellipse":
                        CurrentPoint = e.Location;
                        StaticBitmap.Copy();
                        pictureBox1.Image = ellipse.DrawEllipse(PrevPoint.X, PrevPoint.Y, CurrentPoint.X, CurrentPoint.Y, currentColor);                        
                        break;
                    case "circle":
                        CurrentPoint = e.Location;
                        StaticBitmap.Copy();
                        pictureBox1.Image = ellipse.DrawCircle(PrevPoint.X, PrevPoint.Y, CurrentPoint.X, CurrentPoint.Y, currentColor);
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
                        CurrentPoint = e.Location;
                        StaticBitmap.Copy();
                        triangle.RightTriangle(PrevPoint.X, PrevPoint.Y, CurrentPoint.X, CurrentPoint.Y, currentColor);
                        pictureBox1.Image = StaticBitmap.TmpBitmap;
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

        private void EllipseButton_Click_1(object sender, EventArgs e)
        {
            ToolButton = "ellipse";
        }

        private void ellipseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolButton = "ellipse";
        }

        private void circleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolButton = "circle";
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

