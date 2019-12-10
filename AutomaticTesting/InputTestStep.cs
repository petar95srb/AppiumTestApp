using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomaticTesting
{
    public class InputTestStep : ITestStep
    {
        private UIElement _uIElement;
        private string _inputValue;
        private string _by;
        private string _name;

        public InputTestStep(JObject step)
        {
            string getElementBy = (string)step["by"];
            string getElementByValue = (string)step["elementName"];
            _inputValue = (string)step["inputValue"];
            _by = getElementBy;
            _name = getElementByValue;

            _uIElement = UIElement.GetElement(getElementByValue, UIElement.ParseFindElementBy(getElementBy, getElementByValue));
        }
        public override void PerformStep()
        {
            _uIElement.Element.SendKeys(_inputValue);
        }

        public override JObject GetTestData()
        {
            JObject data = new JObject();

            data["stepName"] = StepName;
            data["testType"] = "input";
            data["by"] = _by;
            data["elementName"] = _name;
            data["inputValue"] = _inputValue;

            return data;
        }
    }
}
