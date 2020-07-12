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
            fill = new Brush.TriangleIsoFill();
            getPoints = new TriangleIsoPoints();
        }
    }
}
