using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEdu_project.GetPoints
{
    public class TriangleEqPoints : IGetPoints
    {
        ConnectPoints cp = new ConnectPoints();
        public List<Point> GetPoints(Point startPoint, Point endPoint, double o, double o2)
        {
            int x0 = startPoint.X;
            int y0 = startPoint.Y;
            int x1 = endPoint.X;
            int y1 = endPoint.Y;
            double angleRadian = 60 * Math.PI / 180;
            //Находим вторую пару координат линии, которую мы разворачиваем на 60 градусов.
            int x2 = (int)((x0 - x1) * Math.Cos(angleRadian) - (y0 - y1) * Math.Sin(angleRadian) + x1);
            int y2 = (int)((x0 - x1) * Math.Sin(angleRadian) + (y0 - y1) * Math.Cos(angleRadian) + y1);

            List<Point> listPoint = new List<Point>();

            listPoint.AddRange(cp.ConnectTwoPoints(new Point(x0, y0), new Point(x1, y1)));
            listPoint.AddRange(cp.ConnectTwoPoints(new Point(x1, y1), new Point(x2, y2)));
            listPoint.AddRange(cp.ConnectTwoPoints(new Point(x2, y2), new Point(x0, y0)));
            return listPoint;
        }
    }
}
