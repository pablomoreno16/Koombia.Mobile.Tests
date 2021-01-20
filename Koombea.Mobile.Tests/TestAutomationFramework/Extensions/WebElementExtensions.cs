using System;
using OpenQA.Selenium.Appium;

namespace TestAutomationFramework.Extensions
{
    public static class AppiumWebElementExtensions
    {
        public static bool IsElementDisplayed(this AppiumWebElement element)
        {
            var flag = false;
            try
            {
                flag = element.Displayed;
            }
            catch (Exception)
            {
                // ignored
            }

            return flag;
        }

        public static bool IsElementEnabled(this AppiumWebElement element)
        {
            var flag = false;
            try
            {
                flag = element.Enabled;
            }
            catch (Exception)
            {
                // ignored
            }

            return flag;
        }
    }
}
