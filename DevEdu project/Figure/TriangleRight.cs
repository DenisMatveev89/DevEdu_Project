using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEdu_project.Figure
{
    public class TriangleRight : IFigure
    {
        public Point StartPoint;
        public Point EndPoint;

        public TriangleRight() { }
        public TriangleRight(Point StartPoint, Point EndPoint) 
        {
            this.StartPoint = StartPoint;
            this.EndPoint = EndPoint;
        }
        public void Update(Point Start, Point End)
        {
            StartPoint = Start;
            EndPoint = End;
        }
        public List<Point> GetPoints()
        {
            int X0 = StartPoint.X;
            int Y0 = StartPoint.Y;
            int X1 = EndPoint.X;
            int Y1 = EndPoint.Y;
            List<Point> listPoint = new List<Point>();

            listPoint.AddRange(StaticBitmap.ConnectTwoPoints(new Point(X0, Y0), new Point(X1, Y1)));
            listPoint.AddRange(StaticBitmap.ConnectTwoPoints(new Point(X1, Y1), new Point(X0, Y1)));
            listPoint.AddRange(StaticBitmap.ConnectTwoPoints(new Point(X0, Y1), new Point(X0, Y0)));
            return listPoint;
           
        }
    }
}
