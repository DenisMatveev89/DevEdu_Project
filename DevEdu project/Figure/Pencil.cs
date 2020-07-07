using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevEdu_project.Figure
{
    public class Pencil : IFigure //Перо
    {
        //В эти конструкторы нужно передавать значения точек из MouseDown, MouswMove, MouseUp
        public Point StartPoint;
        public Point EndPoint;

        public Pencil() { }
        public Pencil(Point StartPoint, Point EndPoint)
        {
            this.StartPoint = StartPoint;
            this.EndPoint = EndPoint;
        }
        public void Update()
        {
        }
        public void Update(Point Start, Point End)
        {
            StaticBitmap.Update();
            StartPoint = EndPoint;
            EndPoint = End;
        }

        public List<Point> GetPoints()
        {
            return StaticBitmap.ConnectTwoPoints(StartPoint, EndPoint);
        }
    }
}
