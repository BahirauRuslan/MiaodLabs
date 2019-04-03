using System;
using System.Windows.Forms;

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
                var client = SolidWorksClient.GetInstance();
                Lab1Drawing.Draw(client);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
