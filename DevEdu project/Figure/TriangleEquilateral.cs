using DevEdu_project.GetPoints;
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
    }
}
