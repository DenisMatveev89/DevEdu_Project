using DevEdu_project.GetPoints;
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
            //fill = new Brush.TriangleIsoFill();
            getPoints = new TriangleIsoPoints();
        }

        public override bool isMouseOnFigure(Point mouse)
        {
            bool check = false;
            Point node1 = _startPoint;
            Point node2 = _endPoint;
            int node3X = (node1.X - (node2.X - node1.X));
            int node3Y = node2.Y;

            int vectorEquation1 = (node1.X - mouse.X) * (node2.Y - node1.Y) - (node2.X - node1.X) * (node1.Y - mouse.Y);
            int vectorEquation2 = (node2.X - mouse.X) * (node3Y - node2.Y) - (node3X - node2.X) * (node2.Y - mouse.Y);
            int vectorEquation3 = (node3X - mouse.X) * (node1.Y - node3Y) - (node1.X - node3X) * (node3Y - mouse.Y);

            if (vectorEquation1 > 0 && vectorEquation2 > 0 && vectorEquation3 > 0)
            {
                check = true;
            }
            else if (vectorEquation1 == 0 || vectorEquation2 == 0 || vectorEquation3 == 0)
            {
                check = true;
            }
            return check;
        }
    }
}
