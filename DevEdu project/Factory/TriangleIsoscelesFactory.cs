using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevEdu_project.Figure;

namespace DevEdu_project.Factory
{
    public class TriangleIsoscelesFactory : IFactory
    {
        public AFigure Create(Point start, Point end)
        {
            TriangleIsosceles triangle = new TriangleIsosceles();
            triangle._startPoint = start;
            triangle._endPoint = end;
            return triangle;
        }
    }
}
