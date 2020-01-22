using AutomaticTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AndroidTestAppGUI
{
    public partial class Form1 : Form
    {
        private Config _config = null;
        private PhoneConfig _phoneConfig = null;
        private AppConfig _appConfig = null;
        private TestResault _testResault = null;
        public Form1()
        {
            InitializeComponent();

            button9.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add_Envierment_varibles add_Envierment_Varibles = new Add_Envierment_varibles(_config);
            DialogResult rs = add_Envierment_Varibles.ShowDialog();
            if(rs == DialogResult.OK)
            {
                _config = new Config();
                _config.AndroidSdkPath = add_Envierment_Varibles.AndroidSDKPath;
                _config.AppiumBinaryPath = add_Envierment_Varibles.AppiumPath;
                _config.AndroidSdkPath = add_Envierment_Varibles.AndroidSDKPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Add_Phone add_Phone = new Add_Phone(_phoneConfig);
            DialogResult rs = add_Phone.ShowDialog();
            if (rs == DialogResult.OK)
            {
                _phoneConfig = new PhoneConfig(add_Phone.PhoneName, add_Phone.PlatformName, add_Phone.PlatformVersion);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Add_Application add_Application = new Add_Application(_appConfig);
            DialogResult rs = add_Application.ShowDialog();
            if (rs == DialogResult.OK)
            {
                _appConfig = new AppConfig(add_Application.AppPackage, add_Application.AppActivity);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (TestAppMain.Instance.InitTest(_config, _phoneConfig, _appConfig, _testResault))
            {
                MessageBox.Show("Connection is sucsesfull", "connection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Connection is not correct", "connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            TestAppMain.Instance.Test.startTest();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            JObject data = TestAppMain.Instance.GetAsJson();

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Title = "Save an Json";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                using (StreamWriter file = File.CreateText(saveFileDialog1.FileName))
                using (JsonTextWriter writer = new JsonTextWriter(file))
                {
                    data.WriteTo(writer);
                }
            }

        }

        private void StepList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void StepList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Add_Step add_step = new Add_Step(StepList.SelectedIndex < 0 ? null : TestAppMain.Instance.Test.TestSteps[StepList.SelectedIndex]);
            DialogResult rs = add_step.ShowDialog();
            if (rs == DialogResult.OK)
            {
                if (add_step.New)
                {
                    TestAppMain.Instance.AddTestStep(add_step.TestStep);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Add_Step add_step = new Add_Step(null);
            DialogResult rs = add_step.ShowDialog();
            if (rs == DialogResult.OK)
            {
                if(add_step.New)
                {
                    TestAppMain.Instance.AddTestStep(add_step.TestStep);
                    StepList.Items.Add(add_step.TestStep);
                    button9.Enabled = true;
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

            Set_Resault set_Resault = new Set_Resault(_testResault);
            DialogResult rs = set_Resault.ShowDialog();
            if (rs == DialogResult.OK)
            {
                _testResault = set_Resault.TestResault;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if(StepList.SelectedIndex != -1)
            {
                TestAppMain.Instance.RemoveTestStep(StepList.SelectedIndex);
                StepList.Items.RemoveAt(StepList.SelectedIndex);

                if (StepList.Items.Count == 0)
                    button9.Enabled = true;
            }
        }
    }
}
