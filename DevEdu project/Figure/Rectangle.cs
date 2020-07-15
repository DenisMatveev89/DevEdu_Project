using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using DevEdu_project.Figure;
using DevEdu_project.GetPoints;

namespace DevEdu_project
{
    public class Rectangle : AFigure // Прямоугольник
    {
        //public Rectangle()
        //{
        //    getPoints = new RectanglePoints();
        //}

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
            return listPoints;
        }

        public override bool isMouseOnFigure(Point mouse)
        {
            bool check = false;
            Point node1 = _startPoint, node2 = _endPoint;
            if (node1.X <= mouse.X && node1.Y <= mouse.Y && node2.X >= mouse.X && node2.Y >= mouse.Y)
                return check = true;
            else
                return check;
        }
    }
}
