using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Appium.MultiTouch;
using TestAutomationFramework.Common;
using TestAutomationFramework.Containers;

namespace TestAutomationFramework.Screens
{
    public class BaseScreen
    {
        protected bool IsAndroid => AppContainer.PlatformName.Equals("Android");
        protected Size ScreenSize = AppContainer.Driver.Manage().Window.Size;

        protected AppiumWebElement TryFindElement(By by)
        {
            try
            {
                return AppContainer.Driver.FindElement(by);
            }
            catch (Exception)
            {
                if (IsAndroid)
                {
                    return new AndroidElement(AppContainer.Driver, null);
                }
                else
                {
                    return new IOSElement(AppContainer.Driver, null);
                }
            }
        }

        protected List<AppiumWebElement> TryFindElements(By by, AppiumWebElement innerElement = null)
        {
            try
            {
                return innerElement == null ? AppContainer.Driver.FindElements(by).ToList() : innerElement.FindElements(by).ToList();
            }
            catch (Exception)
            {
                return new List<AppiumWebElement>();
            }
        }

        protected void ScrollDown(bool allScreenScrolling = true)
        {
            //Calculate the points
            var yMargin = 50;
            var xMid = ScreenSize.Width / 2;
            var yMid = ScreenSize.Height / 2;
            var top = allScreenScrolling ? new Point(xMid, yMargin) : new Point(xMid, yMid);
            var bottom = new Point(xMid, ScreenSize.Height - yMargin);
            
            Logger.WriteLine("Scrolling down.");

            var action = new TouchAction(AppContainer.Driver);
            action.Press(bottom.X, bottom.Y).Wait(1000).MoveTo(top.X, top.Y).Release().Wait(500); //wait at the end for giving time to the animation to finish
            action.Perform();

        }

        protected void TapElement(AppiumWebElement element)
        {
            var touchAction = new TouchAction(AppContainer.Driver);
            touchAction.Tap(element).Perform();
        }
    
    }
}
