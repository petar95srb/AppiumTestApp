using AutomaticTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndroidTest
{
    class Program
    {

        private static AndroidDriver<AppiumWebElement> _driver;
        private static AppiumLocalService _appiumLocalService;
        static void Main(string[] args)
        {

            string resault = TestAppMain.Instance.StartTestApp("test3.json");

            Console.WriteLine(resault);

            //Environment.SetEnvironmentVariable(AppiumServiceConstants.NodeBinaryPath, @"C:\Program Files\nodejs\node.exe");
            //Environment.SetEnvironmentVariable(AppiumServiceConstants.AppiumBinaryPath, @"C:\Program Files\Appium\resources\app\node_modules\appium\build\lib\main.js");
            //Environment.SetEnvironmentVariable("ANDROID_SDK_ROOT", @"C:\Program Files (x86)\Android\android-sdk");

            //_appiumLocalService = new AppiumServiceBuilder().UsingAnyFreePort().Build();
            //_appiumLocalService.Start();

            //var appiumOptions = new AppiumOptions();
            //appiumOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, "MVS4C19809000904");
            //appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
            //appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, "9");

            //_driver = new AndroidDriver<AppiumWebElement>(_appiumLocalService, appiumOptions);

            //if(_driver.IsLocked())
            //{
            //    _driver.Unlock();
            //}

            //_driver.StartActivity("com.android.chrome", "com.google.android.apps.chrome.Main");

            //_driver.FindElementByXPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.view.ViewGroup/android.widget.FrameLayout[1]/android.widget.FrameLayout[1]/android.webkit.WebView/android.view.View/android.view.View[2]/android.view.View[2]/android.view.View[1]/android.view.View/android.widget.EditText").SendKeys("test");

            //_driver.FindElementByXPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.view.ViewGroup/android.widget.FrameLayout[1]/android.widget.FrameLayout[1]/android.webkit.WebView/android.view.View/android.view.View[2]/android.view.View[2]/android.view.View[1]/android.view.View/android.widget.Button").Click();

            //_driver.FindElementByXPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.view.ViewGroup/android.widget.FrameLayout[1]/android.widget.FrameLayout[2]/android.webkit.WebView/android.view.View/android.view.View/android.view.View[2]/android.view.View[2]/android.view.View[1]/android.view.View/android.widget.Button[2]").Click();
            
            ////// _driver?.LaunchApp();   
           
            //_driver.FindElementById("com.android.calculator2:id/op_clr").GetScreenshot().SaveAsFile("tst.png");

            ////_driver.FindElementById("com.android.calculator2:id/op_clr").Click();

            ////_driver.FindElementById("com.android.calculator2:id/digit_3").Click();

            ////_driver.FindElementById("com.android.calculator2:id/op_mul").Click();

            ////_driver.FindElementById("com.android.calculator2:id/digit_6").Click();

            ////_driver.FindElementById("com.android.calculator2:id/eq").Click();

            ////string value = _driver.FindElementById("com.android.calculator2:id/formula").Text;

            ////Console.WriteLine(value);

        }
    }
}

