using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomaticTesting
{
    public class UIElement
    {
        public AppiumWebElement Element
        {
            get
            {
                return TestAppMain.Instance.Connector.Driver.FindElement(_getElementBy);
            }
        }

        private By _getElementBy;

        public static UIElement GetElement(string name, By by)
        {
            UIElement uIElement = null;
            try
            {
                uIElement = new UIElement();
                uIElement._getElementBy = by;

                return uIElement;

            }catch(Exception e)
            {

            }

            return uIElement;
        }

        public static By ParseFindElementBy(string by, string value)
        {
            switch (by)
            {
                case "id":
                    return By.Id(value);
                case "xpath":
                    return By.XPath(value);
                default:
                    throw new Exception("'by' is not correct");
            }
        }
    }
}
