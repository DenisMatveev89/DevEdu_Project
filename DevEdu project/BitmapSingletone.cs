using System.Drawing;
using System.Collections.Generic;
using DevEdu_project.GetPoints;
using System;

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
            _figureList = Storage.GetInstance()._figureList;
        }
        public void UpdateBitmap(int width, int height)
        {
            _bitmap = new Bitmap(width, height);
            _tmpBitmap = new Bitmap(width, height);
            _emptyBitmap = new Bitmap(width, height);
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
                _fillBitmap = (Bitmap)_tmpBitmap.Clone();
                _tmpBitmap = (Bitmap)_bitmap.Clone();
                //_fillBitmap = (Bitmap)_tmpBitmap.Clone();
            }
        }

        public void CopyTmpToFill()
        {
            _fillBitmap = (Bitmap)_tmpBitmap.Clone();
        }

        public void CopyFromFill()
        {
            if (_bitmap != null)
            {
                _tmpBitmap = (Bitmap)_fillBitmap.Clone();
                _bitmap = (Bitmap)_fillBitmap.Clone();
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
            _tmpBitmap = (Bitmap)_emptyBitmap.Clone();
            _bitmap = (Bitmap)_emptyBitmap.Clone();
        }

        public AFigure FigureUnderMouse(Point mouse)
        {
            AFigure figure = null;
            foreach (AFigure i in _figureList)
            {
                if (i.IsMouseOnFigure(mouse))
                {
                    figure = i;

                    if (figure != null)
                    {
                        return figure;
                    }
                }
            }
            return figure;
        }

        //Метод, который принимает настроенную фигуру,
        //вызывает все ее точки и рисует каждую точку
        public Bitmap DrawFigure(AFigure figure)
        {
            if(figure._linewWidth == 0)
            {
                foreach (Point i in figure.GetPoints())
                {
                    SetPixel(i.X, i.Y, figure._colorLine);
                }
            }
            else
            {
                figure.WidthLine();
            }
            return _tmpBitmap;
        }

        public void vDrawFigure(AFigure figure)
        {
            if (figure._linewWidth == 0)
            {
                foreach (Point i in figure.GetPoints())
                {
                    SetPixel(i.X, i.Y, figure._colorLine);
                }
            }
            else
            {
                figure.WidthLine();
            }
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
            //_fillBitmap = (Bitmap)_tmpBitmap.Clone();
            foreach (AFigure i in _figureList)
            {
                i.FillFigure(i._centerPoint);
            }
        }

        public void DrawExceptIndexFigures(AFigure currentFigure)
        {
            foreach (AFigure i in _figureList)
            {
                if (i != currentFigure)
                {
                    DrawFigure(i);
                }
            }
        }

        public void FillFigure(AFigure figure)
        {
            figure.FillFigure(figure._centerPoint);
        }

        public void FillExceptIndexFigures(AFigure currentFigure)
        {
            //_fillBitmap = (Bitmap)_tmpBitmap.Clone();

            foreach (AFigure i in _figureList)
            {
                if (i != currentFigure)
                {
                    i.FillFigure(i._centerPoint);
                    CopyFromFill();
                }
            }
        }

        public void EraseIndexFigure(AFigure currentFigure)
        {
            _figureList.Remove(currentFigure);
            DrawAllFigures();
        }

        // Старый метод, который проходится по листу от первой до последней точки
        // и рисует каждую точку на TmpBitmap
        public void Draw(List<Point> points, Color color)
        {
            foreach (Point i in points)
            {
                SetPixelOnFill(i.X, i.Y, color);
            }
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
