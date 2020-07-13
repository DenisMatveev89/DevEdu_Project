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
            return check;
        }
    }
}
