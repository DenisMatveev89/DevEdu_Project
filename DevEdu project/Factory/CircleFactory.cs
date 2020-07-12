using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEdu_project.Factory
{
    public class CircleFactory : IFactory
    {
        public AFigure Create(Point start, Point end)
        {
            Circle circle = new Circle();
            circle._startPoint = start;
            circle._endPoint = end;
            circle.R = Math.Sqrt(Math.Pow((end.X - start.X), 2) + Math.Pow((end.Y - start.Y), 2));
            return circle;
        }
    }
}
