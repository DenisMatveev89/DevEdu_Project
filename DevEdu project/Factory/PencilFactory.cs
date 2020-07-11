using DevEdu_project.Figure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEdu_project.Factory
{
    public class PencilFactory : IFactory
    {
        //public AFigure Create(Point start, Point end)
        //{
        //    Pencil pencil = new Pencil();
        //    //pencil.Update();
        //    pencil.Update(start, end);
        //    //pencil._startPoint = start;
        //    //pencil._startPoint = pencil._endPoint;
        //    //pencil._endPoint = end;
        //    return pencil;
        //}
        public AFigure Create(Point start, Point end)
        {
            throw new NotImplementedException();
        }
    }
}
