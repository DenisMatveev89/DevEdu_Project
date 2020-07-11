﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEdu_project.Factory
{
    public class RectangleFactory : IFactory
    {
        public AFigure Create(Point start, Point end)
        {
            Rectangle rect = new Rectangle();
            rect._startPoint = start;
            rect._endPoint = end;
            return rect;
        }
    }
}