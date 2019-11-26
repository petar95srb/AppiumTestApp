using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomaticTesting
{
    public class Test
    {
        private List<ITestStep> _testSteps;

        public Test(JArray steps)
        {
            _testSteps = new List<ITestStep>();

            for (int i = 0; i < steps.Count; i++)
            {
                _testSteps.Add(ITestStep.CreateTestStep((JObject)steps[i]));
            }
        }


        public void startTest()
        {
            for (int i = 0; i < _testSteps.Count; i++)
            {
                _testSteps[i].PerformStep();
                if (TestAppMain.Instance.TestResault.ScreenShooAfterEveryStep)
                    TestAppMain.Instance.TestResault.ScreenShot("Step" + i.ToString() + ".png");
            }
        }
    }
}
