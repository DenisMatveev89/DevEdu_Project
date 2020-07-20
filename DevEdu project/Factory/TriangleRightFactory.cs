using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevEdu_project.Figure;

namespace DevEdu_project.Factory
{
    public class TriangleRightFactory : AFactory
    {
        public TriangleRightFactory()
        {
            figure = new TriangleRight();
        }

        public override void Update()
        {
            figure = new TriangleRight();
        }

        public override AFigure Create(Point start, Point end, Color colorLine, Color fillColor, int width)
        {
            TriangleRight triangleRight = new TriangleRight();
            figure = triangleRight;
            base.Create(start, end, colorLine, fillColor, width);
            triangleRight.node3.X = start.X;
            triangleRight.node3.Y = end.Y;
            return triangleRight;


        }
    }
}
