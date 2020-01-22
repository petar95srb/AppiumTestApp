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
    public partial class Add_Step : Form
    {
        public ITestStep TestStep;
        public bool New = true;
        public Add_Step(ITestStep testStep)
        {
            InitializeComponent();

            if(testStep != null)
            {
                New = false;
                JObject data = testStep.GetTestData();

                string testType = (string)data["testType"];
                textBox1.Text = (string)data["stepName"];

                if(testType.Equals("swipe") || testType.Equals("tap"))
                {
                    if(testType.Equals("tap"))
                    {
                        comboBox2.SelectedIndex = 3;

                        textBox4.Text = (string)data["xtap"]; 
                        textBox5.Text = (string)data["xtap"]; 
                    }
                    else
                    {
                        comboBox2.SelectedIndex = 4;

                        textBox4.Text = (string)data["xSwipeStart"];
                        textBox5.Text = (string)data["ySwipeStart"];

                        textBox6.Text = (string)data["xSwipeStop"];
                        textBox7.Text = (string)data["ySwipeStop"];
                    }
                }
                else
                {
                    comboBox1.SelectedItem = (string)data["by"];

                    textBox2.Text = (string)data["elementName"];

                    comboBox2.SelectedItem = testType;

                    if(testType.Equals("input"))
                    {
                        textBox3.Text = (string)data["inputValue"];
                    }
                }
            }
            else
                comboBox2.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(TestStep != null)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            JObject step = new JObject();
            step["stepName"] = textBox1.Text;
            step["testType"] = (string)comboBox2.SelectedItem;
            if(comboBox2.SelectedItem.Equals("tap") || comboBox2.SelectedItem.Equals("swipe"))
            {
                if (comboBox2.SelectedItem.Equals("tap"))
                {
                    step["xtap"] = textBox4.Text;
                    step["ytap"] = textBox5.Text;
                }
                else
                {
                    step["xSwipeStart"] = textBox4.Text;
                    step["ySwipeStart"] = textBox5.Text;

                    step["xSwipeStop"] = textBox6.Text;
                    step["ySwipeStop"] = textBox7.Text;
                }
            }
            else
            {
                step["by"] = (string)comboBox1.SelectedItem;
                step["elementName"] = textBox2.Text;

                if (comboBox2.SelectedItem.Equals("input"))
                {
                    step["inputValue"] = textBox3.Text;
                }
            }

            TestStep = ITestStep.CreateTestStep(step);

            try
            {
                TestStep.PerformStep();
            }catch(Exception g)
            {
                MessageBox.Show("Test Fail: " + g.Message, "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TestStep = null;
                return;
            }

            MessageBox.Show("Test Succ", "Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox2.SelectedItem.Equals("click") || comboBox2.SelectedItem.Equals("submit"))
            {
                textBox3.Visible = false;

                comboBox1.Visible = true;
                textBox2.Visible = true;

                textBox4.Visible = false;
                textBox5.Visible = false;

                textBox6.Visible = false;
                textBox7.Visible = false;
            }
            else if(comboBox2.SelectedItem.Equals("input"))
            {
                textBox3.Visible = true;

                comboBox1.Visible = true;
                textBox2.Visible = true;

                textBox4.Visible = false;
                textBox5.Visible = false;

                textBox6.Visible = false;
                textBox7.Visible = false;
            }
            else if(comboBox2.SelectedItem.Equals("tap"))
            {
                textBox3.Visible = false;
                comboBox1.Visible = false;
                textBox2.Visible = false;

                textBox4.Visible = true;
                textBox5.Visible = true;

                textBox6.Visible = false;
                textBox7.Visible = false;
            }
            else
            {
                textBox3.Visible = false;
                comboBox1.Visible = false;
                textBox2.Visible = false;

                textBox4.Visible = true;
                textBox5.Visible = true;

                textBox6.Visible = true;
                textBox7.Visible = true;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
