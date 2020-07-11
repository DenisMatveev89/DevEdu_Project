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
        BitmapSingletone sBitmap = BitmapSingletone.GetInstance();
        public TriangleIsosceles() { }
        
        public new List<Point> GetPoints()
        {
            int x0 = _startPoint.X;
            int y0 = _startPoint.Y;
            int x1 = _endPoint.X;
            int y1 = _endPoint.Y;
            List<Point> listPoint = new List<Point>();

            listPoint.AddRange(sBitmap.ConnectTwoPoints(new Point(x0, y0), new Point(x1, y1)));
            listPoint.AddRange(sBitmap.ConnectTwoPoints(new Point(x1, y1), new Point((x0 - (x1 - x0)), y1)));
            listPoint.AddRange(sBitmap.ConnectTwoPoints(new Point((x0 - (x1 - x0)), y1), new Point(x0, y0)));
            return listPoint;
            
        }
    }
}
