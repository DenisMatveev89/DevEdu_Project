using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevEdu_project.Figure;

namespace DevEdu_project.Factory
{
    public class TriangleEquilateralFactory : AFactory
    {
        public TriangleEquilateralFactory()
        {
            figure = new TriangleEquilateral();
        }

        //public AFigure Create(Point start, Point end)
        //{
        //    TriangleEquilateral triangle = new TriangleEquilateral();
        //    triangle._startPoint = start;
        //    triangle._endPoint = end;
        //    return triangle;
        //}
    }
}


