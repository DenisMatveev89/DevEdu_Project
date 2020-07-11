using DevEdu_project.GetPoints;
using DocumentFormat.OpenXml.Drawing.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevEdu_project.Figure
{
    public class PencilPoints : IGetPoints //Перо
    {
        protected Point startPoint;
        protected Point endPoint;

        public PencilPoints(Point a, Point b)
        {
            this.startPoint = a;
            this.endPoint = b;
        }

        public void Update()
        {
            if (startPoint == new Point(0, 0))
            {
                startPoint = startPoint;
            }
            else
            {
                startPoint = endPoint;
            }

            endPoint = endPoint;
        }
        public void Update(Point Start, Point End)
        {
            if (startPoint == new Point(0, 0))
            {
                startPoint = Start;
            }
            else
            {
                startPoint = endPoint;
            }

            endPoint = End;
        }

        List<Point> points = new List<Point>();

        public List<Point> GetPoints()
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
                points.Add(new Point((int)X, (int)Y));
                X += Xinc;
                Y += Yinc;
            }
            //Update();
            return points;
        }
        
    }
}
