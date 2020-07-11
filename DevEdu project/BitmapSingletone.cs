using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

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
        public Bitmap Draw(List<Point> linePoints, Color color)
        {
            foreach (Point i in linePoints)
            {
                SetPixel(i.X, i.Y, color);
            }

            return _tmpBitmap;
        }

        public List<Point> ConnectTwoPoints(Point StartPoint, Point EndPoint)
        {
            //Создаем новый лист с точками координат
            List<Point> linePoints = new List<Point>();

            int dx = EndPoint.X - StartPoint.X;//абсолютное значение
            int dy = EndPoint.Y - StartPoint.Y;
            int steps;
            if (Math.Abs(dx) > Math.Abs(dy))
            {
                steps = Math.Abs(dx); //количество шагов
            }
            else
            {
                steps = Math.Abs(dy);
            }

            float Xinc = dx / (float)steps;//приращение для каждого шага 
            float Yinc = dy / (float)steps;

            float X = StartPoint.X;// кладем пиксель для каждого шага 
            float Y = StartPoint.Y;
            for (int i = 0; i <= steps; i++)
            {
                //Добавляем в лист каждую точку, полученную в ходе вычислений
                linePoints.Add(new Point((int)X, (int)Y));
                X += Xinc;
                Y += Yinc;
            }

            return linePoints;
        }        
    }
}
