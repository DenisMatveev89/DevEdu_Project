using System;
using System.Collections.Generic;
using System.Drawing;

namespace DevEdu_project
{
    public interface IFigure
    {
        //GetPoints - обязательное поле для каждого класса, который унаследует IFigure
        //- публичный метод, который возвращает список Point
        //реализация этого метода у каждого наследника будет своя

        List<Point> GetPoints();
    }
}
