using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEdu_project.Factory
{
    public class SquareFactory : AFactory
    {
        public SquareFactory()
        {
            figure = new RectangleSquare();
        }
    }
}
