using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomaticTesting
{
    public class ClickTestStep : ITestStep
    {
        private UIElement _uIElement;

        private string _by;
        private string _name;

        public ClickTestStep(JObject step)
        {
            string getElementBy = (string)step["by"];
            string getElementByValue = (string)step["elementName"];

            _by = getElementBy;
            _name = getElementByValue;

            _uIElement = UIElement.GetElement(getElementByValue, UIElement.ParseFindElementBy(getElementBy, getElementByValue));
        }

        public override JObject GetTestData()
        {
            JObject data = new JObject();

            data["stepName"] = StepName;
            data["testType"] = "click";
            data["by"] = _by;
            data["elementName"] = _name;

            return data;
        }

        public override void PerformStep()
        {
            _uIElement.Element.Click();
        }
    }
}
