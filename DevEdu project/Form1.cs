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
        AFigure _currentFigure = new Pencil();
        AFigure _clickFigure;
        ITool tool;
        
        //Диалоговые окошки
        Dialog dialog = new Dialog();

        //Graphics g = e.Graphics();        
                
        private bool mousePress;
        Color _fillColor = Color.Transparent;
        Color _currentColor = Color.Black;
        Point _currentPoint;
        Point _prevPoint;
        int width = 0;
        BitmapSingletone sBitmap = BitmapSingletone.GetInstance();

        public BetterThanPhotoshop()
        {
            InitializeComponent();
        }

        private void BetterThanPhotoshop_Load(object sender, EventArgs e)
        {
            pictureBox1.Width = Size.Width - 58;
            pictureBox1.Height = Size.Height - 117;
            sBitmap.CreateBitmaps(pictureBox1.Width, pictureBox1.Height);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            _clickFigure = sBitmap.FigureUnderMouse(e.Location);

            if (_clickFigure != null && _currentFigure._startPoint != new Point(0,0))
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

            if (_factory != null)
            {
                _factory.Update();
            }
            else
            {
                _clickFigure = sBitmap.FigureUnderMouse(e.Location);
                if(_clickFigure != null)
                {
                    _currentFigure = _clickFigure;
                    tool.DoLogigOnMouseDown(_currentFigure);
                }                
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
                    _currentFigure = _factory.Create(_prevPoint, _currentPoint, _currentColor, _fillColor, width);
                    sBitmap.DrawFigure(_currentFigure);
                }
                else if(_clickFigure != null)
                {
                    tool.DoLogicOnMouseMove(_prevPoint, _currentPoint, _currentFigure);
                }
                
                pictureBox1.Image = sBitmap._tmpBitmap;
            }
            toolStripStatusLabel1.Text = ($"Coordinates = {e.Location}");
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
        #region Toolbox
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
 
        //private void toolTurnButton_Click(object sender, EventArgs e)
        //{
        //    _factory = null;
        //    _currentFigure._angle = 90 * Math.PI / 180;
        //    sBitmap.Clear();
        //    sBitmap.DrawExceptIndexFigures(_currentFigure);
        //    sBitmap.Copy();
        //    sBitmap.FillExceptIndexFigures(_currentFigure);
        //    sBitmap.CopyFromFill();
        //    pictureBox1.Image = sBitmap._tmpBitmap;
        //    sBitmap.Update();
        //    _currentFigure.Rotate();
        //    sBitmap.Copy();
        //    sBitmap.vDrawFigure(_currentFigure);
        //    sBitmap.Copy();
        //    sBitmap.FillFigure(_currentFigure);
        //    sBitmap.CopyFromFill();
        //    sBitmap.Update();
        //    pictureBox1.Image = sBitmap._bitmap;
            
        //    //_currentFigure._angel = 0;
           
        //}
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
        private void toolMoveButton_Click(object sender, EventArgs e)
        {
            tool = new FigureMoveTool();
            _factory = null;
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            width = 0;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            width = 1;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            width = 3;
        }

        private void EraserButton_Click(object sender, EventArgs e)
        {
            tool = new EraserTool();
            _factory = null;
        }

        private void toolEraseButton_Click(object sender, EventArgs e)
        {
            sBitmap.CreateBitmaps(pictureBox1.Width, pictureBox1.Height);
            sBitmap.Update();
            pictureBox1.Image = null;
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
        private void openSourceToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null) //если в pictureBox есть изображение
            {
                //BitmapSingletone.GetInstance().Clear();
                //pictureBox1.Image = null;
                _currentFigure = new Pencil();
                _fillColor = Color.Transparent;
                DialogResult result = dialog.NewDialog();
                switch (result)
                {
                    case DialogResult.Yes:
                        dialog.SaveSourceDialog();
                        sBitmap.Clear();
                        sBitmap.Update();
                        dialog.OpenSourceDialog();
                        break;
                    case DialogResult.No:
                        sBitmap.Clear();
                        sBitmap.Update();
                        dialog.OpenSourceDialog();
                        break;
                    case DialogResult.Cancel:
                        break;
                }
                //pictureBox1.Image = sBitmap._bitmap;
                
            }

            else
            {
                pictureBox1.Image = null;
                _fillColor = Color.Transparent;
                sBitmap.Clear();
                dialog.OpenSourceDialog();
                //pictureBox1.Image = sBitmap._bitmap;
            }
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

        #endregion

        #region DialogBox
        private void saveAsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null) //если в pictureBox есть изображение
            {
                dialog.SaveSourceDialog();
            }
        }
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
                        sBitmap.CreateBitmaps(pictureBox1.Width, pictureBox1.Height);
                        break;
                    case DialogResult.No:
                        pictureBox1.Image = null;
                        sBitmap.CreateBitmaps(pictureBox1.Width, pictureBox1.Height);
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

        private void Rotate30_Click(object sender, EventArgs e)
        {
            _factory = null;
            _currentFigure._angle = -30 * Math.PI / 180;
            sBitmap.Clear();
            sBitmap.DrawExceptIndexFigures(_currentFigure);
            sBitmap.Copy();
            sBitmap.FillExceptIndexFigures(_currentFigure);
            sBitmap.CopyFromFill();
            pictureBox1.Image = sBitmap._tmpBitmap;
            sBitmap.Update();
            _currentFigure.Rotate();
            sBitmap.Copy();
            sBitmap.vDrawFigure(_currentFigure);
            sBitmap.Copy();
            sBitmap.FillFigure(_currentFigure);
            sBitmap.CopyFromFill();
            sBitmap.Update();
            pictureBox1.Image = sBitmap._bitmap;

        }

        private void Rotate45_Click(object sender, EventArgs e)
        {
            _factory = null;
            _currentFigure._angle = -45 * Math.PI / 180;
            sBitmap.Clear();
            sBitmap.DrawExceptIndexFigures(_currentFigure);
            sBitmap.Copy();
            sBitmap.FillExceptIndexFigures(_currentFigure);
            sBitmap.CopyFromFill();
            pictureBox1.Image = sBitmap._tmpBitmap;
            sBitmap.Update();
            _currentFigure.Rotate();
            sBitmap.Copy();
            sBitmap.vDrawFigure(_currentFigure);
            sBitmap.Copy();
            sBitmap.FillFigure(_currentFigure);
            sBitmap.CopyFromFill();
            sBitmap.Update();
            pictureBox1.Image = sBitmap._bitmap;
        }

        private void Rotate90_Click(object sender, EventArgs e)
        {
            _factory = null;
            _currentFigure._angle = -90 * Math.PI / 180;
            sBitmap.Clear();
            sBitmap.DrawExceptIndexFigures(_currentFigure);
            sBitmap.Copy();
            sBitmap.FillExceptIndexFigures(_currentFigure);
            sBitmap.CopyFromFill();
            pictureBox1.Image = sBitmap._tmpBitmap;
            sBitmap.Update();
            _currentFigure.Rotate();
            sBitmap.Copy();
            sBitmap.vDrawFigure(_currentFigure);
            sBitmap.Copy();
            sBitmap.FillFigure(_currentFigure);
            sBitmap.CopyFromFill();
            sBitmap.Update();
            pictureBox1.Image = sBitmap._bitmap;
        }

        private void Rotate180_Click(object sender, EventArgs e)
        {
            _factory = null;
            _currentFigure._angle = -180 * Math.PI / 180;
            sBitmap.Clear();
            sBitmap.DrawExceptIndexFigures(_currentFigure);
            sBitmap.Copy();
            sBitmap.FillExceptIndexFigures(_currentFigure);
            sBitmap.CopyFromFill();
            pictureBox1.Image = sBitmap._tmpBitmap;
            sBitmap.Update();
            _currentFigure.Rotate();
            sBitmap.Copy();
            sBitmap.vDrawFigure(_currentFigure);
            sBitmap.Copy();
            sBitmap.FillFigure(_currentFigure);
            sBitmap.CopyFromFill();
            sBitmap.Update();
            pictureBox1.Image = sBitmap._bitmap;
        }
    }
}

