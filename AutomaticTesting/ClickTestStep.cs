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

        public ClickTestStep(JObject step)
        {
            string getElementBy = (string)step["by"];
            string getElementByValue = (string)step["elementName"];

            _uIElement = UIElement.GetElement(getElementByValue, UIElement.ParseFindElementBy(getElementBy, getElementByValue));
        }
        public override void PerformStep()
        {
            _uIElement.Element.Click();
        }
    }
}
