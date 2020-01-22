using AutomaticTesting;
using Newtonsoft.Json.Linq;
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
    public partial class Set_Resault : Form
    {
        public TestResault TestResault = null;
        public bool New = true;
        public Set_Resault(TestResault testResault)
        {
            InitializeComponent();

            if(testResault != null)
            {
                New = false;
                JObject data = testResault.Config;

                comboBox1.SelectedItem = data["resaultType"];
                textBox2.Text = (string)data["by"];
                textBox1.Text = (string)data["elementName"];

                checkBox1.Checked = (bool)data["screenShootAfterEveryStep"];

                if(comboBox1.SelectedItem.Equals("value"))
                {
                    textBox3.Text = (string)data["resaultValue"];
                }

                TestResault = testResault;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            JObject data = new JObject();
            data["resaultType"] = (string)comboBox1.SelectedItem;
            data["by"] = textBox2.Text;
            data["elementName"] = textBox1.Text;
            data["screenShootAfterEveryStep"] = checkBox1.Checked;

            if(comboBox1.SelectedItem.Equals("value"))
            {
                data["resaultValue"] = textBox3.Text;
            }

            TestResault = new TestResault(data);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem.Equals("value"))
            {
                textBox3.Visible = true;
            }
            else
            {
                textBox3.Visible = false;
            }
        }
    }
}
