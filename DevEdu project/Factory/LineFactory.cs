using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevEdu_project.Figure;
using DevEdu_project.LineW;

namespace DevEdu_project.Factory
{
    public class LineFactory : AFactory
    {
        public LineFactory()
        {
            figure = new StraightLine();
        }

        public override void Update()
        {
            figure = new StraightLine();
        }
        public override AFigure Create(Point start, Point end, Color colorLine, Color fillColor, int width)
        {
            StraightLine line = new StraightLine();
            figure = line;
            base.Create(start, end, colorLine, fillColor, width);
            line._centerPoint = start;

            return line;
        }

    }
}
