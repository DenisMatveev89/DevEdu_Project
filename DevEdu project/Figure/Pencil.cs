using DevEdu_project.GetPoints;
using DocumentFormat.OpenXml.Drawing.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevEdu_project.Figure
{
    public class Pencil : AFigure //Карандаш
    {
        public Pencil()
        {
            getPoints = new PencilPoints();
        }

        //В эти конструкторы нужно передавать значения точек из MouseDown, MouswMove, MouseUp
        //public Point _startPoint = new Point(0, 0);
        //public Point _endPoint = new Point(0, 0);


        //public void Update()
        //{
        //    _startPoint = new Point(0, 0);
        //    _linePoints = new List<Point>();
        //}
        //public void Update(Point Start, Point End)
        //{
        //    if(_startPoint == new Point(0, 0))
        //    {
        //        _startPoint = Start;
        //    }
        //    else 
        //    {
        //        _startPoint = _endPoint;
        //    }

        //    _endPoint = End;            
        //}       

        //public new List<Point> GetPoints()
        //{
        //    
        //}
    }
}
