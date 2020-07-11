using System;
using System.Windows;
using System.Collections.Generic;
using System.Drawing;
using Point = System.Drawing.Point;
using DocumentFormat.OpenXml.Drawing.Wordprocessing;

namespace DevEdu_project.GetPoints
{
    public class RectanglePoints : IGetPoints
    {
        BitmapSingletone sBitmap = BitmapSingletone.GetInstance();
        Point startPoint;
        Point endPoint;
        public RectanglePoints(Point a, Point b)
        {
            this.startPoint = a;
            this.endPoint = b;
        }
        public void Update() { }
        public List<Point> GetPoints()
        {
            int X0 = startPoint.X;
            int Y0 = startPoint.Y;
            int X1 = endPoint.X;
            int Y1 = endPoint.Y;
            List<Point> listPoints = new List<Point>();
            listPoints.AddRange(sBitmap.ConnectTwoPoints(new Point(X0, Y0), new Point(X1, Y0)));
            listPoints.AddRange(sBitmap.ConnectTwoPoints(new Point(X1, Y0), new Point(X1, Y1)));
            listPoints.AddRange(sBitmap.ConnectTwoPoints(new Point(X1, Y1), new Point(X0, Y1)));
            listPoints.AddRange(sBitmap.ConnectTwoPoints(new Point(X0, Y1), new Point(X0, Y0)));
            return listPoints;
        }
    }
}
