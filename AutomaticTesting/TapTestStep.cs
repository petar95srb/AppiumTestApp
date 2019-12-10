using Newtonsoft.Json.Linq;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.MultiTouch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomaticTesting
{
    public class TapTestStep : ITestStep
    {
        private Vector2 _tapCordinates;

        public TapTestStep(JObject step)
        {
            double x = (double)step["xtap"];
            double y = (double)step["ytap"];

            _tapCordinates = new Vector2 { X = x, Y = y };
        }
        public override void PerformStep()
        {
            TouchAction touch = new TouchAction(TestAppMain.Instance.Connector.Driver);
            touch.Tap(_tapCordinates.X, _tapCordinates.Y);
            touch.Perform();
        }

        public override JObject GetTestData()
        {
            JObject data = new JObject();

            data["stepName"] = StepName;
            data["testType"] = "tap";
            data["xtap"] = _tapCordinates.X;
            data["xtap"] = _tapCordinates.Y;

            return data;
        }
    }
}
