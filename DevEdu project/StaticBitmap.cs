using System;
using System.Drawing;
using System.Collections.Generic;

namespace DevEdu_project
{
    public static class StaticBitmap
    {
        //Основной битмап, на котором должны отображаться все нарисованные элементы
        public static Bitmap Bitmap { get; set; }

        //Временный битмап, на котором должны осуществляться все методы рисования
        public static Bitmap TmpBitmap { get; set; }            

        //Наш собственный метод SetPixel, благодаря которому не возникает ошибки при выходе за границы холста
        //Обратите внимание, он рисует на TmpBitmap
        public static void SetPixel(int x, int y, Color color)
        {
            if (x >= 0 && x < Bitmap.Width && y >= 0 && y < Bitmap.Height)
            {
                TmpBitmap.SetPixel(x, y, color);
            }
        }   

        //Метод, который заменяет TmpBitmap на Bitmap
        public static void Copy()
        {            
            if (Bitmap != null)
            {
                TmpBitmap = (Bitmap)Bitmap.Clone();
            }
        }

        //Метод, который заменяет Bitmap на TmpBitmap
        public static void Update()
        {           
            if (TmpBitmap != null)
            {
                Bitmap = (Bitmap)TmpBitmap.Clone();
            }
        }

        // Метод, который проходится по листу от первой до последней точки
        // и рисует каждую точку на TmpBitmap
        public static Bitmap Draw(List<Point> linePoints, Color color)
        {
            foreach (Point i in linePoints)
            {
                SetPixel(i.X, i.Y, color);
            }

            return TmpBitmap;
        }

        public static List<Point> ConnectTwoPoints(Point StartPoint, Point EndPoint)
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
