using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEdu_project
{
    public class Circle : IFigure
    {
        public Point StartPoint;
        public Point EndPoint;
        double R;

        public void Update(Point Start, Point End)
        {
            StartPoint = Start;
            EndPoint = End;
            R = Math.Sqrt(Math.Pow((EndPoint.X - StartPoint.X), 2) + Math.Pow((EndPoint.Y - StartPoint.Y), 2));
        }
        public void Update() { }

        public List<Point> GetPoints()
        {
            List<Point> circle = new List<Point>();
            int X0 = StartPoint.X;
            int Y0 = StartPoint.Y;
            int x = 0;
            int y = (int)R;
            int delta = 1 - 2 * (int)R;
            int error;
            while (y >= 0)
            {
                circle.Add(new Point(X0 + x, Y0 + y));
                circle.Add(new Point(X0 + x, Y0 - y));
                circle.Add(new Point(X0 - x, Y0 + y));
                circle.Add(new Point(X0 - x, Y0 - y));

                error = 2 * (delta + y) - 1;
                if ((delta < 0) && (error <= 0))
                {
                    delta += 2 * ++x + 1;
                    continue;
                }
                if ((delta > 0) && (error > 0))
                {
                    delta -= 2 * --y + 1;
                    continue;
                }
                delta += 2 * (++x - --y);
            }
            return circle;
        }

    }
}
