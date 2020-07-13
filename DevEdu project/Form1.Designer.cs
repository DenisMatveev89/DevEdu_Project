namespace DevEdu_project
{
    partial class BetterThanPhotoshop
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BetterThanPhotoshop));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearCanvasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.PencilButton = new System.Windows.Forms.ToolStripButton();
            this.LineButton = new System.Windows.Forms.ToolStripButton();
            this.EllipseButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.ellipseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.circleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RectangleDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.rectangleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.squareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TriangleDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.arbitraryTriangleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.isoscelesTriangleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rightTriangleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.equilateralTriangleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FillColorButton = new System.Windows.Forms.ToolStripButton();
            this.EraserButton = new System.Windows.Forms.ToolStripButton();
            this.AngleButton = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton9 = new System.Windows.Forms.ToolStripButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1427, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearCanvasToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(60, 24);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // clearCanvasToolStripMenuItem
            // 
            this.clearCanvasToolStripMenuItem.Image = global::DevEdu_project.Properties.Resources.createnew;
            this.clearCanvasToolStripMenuItem.Name = "clearCanvasToolStripMenuItem";
            this.clearCanvasToolStripMenuItem.Size = new System.Drawing.Size(169, 26);
            this.clearCanvasToolStripMenuItem.Text = "Create New";
            this.clearCanvasToolStripMenuItem.Click += new System.EventHandler(this.clearCanvasToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Image = global::DevEdu_project.Properties.Resources.save;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(169, 26);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::DevEdu_project.Properties.Resources.exit;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(169, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PencilButton,
            this.LineButton,
            this.EllipseButton,
            this.RectangleDropDownButton1,
            this.TriangleDropDownButton1,
            this.FillColorButton,
            this.EraserButton,
            this.AngleButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 28);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(35, 686);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // PencilButton
            // 
            this.PencilButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.PencilButton.Image = ((System.Drawing.Image)(resources.GetObject("PencilButton.Image")));
            this.PencilButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PencilButton.Name = "PencilButton";
            this.PencilButton.Size = new System.Drawing.Size(32, 24);
            this.PencilButton.Text = "Pencil";
            this.PencilButton.Click += new System.EventHandler(this.Pencil_Click);
            // 
            // LineButton
            // 
            this.LineButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.LineButton.Image = ((System.Drawing.Image)(resources.GetObject("LineButton.Image")));
            this.LineButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LineButton.Name = "LineButton";
            this.LineButton.Size = new System.Drawing.Size(37, 24);
            this.LineButton.Text = "Line";
            this.LineButton.Click += new System.EventHandler(this.LineButton_Click);
            // 
            // EllipseButton
            // 
            this.EllipseButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.EllipseButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ellipseToolStripMenuItem,
            this.circleToolStripMenuItem});
            this.EllipseButton.Image = ((System.Drawing.Image)(resources.GetObject("EllipseButton.Image")));
            this.EllipseButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EllipseButton.Name = "EllipseButton";
            this.EllipseButton.Size = new System.Drawing.Size(37, 24);
            this.EllipseButton.Text = "Ellipse";
            this.EllipseButton.Click += new System.EventHandler(this.EllipseButton_Click_1);
            // 
            // ellipseToolStripMenuItem
            // 
            this.ellipseToolStripMenuItem.Image = global::DevEdu_project.Properties.Resources.oval;
            this.ellipseToolStripMenuItem.Name = "ellipseToolStripMenuItem";
            this.ellipseToolStripMenuItem.Size = new System.Drawing.Size(135, 26);
            this.ellipseToolStripMenuItem.Text = "Ellipse";
            this.ellipseToolStripMenuItem.Click += new System.EventHandler(this.ellipseToolStripMenuItem_Click);
            // 
            // circleToolStripMenuItem
            // 
            this.circleToolStripMenuItem.Image = global::DevEdu_project.Properties.Resources.circle;
            this.circleToolStripMenuItem.Name = "circleToolStripMenuItem";
            this.circleToolStripMenuItem.Size = new System.Drawing.Size(135, 26);
            this.circleToolStripMenuItem.Text = "Circle";
            this.circleToolStripMenuItem.Click += new System.EventHandler(this.circleToolStripMenuItem_Click);
            // 
            // RectangleDropDownButton1
            // 
            this.RectangleDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RectangleDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rectangleToolStripMenuItem,
            this.squareToolStripMenuItem});
            this.RectangleDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("RectangleDropDownButton1.Image")));
            this.RectangleDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RectangleDropDownButton1.Name = "RectangleDropDownButton1";
            this.RectangleDropDownButton1.Size = new System.Drawing.Size(37, 24);
            this.RectangleDropDownButton1.Text = "Rectangle";
            // 
            // rectangleToolStripMenuItem
            // 
            this.rectangleToolStripMenuItem.Image = global::DevEdu_project.Properties.Resources.rectangle;
            this.rectangleToolStripMenuItem.Name = "rectangleToolStripMenuItem";
            this.rectangleToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.rectangleToolStripMenuItem.Text = "Rectangle";
            this.rectangleToolStripMenuItem.Click += new System.EventHandler(this.rectangleToolStripMenuItem_Click);
            // 
            // squareToolStripMenuItem
            // 
            this.squareToolStripMenuItem.Image = global::DevEdu_project.Properties.Resources.times_square;
            this.squareToolStripMenuItem.Name = "squareToolStripMenuItem";
            this.squareToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.squareToolStripMenuItem.Text = "Square";
            this.squareToolStripMenuItem.Click += new System.EventHandler(this.squareToolStripMenuItem_Click);
            // 
            // TriangleDropDownButton1
            // 
            this.TriangleDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TriangleDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arbitraryTriangleToolStripMenuItem,
            this.isoscelesTriangleToolStripMenuItem,
            this.rightTriangleToolStripMenuItem,
            this.equilateralTriangleToolStripMenuItem});
            this.TriangleDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("TriangleDropDownButton1.Image")));
            this.TriangleDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TriangleDropDownButton1.Name = "TriangleDropDownButton1";
            this.TriangleDropDownButton1.Size = new System.Drawing.Size(37, 24);
            this.TriangleDropDownButton1.Text = "Triangle";
            // 
            // arbitraryTriangleToolStripMenuItem
            // 
            this.arbitraryTriangleToolStripMenuItem.Name = "arbitraryTriangleToolStripMenuItem";
            this.arbitraryTriangleToolStripMenuItem.Size = new System.Drawing.Size(218, 26);
            this.arbitraryTriangleToolStripMenuItem.Text = "Arbitrary triangle";
            this.arbitraryTriangleToolStripMenuItem.ToolTipText = "произвольный треугольник по трем точкам";
            this.arbitraryTriangleToolStripMenuItem.Click += new System.EventHandler(this.arbitraryTriangleToolStripMenuItem_Click);
            // 
            // isoscelesTriangleToolStripMenuItem
            // 
            this.isoscelesTriangleToolStripMenuItem.Image = global::DevEdu_project.Properties.Resources.img_2020_07_05_16_12_02;
            this.isoscelesTriangleToolStripMenuItem.Name = "isoscelesTriangleToolStripMenuItem";
            this.isoscelesTriangleToolStripMenuItem.Size = new System.Drawing.Size(218, 26);
            this.isoscelesTriangleToolStripMenuItem.Text = "Isosceles triangle";
            this.isoscelesTriangleToolStripMenuItem.ToolTipText = "равнобедренный треугольник по одной из граней";
            this.isoscelesTriangleToolStripMenuItem.Click += new System.EventHandler(this.isoscelesTriangleToolStripMenuItem_Click);
            // 
            // rightTriangleToolStripMenuItem
            // 
            this.rightTriangleToolStripMenuItem.Image = global::DevEdu_project.Properties.Resources.play;
            this.rightTriangleToolStripMenuItem.Name = "rightTriangleToolStripMenuItem";
            this.rightTriangleToolStripMenuItem.Size = new System.Drawing.Size(218, 26);
            this.rightTriangleToolStripMenuItem.Text = "Right triangle";
            this.rightTriangleToolStripMenuItem.ToolTipText = "прямоугольный треугольник по гипотенузе";
            this.rightTriangleToolStripMenuItem.Click += new System.EventHandler(this.rightTriangleToolStripMenuItem_Click);
            // 
            // equilateralTriangleToolStripMenuItem
            // 
            this.equilateralTriangleToolStripMenuItem.Name = "equilateralTriangleToolStripMenuItem";
            this.equilateralTriangleToolStripMenuItem.Size = new System.Drawing.Size(218, 26);
            this.equilateralTriangleToolStripMenuItem.Text = "Equilateral triangle";
            this.equilateralTriangleToolStripMenuItem.ToolTipText = "равносторонний треугольник по одной стороне";
            this.equilateralTriangleToolStripMenuItem.Click += new System.EventHandler(this.equilateralTriangleToolStripMenuItem_Click);
            // 
            // FillColorButton
            // 
            this.FillColorButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.FillColorButton.Image = ((System.Drawing.Image)(resources.GetObject("FillColorButton.Image")));
            this.FillColorButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FillColorButton.Name = "FillColorButton";
            this.FillColorButton.Size = new System.Drawing.Size(37, 24);
            this.FillColorButton.Text = "Color";
            // 
            // EraserButton
            // 
            this.EraserButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.EraserButton.Image = ((System.Drawing.Image)(resources.GetObject("EraserButton.Image")));
            this.EraserButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EraserButton.Name = "EraserButton";
            this.EraserButton.Size = new System.Drawing.Size(37, 24);
            this.EraserButton.Text = "Eraser";
            this.EraserButton.Click += new System.EventHandler(this.EraserButton_Click);
            // 
            // AngleButton
            // 
            this.AngleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AngleButton.Image = ((System.Drawing.Image)(resources.GetObject("AngleButton.Image")));
            this.AngleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AngleButton.Name = "AngleButton";
            this.AngleButton.Size = new System.Drawing.Size(37, 24);
            this.AngleButton.Text = "Angle Modify";
            this.AngleButton.Click += new System.EventHandler(this.AngleButton_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton5,
            this.toolStripButton6,
            this.toolStripButton7,
            this.toolStripButton8,
            this.toolStripButton9});
            this.toolStrip2.Location = new System.Drawing.Point(35, 28);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1392, 25);
            this.toolStrip2.TabIndex = 9;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.BackColor = System.Drawing.Color.Red;
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(29, 22);
            this.toolStripButton5.Text = "toolStripButton5";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.BackColor = System.Drawing.Color.Black;
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(29, 22);
            this.toolStripButton6.Text = "toolStripButton6";
            this.toolStripButton6.Click += new System.EventHandler(this.toolStripButton6_Click);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(29, 22);
            this.toolStripButton7.Text = "toolStripButton7";
            this.toolStripButton7.Click += new System.EventHandler(this.toolStripButton7_Click);
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.BackColor = System.Drawing.Color.Yellow;
            this.toolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.toolStripButton8.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton8.Image")));
            this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size(29, 22);
            this.toolStripButton8.Text = "toolStripButton8";
            this.toolStripButton8.Click += new System.EventHandler(this.toolStripButton8_Click);
            // 
            // toolStripButton9
            // 
            this.toolStripButton9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.toolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.toolStripButton9.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton9.Image")));
            this.toolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton9.Name = "toolStripButton9";
            this.toolStripButton9.Size = new System.Drawing.Size(29, 22);
            this.toolStripButton9.Text = "toolStripButton9";
            this.toolStripButton9.Click += new System.EventHandler(this.toolStripButton9_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox1.Location = new System.Drawing.Point(45, 64);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1384, 657);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove_1);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // BetterThanPhotoshop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1427, 714);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1445, 759);
            this.MinimumSize = new System.Drawing.Size(527, 236);
            this.Name = "BetterThanPhotoshop";
            this.RightToLeftLayout = true;
            this.Text = "BTN - Better Than Photoshop";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BetterThanPhotoshop_FormClosed);
            this.Load += new System.EventHandler(this.BetterThanPhotoshop_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton PencilButton;
        private System.Windows.Forms.ToolStripButton LineButton;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripButton toolStripButton8;
        private System.Windows.Forms.ToolStripButton toolStripButton9;
        private System.Windows.Forms.ToolStripDropDownButton TriangleDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem isoscelesTriangleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rightTriangleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arbitraryTriangleToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton FillColorButton;
        private System.Windows.Forms.ToolStripButton EraserButton;
        private System.Windows.Forms.ToolStripButton AngleButton;
        private System.Windows.Forms.ToolStripDropDownButton RectangleDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem rectangleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem squareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem equilateralTriangleToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton EllipseButton;
        private System.Windows.Forms.ToolStripMenuItem ellipseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem circleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearCanvasToolStripMenuItem;
    }
}

