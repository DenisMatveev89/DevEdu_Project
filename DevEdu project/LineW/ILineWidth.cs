﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEdu_project.LineW
{
    public abstract class ILineWidth
    {
        public BitmapSingletone sBitmap = BitmapSingletone.GetInstance();
        public abstract void LWidth(Point startPoint, Point endPoint, int width, Color colorLine);
    }
}
