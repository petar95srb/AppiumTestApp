using AutomaticTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AndroidTestAppGUI
{
    public partial class Add_Application : Form
    {
        public string AppPackage;
        public string AppActivity;
        public Add_Application(AppConfig appConfig)
        {
            InitializeComponent();
        
            if(appConfig != null)
            {
                textBox1.Text = appConfig.AppPackage;
                textBox2.Text = appConfig.AppActivity;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
                return;

            AppPackage = textBox1.Text;
            AppActivity = textBox2.Text;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
