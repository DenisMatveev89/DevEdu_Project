﻿using DevEdu_project.GetPoints;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEdu_project.Brush
{
    public class FullFill:IBrush
    {
        public AFigure figure;
        ConnectPoints cp = new ConnectPoints();
        BitmapSingletone bs;
        List<Point> listFillPixel = new List<Point>();
        public void Fill(Point mouse, Color fillColor)
        { 
            listFillPixel.AddRange(cp.ConnectTwoPoints(figure._startPoint, figure._endPoint));

        }
    }
}
