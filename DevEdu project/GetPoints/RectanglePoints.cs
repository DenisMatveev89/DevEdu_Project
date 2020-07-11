using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEdu_project.GetPoints
{
    public class RectanglePoints : IGetPoints
    {        
        ConnectPoints cp = new ConnectPoints();         
        public List<Point> GetPoints(Point startPoint, Point endPoint, double o, double o2)
        {
            int X0 = startPoint.X;
            int Y0 = startPoint.Y;
            int X1 = endPoint.X;
            int Y1 = endPoint.Y;
            List<Point> listPoints = new List<Point>();
            listPoints.AddRange(cp.ConnectTwoPoints(new Point(X0, Y0), new Point(X1, Y0)));
            listPoints.AddRange(cp.ConnectTwoPoints(new Point(X1, Y0), new Point(X1, Y1)));
            listPoints.AddRange(cp.ConnectTwoPoints(new Point(X1, Y1), new Point(X0, Y1)));
            listPoints.AddRange(cp.ConnectTwoPoints(new Point(X0, Y1), new Point(X0, Y0)));
            return listPoints;
        }
        //public RectanglePoints(int x1, int y1, int x2, int y2)
        //{
        //    this.startPoint.X = x1;
        //    this.StartPoint.Y = y1;
        //    this.EndPoint.X = x2;
        //    this.EndPoint.Y = y2;
        //}
    }
}
