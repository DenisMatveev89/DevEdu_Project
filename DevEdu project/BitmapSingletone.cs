using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using DevEdu_project.GetPoints;

namespace DevEdu_project
{
    [Serializable]
    public class BitmapSingletone
    {
        private BitmapSingletone() { }

        public List<AFigure> _figureList;

        public List<AFigure> SaveFigures(AFigure figure)
        {
            _figureList.Add(figure);
            return _figureList;
        }

        public AFigure FigureUnderMouse(Point mouse)
        {
            AFigure figure = null;
            foreach (AFigure i in _figureList)
            {
                if (i.IsMouseOnFigure(mouse))
                {
                    figure = i;

                    if(figure != null)
                    {
                        return figure;
                    }
                }
            }
            return figure;
        }

        //Временный и Основной битмап, на котором должны осуществляться все методы рисования
        public Bitmap _tmpBitmap;
        public Bitmap _bitmap;
        public Bitmap _fillBitmap;
        public Bitmap _emptyBitmap;
        ConnectPoints cp = new ConnectPoints();
        public List<Point> borderPoint;
        
        
            Point startXY;
            Point endXY;

        public void CreateBitmaps(int width, int height)
        {
            startXY.X = 0;
            startXY.Y = 0;
            endXY.X = width;
            endXY.Y = height;

            _bitmap = new Bitmap(width, height);
            _tmpBitmap = new Bitmap(width, height);
            _emptyBitmap = new Bitmap(width, height);
            _fillBitmap = new Bitmap(width, height);
            _figureList = new List<AFigure>();
            borderPoint = new List<Point>();
            borderPoint.AddRange(cp.ConnectTwoPoints(startXY, endXY));
            DrawBorder(borderPoint);
        }
        private static BitmapSingletone _instance;

        public static BitmapSingletone GetInstance()
        {
            if (_instance == null)
            {
                _instance = new BitmapSingletone();
            }
            return _instance;
        }
        //Определяем цвет пикселя на который нажили в MouseClick
        public Color ColorSelectPoint(int mouseX,int mouseY)
        {
            Color pixelColor = _bitmap.GetPixel(mouseX, mouseY);
            return pixelColor;
        }
        //Наш собственный метод SetPixel, благодаря которому не возникает ошибки при выходе за границы холста
        //Обратите внимание, он рисует на TmpBitmap
        public void SetPixel(int x, int y, Color color)
        {
            if (x >= 0 && x < _tmpBitmap.Width && y >= 0 && y < _tmpBitmap.Height)
            {
                _tmpBitmap.SetPixel(x, y, color);
            }
        }

        public void SetPixelOnFill(int x, int y, Color color)
        {            
            if (x >= 0 && x < _fillBitmap.Width && y >= 0 && y < _fillBitmap.Height)
            {
                _fillBitmap.SetPixel(x, y, color);
            }
        }

        //Метод, который заменяет TmpBitmap на Bitmap
        public void Copy()
        {
            if (_bitmap != null)
            {             
                _tmpBitmap = (Bitmap)_bitmap.Clone();
                _fillBitmap = (Bitmap)_tmpBitmap.Clone();
            }
        }

        public void CopyFromFill()
        {
            if (_bitmap != null)
            {
                _tmpBitmap = (Bitmap)_fillBitmap.Clone();
            }
        }

        //Метод, который заменяет Bitmap на TmpBitmap
        public void Update()
        {
            if (_tmpBitmap != null)
            {
                _bitmap = (Bitmap)_tmpBitmap.Clone();
            }
        }

        public void Clear()
        {
            _fillBitmap = (Bitmap)_tmpBitmap.Clone();
            //_fillBitmap = (Bitmap)_emptyBitmap.Clone();
            _tmpBitmap = (Bitmap)_emptyBitmap.Clone();   
            _bitmap = (Bitmap)_emptyBitmap.Clone();
        }

        //Метод, который принимает настроенную фигуру,
        //вызывает все ее точки и рисует каждую точку
        public Bitmap DrawFigure(AFigure figure)
        {
            foreach (Point i in figure.GetPoints())
            {
                SetPixel(i.X, i.Y, figure._colorLine);                
            }
            return _tmpBitmap;
        }

        //Метод, который рисует все фигуры из листа фигур        
        public void DrawAllFigures()
        {
            foreach (AFigure i in _figureList)
            {
                DrawFigure(i);
            }            
        }

        public void FillAllFigures()
        {
            foreach (AFigure i in _figureList)
            {
                i.FillFigure(i._centerPoint);
            }
        }

        public Bitmap DrawExceptIndexFigures(AFigure currentFigure)
        {            
            foreach (AFigure i in _figureList)
            {
                if(i != currentFigure)
                {
                    DrawFigure(i);
                }                
            }
            return _tmpBitmap;
        }

        public Bitmap FillExceptIndexFigures(AFigure currentFigure)
        {
            foreach (AFigure i in _figureList)
            {
                if (i != currentFigure)
                {
                    i.FillFigure(i._centerPoint);
                    CopyFromFill();
                }
            }
            return _fillBitmap;
        }

        public Bitmap EraseIndexFigure(AFigure currentFigure)
        {
            _figureList.Remove(currentFigure);
            DrawAllFigures();
            return _tmpBitmap;
        }

        // Старый метод, который проходится по листу от первой до последней точки
        // и рисует каждую точку на TmpBitmap
        public Bitmap Draw(List<Point> points, Color color)
        {

            foreach (Point i in points)
            {
                SetPixelOnFill(i.X, i.Y, color);
            }
            return _fillBitmap;
        }
        public Bitmap DrawBorder(List<Point> points)
        {
            Color color = Color.Black;
            foreach (Point i in points)
            {
                SetPixelOnFill(i.X, i.Y, color);
            }
            return _fillBitmap;
        }

    }
}
