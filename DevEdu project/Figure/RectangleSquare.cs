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
    public class RectangleSquar : AFigure //Квадрат
    {
        public RectangleSquar()
        {
            fill = new Brush.RectSquarFill();
            getPoints = new RectSquarePoints();
        }
    }
}
