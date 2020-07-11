using DevEdu_project.GetPoints;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEdu_project
{
    public class Circle : AFigure

    {
        public Circle()
        {
            fill = new Brush.CircleFill();
            getPoints = new CirclePoints();
        }
    }
}
