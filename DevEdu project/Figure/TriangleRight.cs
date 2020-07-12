using DevEdu_project.GetPoints;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEdu_project.Figure
{
    public class TriangleRight : AFigure//правильный треугольник
    {
        public TriangleRight()
        {
            fill = new Brush.TriangleRightFill();
            getPoints = new TriangleRightPoints();
        }
    }
}
