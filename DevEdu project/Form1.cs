using DevEdu_project.Figure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Windows.Documents;
using System.Windows.Forms;
using Color = System.Drawing.Color;
using DevEdu_project.Factory;

namespace DevEdu_project
{
    public partial class BetterThanPhotoshop : Form
    {
        //Объявляем фабрику
        public IFactory factory;
        
        //Объявляем интерфейс AFigure
        static AFigure figure; 

        Dialog dialog = new Dialog();

        Color currentColor = Color.Black;
        private bool mousePress;        
        Point _currentPoint;
        Point _prevPoint;
        BitmapSingletone sBitmap = BitmapSingletone.GetInstance();

        public BetterThanPhotoshop()
        {
            InitializeComponent();
        }

        private void BetterThanPhotoshop_Load(object sender, EventArgs e)
        {            
            sBitmap.CreateBitmaps(pictureBox1.Width, pictureBox1.Height);
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            mousePress = true;
            _prevPoint = e.Location;            
            
            if(factory is PencilFactory) //проверка для карандаша
            {
                factory = new PencilFactory();
            }            
        }
        
        private void pictureBox_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (mousePress)
            {
                _currentPoint = e.Location; //координаты нам нужно фиксировать только когда мышь нажата
                
                sBitmap.Copy();
                figure = factory.Create(_prevPoint, _currentPoint);
                pictureBox1.Image = sBitmap.Draw(figure.GetPoints(), currentColor);
            }
        }
        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {            
            _currentPoint = e.Location;
            _prevPoint = new Point(0, 0);
            mousePress = false;
            sBitmap.Update();
        }
        #region ToolBox
        private void Pencil_Click(object sender, EventArgs e)
        {
            factory = new PencilFactory();            
        }

        private void LineButton_Click(object sender, EventArgs e)
        {
            factory = new LineFactory();
        }        
        private void squareToolStripMenuItem_Click(object sender, EventArgs e)
        {

            factory = new SquareFactory();
        }
        private void rectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            factory = new RectangleFactory();
        }

        private void arbitraryTriangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
             //произвольный треугольник по трем точкам
        }
        
        private void isoscelesTriangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            factory = new TriangleIsoscelesFactory(); //равнобедренный треугольник по одной из граней
        }

        private void rightTriangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            factory = new TriangleRightFactory(); //прямоугольный треугольник по гипотенузе
        }

        private void equilateralTriangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            factory = new TriangleEquilateralFactory(); //равносторонний треугольник по одной стороне
        }
        private void EllipseButton_Click_1(object sender, EventArgs e)
        {
            factory = new EllipseFactory();
        }

        private void ellipseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            factory = new EllipseFactory();
        }

        private void circleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            factory = new CircleFactory();
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
                        sBitmap._bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                        break;
                    case DialogResult.No:
                        pictureBox1.Image = null;
                        sBitmap._bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                        break;
                    case DialogResult.Cancel:
                        break;
                }
            }
        }
    }
}

