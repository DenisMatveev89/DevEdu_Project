using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEdu_project.GetPoints
{
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
    }
}
