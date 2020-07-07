using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using DevEdu_project.Figure;

namespace DevEdu_project
{
    public class Rectangle : IFigure // Прямоугольник
    {
        public Point StartPoint;
        public Point EndPoint;
        public Rectangle() { }
        public Rectangle(Point StartPoint, Point EndPoint) 
        {
            this.StartPoint = StartPoint;
            this.EndPoint = EndPoint;
        }
        public void Update(Point Start, Point End)
        {
            StartPoint = Start;
            EndPoint = End;

        }
        public void Update(){}

        public List<Point> GetPoints()
        {
            int X0 = StartPoint.X;
            int Y0 = StartPoint.Y;
            int X1 = EndPoint.X;
            int Y1 = EndPoint.Y;
            List<Point> listPoints = new List<Point>();
            listPoints.AddRange(StaticBitmap.ConnectTwoPoints(new Point(X0, Y0), new Point(X1, Y0)));
            listPoints.AddRange(StaticBitmap.ConnectTwoPoints(new Point(X1, Y0), new Point(X1, Y1)));
            listPoints.AddRange(StaticBitmap.ConnectTwoPoints(new Point(X1, Y1), new Point(X0, Y1)));
            listPoints.AddRange(StaticBitmap.ConnectTwoPoints(new Point(X0, Y1), new Point(X0, Y0)));
            return listPoints;
        }
    }
}
