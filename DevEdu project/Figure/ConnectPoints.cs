using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEdu_project.GetPoints
{
    [Serializable]
    public class ConnectPoints
    {
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
        //BitmapSingletone sBitmap = BitmapSingletone.GetInstance();
        List<Point> linePoints = new List<Point>();
        public List<Point> ConnectTwoPoints(Point startPoint, Point endPoint, int width, Color color)
        //public void ConnectTwoPoints(Point StartPoint, Point EndPoint, int width, Color color)
        {
            int dx = endPoint.X - startPoint.X;//абсолютное значение
            int dy = endPoint.Y - startPoint.Y;
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

            float X = startPoint.X;// кладем пиксель для каждого шага 
            float Y = startPoint.Y;
            for (int i = 0; i <= steps; i++)
            {
                for (int j=-width; j<=width; j++)
                {
                    double d = Math.Sqrt(width * width - j * j);
                    Point tmp = new Point((int)(j + X), (int)(width + Y));
                    linePoints.Add(new Point(tmp.X, tmp.Y));
                    //sBitmap.SetPixel(tmp.X, tmp.Y, color);
                    tmp = new Point((int)(j + X), (int)(-width + Y));
                    linePoints.Add(new Point(tmp.X, tmp.Y));
                    //sBitmap.SetPixel(tmp.X, tmp.Y, color);
                    tmp = new Point((int)(width + X), (int)(j + Y));
                    linePoints.Add(new Point(tmp.X, tmp.Y));
                    //sBitmap.SetPixel(tmp.X, tmp.Y, color);
                    tmp = new Point((int)(-width + X), (int)(width + Y));
                    linePoints.Add(new Point(tmp.X, tmp.Y));
                    //sBitmap.SetPixel(tmp.X, tmp.Y, color);
                    tmp = new Point((int)(j + X), (int)(j + Y));
                    linePoints.Add(new Point(tmp.X, tmp.Y));
                    //sBitmap.SetPixel(tmp.X, tmp.Y, color);
                    tmp = new Point((int)(j + X), (int)(-width + Y));
                    linePoints.Add(new Point(tmp.X, tmp.Y));
                    //sBitmap.SetPixel(tmp.X, tmp.Y, color);
                    tmp = new Point((int)(width + X), (int)(j + Y));
                    linePoints.Add(new Point(tmp.X, tmp.Y));
                    //sBitmap.SetPixel(tmp.X, tmp.Y, color);
                    tmp = new Point((int)(-width + X), (int)(j + Y));
                    linePoints.Add(new Point(tmp.X, tmp.Y));
                    //sBitmap.SetPixel(tmp.X, tmp.Y, color);
                }
                    //Добавляем в лист каждую точку, полученную в ходе вычислений
                    //linePoints.Add(new Point((int)X, (int)Y));
                    X += Xinc;
                    Y += Yinc;
            }

            return linePoints;
        }


    }
}
