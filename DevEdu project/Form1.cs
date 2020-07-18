using DevEdu_project.Brush;
using DevEdu_project.Figure;
using System;
using System.Drawing;
using System.Windows.Forms;
using DevEdu_project.Factory;
using DocumentFormat.OpenXml.Bibliography;
using DevEdu_project.LineW;
using Newtonsoft.Json;
using System.IO;

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
        //ILineWidth lineWidth = new LineWidth();
        
        //Диалоговые окошки
        Dialog dialog = new Dialog();

        //хранилище фигур    
        Storage storage = new Storage();
        //Тулсы всякие
        bool figureMoveTool = false;
        bool eraserTool = false;
        bool fillTool = false;
        bool resizeTool = false;
        private bool mousePress;
        //Color _fillColor = Color.Red;
        Color _fillColor = Color.Transparent;
        Color _currentColor = Color.Black;
        Point _currentPoint;
        Point _prevPoint;
        Point _startMovingPoint;
        Point _movingPoint;
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
            AFigure clickFigure = sBitmap.FigureUnderMouse(e.Location);

            if (fillTool && _factory == null && clickFigure != null)
            {
                _currentFigure = clickFigure;
                sBitmap.Clear();
                sBitmap.DrawExceptIndexFigures(_currentFigure);
                //sBitmap.FillExceptIndexFigures(_currentFigure);

                _currentFigure._fillColor = _fillColor;
                _currentFigure.FillFigure(e.Location);
                sBitmap.CopyFromFill();
                pictureBox1.Image = sBitmap._tmpBitmap;
            }
            else if (eraserTool && clickFigure != null && _factory == null)
            {
                _currentFigure = clickFigure;
                sBitmap.Clear();
                pictureBox1.Image = sBitmap.EraseIndexFigure(_currentFigure);
            }
            
            sBitmap.Update();
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            _prevPoint = e.Location;
            if (_factory != null)
            {
                _factory.Update();
                mousePress = true;
            }
            else if(figureMoveTool || resizeTool)
            {
                mousePress = true;
            }

            AFigure clickFigure = sBitmap.FigureUnderMouse(e.Location);
            if (figureMoveTool && clickFigure != null && _factory == null)
            {
                _currentFigure = clickFigure;
                _startMovingPoint = e.Location;
                //очищаем битмапы, fillBitmap = прежнему tmp
                sBitmap.Clear();

                //рисуем на tmpBitmap все фигуры, кроме выбранной, потом заливаем их
                sBitmap.DrawExceptIndexFigures(_currentFigure);
                //sBitmap.FillExceptIndexFigures(_currentFigure);

                //pictureBox1.Image = sBitmap._tmpBitmap;
                //sBitmap.CopyFromFill();

            }
            else if (resizeTool && clickFigure != null && _factory == null)
            {
                _currentFigure = clickFigure;
                //_currentFigure._startPoint = e.Location;
                //очищаем битмапы, fillBitmap = прежнему tmp
                sBitmap.Clear();

                //рисуем на tmpBitmap все фигуры, кроме выбранной, потом заливаем их
                sBitmap.DrawExceptIndexFigures(_currentFigure);
                //sBitmap.FillExceptIndexFigures(_currentFigure);

                pictureBox1.Image = sBitmap._tmpBitmap;
                //sBitmap.CopyFromFill();
            }
        }

        private void pictureBox_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (mousePress && _factory != null)
            {
                _currentPoint = e.Location; //координаты нам нужно фиксировать только когда мышь нажата
                sBitmap.Copy();
                sBitmap.DrawExceptIndexFigures(_currentFigure);

                _figure = _factory.Create(_prevPoint, _currentPoint, _currentColor, _fillColor);
                sBitmap.DrawFigure(_figure);

                pictureBox1.Image = sBitmap._tmpBitmap;
            }
            else if(mousePress && figureMoveTool)
            {
                //Расстояние, на которое смещаются точки
                _movingPoint = e.Location;
                sBitmap.Copy();
                _currentFigure = _currentFigure.Move(_startMovingPoint, _movingPoint, _currentFigure);
                //Изменение фигуры
                //_currentPoint = e.Location;
                //sBitmap.Copy();

                //_currentFigure._endPoint = e.Location;
                sBitmap.DrawFigure(_currentFigure);

                pictureBox1.Image = sBitmap._tmpBitmap;
            }
            else if(mousePress && resizeTool)
            {
                _currentPoint = e.Location;
                sBitmap.Copy();

                _currentFigure._endPoint = e.Location;
                pictureBox1.Image = sBitmap.DrawFigure(_currentFigure);
            }
        }
        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            _currentPoint = e.Location;
            mousePress = false;
            if (_factory != null)
            {
                sBitmap.SaveFigures(_figure);
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
            resizeTool = false;
        }

        private void AngleButton_Click(object sender, EventArgs e)
        {
            resizeTool = true;
            figureMoveTool = false;
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
            resizeTool = false;
        }
        private void Pencil_Click(object sender, EventArgs e)
        {
            _factory = new PencilFactory();
            eraserTool = false;
            figureMoveTool = false;
            fillTool = false;
            resizeTool = false;
        }

        private void LineButton_Click(object sender, EventArgs e)
        {
            _factory = new LineFactory();
            eraserTool = false;
            figureMoveTool = false;
            fillTool = false;
            resizeTool = false;
        }
        private void squareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _factory = new SquareFactory();
            eraserTool = false;
            figureMoveTool = false;
            fillTool = false;
            resizeTool = false;
        }
        private void rectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _factory = new RectangleFactory();
            eraserTool = false;
            figureMoveTool = false;
            fillTool = false;
            resizeTool = false;
        }

        private void arbitraryTriangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //произвольный треугольник по трем точкам
            eraserTool = false;
            figureMoveTool = false;
            fillTool = false;
            resizeTool = false;
        }

        private void isoscelesTriangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _factory = new TriangleIsoscelesFactory(); //равнобедренный треугольник по одной из граней
            eraserTool = false;
            figureMoveTool = false;
            fillTool = false;
            resizeTool = false;
        }

        private void rightTriangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _factory = new TriangleRightFactory(); //прямоугольный треугольник по гипотенузе
            eraserTool = false;
            figureMoveTool = false;
            fillTool = false;
            resizeTool = false;
        }

        private void equilateralTriangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _factory = new TriangleEquilateralFactory(); //равносторонний треугольник по одной стороне
            eraserTool = false;
            figureMoveTool = false;
            fillTool = false;
            resizeTool = false;
        }
        private void EllipseButton_Click_1(object sender, EventArgs e)
        {
            _factory = new EllipseFactory();
            eraserTool = false;
            figureMoveTool = false;
            fillTool = false;
            resizeTool = false;
        }

        private void ellipseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            eraserTool = false;
            figureMoveTool = false;
            resizeTool = false;
            fillTool = false;
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
            resizeTool = false;
        }
        #endregion

        #region BorderLineColor
        private void toolColorLineButtonRed_Click(object sender, EventArgs e)
        {
            _currentColor = Color.Red;
        }

        private void toolColorLineButtonGreen_Click(object sender, EventArgs e)
        {
            _currentColor = Color.Green;
        }

        private void toolColorLineButtonYellow_Click(object sender, EventArgs e)
        {
            _currentColor = Color.Yellow;
        }

        private void toolColorLineButtonBlue_Click(object sender, EventArgs e)
        {
            _currentColor = Color.Blue;
        }

        private void toolColorLineButtonWhite_Click(object sender, EventArgs e)
        {
            _currentColor = Color.White;
        }
        private void toolColorLineButtonBlack_Click(object sender, EventArgs e)
        {
            _currentColor = Color.Black;
        }

        #endregion

        #region Menu
        //Menu Exit
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        public void EventNew()
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
        private void toolFillColorBlack_Click(object sender, EventArgs e)
        {
            _fillColor = Color.Black;
        }

        private void toolFillColorWhite_Click(object sender, EventArgs e)
        {
            _fillColor = Color.White;
        }

        private void toolFillColorTransparent_Click(object sender, EventArgs e)
        {
            _fillColor = Color.Transparent;
        }

        private void toolFillColorRed_Click(object sender, EventArgs e)
        {
            _fillColor = Color.Red;
        }

        private void toolFillColorGreen_Click(object sender, EventArgs e)
        {
            _fillColor = Color.Green;
        }

        private void toolFillColorYellow_Click(object sender, EventArgs e)
        {
            _fillColor = Color.Yellow;
        }

        private void toolFillColorBlue_Click(object sender, EventArgs e)
        {
            _fillColor = Color.Blue;
        }
        #endregion

        private void toolMoveButton_Click(object sender, EventArgs e)
        {
            figureMoveTool = true;
            resizeTool = false;
            eraserTool = false;
            fillTool = false;
            _factory = null;
        }

        private void saveAsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
            
        }

        private void openSourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null) //если в pictureBox есть изображение
            {
                DialogResult result = dialog.NewDialog();
                switch (result)
                {
                    case DialogResult.Yes:
                        dialog.SaveSourceDialog();
                        dialog.OpenSourceDialog();
                        pictureBox1.Image = null;
                        break;
                    case DialogResult.No:
                        dialog.OpenSourceDialog();
                        pictureBox1.Image = null;
                        break;
                    case DialogResult.Cancel:
                        break;
                }
                _fillColor = Color.Transparent;
                _currentColor = Color.Black;
                pictureBox1.Image = sBitmap._tmpBitmap;
            }
            else
            {
                dialog.OpenSourceDialog();
                pictureBox1.Image = sBitmap._tmpBitmap;
            }
        }

        private void toolEraseButton_Click(object sender, EventArgs e)
        {
            sBitmap.CreateBitmaps(pictureBox1.Width, pictureBox1.Height);
            sBitmap.Update();
            pictureBox1.Image = null;
        }

        private void saveAsImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null) //если в pictureBox есть изображение
            {
                dialog.SaveDialog();
            }
        }

        private void saveAsSourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null) //если в pictureBox есть изображение
            {
                dialog.SaveSourceDialog();
            }
        }

        private void BetterThanPhotoshop_SizeChanged(object sender, EventArgs e)
        {
            pictureBox1.Width = Size.Width - 60;
            pictureBox1.Height = Size.Height - 100;
            sBitmap.UpdateBitmap(pictureBox1.Width, pictureBox1.Height);
            sBitmap.Update();
        }
    }
}

