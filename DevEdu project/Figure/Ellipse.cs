using DevEdu_project.GetPoints;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEdu_project
{
    public class Ellipse : AFigure
    {

        public Ellipse()
        {
            fill = new Brush.ElipseFill();
            //getPoints = new EllipsePoints();
        }
    }
}
