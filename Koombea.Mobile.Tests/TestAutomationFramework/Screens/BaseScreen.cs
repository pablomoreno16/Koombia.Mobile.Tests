using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.ImageComparison;
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

            var action = new TouchAction(AppContainer.Driver);
            switch (direction)
            {
                case ScrollDirection.Down:
                    action.Press(bottom.X, bottom.Y).Wait(200).MoveTo(top.X, top.Y).Release().Wait(500); //wait at the end for giving time to the animation to finish
                    break;
                case ScrollDirection.Up:
                    action.Press(top.X, top.Y).Wait(200).MoveTo(bottom.X, bottom.Y).Release().Wait(500); //wait at the end for giving time to the animation to finish
                    break;
            }
            action.Perform();
        }

        [Obsolete("ScrollToUp is deprecated since PageSource change because the ads bar. Please use ScrollToTop instead.")]
        protected void ScrollToUp()
        {
            Logger.WriteLine("Scrolling up until reaching the top of the screen");
            string pageBeforeScrolling, pageAfterScrolling;
            do
            {
                pageBeforeScrolling = AppContainer.Driver.PageSource;
                Scroll(ScrollDirection.Up);
                pageAfterScrolling = AppContainer.Driver.PageSource;
            } while (pageBeforeScrolling != pageAfterScrolling);
        }

        protected void ScrollToTop()
        {
            Logger.WriteLine("Scrolling up until reaching the top of the screen");
            SimilarityMatchingResult result;
            do
            {
                var pageBeforeScrolling = AppContainer.Driver.GetScreenshot().AsBase64EncodedString;
                Scroll(ScrollDirection.Up);
                var pageAfterScrolling = AppContainer.Driver.GetScreenshot().AsBase64EncodedString;
                result = AppContainer.Driver.GetImagesSimilarity(pageBeforeScrolling, pageAfterScrolling, new SimilarityMatchingOptions { Visualize = true });
                //Logger.WriteLine($"Score: {result.Score}");
            } while (result.Score < 0.98);
        }

        protected void TapElement(AppiumWebElement element)
        {
            var touchAction = new TouchAction(AppContainer.Driver);
            touchAction.Tap(element).Perform();
        }

        /// <summary>
        /// Look for a group of element the one that has the text received
        /// </summary>
        /// <param name="by">Locator for the group of elements</param>
        /// <param name="text">Text criteria for the search</param>
        protected void FindElementByText(By by, string text)
        {
            ScrollToTop();
            SimilarityMatchingResult result;
            do
            {
                var elementToTap = TryFindElements(by).FirstOrDefault(opt => opt.Text.Equals(text));

                if (elementToTap != null && elementToTap.IsElementDisplayed())
                {
                    Logger.WriteLine($"Tapping on {text}...");
                    TapElement(elementToTap);
                    Logger.WriteLine($"Tapped on {text}");
                    return;
                }

                var pageBeforeScrolling = AppContainer.Driver.GetScreenshot().AsBase64EncodedString;
                Scroll();
                var pageAfterScrolling = AppContainer.Driver.GetScreenshot().AsBase64EncodedString;
                
                result = AppContainer.Driver.GetImagesSimilarity(pageBeforeScrolling, pageAfterScrolling, new SimilarityMatchingOptions { Visualize = true });
            } while (result.Score < 0.98);
            var errorMsg = $"Option [{text}] was not found.";
            Logger.WriteLine(errorMsg, LogType.Error);
            throw new Exception(errorMsg);
        }
    }
}
