using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEdu_project.GetPoints
{
    public class PencilPoints : IGetPoints
    {
        List<Point> linePoints = new List<Point>();
        public List<Point> GetPoints(Point startPoint, Point endPoint)
        {
            int dx = endPoint.X - startPoint.X;
            int dy = endPoint.Y - startPoint.Y;
            int steps;
            if (Math.Abs(dx) > Math.Abs(dy))
            {
                steps = Math.Abs(dx);
            }
            else
            {
                steps = Math.Abs(dy);
            }

            float Xinc = dx / (float)steps;
            float Yinc = dy / (float)steps;

            float X;
            float Y;
            if (startPoint == new Point(0, 0))
            {
                X = endPoint.X;
                Y = endPoint.Y;
            }
            else
            {
                X = startPoint.X;
                Y = startPoint.Y;
            }
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
