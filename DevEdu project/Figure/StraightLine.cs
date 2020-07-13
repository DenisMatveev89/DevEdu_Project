using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace DevEdu_project.Figure
{
    public class StraightLine: AFigure //Линия
    {
        public StraightLine()
        {
            fill = new Brush.EmptyFill();
            getPoints = new StraightLinePoints();
        }

        public override bool isMouseOnFigure(Point mouse)
        {
            bool check = false;
            List<Point> line = base.GetPoints();
            foreach (Point i in line)
            {
                if (i == mouse)
                    check = true;
            }
            return check;
        }
    }
}
