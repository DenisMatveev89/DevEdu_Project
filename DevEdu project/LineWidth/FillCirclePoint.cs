using DevEdu_project.GetPoints;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEdu_project.LineWidth
{
    public class FillCirclePoint
    {
        public List<Point> FillPoint(Circle circle)
        {
            List<Point> circlePoints = new List<Point>();
            Circle copyCircle = circle;
            while(copyCircle.R != 0)
            {
                circlePoints.AddRange(circle.GetPoints());
                copyCircle.R--;
            }

            return circlePoints;
        }
    }
}
