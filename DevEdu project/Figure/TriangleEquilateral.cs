using DevEdu_project.GetPoints;
using DocumentFormat.OpenXml.Drawing.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEdu_project.Figure
{
    [Serializable]
    public class TriangleEquilateral : AFigure//Треугольник Равносторонний
    {
        public TriangleEquilateral()
        {
            //fill = new Brush.TriangleEqFill();
        }
        public override List<Point> GetPoints()
        {
            ConnectPoints cp = new ConnectPoints();

            int x0 = _startPoint.X;
            int y0 = _startPoint.Y;
            int x1 = _endPoint.X;
            int y1 = _endPoint.Y;
            double angleRadian = 60 * Math.PI / 180;
            //Находим вторую пару координат линии, которую мы разворачиваем на 60 градусов.
            int x2 = (int)((x0 - x1) * Math.Cos(angleRadian) - (y0 - y1) * Math.Sin(angleRadian) + x1);
            int y2 = (int)((x0 - x1) * Math.Sin(angleRadian) + (y0 - y1) * Math.Cos(angleRadian) + y1);

            List<Point> listPoint = new List<Point>();

            listPoint.AddRange(cp.ConnectTwoPoints(new Point(x0, y0), new Point(x1, y1)));
            listPoint.AddRange(cp.ConnectTwoPoints(new Point(x1, y1), new Point(x2, y2)));
            listPoint.AddRange(cp.ConnectTwoPoints(new Point(x2, y2), new Point(x0, y0)));

            double lengthSize1 = Math.Sqrt(Math.Pow((x1 - x0), 2) + Math.Pow((y1 - y0), 2));
            double lengthSize2 = Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
            double lengthSize3 = Math.Sqrt(Math.Pow((x0 - x2), 2) + Math.Pow((y0 - y2), 2));

            _centerPoint.X = (int)((lengthSize1 * x2 + lengthSize2 * x0 + lengthSize3 * x1) / (lengthSize1 + lengthSize2 + lengthSize3));
            _centerPoint.Y = (int)((lengthSize1 * y2 + lengthSize2 * y0 + lengthSize3 * y1) / (lengthSize1 + lengthSize2 + lengthSize3));
            _centerPoint = new Point(_centerPoint.X, _centerPoint.Y);

            return listPoint;
        }

        public override bool IsMouseOnFigure(Point mouse)
        {
            bool check = false;
            double angleRadian = 60 * Math.PI / 180;
            Point node1 = _startPoint;
            Point node2 = _endPoint;
            int node3X = (int)((node1.X - node2.X) * Math.Cos(angleRadian) - (node1.Y - node2.Y) * Math.Sin(angleRadian) + node2.X);
            int node3Y = (int)((node1.X - node2.X) * Math.Sin(angleRadian) + (node1.Y - node2.Y) * Math.Cos(angleRadian) + node2.Y);

            int vectorEquation1 = (node1.X - mouse.X) * (node2.Y - node1.Y) - (node2.X - node1.X) * (node1.Y - mouse.Y);
            int vectorEquation2 = (node2.X - mouse.X) * (node3Y - node2.Y) - (node3X - node2.X) * (node2.Y - mouse.Y);
            int vectorEquation3 = (node3X - mouse.X) * (node1.Y - node3Y) - (node1.X - node3X) * (node3Y - mouse.Y);

            if( vectorEquation1 > 0 && vectorEquation2 > 0 && vectorEquation3 > 0)
            {
                check = true;
            }
            else if (vectorEquation1 < 0 && vectorEquation2 < 0 && vectorEquation3 < 0)
            {
                check = true;
            }
            else if (vectorEquation1 ==0 || vectorEquation2 == 0 || vectorEquation3 == 0)
            {
                check = true;
            }
            else if (vectorEquation1 < 0 && vectorEquation2 < 0 && vectorEquation3 < 0)
            {
                check = true;
            }
            return check;
        }
    }
}
