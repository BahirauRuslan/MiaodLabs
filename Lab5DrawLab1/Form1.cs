using System;
using System.Windows.Forms;
using SolidWorks.Interop.swconst;

namespace Lab5DrawLab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.InitializeComponent();
        }

        private void MainButton_Click(object sender, EventArgs e)
        {
            try
            {
                var client = new SolidWorksClient(swDocumentTypes_e.swDocDRAWING);
                Lab1Drawing.Draw(client);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
