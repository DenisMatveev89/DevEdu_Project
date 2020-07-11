using System;
using System.Collections.Generic;
using System.Drawing;

namespace DevEdu_project.GetPoints
{
    //public abstract class AGetPoints<T>
    //{
    //    public abstract List<Point> GetPoints(Point start, T end, T optional);
    //    //public abstract List<Point> GetPoints(Point start, double R);

    //}

    public interface IGetPoints
    {
        List<Point> GetPoints(Point start, Point end, double optional = 0, double optional2 = 0);
        
    }
}
