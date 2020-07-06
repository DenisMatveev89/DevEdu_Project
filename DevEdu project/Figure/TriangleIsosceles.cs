using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEdu_project.Figure
{
    public class TriangleIsosceles :IFigure
    {
        public Point StartPoint;
        public Point EndPoint;

        public TriangleIsosceles() { }
        public TriangleIsosceles(Point StartPoint, Point EndPoint)
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
            int x0 = StartPoint.X;
            int y0 = StartPoint.Y;
            int x1 = EndPoint.X;
            int y1 = EndPoint.Y;
            List<Point> listPoint = new List<Point>();

            listPoint.AddRange(StaticBitmap.ConnectTwoPoints(new Point(x0, y0), new Point(x1, y1)));
            listPoint.AddRange(StaticBitmap.ConnectTwoPoints(new Point(x1, y1), new Point((x0 - (x1 - x0)), y1)));
            listPoint.AddRange(StaticBitmap.ConnectTwoPoints(new Point((x0 - (x1 - x0)), y1), new Point(x0, y0)));
            return listPoint;
            
        }
    }
}
