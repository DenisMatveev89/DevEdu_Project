using System;
using System.Collections.Generic;
using System.Drawing;

namespace DevEdu_project
{
    public interface IFigure
    {
        //List<Point> GetPoints();, Update();, void Update(Point Start, Point End); - 
        //обязательные поля для каждого класса, который унаследует IFigure
        //реализация этого метода у каждого наследника будет своя
        void Update(Point Start, Point End);
        void Update();
        List<Point> GetPoints();
    }
}
