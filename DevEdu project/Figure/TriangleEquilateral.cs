using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEdu_project.Figure
{
    public class TriangleEquilateral : AFigure//Треугольник Равносторонний
    {
        public Point _startPoint;
        public Point _endPoint;
        BitmapSingletone sBitmap = BitmapSingletone.GetInstance();
        public TriangleEquilateral() { }
        public TriangleEquilateral(Point StartPoint, Point EndPoint)
        {
            this._startPoint = StartPoint;
            this._endPoint = EndPoint;
        }        

        public override List<Point> GetPoints()
        {
            int x0 = _startPoint.X;
            int y0 = _startPoint.Y;
            int x1 = _endPoint.X;
            int y1 = _endPoint.Y;
            double angleRadian = 60 * Math.PI / 180;
            //Находим вторую пару координат линии, которую мы разворачиваем на 60 градусов.
            int x2 = (int)((x0 - x1) * Math.Cos(angleRadian) - (y0 - y1) * Math.Sin(angleRadian) + x1);
            int y2 = (int)((x0 - x1) * Math.Sin(angleRadian) + (y0 - y1) * Math.Cos(angleRadian) + y1);
           
            List<Point> listPoint = new List<Point>();

            listPoint.AddRange(sBitmap.ConnectTwoPoints(new Point(x0, y0), new Point(x1, y1)));
            listPoint.AddRange(sBitmap.ConnectTwoPoints(new Point(x1, y1), new Point(x2, y2)));
            listPoint.AddRange(sBitmap.ConnectTwoPoints(new Point(x2, y2), new Point(x0, y0)));
            return listPoint;         
        }
    }
}
