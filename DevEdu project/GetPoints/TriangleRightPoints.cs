using DevEdu_project.GetPoints;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEdu_project.Figure
{
    public class TriangleRightPoints : IGetPoints//правильный треугольник
    {
        public Point StartPoint;
        public Point EndPoint;
        BitmapSingletone sBitmap = BitmapSingletone.GetInstance();

        public TriangleRightPoints() { }
        public TriangleRightPoints(Point StartPoint, Point EndPoint) 
        {
            this.StartPoint = StartPoint;
            this.EndPoint = EndPoint;
        }

        public TriangleRightPoints(int x1, int y1, int x2, int y2)
        {
            this.StartPoint.X = x1;
            this.StartPoint.Y = y1;
            this.EndPoint.X = x2;
            this.EndPoint.Y = y2;
        }
        public List<Point> GetPoints()
        {
            int X0 = StartPoint.X;
            int Y0 = StartPoint.Y;
            int X1 = EndPoint.X;
            int Y1 = EndPoint.Y;
            List<Point> listPoint = new List<Point>();

            listPoint.AddRange(sBitmap.ConnectTwoPoints(new Point(X0, Y0), new Point(X1, Y1)));
            listPoint.AddRange(sBitmap.ConnectTwoPoints(new Point(X1, Y1), new Point(X0, Y1)));
            listPoint.AddRange(sBitmap.ConnectTwoPoints(new Point(X0, Y1), new Point(X0, Y0)));
            return listPoint;
           
        }
    }
}
