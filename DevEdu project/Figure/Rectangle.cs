using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using DevEdu_project.Figure;
using DevEdu_project.GetPoints;
using DevEdu_project.LineW;

namespace DevEdu_project
{
    [Serializable]
    public class Rectangle : AFigure // Прямоугольник
    {        

        public Rectangle()
        {

        }

        public override List<Point> GetPoints()
        {
            ConnectPoints cp = new ConnectPoints();
            
            int X0 = _startPoint.X;
            int Y0 = _startPoint.Y;
            int X1 = _endPoint.X;
            int Y1 = _endPoint.Y;
            List<Point> listPoints = new List<Point>();
            listPoints.AddRange(cp.ConnectTwoPoints(new Point(X0, Y0), new Point(X1, Y0)));
            listPoints.AddRange(cp.ConnectTwoPoints(new Point(X1, Y0), new Point(X1, Y1)));
            listPoints.AddRange(cp.ConnectTwoPoints(new Point(X1, Y1), new Point(X0, Y1)));
            listPoints.AddRange(cp.ConnectTwoPoints(new Point(X0, Y1), new Point(X0, Y0)));


            _centerPoint = new Point(X0 + ((X1 - X0) / 2), Y0 +((Y1 - Y0)/ 2));
            return listPoints;
        }

        public override void WidthLine()
        {
            ILineWidth lineWidth = new LineWidth();

            int X0 = _startPoint.X;
            int Y0 = _startPoint.Y;
            int X1 = _endPoint.X;
            int Y1 = _endPoint.Y;

            lineWidth.LWidth(new Point(X0, Y0), new Point(X1, Y0), _linewWidth, _colorLine);
            lineWidth.LWidth(new Point(X1, Y0), new Point(X1, Y1), _linewWidth, _colorLine);
            lineWidth.LWidth(new Point(X1, Y1), new Point(X0, Y1), _linewWidth, _colorLine);
            lineWidth.LWidth(new Point(X0, Y1), new Point(X0, Y0), _linewWidth, _colorLine);

            _centerPoint = new Point(X0 + ((X1 - X0) / 2), Y0 + ((Y1 - Y0) / 2));
        }

        public override bool IsMouseOnFigure(Point mouse)
        {
            bool check = false;
            Point node1 = _startPoint, node2 = _endPoint;

            if(_startPoint.X < _endPoint.X && _startPoint.Y < _endPoint.Y)
            {
                node1.X -= _linewWidth;
                node1.Y -= _linewWidth;
                node2.X += _linewWidth;
                node2.Y += _linewWidth;

                if (node1.X <= mouse.X && node1.Y <= mouse.Y && node2.X >= mouse.X && node2.Y >= mouse.Y)
                    return check = true;
            }
            else if(_startPoint.X > _endPoint.X && _startPoint.Y < _endPoint.Y)
            {
                node1.X += _linewWidth;
                node1.Y -= _linewWidth;
                node2.X -= _linewWidth;
                node2.Y += _linewWidth;

                if (node2.X <= mouse.X && node1.Y <= mouse.Y && node1.X >= mouse.X && node2.Y >= mouse.Y)
                    return check = true;
            }
            else if (_startPoint.X > _endPoint.X && _startPoint.Y > _endPoint.Y)
            {
                node1.X += _linewWidth;
                node1.Y += _linewWidth;
                node2.X -= _linewWidth;
                node2.Y -= _linewWidth;

                if (node2.X <= mouse.X && node2.Y <= mouse.Y && node1.X >= mouse.X && node1.Y >= mouse.Y)
                    return check = true;
            }
            else if (_startPoint.X < _endPoint.X && _startPoint.Y > _endPoint.Y)
            {
                node1.X -= _linewWidth;
                node1.Y += _linewWidth;
                node2.X += _linewWidth;
                node2.Y -= _linewWidth;

                if (node1.X <= mouse.X && node2.Y <= mouse.Y && node2.X >= mouse.X && node1.Y >= mouse.Y)
                    return check = true;
            }

            return check;
        }
    }
}
