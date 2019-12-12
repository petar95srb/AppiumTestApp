using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomaticTesting
{
    public class AppConfig
    {
        private string _appPackage;
        private string _appActivity;

        public string AppPackage
        {
            get
            {
                return _appPackage;
            }
        }

        public string AppActivity
        {
            get
            {
                return _appActivity;
            }
        }

        public AppConfig(string appPackage, string appActivity)
        {
            _appPackage = appPackage;
            _appActivity = appActivity;
        }

        public AppConfig(JObject config)
        {
            _appPackage = (string)config["appPackage"];
            _appActivity = (string)config["appActivity"];
        }


        public void StartApp()
        {
          
        }

        public JObject GetAsJson()
        {
            JObject data = new JObject();
            data["appPackage"] = _appPackage;
            data["appActivity"] = _appActivity;

            return data;
        }
    }
}
