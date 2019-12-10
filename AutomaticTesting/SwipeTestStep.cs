using Newtonsoft.Json.Linq;
using OpenQA.Selenium.Appium.MultiTouch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomaticTesting
{
    public class SwipeTestStep : ITestStep
    {
        private Vector2 _swipeStartCordinates;
        private Vector2 _swipeStopCordinates;

        public SwipeTestStep(JObject step)
        {
            double xStart = (double)step["xSwipeStart"];
            double yStart = (double)step["ySwipeStart"];

            _swipeStartCordinates = new Vector2 { X = xStart, Y = yStart };

            double xStop = (double)step["xSwipeStop"];
            double yStop = (double)step["ySwipeStop"];

            _swipeStopCordinates = new Vector2 { X = xStop, Y = yStop };
        }
        public override void PerformStep()
        {
            TouchAction touch = new TouchAction(TestAppMain.Instance.Connector.Driver);

            touch.Press(_swipeStartCordinates.X, _swipeStartCordinates.Y);
            touch.MoveTo(_swipeStopCordinates.X, _swipeStopCordinates.Y);
            touch.Release();
            touch.Perform();
        }

        public override JObject GetTestData()
        {
            JObject data = new JObject();

            data["stepName"] = StepName;
            data["testType"] = "swipe";
            data["xSwipeStart"] = _swipeStartCordinates.X;
            data["ySwipeStart"] = _swipeStartCordinates.Y;

            data["xSwipeStop"] = _swipeStopCordinates.X;
            data["ySwipeStop"] = _swipeStopCordinates.Y;

            return data;
        }
    }
}
