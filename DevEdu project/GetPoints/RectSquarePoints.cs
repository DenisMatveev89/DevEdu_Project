using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEdu_project.GetPoints
{
    public class RectSquarePoints:IGetPoints
    {
        BitmapSingletone sBitmap = BitmapSingletone.GetInstance();
        //В эти конструкторы нужно передавать значения точек из MouseDown, MouswMove, MouseUp
        public Point StartPoint;
        public Point EndPoint;
        public RectSquarePoints() { }
        public RectSquarePoints(Point StartPoint, Point EndPoint)
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
            List<Point> listPoint = new List<Point>();
            int d = EndPoint.X - StartPoint.X;//длина одной стороны, все остальные равны ей
            int X0 = StartPoint.X;
            int Y0 = StartPoint.Y;
            int X1 = EndPoint.X;
            listPoint.AddRange(sBitmap.ConnectTwoPoints(new Point(X0, Y0), new Point(X1, Y0)));
            listPoint.AddRange(sBitmap.ConnectTwoPoints(new Point(X0, Y0 + d), new Point(X1, Y0 + d)));
            listPoint.AddRange(sBitmap.ConnectTwoPoints(new Point(X0, Y0), new Point(X0, Y0 + d)));
            listPoint.AddRange(sBitmap.ConnectTwoPoints(new Point(X0 + d, Y0), new Point(X0 + d, Y0 + d)));
            return listPoint;
        }
    }
}
