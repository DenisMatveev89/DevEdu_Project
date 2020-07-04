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
        private int abs(int n)
        {
            if (n > 0)
            {
                return n;
            }
            else
            {
                return n * -1;
            }
        }
        public Bitmap DrawSquare(int X0, int Y0, int X1, int Y1, Color currentColor)
        {
            StaticBitmap.TmpBitmap = new Bitmap(StaticBitmap.Bitmap);
            int dx = X1 - X0;//абсолютное значение
            int dy = dx;
            int d=dx; //длина диагонали

            float Xinc = dx / (float)d;//приращение для каждого шага 
            float Yinc = dy / (float)d;

            float X = X0;// кладем пиксель для каждого шага 
            float Y = Y0;

            for (int i = 0; i <= d; i++)
            {
                StaticBitmap.SetPixel((int)X, (int)Y, currentColor);
                StaticBitmap.SetPixel((int)X, (int)Y+d, currentColor);
                X += Xinc;
            }
            for (int j = 0; j <= d; j++)
            {
                StaticBitmap.SetPixel((int)X, (int)Y, currentColor);
                StaticBitmap.SetPixel((int)X-d, (int)Y, currentColor);
                Y += Yinc;
            }

            return StaticBitmap.TmpBitmap;
        }
        public Bitmap DrawRectangle(int X0, int Y0, int X1, int Y1, Color currentColor)
        {
           /* StaticBitmap.TmpBitmap = new Bitmap(StaticBitmap.Bitmap);
            int dx = X1 - X0;//абсолютное значение
            int dy = Y1 - Y0;
            int d;

            if (abs(dx) > abs(dy))
            {
                d = dx-dy;
                float Xinc = dx / (float)d;//приращение для каждого шага 
                float Yinc = dy / (float)d;

                float X = X0;// кладем пиксель для каждого шага 
                float Y = Y0;
                for (int i = 0; i <= d; i++)
                {
                    StaticBitmap.SetPixel((int)X, (int)Y+d, currentColor);
                    StaticBitmap.SetPixel((int)X, (int)Y, currentColor);
                    X += Xinc;
                    //Y += Yinc;
                }
                return StaticBitmap.TmpBitmap;
            }
            else
            {
                d = dy-dx;
                float Xinc = dx / (float)d;//приращение для каждого шага 
                float Yinc = dy / (float)d;

                float X = X0;// кладем пиксель для каждого шага 
                float Y = Y0;
                for (int i = 0; i <= d; i++)
                {
                    StaticBitmap.SetPixel((int)X, (int)Y, currentColor);
                    StaticBitmap.SetPixel((int)X+d, (int)Y, currentColor);
                    //X += Xinc;
                    Y += Yinc;
                }
                return StaticBitmap.TmpBitmap;
            }
            */
            return StaticBitmap.TmpBitmap;
        }
    }
}
