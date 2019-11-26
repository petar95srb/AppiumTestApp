using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomaticTesting
{
    public enum TestStepType
    {
        CLICK,
        INPUT,
        SUBMIT,
        TAP,
        SWIPE
    }

    public class Vector2
    {
        private double _x;
        private double _y;

        public double X
        {
            get
            {

                return _x;
            }
            set
            {
                _x = value;
            }
        }

        public double Y
        {
            get
            {

                return _y;
            }
            set
            {
                _y = value;
            }
        }
    }

    public abstract class ITestStep
    {
        public abstract void PerformStep();

        private TestStepType _testStepType;
        public TestStepType TestStepType
        {
            get
            {
                return _testStepType;
            }
        }

        public static ITestStep CreateTestStep(JObject step)
        {
            string testType = (string)step["testType"];

            TestStepType type = ITestStep.ParseTestStepType(testType);

            ITestStep testStep = null;

            switch (type)
            {
                case TestStepType.CLICK:
                    testStep = new ClickTestStep(step);
                    break;
                case TestStepType.INPUT:
                    break;
                case TestStepType.SUBMIT:
                    break;
                case TestStepType.TAP:
                    break;
                case TestStepType.SWIPE:
                    break;
                default:
                    break;
            }

            testStep._testStepType = type;

            return testStep;

        }

        private static TestStepType ParseTestStepType(string value)
        {
            switch (value)
            {
                case "click":
                    return TestStepType.CLICK;
                case "input":
                    return TestStepType.INPUT;
                case "submit":
                    return TestStepType.SUBMIT;
                case "tap":
                    return TestStepType.TAP;
                case "swipe":
                    return TestStepType.SWIPE;
                default:
                    throw new Exception("teststep type is not correct");
            }
        }
    }
}
