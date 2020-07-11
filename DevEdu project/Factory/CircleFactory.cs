﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEdu_project.Factory
{
    public class CircleFactory : AFactory
    {
        //public CircleFactory()
        //{
        //    figure = new Circle();
        //}

        public override AFigure Create(Point start, Point end, Color colorLine)
        {
            Circle circle = new Circle();
            circle._startPoint = start;
            circle._endPoint = end;
            circle.R = Math.Sqrt(Math.Pow((end.X - start.X), 2) + Math.Pow((end.Y - start.Y), 2));
            circle._colorLine = colorLine;
            return circle;
        }
    }
}
