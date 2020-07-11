using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using DevEdu_project.Figure;
using DevEdu_project.GetPoints;

namespace DevEdu_project
{
    public class Rectangle : AFigure // Прямоугольник
    {
        public Rectangle(Point a, Point b)
        {
            fill = new Brush.RectangleFill();
            getPoints = new RectanglePoints(a, b);
        }

        /*public override List<Point> GetPoints()
        {
            int X0 = StartPoint.X;
            int Y0 = StartPoint.Y;
            int X1 = EndPoint.X;
            int Y1 = EndPoint.Y;
            List<Point> listPoints = new List<Point>();
            listPoints.AddRange(sBitmap.ConnectTwoPoints(new Point(X0, Y0), new Point(X1, Y0)));
            listPoints.AddRange(sBitmap.ConnectTwoPoints(new Point(X1, Y0), new Point(X1, Y1)));
            listPoints.AddRange(sBitmap.ConnectTwoPoints(new Point(X1, Y1), new Point(X0, Y1)));
            listPoints.AddRange(sBitmap.ConnectTwoPoints(new Point(X0, Y1), new Point(X0, Y0)));
            return listPoints;
        }*/
    }
}
