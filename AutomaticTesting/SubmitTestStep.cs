using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomaticTesting
{
    public class SubmitTestStep : ITestStep
    {
        private UIElement _uIElement;
        private string _by;
        private string _name;

        public SubmitTestStep(JObject step)
        {
            string getElementBy = (string)step["by"];
            string getElementByValue = (string)step["elementName"];
            _by = getElementBy;
            _name = getElementByValue;

            _uIElement = UIElement.GetElement(getElementByValue, UIElement.ParseFindElementBy(getElementBy, getElementByValue));
        }
        public override void PerformStep()
        {
            _uIElement.Element.Submit();
        }

        public override JObject GetTestData()
        {
            JObject data = new JObject();

            data["stepName"] = StepName;
            data["testType"] = "submit";
            data["by"] = _by;
            data["elementName"] = _name;

            return data;
        }
    }
}
