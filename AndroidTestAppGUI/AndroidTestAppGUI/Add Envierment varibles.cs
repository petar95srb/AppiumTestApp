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
    public partial class Add_Envierment_varibles : Form
    {
        public string NodePath;
        public string AppiumPath;
        public string AndroidSDKPath;

        public Add_Envierment_varibles(Config config)
        {
            InitializeComponent();

            if (config != null)
            {
                textBox1.Text = config.AppiumBinaryPath;
                textBox2.Text = config.NodeBinaryPath;
                textBox3.Text = config.AndroidSdkPath;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text))
                return;

            AppiumPath = textBox1.Text;
            NodePath = textBox2.Text;
            AndroidSDKPath = textBox3.Text;

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
