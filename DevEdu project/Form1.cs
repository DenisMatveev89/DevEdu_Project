using DevEdu_project.Brush;
using DevEdu_project.Figure;
using System;
using System.Drawing;
using System.Windows.Forms;
using DevEdu_project.Factory;
using DocumentFormat.OpenXml.Bibliography;

namespace DevEdu_project
{
    public partial class BetterThanPhotoshop : Form
    {
        //Объявляем фабрику
        AFactory _factory = new PencilFactory();
        //Объявляем интерфейс AFigure
        AFigure _figure = new Pencil();
        AFigure _currentFigure;
        AFigure _movingFigure;
        IBrush fill = new FullFill();
        //Диалоговые окошки
        Dialog dialog = new Dialog();

        double brushWidth = 10;
        //хранилище фигур
        Storage storage = new Storage();
        //Тулсы всякие
        bool figureMoveTool = false;
        bool eraserTool = false;
        bool fillTool = false;
        private bool mousePress;
        //Color _fillColor = Color.Red;
        Color _fillColor = Color.Transparent;
        Color _currentColor = Color.Black;
        Point _currentPoint;
        Point _prevPoint;
        BitmapSingletone sBitmap = BitmapSingletone.GetInstance();


        public BetterThanPhotoshop()
        {
            InitializeComponent();
        }

        private void BetterThanPhotoshop_Load(object sender, EventArgs e)
        {
            sBitmap.CreateBitmaps(pictureBox1.Width - 1, pictureBox1.Height - 1);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (figureMoveTool)
            {
                _movingFigure = sBitmap.figureUnderMouse(e.Location);
                if (_movingFigure != null)
                {
                    pictureBox1.Image = null;
                    sBitmap.Clear();
                    pictureBox1.Image = sBitmap.DrawIndexFigures(_movingFigure);
                }
            }
            if (fillTool)
            {
                //_fillFigure = null;
                //Color currentPxColor = sBitmap.ColorSelectPoint(e.X, e.Y);
                
                _currentFigure = sBitmap.figureUnderMouse(e.Location);
                
                if (_factory == null && _currentFigure != null)
                {
                    sBitmap.Clear();
                    sBitmap.DrawIndexFigures(_currentFigure);
                    _currentFigure._fillColor = _fillColor;
                    _currentFigure.FillFigure(e.Location);
                    sBitmap.CopyFromFill();
                    pictureBox1.Image = sBitmap._tmpBitmap;
                }
            }
            if (eraserTool)
            {
                _currentFigure = sBitmap.figureUnderMouse(e.Location);
                if (_factory == null && _currentFigure != null)
                {                   
                    sBitmap.Clear();
                    pictureBox1.Image = sBitmap.EraseIndexFigure(_currentFigure);
                }
                
            }
            sBitmap.Update();
        }
      
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {            
            _prevPoint = e.Location; 
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
                sBitmap.DrawFigure(_figure);
                
                //sBitmap.Copy();
                //_figure.FillFigure(e.Location);
                //sBitmap.CopyFromFill();
                pictureBox1.Image = sBitmap._tmpBitmap;
            }
            
        }
        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            _currentPoint = e.Location;
            mousePress = false;
            if (_factory != null)
            {
                sBitmap.saveFigures(_figure);
                _currentFigure = _figure;                
                sBitmap.Update();

                if (_fillColor != Color.Transparent)
                {
                    sBitmap.Copy();
                    _figure.FillFigure(_currentFigure._centerPoint);
                    sBitmap.CopyFromFill();
                    pictureBox1.Image = sBitmap._tmpBitmap;  
                }
            }

            sBitmap.Update();

        }
        #region ToolBox
        private void EraserButton_Click(object sender, EventArgs e)
        {
            eraserTool = true;
            figureMoveTool = false;
            fillTool = false;
            _factory = null;
        }

        private void AngleButton_Click(object sender, EventArgs e)
        {
            figureMoveTool = true;
            eraserTool = false;
            fillTool = false;
            _factory = null;
        }

        private void FillColorButton_Click(object sender, EventArgs e)
        {
            fillTool = true;
            eraserTool = false;
            figureMoveTool = false;
            _factory = null;
        }
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

        #region BorderLineColor
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

        #region DialogBox
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
        #endregion

        #region FillColorMenu
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            _fillColor = Color.Black;
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            _fillColor = Color.White;
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            _fillColor = Color.Transparent;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            _fillColor = Color.Red;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            _fillColor = Color.Green;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            _fillColor = Color.Yellow;
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            _fillColor = Color.Blue;
        }
        #endregion

        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            figureMoveTool = false;
            eraserTool = false;
            fillTool = false;
        }
    }
}

