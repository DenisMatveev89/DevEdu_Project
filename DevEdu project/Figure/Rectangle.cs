using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using DevEdu_project.Figure;
using DevEdu_project.Factory;

namespace DevEdu_project
{
    public class Rectangle : AFigure // Прямоугольник
    {
        public Point _startPoint;
        public Point _endPoint;
        BitmapSingletone sBitmap = BitmapSingletone.GetInstance();
        public Rectangle() { }        

        public Rectangle(Point StartPoint, Point EndPoint) 
        {
            this._startPoint = StartPoint;
            this._endPoint = EndPoint;
        }

        public Rectangle(int x1, int y1, int x2, int y2)
        {
            this._startPoint.X = x1;
            this._startPoint.Y = y1;
            this._endPoint.X = x2;
            this._endPoint.Y = y2;
        }

        public override List<Point> GetPoints()
        {
            int X0 = _startPoint.X;
            int Y0 = _startPoint.Y;
            int X1 = _endPoint.X;
            int Y1 = _endPoint.Y;
            List<Point> listPoints = new List<Point>();
            listPoints.AddRange(sBitmap.ConnectTwoPoints(new Point(X0, Y0), new Point(X1, Y0)));
            listPoints.AddRange(sBitmap.ConnectTwoPoints(new Point(X1, Y0), new Point(X1, Y1)));
            listPoints.AddRange(sBitmap.ConnectTwoPoints(new Point(X1, Y1), new Point(X0, Y1)));
            listPoints.AddRange(sBitmap.ConnectTwoPoints(new Point(X0, Y1), new Point(X0, Y0)));
            return listPoints;
        }
    }
}
