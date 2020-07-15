
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevEdu_project.Figure;

namespace DevEdu_project.Factory
{
    public abstract class AFactory
    {        
        public AFigure figure;

        public abstract void Update();

        //Базовый метод, который задает настройки, одинаковые для большинства фигур
        //При этом параметр virtual позволяет изменять реализацию метода в классах-наследниках
        public virtual AFigure Create(Point start, Point end, Color colorLine)
        {
            figure._startPoint = start;
            figure._endPoint = end;
            figure._colorLine = colorLine;
            return figure;
        }
    }
}
