﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEdu_project.Factory
{
    public class EllipseFactory : AFactory
    {
        public EllipseFactory()
        {
            figure = new Ellipse();
        }

        public override void Update()
        {
            figure = new Ellipse();
        }

        public override AFigure Create(Point start, Point end, Color colorLine)
        {
            Ellipse ellipse = new Ellipse();
            ellipse._startPoint = start;
            ellipse._endPoint = end;
            ellipse._colorLine = colorLine;
            ellipse.RX = Math.Sqrt(Math.Pow((end.X - start.X), 2));
            ellipse.RY = Math.Sqrt(Math.Pow((end.Y - start.Y), 2));
            
            return ellipse;
        }
    }
}
