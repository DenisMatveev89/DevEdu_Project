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
        Pencil pencil = new Pencil();

        public AFigure Create(Point start, Point end)
        {
            pencil._startPoint = start;
            pencil._endPoint = end;
            return pencil;
        }
    }
}
