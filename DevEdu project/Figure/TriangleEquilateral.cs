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
        public Point StartPoint;
        public Point EndPoint;
       // BitmapSingletone sBitmap = BitmapSingletone.GetInstance();
        public TriangleEquilateral()
        {
            fill = new Brush.TriangleEqFill();
            getPoints = new TriangleEqPoints();
        }
        public TriangleEquilateral(Point StartPoint, Point EndPoint)
        {
            this.StartPoint = StartPoint;
            this.EndPoint = EndPoint;
            fill = new Brush.TriangleEqFill();
            getPoints = new TriangleEqPoints();
        }
        /* public TriangleRight(int x1, int y1, int x2, int y2)
        {
            this.StartPoint.X = x1;
            this.StartPoint.Y = y1;
            this.EndPoint.X = x2;
            this.EndPoint.Y = y2;
        }*/

        /* public override List<Point> GetPoints()
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

             listPoint.AddRange(sBitmap.ConnectTwoPoints(new Point(x0, y0), new Point(x1, y1)));
             listPoint.AddRange(sBitmap.ConnectTwoPoints(new Point(x1, y1), new Point(x2, y2)));
             listPoint.AddRange(sBitmap.ConnectTwoPoints(new Point(x2, y2), new Point(x0, y0)));
             return listPoint;         
         }*/
    }
}
