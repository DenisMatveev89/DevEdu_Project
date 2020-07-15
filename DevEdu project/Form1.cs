using DevEdu_project.Brush;
using DevEdu_project.Figure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Windows.Documents;
using System.Windows.Forms;
using Color = System.Drawing.Color;

using DevEdu_project.Factory;
using System.Threading;

namespace DevEdu_project
{
    public partial class BetterThanPhotoshop : Form
    {
        //Объявляем фабрику
        AFactory _factory = new PencilFactory();
        //Объявляем интерфейс AFigure
        AFigure _figure = new Pencil();
        AFigure _currentFigure;
        AFigure _onFigure;
        AFigure _fillFigure;
        //Диалоговые окошки
        Dialog dialog = new Dialog();

        double brushWidth = 10;
        //хранилище фигур
        Storage storage = new Storage();
        //Тулсы всякие
        bool figureMoveTool = false;
        bool eraserTool = false;
        bool fillTool = false;
        Color _fillColor = Color.Red;

        Color _currentColor = Color.Black;
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

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            _onFigure = null;
            if (fillTool)
            {
                _fillFigure = null;
                _fillFigure = storage.figureUnderMouse(e.Location);
                //Color currentPxColor = sBitmap.ColorSelectPoint(e.X, e.Y);
                if (_fillFigure != null)
                {
                    sBitmap.Copy();
                    _figure.Fill(e.Location, Color.Red);
                    pictureBox1.Image = sBitmap._tmpBitmap;
                    sBitmap.Update();
                }
            }
            if (eraserTool)
            {
                if (_currentFigure != null)
                {
                    _onFigure = sBitmap.figureUnderMouse(e.Location);
                    sBitmap.Clear();
                    pictureBox1.Image = sBitmap.EraseIndexFigure(_onFigure);
                }
                
            }
            sBitmap.Update();
        }
      
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {            
            _prevPoint = e.Location;            
            _currentFigure = _figure;
            if(_factory != null)
            {
                _factory.Update();
                mousePress = true;
            } 
        }

        private void pictureBox_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (mousePress && _factory != null)
            {
                _currentPoint = e.Location; //координаты нам нужно фиксировать только когда мышь нажата

                sBitmap.Copy();
                _figure = _factory.Create(_prevPoint, _currentPoint, _currentColor, _fillColor);
                pictureBox1.Image = sBitmap.DrawFigure(_figure);
            }
        }
        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            _currentPoint = e.Location;
            if (_factory != null)
            {
                sBitmap.saveFigures(_figure);
                _currentFigure = _figure;
                mousePress = false;
                sBitmap.Update();
            }            
        }
        #region ToolBox
        private void Pencil_Click(object sender, EventArgs e)
        {
            _factory = new PencilFactory();
            eraserTool = false;
            figureMoveTool = false;
            fillTool = false;
        }

        private void LineButton_Click(object sender, EventArgs e)
        {
            _factory = new LineFactory();
            eraserTool = false;
            figureMoveTool = false;
            fillTool = false;
        }
        private void squareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _factory = new SquareFactory();
            eraserTool = false;
            figureMoveTool = false;
            fillTool = false;
        }
        private void rectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _factory = new RectangleFactory();
            eraserTool = false;
            figureMoveTool = false;
            fillTool = false;
        }

        private void arbitraryTriangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //произвольный треугольник по трем точкам
            eraserTool = false;
            figureMoveTool = false;
            fillTool = false;
        }

        private void isoscelesTriangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _factory = new TriangleIsoscelesFactory(); //равнобедренный треугольник по одной из граней
            eraserTool = false;
            figureMoveTool = false;
            fillTool = false;
        }

        private void rightTriangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _factory = new TriangleRightFactory(); //прямоугольный треугольник по гипотенузе
            eraserTool = false;
            figureMoveTool = false;
            fillTool = false;
        }

        private void equilateralTriangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _factory = new TriangleEquilateralFactory(); //равносторонний треугольник по одной стороне
            eraserTool = false;
            figureMoveTool = false;
            fillTool = false;
        }
        private void EllipseButton_Click_1(object sender, EventArgs e)
        {
            _factory = new EllipseFactory();
            eraserTool = false;
            figureMoveTool = false;
            fillTool = false;
        }

        private void ellipseToolStripMenuItem_Click(object sender, EventArgs e)
        {

            eraserTool = false;
            figureMoveTool = false;
            if (eraserTool == false && figureMoveTool == false)
            {
                _factory = new EllipseFactory();
            }
            


        }

        private void circleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            _factory = new CircleFactory();
            eraserTool = false;
            figureMoveTool = false;
            fillTool = false;
        }
        #endregion

        #region Color
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            _currentColor = Color.Red;
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            _currentColor = Color.Black;
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            _currentColor = Color.Green;
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            _currentColor = Color.Yellow;
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            _currentColor = Color.Blue;
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
                
        private void EraserButton_Click(object sender, EventArgs e)
        {
          
            eraserTool = true;
            figureMoveTool = false;
            fillTool = false;
            _factory = null;

            //Вызов метода, который возвращает все фигуры, сохраненные в листе
            //pictureBox1.Image = sBitmap.DrawAllFigures(storage.figureList);
        }

        private void AngleButton_Click(object sender, EventArgs e)
        {
            figureMoveTool = true;
            eraserTool = false;
            fillTool = false;
        }

        private void FillColorButton_Click(object sender, EventArgs e)
        {
            fillTool = true;
            eraserTool = false;
            figureMoveTool = false;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            _fillColor = Color.Black;
        }
    }
}

