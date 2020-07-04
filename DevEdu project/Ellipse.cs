using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEdu_project
{
    public class Ellipse
    {
        public Ellipse() { }

        public Bitmap DrawCircle(int X0, int Y0, int X1, int Y1, Color currentColor)
        {
          
            double R = Math.Sqrt(Math.Pow((X1 - X0), 2) + Math.Pow((Y1 - Y0), 2));

            int x = 0;
            int y = (int)R;
            int delta = 1 - 2 * (int)R;
            int error;
            while (y >= 0)
            {
                StaticBitmap.SetPixel(X0 + x, Y0 + y, currentColor);
                StaticBitmap.SetPixel(X0 + x, Y0 - y, currentColor);
                StaticBitmap.SetPixel(X0 - x, Y0 + y, currentColor);
                StaticBitmap.SetPixel(X0 - x, Y0 - y, currentColor);

                error = 2 * (delta + y) - 1;
                if ((delta < 0) && (error <= 0))
                {
                    delta += 2 * ++x + 1;
                    continue;
                }
                if ((delta > 0) && (error > 0))
                {
                    delta -= 2 * --y + 1;
                    continue;
                }
                delta += 2 * (++x - --y);
            }
            return StaticBitmap.TmpBitmap;
        }

        public Bitmap DrawEllipse(int X0, int Y0, int X1, int Y1, Color currentColor)
        {
        

            double RX = Math.Sqrt(Math.Pow((X1 - X0), 2));
            double RY = Math.Sqrt(Math.Pow((Y1 - Y0), 2));
            int centerX = X0;
            int centerY = Y0;
            int radiusX = (int)RX;
            int radiusY = (int)RY;
            
            int posX = radiusX;
            int posY = 0;

            int deltaX = 2 * radiusY * radiusY * posX;
            int deltaY = 2 * radiusX * radiusX * posY;
            int err = (radiusX * radiusX) - (radiusY * radiusY * radiusX) + (radiusY * radiusY) / 4;

            while (deltaY < deltaX)
            {
                StaticBitmap.SetPixel(centerX + posX, centerY + posY, currentColor);
                StaticBitmap.SetPixel(centerX + posX, centerY - posY, currentColor);
                StaticBitmap.SetPixel(centerX - posX, centerY + posY, currentColor);
                StaticBitmap.SetPixel(centerX - posX, centerY - posY, currentColor);
                posY++;

                if (err < 0)
                {
                    deltaY += 2 * radiusX * radiusX;
                    err += deltaY + radiusX * radiusX;
                }
                else
                {
                    posX--;
                    deltaY += 2 * radiusX * radiusX;
                    deltaX -= 2 * radiusY * radiusY;
                    err += deltaY - deltaX + radiusX * radiusX;
                }
            }            

            err = radiusX * radiusX * (posY * posY + posY)
                + radiusY * radiusY * (posX - 1) * (posX - 1)
                - radiusY * radiusY * radiusX * radiusX;

            while (posX >= 0)
            {
                StaticBitmap.SetPixel(centerX + posX, centerY + posY, currentColor);
                StaticBitmap.SetPixel(centerX + posX, centerY - posY, currentColor);
                StaticBitmap.SetPixel(centerX - posX, centerY + posY, currentColor);
                StaticBitmap.SetPixel(centerX - posX, centerY - posY, currentColor);
                posX--;

                if (err > 0)
                {
                    deltaX -= 2 * radiusY * radiusY;
                    err += radiusY * radiusY - deltaX;
                }
                else
                {
                    posY++;
                    deltaY += 2 * radiusX * radiusX;
                    deltaX -= 2 * radiusY * radiusY;
                    err += deltaY - deltaX + radiusY * radiusY;
                }
            }
            return StaticBitmap.TmpBitmap;
        }      
        
    }
}
