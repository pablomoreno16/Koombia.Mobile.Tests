using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using TestAutomationFramework.Containers;
using TestAutomationFramework.Extensions;
using TestAutomationFramework.Screens;
using LogType = TestAutomationFramework.Common.LogType;

namespace UnitConverter.Mobile.Tests.ScreenObjects
{
    public class CalculatorScreen : BaseScreen
    {
        //This is just for illustrating how it would be for both iOS and Android
        private AppiumWebElement MenuButton => IsAndroid ? TryFindElement(By.XPath("//android.widget.ImageButton[@content-desc='Open navigation drawer']")) : TryFindElement(By.Name("put the id here"));
        //As this exercise is only for android I will avoid casting the rest of the code
        private List<AppiumWebElement> MenuOptions => TryFindElements(By.Id("drawerCategoryName"));
        private AppiumWebElement Title => TryFindElement(By.XPath("//android.widget.TextView[1]"));
        private AppiumWebElement UnitFrom => TryFindElement(By.Id("select_unit_spinner"));

        public void TapMenuButton()
        {
            TestAutomationFramework.Common.Logger.WriteLine("Tap Menu button");
            TapElement(MenuButton);
        }

        public void SelectMenuOption(string option)
        {
            string pageBeforeScrolling, pageAfterScrolling;
            do
            {
                var elementToTap = MenuOptions.FirstOrDefault(opt => opt.Text.Equals(option));

                if (elementToTap != null && elementToTap.IsElementDisplayed())
                {
                    TestAutomationFramework.Common.Logger.WriteLine($"Tapping on {option}...");
                    TapElement(elementToTap);
                    TestAutomationFramework.Common.Logger.WriteLine($"Tapped on {option}");
                    return;
                }

                pageBeforeScrolling = AppContainer.Driver.PageSource;
                ScrollDown();
                pageAfterScrolling = AppContainer.Driver.PageSource;
            } while (pageBeforeScrolling != pageAfterScrolling);
            var errorMsg = $"Option [{option}] was not found.";
            TestAutomationFramework.Common.Logger.WriteLine(errorMsg, LogType.Error);
            throw new Exception(errorMsg);
        }

        public string GetTitle()
        {
            return Title.Text;
        }
    }
}
