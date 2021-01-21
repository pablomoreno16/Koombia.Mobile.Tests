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
using TestAutomationFramework.Extensions;
using LogType = TestAutomationFramework.Common.LogType;

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
                Logger.WriteLine("Element not found");
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

        protected void TapElement(AppiumWebElement element)
        {
            var touchAction = new TouchAction(AppContainer.Driver);
            touchAction.Tap(element).Perform();
        }

        public enum ScrollDirection
        {
            Up,
            Down
        }
        protected void Scroll(ScrollDirection direction = ScrollDirection.Down, bool allScreenScrolling = true)
        {
            //Calculate the points
            var yMargin = ScreenSize.Height / 4; 
            var xMid = ScreenSize.Width / 2;
            var yMid = ScreenSize.Height / 2;
            var top = allScreenScrolling ? new Point(xMid, yMargin) : new Point(xMid, yMid);
            var bottom = new Point(xMid, ScreenSize.Height - yMargin);
            
            Logger.WriteLine($"Scrolling {direction}");

            switch (direction)
            {
                case ScrollDirection.Down:
                    Swipe(bottom, top);
                    break;
                case ScrollDirection.Up:
                    Swipe(top, bottom, 0, 0);
                    break;
            }
        }

        protected void ScrollToTop()
        {
            Logger.WriteLine("Scrolling up until reaching the top of the screen");
            for (var count = 0; count < 3; count++)
            {
                Scroll(ScrollDirection.Up);
            }
        }

        protected void ScrollToElement(AppiumWebElement element)
        {
            while (!element.IsElementDisplayed())
            {
                Scroll();
            }
        }

        protected void Swipe(Point start, Point end, int msDuration = 500, int msDuration2 = 1000)
        {
            var action = new TouchAction(AppContainer.Driver);
            action.Press(start.X, start.Y).Wait(msDuration).MoveTo(end.X, end.Y).Wait(msDuration2).Release();
            action.Perform();
        }

        /// <summary>
        /// Look for a group of element the one that has the text received
        /// </summary>
        /// <param name="xpath">xpath locator</param>
        /// <param name="text">Text criteria for the search</param>
        protected void FindElementByText(string xpath, string text)
        {
            ScrollToTop();
            for(var count = 0; count < 4 ; count++)
            {
                var elementToTap = TryFindElement(By.XPath(string.Format(xpath, text)));

                if (elementToTap != null && elementToTap.IsElementDisplayed())
                {
                    ScrollToElement(elementToTap);
                    Logger.WriteLine($"Tapping on {text}...");
                    TapElement(elementToTap);
                    Logger.WriteLine($"Tapped on {text}");
                    return;
                }
                Scroll();
            }
            var errorMsg = $"Option [{text}] was not found.";
            Logger.WriteLine(errorMsg, LogType.Error);
            throw new Exception(errorMsg);
        }
    }
}
