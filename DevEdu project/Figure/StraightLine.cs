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
            Point node1 = _startPoint;
            Point node2 = _endPoint;
            int vectorEquation = (node1.X - mouse.X) * (node2.Y - node1.Y) - (node2.X - node1.X) * (node1.Y - mouse.Y);
            if (vectorEquation == 0)
            {
                check = true;
            }
            return check;

            //List<Point> line = base.GetPoints();
            //foreach (Point i in line)
            //{
            //    if (i == mouse)
            //        check = true;
            //}
            //return check;
        }
    }
}
