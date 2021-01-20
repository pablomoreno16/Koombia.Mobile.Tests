using System;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.iOS;
using TestAutomationFramework.Common;


namespace TestAutomationFramework.Containers
{
    public class AppContainer
    {
        public static AppiumDriver<AppiumWebElement> Driver;
        public static string PlatformName;

        /// <summary>
        /// Set up the Driver according with configurations in appsettings.json
        /// </summary>
        public static void SetUpDriver()
        {
            #region GetProperties

            PlatformName = TestConfig.Instance.GetValue("platformName");
            var appiumServerUrl = TestConfig.Instance.GetUriValue("appiumServerUrl");
            var mobileAppPath = AppDomain.CurrentDomain.BaseDirectory + TestConfig.Instance.GetValue("mobileAppPath");
            var deviceName = TestConfig.Instance.GetValue("deviceName");

            #endregion GetProperties

            try
            {
                var opts = new AppiumOptions
                {
                    PlatformName = PlatformName
                };
                opts.AddAdditionalCapability(MobileCapabilityType.DeviceName, deviceName);
                opts.AddAdditionalCapability(MobileCapabilityType.App, mobileAppPath);
                opts.AddAdditionalCapability("noReset", true);
                opts.AddAdditionalCapability("newCommandTimeout", 120000);

                //if app is not native then add chromedriver
                //opts.AddAdditionalCapability("chromedriverExecutable", "Resources/Drivers/appium_chromedriver.exe");

                if (PlatformName.Equals("Android"))
                {
                    Driver = new AndroidDriver<AppiumWebElement>(appiumServerUrl, opts);
                }
                else if (PlatformName.Equals("iOS"))
                {
                    Driver = new IOSDriver<AppiumWebElement>(appiumServerUrl, opts);
                }
                else
                {
                    throw new NotImplementedException("Platform '" + PlatformName + "' not setup in AppContainer.SetUpDriver();");
                }
            }
            catch (Exception e)
            {
                Logger.WriteLine(e.Message, LogType.Error);
                Assert.Fail(e.Message);
            }
        }
    }
}
