using DevEdu_project.GetPoints;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace DevEdu_project.Figure
{
    public class StraightLinePoints : IGetPoints //Линия
    {
        ConnectPoints cp = new ConnectPoints();
        public List<Point> GetPoints(Point startPoint, Point endPoint, double opt, double opt2)
        {
            return cp.ConnectTwoPoints(startPoint, endPoint);
        }
    }
}
