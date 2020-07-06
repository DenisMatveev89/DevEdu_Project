﻿using DevEdu_project.Figure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Documents;
using System.Windows.Forms;
using Color = System.Drawing.Color;

namespace DevEdu_project
{
    public partial class BetterThanPhotoshop : Form
    {
        //Объявляем интерфейс IFigure
        static IFigure figure;

        //Эти классы будут внутри методов SelectFigure
        //Line line = new Line();
        Ellipse ellips = new Ellipse();
        Rectangle rectangle = new Rectangle();
        Triangle triangle = new Triangle();
        Dialog dialog = new Dialog();

        Color currentColor = Color.Black;
        private bool mousePress;
        string ToolButton = "pencil"; //кнопка выбора инструмента рисования

        Point CurrentPoint;
        Point PrevPoint;

        public BetterThanPhotoshop()
        {
            InitializeComponent();
        }

        private void BetterThanPhotoshop_Load(object sender, EventArgs e)
        {
            StaticBitmap.Bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            StaticBitmap.TmpBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            CurrentPoint = e.Location;
            PrevPoint = e.Location;
            mousePress = true;
            
        }

        private void pictureBox_MouseMove_1(object sender, MouseEventArgs e)
        {            
            if (mousePress)
            {
                switch (ToolButton)
                {
                    case "pencil":
                        PrevPoint = CurrentPoint;
                        StaticBitmap.Copy();
                        SelectLine(PrevPoint, CurrentPoint);
                                                  
                            //pictureBox1.Image = line.DrawLine(PrevPoint.X, PrevPoint.Y, CurrentPoint.X, CurrentPoint.Y, currentColor);
                        StaticBitmap.Update();
                        break;

                    case "line":
                        CurrentPoint = e.Location;
                        StaticBitmap.Copy();
                        SelectLine(PrevPoint, CurrentPoint);

                        //StraightLine.Draw(figure.GetPoints(), currentColor); // так было у Максима

                        //pictureBox1.Image = line.DrawLine(PrevPoint.X, PrevPoint.Y, CurrentPoint.X, CurrentPoint.Y, currentColor);
                        break;

                    case "ellipse":
                        CurrentPoint = e.Location;
                        StaticBitmap.Copy();
                        pictureBox1.Image = ellips.DrawEllipse(PrevPoint.X, PrevPoint.Y, CurrentPoint.X, CurrentPoint.Y, currentColor);                                            
                        break;
                    case "circle":
                        CurrentPoint = e.Location;
                        StaticBitmap.Copy();
                        pictureBox1.Image = ellips.DrawCircle(PrevPoint.X, PrevPoint.Y, CurrentPoint.X, CurrentPoint.Y, currentColor);
                        break;
                    case "rectangle":
                        //прямоугольник
                        CurrentPoint = e.Location;
                        StaticBitmap.Copy();
                        pictureBox1.Image = rectangle.DrawRectangle(PrevPoint.X, PrevPoint.Y, CurrentPoint.X, CurrentPoint.Y, currentColor);
                        break;

                    case "square":
                        //квадрат
                        CurrentPoint = e.Location;
                        StaticBitmap.Copy();
                        pictureBox1.Image = rectangle.DrawSquare(PrevPoint.X, PrevPoint.Y, CurrentPoint.X, CurrentPoint.Y, currentColor);
                        break;

                    case "arbirtrary triangle":
                        //произвольный треугольник по трем точкам
                        break;

                    case "isosceles triangle":
                        //равнобедренный треугольник по одной из граней
                        CurrentPoint = e.Location;
                        StaticBitmap.Copy();
                        triangle.IsoscelesTriangle(PrevPoint.X, PrevPoint.Y, CurrentPoint.X, CurrentPoint.Y, currentColor);
                        pictureBox1.Image = StaticBitmap.TmpBitmap;
                        break;

                    case "right triangle":
                        //прямоугольный треугольник по гипотенузе
                        CurrentPoint = e.Location;
                        StaticBitmap.Copy();
                        triangle.RightTriangle(PrevPoint.X, PrevPoint.Y, CurrentPoint.X, CurrentPoint.Y, currentColor);
                        pictureBox1.Image = StaticBitmap.TmpBitmap;
                        break;

                    case "equilateral triangle":
                        //равносторонний треугольник по одной стороне
                        CurrentPoint = e.Location;
                        StaticBitmap.Copy();
                        triangle.EquilateralTriangle(PrevPoint.X, PrevPoint.Y, CurrentPoint.X, CurrentPoint.Y, currentColor);
                        pictureBox1.Image = StaticBitmap.TmpBitmap;
                        break;
                }
            }
        }

        public void SelectLine(Point Start, Point End)
        {
            //figure = new StraightLine(); - эта строка нам понадобится потом, когда разберёмся с интерфейсами
            
            //Создаем экземпляр класса линии (это класс-наследник IFigure)
            StraightLine line = new StraightLine();

            //Задаем координаты
            line.StartPoint = Start;
            line.EndPoint = End;

            //Вызываем математику: метод, который сохраняет в лист точки нашей линии
            List<Point> finalLine = line.GetPoints();

            //Берем лист с полученными точками и передаем его в метод Draw,
            //который проходится по листу и рисует каждую точку
            pictureBox1.Image = StaticBitmap.Draw(finalLine, currentColor);
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            CurrentPoint = e.Location;
            mousePress = false;
            StaticBitmap.Update();
        }
        #region ToolBox
        private void Pencil_Click(object sender, EventArgs e)
        {
            ToolButton = "pencil";
        }

        private void LineButton_Click(object sender, EventArgs e)
        {
            ToolButton = "line";
        }        

        private void RectangleDropDownButton1_Click(object sender, EventArgs e)
        {
            ToolButton = "rectangle";
        }

        private void rectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolButton = "rectangle";
        }

        private void squareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolButton = "square";
        }

        private void triangleDropDownButton1_Click(object sender, EventArgs e)
        {
            ToolButton = "arbirtrary triangle"; //произвольный треугольник по трем точкам
        }

        private void arbitraryTriangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolButton = "arbirtrary triangle"; //произвольный треугольник по трем точкам
        }

        private void isoscelesTriangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolButton = "isosceles triangle"; //равнобедренный треугольник по одной из граней
        }

        private void rightTriangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolButton = "right triangle"; //прямоугольный треугольник по гипотенузе
        }

        private void equilateralTriangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolButton = "equilateral triangle"; //равносторонний треугольник по одной стороне
        }
        private void EllipseButton_Click_1(object sender, EventArgs e)
        {
            ToolButton = "ellipse";
        }

        private void ellipseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolButton = "ellipse";
        }

        private void circleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolButton = "circle";
        }
        #endregion

        #region Color
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            currentColor = Color.Red;
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            currentColor = Color.Black;
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            currentColor = Color.Green;
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            currentColor = Color.Yellow;
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            currentColor = Color.Blue;
        }



        #endregion

        #region Menu
        //Menu Exit
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //Menu SaveAs
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null) //если в pictureBox есть изображение
            {
                dialog.SaveDialog();
            }
        }
        //Create new
        private void clearCanvasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventNew();       
        }
        //Application Closed
        private void BetterThanPhotoshop_FormClosed(object sender, FormClosedEventArgs e)
        {
            EventClose();
            Application.Exit();
        }
        #endregion

        private void EventClose()
        {
            if (pictureBox1.Image != null) //если в pictureBox есть изображение
            {
                DialogResult result = dialog.NewDialog();
                switch (result)
                {
                    case DialogResult.Yes:
                        dialog.SaveDialog();
                        break;
                    case DialogResult.No:
                        Application.Exit();
                        break;
                    case DialogResult.Cancel:
                        break;
                }
            }
            Application.Exit();
        }

        private void EventNew()
        {
            if (pictureBox1.Image != null) //если в pictureBox есть изображение
            {
                DialogResult result = dialog.NewDialog();
                switch (result)
                {
                    case DialogResult.Yes:
                        dialog.SaveDialog();
                        pictureBox1.Image = null;
                        StaticBitmap.Bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                        break;
                    case DialogResult.No:
                        pictureBox1.Image = null;
                        StaticBitmap.Bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                        break;
                    case DialogResult.Cancel:
                        break;
                }
            }
        }

       
    }
}

