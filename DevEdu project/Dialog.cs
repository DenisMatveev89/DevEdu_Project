using System.Windows.Forms;

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
                    StaticBitmap.Bitmap.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                }
                catch
                {
                    MessageBox.Show("Unable to save image", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
