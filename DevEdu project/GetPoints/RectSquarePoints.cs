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
        Point startPoint;
        Point endPoint;
        public void Update() { }
        public List<Point> GetPoints()
        {
            List<Point> listPoint = new List<Point>();
            int d = endPoint.X - startPoint.X;//длина одной стороны, все остальные равны ей
            int X0 = startPoint.X;
            int Y0 = startPoint.Y;
            int X1 = endPoint.X;
            listPoint.AddRange(sBitmap.ConnectTwoPoints(new Point(X0, Y0), new Point(X1, Y0)));
            listPoint.AddRange(sBitmap.ConnectTwoPoints(new Point(X0, Y0 + d), new Point(X1, Y0 + d)));
            listPoint.AddRange(sBitmap.ConnectTwoPoints(new Point(X0, Y0), new Point(X0, Y0 + d)));
            listPoint.AddRange(sBitmap.ConnectTwoPoints(new Point(X0 + d, Y0), new Point(X0 + d, Y0 + d)));
            return listPoint;
        }
    }
}
