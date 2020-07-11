using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEdu_project.Figure
{
    public class TriangleIsosceles : AFigure//Равнобедренный треугольник
    {
        public TriangleIsosceles()
        {
            fill = new Brush.TriangleIsoFill();
            getPoints = new TriangleIsoPoints();
        }
        /* public TriangleRight(int x1, int y1, int x2, int y2)
        {
            this.StartPoint.X = x1;
            this.StartPoint.Y = y1;
            this.EndPoint.X = x2;
            this.EndPoint.Y = y2;
        }*/
        /*  public override List<Point> GetPoints()
          {
              int x0 = StartPoint.X;
              int y0 = StartPoint.Y;
              int x1 = EndPoint.X;
              int y1 = EndPoint.Y;
              List<Point> listPoint = new List<Point>();

              listPoint.AddRange(sBitmap.ConnectTwoPoints(new Point(x0, y0), new Point(x1, y1)));
              listPoint.AddRange(sBitmap.ConnectTwoPoints(new Point(x1, y1), new Point((x0 - (x1 - x0)), y1)));
              listPoint.AddRange(sBitmap.ConnectTwoPoints(new Point((x0 - (x1 - x0)), y1), new Point(x0, y0)));
              return listPoint;

          }*/
    }
}
