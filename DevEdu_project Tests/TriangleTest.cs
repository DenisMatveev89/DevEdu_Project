using DevEdu_project.Figure;
using NUnit.Framework;
using StraightLineGetPoints.Tests;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace DevEdu_project_Tests
{
    public class TriangleTest
    {
        [TestCase(1, 1, 2, 6, 7)]
        [TestCase(2, 6, 3, 3, 1)]
        [TestCase(3, 3, 1, 1, 3)]

        public void TriangleRightTest(int i, int x1, int y1, int x2, int y2)
        {

            TriangleRight triangleRight = new TriangleRight();
            triangleRight._startPoint = new Point(x1, y1);
            triangleRight._endPoint = new Point(x2, y2);

            TriangleRightMoks triangleRightMoks = new TriangleRightMoks();

            List<Point> Exp = triangleRightMoks.Get(i);
            List<Point> Act = triangleRight.GetPoints();

            CollectionAssert.AreEqual(Exp, Act);

        }

        [TestCase(1, 6, 2, 10, 6)]
        [TestCase(2, 5, 7, 8, 4)]
        public void TriangleIsoscelesTest(int i, int x1, int y1, int x2, int y2)
        {
            TriangleIsosceles triangleIsosceles = new TriangleIsosceles();
            triangleIsosceles._startPoint = new Point(x1, y1);
            triangleIsosceles._endPoint = new Point(x2, y2);

            TriangleIsoscelesMoks triangleIsoscelesMoks = new TriangleIsoscelesMoks();

            List<Point> Exp = triangleIsoscelesMoks.Get(i);
            List<Point> Act = triangleIsosceles.GetPoints();
            CollectionAssert.AreEqual(Exp, Act);

        }

       
        [TestCase(1, 6, 1, 7, 3)]
        [TestCase(2, 6, 6, 4, 9)]
        [TestCase(3, 4, 2, 4, 4)]
        public void TriangleEquilateralTest(int i, int x1, int y1, int x2, int y2)
        {
            TriangleEquilateral triangleEquilateral = new TriangleEquilateral();
            triangleEquilateral._startPoint = new Point(x1, y1);
            triangleEquilateral._endPoint = new Point(x2, y2);

            TriangleEquilateralMoks triangleEquilateralMoks = new TriangleEquilateralMoks();

            List<Point> Exp = triangleEquilateralMoks.Get(i);
            List<Point> Act = triangleEquilateral.GetPoints();
            CollectionAssert.AreEqual(Exp, Act);

        }
    }
}
