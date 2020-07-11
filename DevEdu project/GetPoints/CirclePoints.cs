using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEdu_project.GetPoints
{
    public class CirclePoints : IGetPoints
    {
        public List<Point> GetPoints(Point startPoint, Point endPoint, double R, double optional)
        {
            List<Point> circle = new List<Point>();
            //double R = Math.Sqrt(Math.Pow((endPoint.X - startPoint.X), 2) + Math.Pow((endPoint.Y - startPoint.Y), 2));
            int X0 = startPoint.X;
            int Y0 = startPoint.Y;
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
