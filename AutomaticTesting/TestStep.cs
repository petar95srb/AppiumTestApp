using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomaticTesting
{

    public class TestStep
    {
        private UIElement _uIElement;
        private TestStepType _testStepType;
        private string _inputValue;

        private Vector2 _touchCordinates;

        public TestStep(JObject step)
        {
            string getElementBy = (string)step["by"];
            string getElementByValue = (string)step["elementName"];
            string testType = (string)step["testType"];

            _uIElement = UIElement.GetElement(getElementByValue, UIElement.ParseFindElementBy(getElementBy, getElementByValue));
            _testStepType = TestStep.ParseTestStepType(testType);

            if(_testStepType == TestStepType.INPUT)
            {
                _inputValue = (string)step["inputValue"];
            }
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
                default:
                    throw new Exception("teststep type is not correct");
            }
        }

        public void StartTestStep()
        {
            switch (_testStepType)
            {
                case TestStepType.CLICK:
                    _uIElement.Element.Click();
                    break;
                case TestStepType.INPUT:
                    _uIElement.Element.SendKeys(_inputValue);
                    break;
                case TestStepType.SUBMIT:
                    _uIElement.Element.Submit();
                    break;
                default:
                    break;
            }
        }
    }
}
