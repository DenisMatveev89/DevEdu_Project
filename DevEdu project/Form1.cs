using DevEdu_project.Brush;
using DevEdu_project.Figure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Windows.Documents;
using System.Windows.Forms;
using Color = System.Drawing.Color;

namespace DevEdu_project
{
    public partial class BetterThanPhotoshop : Form
    {
        //Объявляем интерфейс IFigure

        AFigure figure = new Pencil();
        
        Dialog dialog = new Dialog();

        Color currentColor = Color.Black;
        private bool mousePress;
        Point CurrentPoint;
        Point PrevPoint;
        BitmapSingletone sBitmap = BitmapSingletone.GetInstance();

        public BetterThanPhotoshop()
        {
            InitializeComponent();
            
        }

        private void BetterThanPhotoshop_Load(object sender, EventArgs e)
        {
            
            sBitmap.CreateBitmaps(pictureBox1.Width, pictureBox1.Height);
            //StaticBitmap.Bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            ///StaticBitmap.TmpBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height); //Эта строчка нужна, чтобы не было ошибок
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            mousePress = true;
            PrevPoint = e.Location;            
            CurrentPoint = e.Location;
            //figure.Update(); //это обновление нужно, чтобы карандаш работал правильно
            sBitmap.Update();
        }
        
        private void pictureBox_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (mousePress)
            {
                CurrentPoint = e.Location; //координаты нам нужно фиксировать только когда мышь нажата
                
                figure._startPoint = PrevPoint;
                figure._endPoint = CurrentPoint;
                sBitmap.Copy();
                figure.Update();
                pictureBox1.Image = sBitmap.Draw(figure.GetPoints(), currentColor);
            }
        }
        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {            
            CurrentPoint = e.Location;            
            mousePress = false;
            sBitmap.Update();
        }
        #region ToolBox
        private void Pencil_Click(object sender, EventArgs e)
        {
            figure = new Pencil(PrevPoint, CurrentPoint);
        }

        private void LineButton_Click(object sender, EventArgs e)
        {
            figure = new StraightLine();
        }        
        private void squareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            figure = new RectangleSquar();
        }
        private void rectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            figure = new Rectangle();
        }

        private void arbitraryTriangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
             //произвольный треугольник по трем точкам
        }
        
        private void isoscelesTriangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            figure = new TriangleIsosceles(); //равнобедренный треугольник по одной из граней
        }

        private void rightTriangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            figure = new TriangleRight(); //прямоугольный треугольник по гипотенузе
        }

        private void equilateralTriangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            figure = new TriangleEquilateral(); //равносторонний треугольник по одной стороне
        }
        private void EllipseButton_Click_1(object sender, EventArgs e)
        {
            figure = new Ellipse();
        }

        private void ellipseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            figure = new Ellipse();
        }

        private void circleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            figure = new Circle();
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

        #region Menu
        //Menu Exit
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //Menu SaveAs
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null) //если в pictureBox есть изображение
            {
                dialog.SaveDialog();
            }
        }
        //Create new
        private void clearCanvasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventNew();       
        }
        //Application Closed
        private void BetterThanPhotoshop_FormClosed(object sender, FormClosedEventArgs e)
        {
            EventClose();
            Application.Exit();
        }
        #endregion

        private void EventClose()
        {
            if (pictureBox1.Image != null) //если в pictureBox есть изображение
            {
                DialogResult result = dialog.NewDialog();
                switch (result)
                {
                    case DialogResult.Yes:
                        dialog.SaveDialog();
                        break;
                    case DialogResult.No:
                        Application.Exit();
                        break;
                    case DialogResult.Cancel:
                        break;
                }
            }
            Application.Exit();
        }

        private void EventNew()
        {
            if (pictureBox1.Image != null) //если в pictureBox есть изображение
            {
                DialogResult result = dialog.NewDialog();
                switch (result)
                {
                    case DialogResult.Yes:
                        dialog.SaveDialog();
                        pictureBox1.Image = null;
                        sBitmap.Bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                        break;
                    case DialogResult.No:
                        pictureBox1.Image = null;
                        sBitmap.Bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                        break;
                    case DialogResult.Cancel:
                        break;
                }
            }
        }
    }
}

