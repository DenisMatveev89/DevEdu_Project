﻿using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using Newtonsoft.Json;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using DocumentFormat.OpenXml.Drawing;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using DevEdu_project.Factory;
using System.Drawing;

namespace DevEdu_project
{
    public class Dialog
    {
        public void SaveDialog()
        {
            SaveFileDialog savedialog = new SaveFileDialog();
            savedialog.Title = "Save image as...";
            savedialog.OverwritePrompt = true;
            savedialog.CheckPathExists = true;

            savedialog.Filter = "Image Files(*.PNG)|*.PNG|All files (*.*)|*.*";
            savedialog.ShowHelp = true;
            if (savedialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    BitmapSingletone.GetInstance()._bitmap.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                }
                catch
                {
                    MessageBox.Show("Unable to save image", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void SaveSourceDialog()
        {
            SaveFileDialog savedialog = new SaveFileDialog();
            savedialog.Title = "Save source as...";
            savedialog.OverwritePrompt = true;
            savedialog.CheckPathExists = true;

            savedialog.Filter = "Image Files(*.btn)|*.btn|All files (*.*)|*.*";
            savedialog.ShowHelp = true;
            if (savedialog.ShowDialog() == DialogResult.OK)
            {
                BinaryFormatter serializerFig = new BinaryFormatter();
                string path = savedialog.FileName;
                List <AFigure> listSave = BitmapSingletone.GetInstance()._figureList;
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    serializerFig.Serialize(fs, listSave);
                }
            }
        }
        public void OpenSourceDialog()
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Open source...";
            open.CheckPathExists = true;
            open.Filter = "Image Files(*.btn)|*.btn|All files (*.*)|*.*";
            if (open.ShowDialog() == DialogResult.OK)
            {
                string path = open.FileName;
                BinaryFormatter serializerFig = new BinaryFormatter();
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    //BitmapSingletone.GetInstance()._tmpBitmap = BitmapSingletone.GetInstance()._bitmap;// эта строчка важна при открытии исходников
                    
                    BitmapSingletone.GetInstance().Clear();
                    BitmapSingletone.GetInstance()._figureList = null;
                    BitmapSingletone.GetInstance()._figureList = (List<AFigure>)serializerFig.Deserialize(fs);
                    BitmapSingletone.GetInstance().DrawAllFigures();
                    BitmapSingletone.GetInstance().Copy();
                    BitmapSingletone.GetInstance().FillAllFigures();
                    BitmapSingletone.GetInstance().CopyFromFill();
                    BitmapSingletone.GetInstance().Update();
                }
            }
        }
        public DialogResult NewDialog()
        {
            string message = "Do you want to save changes?";
            string caption = "Saving changes";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            System.Windows.MessageBoxImage icon = System.Windows.MessageBoxImage.Warning;
            return MessageBox.Show(message, caption, buttons, (MessageBoxIcon)icon);
        }
    }
}
