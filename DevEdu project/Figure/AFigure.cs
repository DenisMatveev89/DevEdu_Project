using System;
using System.Collections.Generic;
using System.Drawing;

namespace DevEdu_project
{
    public abstract class AFigure
    {
        //List<Point> GetPoints();, Update();, void Update(Point Start, Point End); - 
        //обязательные поля для каждого класса, который унаследует IFigure
        //реализация этого метода у каждого наследника будет своя

        //public abstract void Update(Point start, Point end);
        //public abstract void Update();
        public abstract List<Point> GetPoints();
    }
}
