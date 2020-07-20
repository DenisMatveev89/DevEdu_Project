using DevEdu_project.GetPoints;
using DevEdu_project.LineW;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEdu_project.Figure
{
    [Serializable]
    public class TriangleRight : AFigure//правильный треугольник
    {
        public TriangleRight()
        {
        }

        public Point node3;
        public override List<Point> GetPoints()
        {
            ConnectPoints cp = new ConnectPoints();

            int x0 = _startPoint.X;
            int y0 = _startPoint.Y;
            int x1 = _endPoint.X;
            int y1 = _endPoint.Y;
            node3.X = _startPoint.X;
            node3.Y = _endPoint.Y;
            List<Point> listPoint = new List<Point>();

            listPoint.AddRange(cp.ConnectTwoPoints(new Point(x0, y0), new Point(x1, y1)));
            listPoint.AddRange(cp.ConnectTwoPoints(new Point(x1, y1), new Point(x0, y1)));
            listPoint.AddRange(cp.ConnectTwoPoints(new Point(x0, y1), new Point(x0, y0)));

            double lengthSize1 = Math.Sqrt(Math.Pow((x1 - x0), 2) + Math.Pow((y1 - y0), 2));
            double lengthSize2 = Math.Sqrt(Math.Pow((x0 - x1), 2) + Math.Pow((y1 - y1), 2));
            double lengthSize3 = Math.Sqrt(Math.Pow((x0 - x0), 2) + Math.Pow((y0 - y1), 2));

            _centerPoint.X = (int)((lengthSize1 * x0 + lengthSize2 * x0 + lengthSize3 * x1) / (lengthSize1 + lengthSize2 + lengthSize3));
            _centerPoint.Y = (int)((lengthSize1 * y1 + lengthSize2 * y0 + lengthSize3 * y1) / (lengthSize1 + lengthSize2 + lengthSize3));
            _centerPoint = new Point(_centerPoint.X, _centerPoint.Y);

            return listPoint;
        }
        public override void WidthLine()
        {
            ILineWidth lineWidth = new LineWidth();
            int x0 = _startPoint.X;
            int y0 = _startPoint.Y;
            int x1 = _endPoint.X;
            int y1 = _endPoint.Y;
            List<Point> listPoint = new List<Point>();

            lineWidth.LWidth(new Point(x0, y0), new Point(x1, y1), _linewWidth, _colorLine);
            lineWidth.LWidth(new Point(x1, y1), new Point(x0, y1), _linewWidth, _colorLine);
            lineWidth.LWidth(new Point(x0, y1), new Point(x0, y0), _linewWidth, _colorLine);

            double lengthSize1 = Math.Sqrt(Math.Pow((x1 - x0), 2) + Math.Pow((y1 - y0), 2));
            double lengthSize2 = Math.Sqrt(Math.Pow((x0 - x1), 2) + Math.Pow((y1 - y1), 2));
            double lengthSize3 = Math.Sqrt(Math.Pow((x0 - x0), 2) + Math.Pow((y0 - y1), 2));

            _centerPoint.X = (int)((lengthSize1 * x0 + lengthSize2 * x0 + lengthSize3 * x1) / (lengthSize1 + lengthSize2 + lengthSize3));
            _centerPoint.Y = (int)((lengthSize1 * y1 + lengthSize2 * y0 + lengthSize3 * y1) / (lengthSize1 + lengthSize2 + lengthSize3));
            _centerPoint = new Point(_centerPoint.X, _centerPoint.Y);
        }

        public override bool IsMouseOnFigure(Point mouse)
        {
            bool check = false;
            Point node1 = _startPoint;
            Point node2 = _endPoint;
            int node3X = node1.X;
            int node3Y = node2.Y;

            int vectorEquation1 = (node1.X - mouse.X) * (node2.Y - node1.Y) - (node2.X - node1.X) * (node1.Y - mouse.Y);
            int vectorEquation2 = (node2.X - mouse.X) * (node3Y - node2.Y) - (node3X - node2.X) * (node2.Y - mouse.Y);
            int vectorEquation3 = (node3X - mouse.X) * (node1.Y - node3Y) - (node1.X - node3X) * (node3Y - mouse.Y);

            if (vectorEquation1 > 0 && vectorEquation2 > 0 && vectorEquation3 > 0)
            {
                check = true;
            }
            else if (vectorEquation1 < 0 && vectorEquation2 < 0 && vectorEquation3 < 0)
            {
                check = true;
            }
            else if (vectorEquation1 == 0 || vectorEquation2 == 0 || vectorEquation3 == 0)
            {
                check = true;
            }
            return check;
        }

        public override void Rotate()
        {
            ConnectPoints cp = new ConnectPoints();
            ILineWidth lineWidth = new LineWidth();

            int x0 = _startPoint.X;
            int y0 = _startPoint.Y;
            int x1 = _endPoint.X;
            int y1 = _endPoint.Y;
            List<Point> listPoint = new List<Point>();

            double lengthSize1 = Math.Sqrt(Math.Pow((x1 - x0), 2) + Math.Pow((y1 - y0), 2));
            double lengthSize2 = Math.Sqrt(Math.Pow((x0 - x1), 2) + Math.Pow((y1 - y1), 2));
            double lengthSize3 = Math.Sqrt(Math.Pow((x0 - x0), 2) + Math.Pow((y0 - y1), 2));

            _centerPoint.X = (int)((lengthSize1 * x0 + lengthSize2 * x0 + lengthSize3 * x1) / (lengthSize1 + lengthSize2 + lengthSize3));
            _centerPoint.Y = (int)((lengthSize1 * y1 + lengthSize2 * y0 + lengthSize3 * y1) / (lengthSize1 + lengthSize2 + lengthSize3));
            _centerPoint = new Point(_centerPoint.X, _centerPoint.Y);

            double tmpX = (x0 - node3.X) * Math.Cos(_angel) - (y0 - node3.Y) * Math.Sin(_angel) + node3.X;
            double tmpY = (x0 - node3.X) * Math.Sin(_angel) + (y0 - node3.Y) * Math.Cos(_angel) + node3.Y;

            x0 = (int)tmpX;
            y0 = (int)tmpY;

            tmpX = (x1 - node3.X) * Math.Cos(_angel) - (y1 - node3.Y) * Math.Sin(_angel) + node3.X;
            tmpY = (x1 - node3.X) * Math.Sin(_angel) + (y1 - node3.Y) * Math.Cos(_angel) + node3.Y;
            x1 = (int)tmpX;
            y1 = (int)tmpY;

            List<Point> listpoint = new List<Point>();
            listPoint.AddRange(cp.ConnectTwoPoints(new Point(x0, y0), new Point(x1, y1)));
            listPoint.AddRange(cp.ConnectTwoPoints(new Point(x1, y1), new Point(node3.X, node3.Y)));
            listPoint.AddRange(cp.ConnectTwoPoints(new Point(node3.X, node3.Y), new Point(x0, y0)));

           /* lineWidth.LWidth(new Point(x0, y0), new Point(x1, y1), _linewWidth, _colorLine);
            lineWidth.LWidth(new Point(x1, y1), new Point(node3.X, node3.Y), _linewWidth, _colorLine);
            lineWidth.LWidth(new Point(node3.X, node3.Y), new Point(x0, y0), _linewWidth, _colorLine);
            _centerPoint.X = (int)((lengthSize1 * x0 + lengthSize2 * x0 + lengthSize3 * x1) / (lengthSize1 + lengthSize2 + lengthSize3));
            _centerPoint.Y = (int)((lengthSize1 * y1 + lengthSize2 * y0 + lengthSize3 * y1) / (lengthSize1 + lengthSize2 + lengthSize3));
            _centerPoint = new Point(_centerPoint.X, _centerPoint.Y);*/
        }
    }
}
