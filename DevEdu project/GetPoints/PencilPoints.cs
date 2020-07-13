using System;
using System.Collections.Generic;
using System.Drawing;

namespace DevEdu_project.GetPoints
{
    public class PencilPoints : IGetPoints
    {
        List<Point> linePoints = new List<Point>();

        Point start = new Point(0, 0);
        Point end = new Point(0, 0);

        public List<Point> GetPoints(Point startPoint, Point endPoint)
        {
            //Этим условием мы правильно задаем начальную точку и все последующие точки карандаша
            if (start == new Point(0, 0))
            {
                start = startPoint;
                end = endPoint;
            }
            else
            {
                start = end;
                end = endPoint;
            }

            int dx = end.X - start.X;//абсолютное значение
            int dy = end.Y - start.Y;
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

            float X = start.X;// кладем пиксель для каждого шага 
            float Y = start.Y;
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
