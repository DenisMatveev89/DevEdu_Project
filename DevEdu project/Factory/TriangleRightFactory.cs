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

        //public AFigure Create(Point start, Point end)
        //{
        //    TriangleRight triangle = new TriangleRight();
        //    triangle._startPoint = start;
        //    triangle._endPoint = end;
        //    return triangle;
        //}
    }
}
