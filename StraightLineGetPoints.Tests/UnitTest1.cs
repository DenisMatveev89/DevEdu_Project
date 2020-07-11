using DevEdu_project;
using DevEdu_project.Figure;
using NUnit.Framework;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http.Headers;
using Rectangle = DevEdu_project.Rectangle;

namespace StraightLineGetPoints.Tests
{
    public class Tests
    {
        static AFigure Figure;
        [SetUp]
        public void Setup()
        {
        }
        [TestCase(1, 1, 1, 5, 5)]
        [TestCase(2, 0, 0, 0, 0)]
        [TestCase(3, 0, 0, 2, 2)]
        [TestCase(4, 1, 1, 5, 7)]
        public void RectangleGetPointsTest(int i, int x1, int y1, int x2, int y2)
        {
            
            Figure = new Rectangle(x1, y1, x2, y2);
            
            RectangleMoks rectMocks = new RectangleMoks();
            
            List<Point> Exp = rectMocks.Get(i);
            List<Point> Act = Figure.GetPoints();

            CollectionAssert.AreEqual(Exp, Act);
        }
        [TestCase(1, 1, 1, 5, 5)]
        [TestCase(2, 0, 0, 0, 0)]
        [TestCase(3, 0, 0, 2, 2)]
        public void RectangleSquarGetPointsTest(int i, int x1, int y1, int x2, int y2)
        {

            Figure = new RectangleSquar(x1, y1, x2, y2);

            RectangleSquarMoks squarMocks = new RectangleSquarMoks();

            List<Point> Exp = squarMocks.Get(i);
            List<Point> Act = Figure.GetPoints();

            CollectionAssert.AreEqual(Exp, Act);
        }
        [TestCase(1, 1, 1, 5, 1)]
        [TestCase(2, 0, 0, 5, 0)]
        [TestCase(3, 0, 0, 0, 0)]
        public void LineGetPointsTest(int i, int x1, int y1, int x2, int y2)
        {
            Figure = new StraightLine(x1, y1, x2, y2);
            lineMoks lineMoks = new lineMoks();

            List<Point> Exp = lineMoks.Get(i);
            List<Point> Act = Figure.GetPoints();

            CollectionAssert.AreEqual(Exp, Act);
        }

    }
}
