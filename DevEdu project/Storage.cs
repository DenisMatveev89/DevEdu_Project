﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DevEdu_project
{
    public class Storage
    {        
        public List<AFigure> figureList = new List<AFigure>();

        public List<AFigure> saveFigures(AFigure figure)
        {
            figureList.Add(figure);
            return figureList;
        }
    }
}