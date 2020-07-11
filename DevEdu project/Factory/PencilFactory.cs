using DevEdu_project.Figure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEdu_project.Factory
{
    public class PencilFactory : AFactory
    {
        Pencil pencil = new Pencil();

        public override AFigure Create(Point start, Point end, Color color)
        {
            pencil._startPoint = start;
            pencil._endPoint = end;
            pencil._colorLine = color;
            return pencil;
        }
    }
}
