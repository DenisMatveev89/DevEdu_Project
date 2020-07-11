using DevEdu_project.Brush;
using DevEdu_project.GetPoints;
using DocumentFormat.OpenXml.Drawing.Wordprocessing;
using DocumentFormat.OpenXml.EMMA;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace DevEdu_project
{
    public abstract class AFigure
    {
        protected IBrush fill;
        protected IGetPoints getPoints;
        public Point a;
        public Point b;
        public void Brush()
        {
            fill.Fill();
        }

        public List<Point> GetPoints()
        {
            getPoints.Update();
            return getPoints.GetPoints();
        }
        public void Update()
        {
            getPoints.Update();
        }
    }
}
