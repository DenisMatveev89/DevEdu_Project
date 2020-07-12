﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevEdu_project.Figure;

namespace DevEdu_project.Factory
{
    public class LineFactory : AFactory
    {
        public LineFactory()
        {
            figure = new StraightLine();
        }
    }
}
