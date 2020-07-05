using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEdu_project
{
    public class Brush //класс заливки
    {
        public Bitmap BrushAll (int X, int Y, Color currentColor)
        {
            
            while(X!=0 && Y != 0)
            {
                StaticBitmap.SetPixel(X, Y, currentColor);
                X -= 1;
                Y -= 1;
            }
            return StaticBitmap.TmpBitmap;
        }
    }
}
