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
    public class TriangleEquilateral : AFigure//Треугольник Равносторонний
    {
        public TriangleEquilateral()
        {
            fill = new Brush.TriangleEqFill();
            getPoints = new TriangleEqPoints();
        }

        public override bool isMouseOnFigure(Point mouse)
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
            else if (vectorEquation1 ==0 || vectorEquation2 == 0 || vectorEquation3 == 0)
            {
                check = true;
            }
            return check;
        }
    }
}
