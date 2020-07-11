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

        public void CreateBitmaps(int width, int height)
        {
            _bitmap = new Bitmap(width, height);
            _tmpBitmap = new Bitmap(width, height);
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

        // Метод, который проходится по листу от первой до последней точки
        // и рисует каждую точку на TmpBitmap
        public Bitmap Draw(List<Point> points, Color color)
        {

            foreach (Point i in points)
            {
                SetPixel(i.X, i.Y, color);
            }

            return _tmpBitmap;
        }

        //Метод, который рисует все фигуры из листа фигур
        public Bitmap DrawAllFigures(List<AFigure> figure)
        {
            foreach (AFigure i in figure)
            {
                List<Point> figurePoints = i.GetPoints();
                foreach (Point j in figurePoints)
                {
                    SetPixel(j.X, j.Y, i._colorLine);
                }
            }
            return _tmpBitmap;
        }
    }
}
