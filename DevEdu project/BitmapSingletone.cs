using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using DevEdu_project.GetPoints;

namespace DevEdu_project
{
    public class BitmapSingletone
    {
        private BitmapSingletone() { }

        //Временный и Основной битмап, на котором должны осуществляться все методы рисования
        public Bitmap _tmpBitmap;
        public Bitmap _bitmap;
        public Bitmap _emptyBitmap;

        public void CreateBitmaps(int width, int height)
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
            if (x >= 0 && x < _bitmap.Width && y >= 0 && y < _bitmap.Height)
            {
                _tmpBitmap.SetPixel(x, y, color);
            }
        }

        //Метод, который заменяет TmpBitmap на Bitmap
        public void Copy()
        {
            if (_bitmap != null)
            {
                _tmpBitmap = (Bitmap)_bitmap.Clone();
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
            _tmpBitmap = (Bitmap)_emptyBitmap.Clone();    
            _bitmap = (Bitmap)_emptyBitmap.Clone();
        }

        //Метод, который принимает настроенную фигуру,
        //вызывает все ее точки и рисует каждую точку
        public Bitmap DrawFigure(AFigure figure)
        {
            List<Point> figurePoints = figure.GetPoints();

            foreach (Point i in figurePoints)
            {
                SetPixel(i.X, i.Y, figure._colorLine);
            }

            return _tmpBitmap;
        }

        //Метод, который рисует все фигуры из листа фигур
        public Bitmap DrawAllFigures(List<AFigure> figure)
        {
            foreach (AFigure i in figure)
            {
                DrawFigure(i);
            }
            
            return _tmpBitmap;
        }

        public Bitmap DrawIndexFigures(List<AFigure> figure, AFigure currentFigure)
        {
            foreach (AFigure i in figure)
            {
                if(i != currentFigure)
                {
                    DrawFigure(i);
                }                
            }
            return _tmpBitmap;
        }

        public Bitmap EraseIndexFigure(List<AFigure> figure, AFigure currentFigure)
        {
            for (int i = 0; i < figure.Count; i++) 
            {
                if (figure[i] != currentFigure)
                {
                    DrawFigure(figure[i]);
                }
                else
                {
                    figure.Remove(figure[i]);
                }
            }
            //for(int i = 0; i<figure.Count; i++)
            //{
            //    if(figure[i] == currentFigure)
            //    {
            //        figure.Remove(figure[i]);
            //    }
            //}
            return _tmpBitmap;
        }

        // Старый метод, который проходится по листу от первой до последней точки
        // и рисует каждую точку на TmpBitmap
        public Bitmap Draw(List<Point> points, Color color)
        {

            foreach (Point i in points)
            {
                SetPixel(i.X, i.Y, color);
            }

            return _tmpBitmap;
        }
    }
}
