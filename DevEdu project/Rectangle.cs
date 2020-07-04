using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DevEdu_project
{
    public class Rectangle
    {
        public Rectangle() { }
        public Bitmap DrawSquare(int X0, int Y0, int X1, int Y1, Color currentColor)
        {
            StaticBitmap.TmpBitmap = new Bitmap(StaticBitmap.Bitmap);
            int dx = X1 - X0;//абсолютное значение
            int dy = dx;
            int d=dx*2; //длина диагонали

            float Xinc = dx / (float)d;//приращение для каждого шага 
            float Yinc = dy / (float)d;

            float X = X0;// кладем пиксель для каждого шага 
            float Y = Y0;

            for (int i = 0; i <= d; i++)
            {
                StaticBitmap.SetPixel((int)X, (int)Y, currentColor);
                StaticBitmap.SetPixel((int)X, (int)Y+d/2, currentColor);
                X += Xinc;
            }
            for (int j = 0; j <= d; j++)
            {
                StaticBitmap.SetPixel((int)X, (int)Y, currentColor);
                StaticBitmap.SetPixel((int)X-d/2, (int)Y, currentColor);
                Y += Yinc;
            }

            return StaticBitmap.TmpBitmap;
        }
        public Bitmap DrawRectangle(int X0, int Y0, int X1, int Y1, Color currentColor)
        {

            return StaticBitmap.TmpBitmap;
        }
    }
}
