using DevEdu_project.Brush;
using DevEdu_project.Figure;
using System;
using System.Drawing;
using System.Windows.Forms;
using DevEdu_project.Factory;
using DocumentFormat.OpenXml.Bibliography;using DevEdu_project.ToolBox;
using Newtonsoft.Json;
using System.IO;
using DevEdu_project.LineW;
namespace DevEdu_project
{
    public partial class BetterThanPhotoshop : Form
    {
        //Объявляем фабрику
        AFactory _factory = new PencilFactory();
        //Объявляем интерфейс AFigure
        //AFigure _figure = new Pencil();
        AFigure _currentFigure;
        AFigure _clickFigure;
        ITool tool;
        IBrush fill = new FullFill();
        //ILineWidth lineWidth = new LineWidth();
        
        //Диалоговые окошки
        Dialog dialog = new Dialog();

        //Graphics g = e.Graphics();

        double brushWidth = 10;
                
        private bool mousePress;
        //Color _fillColor = Color.Red;
        Color _fillColor = Color.Transparent;
        Color _currentColor = Color.Black;
        Point _currentPoint;
        Point _prevPoint;
        Point _startMovingPoint;
        //Point _movingPoint;
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
            _clickFigure = sBitmap.FigureUnderMouse(e.Location);

            if (_clickFigure != null)
            {
                _currentFigure = _clickFigure;
                tool.DoLogicOnMouseClick(e.Location, _currentFigure, _fillColor);
                pictureBox1.Image = sBitmap._tmpBitmap;
                sBitmap.Update();
            }

        }
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            _prevPoint = e.Location;            mousePress = true;
            _clickFigure = sBitmap.FigureUnderMouse(e.Location);

            if (_factory != null)
            {
                _factory.Update();
            }
            else if (_clickFigure != null)
            {
                _currentFigure = _clickFigure;
                tool.DoLogigOnMouseDown(_currentFigure);
            }
        }

        private void pictureBox_MouseMove_1(object sender, MouseEventArgs e)
        {
            if(mousePress)
            {
                _currentPoint = e.Location;
                sBitmap.Copy();
                if (_factory != null)
                {
                    _currentFigure = _factory.Create(_prevPoint, _currentPoint, _currentColor, _fillColor);
                    sBitmap.DrawFigure(_currentFigure);
                }
                else if(_clickFigure != null)
                {
                    tool.DoLogicOnMouseMove(_prevPoint, _currentPoint, _currentFigure);
                }

                pictureBox1.Image = sBitmap._tmpBitmap;
            }
        }
        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            _currentPoint = e.Location;
            mousePress = false;
            if (_factory != null)
            {
                sBitmap.SaveFigures(_currentFigure);
                sBitmap.Update();
                if (_fillColor != Color.Transparent)
                {                    sBitmap.Copy();
                    _currentFigure.FillFigure(_currentFigure._centerPoint);
                    sBitmap.CopyFromFill();
                }
            }            else
            {
                if(_clickFigure != null)
                {
                    tool.DoLogicOnMouseUp(_currentFigure);
                }                
            }
            sBitmap.Update();            pictureBox1.Image = sBitmap._bitmap;
        }
        #region ToolBox
        private void EraserButton_Click(object sender, EventArgs e)
        {
            tool = new EraserTool();
            _factory = null;
        }

        private void AngleButton_Click(object sender, EventArgs e)
        {
            tool = new ResizeTool();
            _factory = null;  
        }
        private void FillColorButton_Click(object sender, EventArgs e)
        {
            tool = new FillTool();
            _factory = null;
        }
        private void Pencil_Click(object sender, EventArgs e)
        {
            tool = new FigureDrawTool();
            _factory = new PencilFactory();            
        }

        private void LineButton_Click(object sender, EventArgs e)
        {
            tool = new FigureDrawTool();
            _factory = new LineFactory();
        }
        private void squareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tool = new FigureDrawTool();
            _factory = new SquareFactory();
        }
        private void rectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tool = new FigureDrawTool();
            _factory = new RectangleFactory();
        }

        private void arbitraryTriangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tool = new FigureDrawTool();
            //произвольный треугольник по трем точкам
            
        }

        private void isoscelesTriangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tool = new FigureDrawTool();
            _factory = new TriangleIsoscelesFactory(); //равнобедренный треугольник по одной из граней
            
        }

        private void rightTriangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tool = new FigureDrawTool();
            _factory = new TriangleRightFactory(); //прямоугольный треугольник по гипотенузе
            
        }

        private void equilateralTriangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tool = new FigureDrawTool();
            _factory = new TriangleEquilateralFactory(); //равносторонний треугольник по одной стороне
            
        }
        private void EllipseButton_Click_1(object sender, EventArgs e)
        {
            tool = new FigureDrawTool();
            _factory = new EllipseFactory();
            
        }

        private void ellipseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tool = new FigureDrawTool();
            _factory = new EllipseFactory();
        }

        private void circleToolStripMenuItem_Click(object sender, EventArgs e)
        {            tool = new FigureDrawTool();
            _factory = new CircleFactory();
        }
        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            tool = new FigureMoveTool();
            _factory = null;            
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
        private void saveAsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null) //если в pictureBox есть изображение
            {
                dialog.SaveSourceDialog();
            }
            
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
                        break;
                    case DialogResult.No:
                        dialog.OpenSourceDialog();
                        
                        break;
                    case DialogResult.Cancel:
                        break;
                }
                pictureBox1.Image = null;
                pictureBox1.Image = sBitmap._tmpBitmap;
            }
            else
            {
                dialog.OpenSourceDialog();
                pictureBox1.Image = sBitmap._tmpBitmap;
            }
        }

        private void toolStripButton16_Click(object sender, EventArgs e)
        {
            sBitmap.CreateBitmaps(pictureBox1.Width, pictureBox1.Height);
            sBitmap.Update();
            pictureBox1.Image = null;
        }
    }
}

