using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEdu_project.GetPoints
{
    public interface IGetPoints
    {
        List<Point> GetPoints();
        void Update();
        void Update(Point startPoint, Point ebdPoint);
    }
}
