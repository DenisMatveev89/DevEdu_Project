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

        public Point _startPoint;
        public Point _endPoint;
        public AFigure(Point start, Point end)
        {
            _startPoint = start;
            _endPoint = end;
        }
        public AFigure() { }


        public void Brush()
        {
            fill.Fill();
        }

        public List<Point> GetPoints()
        {
            return getPoints.GetPoints();
        }
    }
}
