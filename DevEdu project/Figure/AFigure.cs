using DevEdu_project.Brush;
using DevEdu_project.GetPoints;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace DevEdu_project
{
    public abstract class AFigure
    {
        protected IBrush fill;
        protected IGetPoints getPoints;
        public Point StartPoint;
        public Point EndPoint;
        public void Brush()
        {
            fill.Fill();
        }

        public List<Point> GetPoints()
        {
            return getPoints.GetPoints();
        }
        public void Update()
        {
            getPoints.Update();
        }
        public void Update(Point StartPoint, Point EndPoint)
        {
            getPoints.Update(StartPoint, EndPoint);
        }

    }
}
