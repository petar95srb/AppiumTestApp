using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomaticTesting
{
    public class PhoneConfig
    {
        private string _deviceName;
        private string _platformName;
        private string _platformVersion;

        public string DeviceName
        {
            get
            {
                return _deviceName;
            }
        }

        public string PlatformName
        {
            get
            {
                return _platformName;
            }
        }

        public string PlatformVersion
        {
            get
            {
                return _platformVersion;
            }
        }

        public PhoneConfig(string deviceName, string platformName, string platformVersion)
        {
            _deviceName = deviceName;
            _platformName = platformName;
            _platformVersion = platformVersion;
        }

        public PhoneConfig(JObject config)
        {
            _deviceName = (string)config["deviceName"];
            _platformName = (string)config["platformName"];
            _platformVersion = (string)config["platformVersion"];
        }
    }
}
