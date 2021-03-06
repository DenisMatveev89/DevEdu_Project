﻿
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevEdu_project.Figure;
using DevEdu_project.LineW;

namespace DevEdu_project.Factory
{
    public abstract class AFactory
    {        
        public AFigure figure;

        public abstract void Update();

        //Базовый метод, который задает настройки, одинаковые для большинства фигур
        //При этом параметр virtual позволяет изменять реализацию метода в классах-наследниках
        public virtual AFigure Create(Point start, Point end, Color colorLine, Color fillColor, int width)
        {
            figure._startPoint = start;
            figure._endPoint = end;
            figure._colorLine = colorLine;
            figure._fillColor = fillColor;
            figure._linewWidth = width;

            return figure;
        }

        
    }
}
