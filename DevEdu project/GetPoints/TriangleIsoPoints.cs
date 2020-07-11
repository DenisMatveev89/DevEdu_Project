using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEdu_project.GetPoints
{
    public class TriangleIsoPoints : IGetPoints
    {

        ConnectPoints cp = new ConnectPoints();
        public List<Point> GetPoints(Point startPoint, Point endPoint)
        {
            int x0 = startPoint.X;
            int y0 = startPoint.Y;
            int x1 = endPoint.X;
            int y1 = endPoint.Y;

            List<Point> listPoint = new List<Point>();
            listPoint.AddRange(cp.ConnectTwoPoints(new Point(x0, y0), new Point(x1, y1)));
            listPoint.AddRange(cp.ConnectTwoPoints(new Point(x1, y1), new Point((x0 - (x1 - x0)), y1)));
            listPoint.AddRange(cp.ConnectTwoPoints(new Point((x0 - (x1 - x0)), y1), new Point(x0, y0)));
            return listPoint;
        }
    }
}
