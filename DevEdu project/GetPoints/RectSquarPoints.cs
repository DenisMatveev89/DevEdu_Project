using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEdu_project.GetPoints
{
    public class RectSquarePoints : IGetPoints
    {
        ConnectPoints cp = new ConnectPoints();
        public List<Point> GetPoints(Point startPoint, Point endPoint)
        {
            Point oneP = startPoint;
            Point twoP = startPoint;
            Point threP = startPoint;
            Point fourP = startPoint;
            int d;
            List<Point> listPoint = new List<Point>();
            if (startPoint.X<endPoint.X && startPoint.Y < endPoint.Y)
            {
                d = endPoint.Y - startPoint.Y;
                twoP.X = startPoint.X + d;
                twoP.Y = startPoint.Y;

                threP.X = twoP.X;
                threP.Y = threP.Y + d;

                fourP.X = threP.X - d;
                fourP.Y = threP.Y;
            }
            if (startPoint.X > endPoint.X && startPoint.Y > endPoint.Y)
            {
                d = startPoint.X - endPoint.X;
                twoP.X = startPoint.X - d;
                twoP.Y = startPoint.Y;

                threP.X = twoP.X;
                threP.Y = threP.Y - d;

                fourP.X = threP.X + d;
                fourP.Y = threP.Y;
            }
            if (startPoint.X > endPoint.X && startPoint.Y < endPoint.Y)
            {
                d = startPoint.X - endPoint.X;
                twoP.X = startPoint.X;
                twoP.Y = startPoint.Y+d;

                threP.X = twoP.X-d;
                threP.Y = twoP.Y;

                fourP.X = threP.X;
                fourP.Y = threP.Y-d;
            }
            if (startPoint.X < endPoint.X && startPoint.Y > endPoint.Y)
            {
                d = endPoint.X - startPoint.X;
                twoP.X = startPoint.X + d;
                twoP.Y = startPoint.Y;

                threP.X = twoP.X;
                threP.Y = threP.Y - d;

                fourP.X = threP.X - d;
                fourP.Y = threP.Y;
            }
            listPoint.AddRange(cp.ConnectTwoPoints(new Point(startPoint.X, startPoint.Y), new Point(twoP.X, twoP.Y)));
            listPoint.AddRange(cp.ConnectTwoPoints(new Point(twoP.X, twoP.Y), new Point(threP.X, threP.Y)));
            listPoint.AddRange(cp.ConnectTwoPoints(new Point (threP.X, threP.Y), new Point(fourP.X, fourP.Y)));
            listPoint.AddRange(cp.ConnectTwoPoints(new Point (fourP.X, fourP.Y), new Point(startPoint.X, startPoint.Y)));
            return listPoint;
        }
    }
}
