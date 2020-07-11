using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEdu_project.Figure
{
    public class TriangleRight : AFigure//правильный треугольник
<<<<<<< HEAD
    {
        public TriangleRight()
        {
            fill = new Brush.TriangleRightFill();
            getPoints = new TriangleRightPoints();
        }
=======
    {
        BitmapSingletone sBitmap = BitmapSingletone.GetInstance();

        public TriangleRight() { }        
>>>>>>> Factory

       /* public TriangleRight(int x1, int y1, int x2, int y2)
        {
<<<<<<< HEAD
            this.StartPoint.X = x1;
            this.StartPoint.Y = y1;
            this.EndPoint.X = x2;
            this.EndPoint.Y = y2;
        }*/
     /*   public override List<Point> GetPoints()
=======
            this._startPoint.X = x1;
            this._startPoint.Y = y1;
            this._endPoint.X = x2;
            this._endPoint.Y = y2;
        }
        
        public new List<Point> GetPoints()
>>>>>>> Factory
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
           
        }*/
    }
}
