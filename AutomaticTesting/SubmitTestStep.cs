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

        public SubmitTestStep(JObject step)
        {
            string getElementBy = (string)step["by"];
            string getElementByValue = (string)step["elementName"];

            _uIElement = UIElement.GetElement(getElementByValue, UIElement.ParseFindElementBy(getElementBy, getElementByValue));
        }
        public override void PerformStep()
        {
            _uIElement.Element.Submit();
        }
    }
}
