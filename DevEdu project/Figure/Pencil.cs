using DevEdu_project.GetPoints;
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
               
    }
}
