using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DevEdu_project
{
    public class Line //Линия по двум точкам
    {
        public Line() { }

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
        public Image DrawLine(int X0, int Y0, int X1, int Y1, Color currentColor)
        {
            StaticBitmap.TmpBitmap = new Bitmap(StaticBitmap.Bitmap);
            int dx = X1 - X0;//абсолютное значение
            int dy = Y1 - Y0;
            int steps;
            if (abs(dx) > abs(dy))
            {
                steps = abs(dx); //количество шагов
            }
            else
            {
                steps = abs(dy);
            }

            float Xinc = dx / (float)steps;//приращение для каждого шага 
            float Yinc = dy / (float)steps;

            float X = X0;// кладем пиксель для каждого шага 
            float Y = Y0;
            for (int i = 0; i <= steps; i++)
            {
                StaticBitmap.SetPixel((int)X, (int)Y, currentColor);
                X += Xinc;
                Y += Yinc;
            }
            return StaticBitmap.TmpBitmap;
        }
    }
}
