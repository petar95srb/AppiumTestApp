using Newtonsoft.Json.Linq;
using OpenQA.Selenium.Appium.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomaticTesting
{
    public class Config
    {
        public const string ANDROID_SDK_ROOT_PATH = "ANDROID_SDK_ROOT";
        private static Config _instance;
        public static Config Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Config();

                return _instance;
            }
        }

        private string _nodeBinaryPath;
        private string _appiumBinaryPath;
        private string _androidSdkPath;

        public Config()
        {
            _nodeBinaryPath = @"C:\Program Files\nodejs\node.exe";
            _appiumBinaryPath = @"C:\Program Files\Appium\resources\app\node_modules\appium\build\lib\main.js";
            _androidSdkPath = @"C:\Program Files (x86)\Android\android-sdk";

            UpdateEnvironmentVariable();
        }

        public void SetConfig(JObject config)
        {
            _nodeBinaryPath = (string)config["nodeBinaryPath"];
            _appiumBinaryPath = (string)config["appiumBinaryPath"];
            _androidSdkPath = (string)config["androidSDKPath"];

            UpdateEnvironmentVariable();
        }

        public void SetConfig(Config config)
        {
            _nodeBinaryPath = config._nodeBinaryPath;
            _appiumBinaryPath = config._appiumBinaryPath;
            _androidSdkPath = config._androidSdkPath;

            UpdateEnvironmentVariable();
        }

        private void UpdateEnvironmentVariable()
        {
            Environment.SetEnvironmentVariable(AppiumServiceConstants.NodeBinaryPath, _nodeBinaryPath);
            Environment.SetEnvironmentVariable(AppiumServiceConstants.AppiumBinaryPath, _appiumBinaryPath);
            Environment.SetEnvironmentVariable(Config.ANDROID_SDK_ROOT_PATH, _androidSdkPath);
        }

        public string NodeBinaryPath
        {
            get
            {
                return _nodeBinaryPath;
            }

            set
            {
                if(value != _nodeBinaryPath)
                {
                    _nodeBinaryPath = value;
                    UpdateEnvironmentVariable();
                }
            }
        }

        public string AppiumBinaryPath
        {
            get
            {
                return _appiumBinaryPath;
            }

            set
            {
                if (value != _appiumBinaryPath)
                {
                    _appiumBinaryPath = value;
                    UpdateEnvironmentVariable();
                }
            }
        }

        public string AndroidSdkPath
        {
            get
            {
                return _androidSdkPath;
            }

            set
            {
                if (value != _androidSdkPath)
                {
                    _androidSdkPath = value;
                    UpdateEnvironmentVariable();
                }
            }
        }
    }
}
