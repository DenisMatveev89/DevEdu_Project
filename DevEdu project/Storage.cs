using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DevEdu_project
{
    public class Storage
    {
        //public List<AFigure> figureList = new List<AFigure>();
        public List<AFigure> figureList;
        private static Storage _instance;
        public static Storage GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Storage();
                List<AFigure> figureList = new List<AFigure>();
            }
            return _instance;
        }
        public void FigureListCreate()
        {
            figureList = new List<AFigure>();
        }
        public List<AFigure> SaveFigures(AFigure figure)
        {
            figureList.Add(figure);
            return figureList;
        }
    }
}
