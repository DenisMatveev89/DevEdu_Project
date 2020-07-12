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
            getPoints = new CirclePoints();
        }

        public double R;

        public override List<Point> GetPoints()
        {
            return getPoints.GetPoints(_startPoint, _endPoint, R);
        }

    }
}
