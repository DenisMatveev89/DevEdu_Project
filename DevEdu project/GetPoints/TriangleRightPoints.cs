using DevEdu_project.GetPoints;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEdu_project.Figure
{
    public class TriangleRightPoints : IGetPoints//правильный треугольник
    {
        Point startPoint;
        Point endPoint;
        BitmapSingletone sBitmap = BitmapSingletone.GetInstance();
        /*        public TriangleRightPoints(int x1, int y1, int x2, int y2)
                {
                    this.StartPoint.X = x1;
                    this.StartPoint.Y = y1;
                    this.EndPoint.X = x2;
                    this.EndPoint.Y = y2;
                }*/
        public void Update() { }
        public List<Point> GetPoints()
        {
            int X0 = startPoint.X;
            int Y0 = startPoint.Y;
            int X1 = endPoint.X;
            int Y1 = endPoint.Y;
            List<Point> listPoint = new List<Point>();

            listPoint.AddRange(sBitmap.ConnectTwoPoints(new Point(X0, Y0), new Point(X1, Y1)));
            listPoint.AddRange(sBitmap.ConnectTwoPoints(new Point(X1, Y1), new Point(X0, Y1)));
            listPoint.AddRange(sBitmap.ConnectTwoPoints(new Point(X0, Y1), new Point(X0, Y0)));
            return listPoint;
           
        }
    }
}
