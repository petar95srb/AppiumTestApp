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
    public partial class Add_Phone : Form
    {
        public string PhoneName;
        public string PlatformName;
        public string PlatformVersion;
        public Add_Phone(PhoneConfig phoneConfig)
        {
            InitializeComponent();

            if (phoneConfig != null)
            {
                textBox1.Text = phoneConfig.DeviceName;
                textBox2.Text = phoneConfig.PlatformName;
                textBox3.Text = phoneConfig.PlatformVersion;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text))
                return;

            PhoneName = textBox1.Text;
            PlatformName = textBox2.Text;
            PlatformVersion = textBox3.Text;

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
