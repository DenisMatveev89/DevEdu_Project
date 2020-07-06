using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using DevEdu_project.Figure;

namespace DevEdu_project
{
    public class Rectangle:IFigure // Через зад мне кажется, переделать по возможности
    {
        //В эти конструкторы нужно передавать значения точек из MouseDown, MouswMove, MouseUp
        public Point StartPoint;
        public Point EndPoint;

        public List<Point> GetPoints()
        {

            int X0 = StartPoint.X;
            int Y0 = StartPoint.Y;
            int X1 = EndPoint.X;
            int Y1 = EndPoint.Y;
           
            List<Point> points = new List<Point>();
            List<Point> listPoints = new List<Point>();

            points.Add(new Point(X0, Y0));
            points.Add(new Point(X1, Y0));
            points.Add(new Point(X1, Y0));
            points.Add(new Point(X1, Y0));
            points.Add(new Point(X1, Y1));
            points.Add(new Point(X1, Y1));
            points.Add(new Point(X0, Y1));
            points.Add(new Point(X0, Y1));
            points.Add(new Point(X0, Y0));

            for (int i=0; i<8; i++)
            {
                StraightLine line = new StraightLine();
                line.StartPoint = points[i];
                line.EndPoint = points[i+1];
                listPoints.AddRange(line.GetPoints());
            }
            return listPoints;
        }
    }
}
