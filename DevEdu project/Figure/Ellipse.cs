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
            getPoints = new EllipsePoints();
        }

        public double RX;
        public double RY;
        
    }
}
