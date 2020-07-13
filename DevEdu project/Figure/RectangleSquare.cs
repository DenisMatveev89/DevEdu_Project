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
    public class RectangleSquare : AFigure //Квадрат
    {
        public RectangleSquare()
        {
            fill = new Brush.RectSquareFill();
            getPoints = new RectSquarePoints();
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
