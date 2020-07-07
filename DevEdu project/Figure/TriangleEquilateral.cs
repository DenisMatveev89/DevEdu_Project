using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEdu_project.Figure
{
    public class TriangleEquilateral : IFigure//Треугольник Равносторонний
    {
        public Point StartPoint;
        public Point EndPoint;
        public TriangleEquilateral() { }
        public TriangleEquilateral(Point StartPoint, Point EndPoint)
        {
            this.StartPoint = StartPoint;
            this.EndPoint = EndPoint;
        }
        public void Update(Point Start, Point End)
        {
            StartPoint = Start;
            EndPoint = End;
        }
        public void Update() { }

        public List<Point> GetPoints()
        {
            int x0 = StartPoint.X;
            int y0 = StartPoint.Y;
            int x1 = EndPoint.X;
            int y1 = EndPoint.Y;
            double angleRadian = 60 * Math.PI / 180;
            //Находим вторую пару координат линии, которую мы разворачиваем на 60 градусов.
            int x2 = (int)((x0 - x1) * Math.Cos(angleRadian) - (y0 - y1) * Math.Sin(angleRadian) + x1);
            int y2 = (int)((x0 - x1) * Math.Sin(angleRadian) + (y0 - y1) * Math.Cos(angleRadian) + y1);
           
            List<Point> listPoint = new List<Point>();

            listPoint.AddRange(StaticBitmap.ConnectTwoPoints(new Point(x0, y0), new Point(x1, y1)));
            listPoint.AddRange(StaticBitmap.ConnectTwoPoints(new Point(x1, y1), new Point(x2, y2)));
            listPoint.AddRange(StaticBitmap.ConnectTwoPoints(new Point(x2, y2), new Point(x0, y0)));
            return listPoint;         
        }
    }
}
