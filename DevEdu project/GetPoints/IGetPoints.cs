using System;
using System.Collections.Generic;
using System.Drawing;

namespace DevEdu_project.GetPoints
{
    public interface IGetPoints
    {
        //double optional - переменные, которые нужны для круга и эллипса, через них передается радиус
        //поэтому они необязательные для всех фигур
        //радиус можно было бы считать внутри GetPoints, но это не оптимально с точки зрения производительности
        List<Point> GetPoints(Point start, Point end);
        
    }

    //public abstract class AGetPoints<T>
    //{
    //    public abstract List<Point> GetPoints(Point start, T end, T optional);
    //}
}
