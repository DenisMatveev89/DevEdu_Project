using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEdu_project.Figure
{
    public class TriangleRight : AFigure//правильный треугольник
    {
        public Point _startPoint;
        public Point _endPoint;
        BitmapSingletone sBitmap = BitmapSingletone.GetInstance();

        public TriangleRight() { }
        public TriangleRight(Point startPoint, Point endPoint) 
        {
            this._startPoint = startPoint;
            this._endPoint = endPoint;
        }

        public TriangleRight(int x1, int y1, int x2, int y2)
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
            List<Point> listPoint = new List<Point>();

            listPoint.AddRange(sBitmap.ConnectTwoPoints(new Point(X0, Y0), new Point(X1, Y1)));
            listPoint.AddRange(sBitmap.ConnectTwoPoints(new Point(X1, Y1), new Point(X0, Y1)));
            listPoint.AddRange(sBitmap.ConnectTwoPoints(new Point(X0, Y1), new Point(X0, Y0)));
            return listPoint;
           
        }
    }
}
