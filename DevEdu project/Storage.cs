using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DevEdu_project
{
    [Serializable]
    public class Storage
    {
        //public List<AFigure> figureList = new List<AFigure>();
        public  List<AFigure> _figureList = new List<AFigure>();
        private static Storage _instance;
        public static Storage GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Storage();
            }
            return _instance;
        }
        public void figureListCreate()
        {
            _figureList = new List<AFigure>();
        }
        public List<AFigure> SaveFigures(AFigure figure)
        {
            _figureList.Add(figure);
            return _figureList;
        }
    }
}
