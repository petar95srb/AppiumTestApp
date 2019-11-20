using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomaticTesting
{
    public class Connector
    {
        private AndroidDriver<AppiumWebElement> _driver;
        public AndroidDriver<AppiumWebElement> Driver
        {
            get
            {
                return _driver;
            }
        }

        private AppiumLocalService _appiumLocalService;

        public Connector(PhoneConfig phoneConfig, AppConfig appConfig)
        {
            _appiumLocalService = new AppiumServiceBuilder().UsingAnyFreePort().Build();
            _appiumLocalService.Start();

            var appiumOptions = new AppiumOptions();
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, phoneConfig.DeviceName);
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, phoneConfig.PlatformName);
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, phoneConfig.PlatformVersion);

            _driver = new AndroidDriver<AppiumWebElement>(_appiumLocalService, appiumOptions);

            _driver.StartActivity(appConfig.AppPackage, appConfig.AppActivity);
        }
    }
}
