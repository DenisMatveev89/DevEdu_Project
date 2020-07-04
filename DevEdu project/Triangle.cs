using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEdu_project
{
    public class Triangle
    {
        Line line = new Line();
        public Bitmap RightTriangle(int PrevPointX, int PrevPointY, int CurrentPointX, int CurrentPointY, Color currentColor)
        {
            line.DrawLine(PrevPointX, PrevPointY, CurrentPointX, CurrentPointY, currentColor);
            line.DrawLine(CurrentPointX, CurrentPointY, PrevPointX, CurrentPointY, currentColor);
            line.DrawLine(PrevPointX, CurrentPointY, PrevPointX, PrevPointY, currentColor);
            return StaticBitmap.TmpBitmap;
        }
    }
}
