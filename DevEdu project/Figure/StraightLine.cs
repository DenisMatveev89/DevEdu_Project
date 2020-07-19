using DevEdu_project.Brush;
using DevEdu_project.GetPoints;
using DevEdu_project.LineW;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace DevEdu_project.Figure
{
    [Serializable]
    public class StraightLine: AFigure //Линия
    {
        public StraightLine()
        {
            _fill = new Brush.EmptyFill();            
        }

        public override List<Point> GetPoints()
        {
            ConnectPoints cp = new ConnectPoints();
            return cp.ConnectTwoPoints(_startPoint, _endPoint);
        }
        public override void WidthLine()
        {
            ILineWidth lineWidth = new LineWidth();
            lineWidth.LWidth(_startPoint, _endPoint, _linewWidth, _colorLine);
        }

        public override bool IsMouseOnFigure(Point mouse)
        {
            bool check = false;

            List<Point> line = GetPoints();
            foreach (Point i in line)
            {
                if (i==mouse)
                check = true;
            }
            return check;
        }

        public override void FillFigure(Point mouse)
        {
            _fill = new EmptyFill();
        }
    }
}
