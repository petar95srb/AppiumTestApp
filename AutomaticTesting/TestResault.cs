using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomaticTesting
{
    public enum ResaultType
    {
        SCREENSHOT,
        VALUE
    }
    public class TestResault
    {
        private JObject _config;
        public JObject Config
        {
            get
            {
                return _config;
            }
        }

        private ResaultType _resaultType;

        private UIElement _uIElement;
        private string _by;
        private string _name;
        private string _value;

        private string _screenShotFileName;

        private bool _screenShooAfterEveryStep;
        public bool ScreenShooAfterEveryStep
        {
            get
            {
                return _screenShooAfterEveryStep;
            }
        }

        public TestResault(JObject config)
        {
            string resaultType = (string)config["resaultType"];

            _resaultType = TestResault.ParseResaultType(resaultType);

            string getElementBy = (string)config["by"];
            string getElementByValue = (string)config["elementName"];

            _by = getElementBy;
            _name = getElementByValue;

            _screenShooAfterEveryStep = (bool)config["screenShootAfterEveryStep"];

            _uIElement = UIElement.GetElement(getElementByValue, UIElement.ParseFindElementBy(getElementBy, getElementByValue));

            if (_resaultType == ResaultType.VALUE)
            {
                _value = (string)config["resultValue"];
            }
            else
            {
                _screenShotFileName = (string)config["screenShotFileName"];
            }
        }

        private static ResaultType ParseResaultType(string value)
        {
            switch (value)
            {
                case "screenShot":
                    return ResaultType.SCREENSHOT;
                case "value":
                    return ResaultType.VALUE;
                default:
                    throw new Exception("resault type is incorect");
            }
        }

        public string CheckResault()
        {
            if(_resaultType == ResaultType.VALUE)
            {
                return "value: " + _uIElement.Element.Text + " , Excepted value: " + _value;
            }
            else
            {
                _uIElement.Element.GetScreenshot().SaveAsFile(_screenShotFileName);
                return _screenShotFileName;
            }
        }

        public void ScreenShot(string fileName)
        {
            _uIElement.Element.GetScreenshot().SaveAsFile(fileName);
        }

        public JObject GetAsJson()
        {
            JObject data = new JObject();
            data["resaultType"] = _resaultType == ResaultType.SCREENSHOT? "screenShot" : "value";
            data["by"] = _by;
            data["elementName"] = _name;
            data["screenShootAfterEveryStep"] = _screenShooAfterEveryStep;

            if(_resaultType == ResaultType.VALUE)
                data["resultValue"] = _value;

            return data;
        }
    }
}
