using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using TestAutomationFramework.Common;
using TestAutomationFramework.Extensions;
using TestAutomationFramework.Screens;

namespace UnitConverter.Mobile.Tests.ScreenObjects
{
    public class CalculatorScreen : BaseScreen
    {
        #region DOM elements
        //This is just for illustrating how it would be for both iOS and Android
        private AppiumWebElement MenuButton => IsAndroid ? TryFindElement(By.XPath("//android.widget.ImageButton[@content-desc='Open navigation drawer']")) : TryFindElement(By.Name("put the id here"));
        //As this exercise is only for android I will avoid casting the rest of the code
        private AppiumWebElement Title => TryFindElement(By.XPath("//android.widget.TextView[1]"));
        private AppiumWebElement UnitFrom => TryFindElement(By.XPath("//android.widget.Spinner[@resource-id='com.ba.universalconverter:id/from_units_spinner']//android.widget.TextView[@resource-id='com.ba.universalconverter:id/select_unit_spinner']"));
        private AppiumWebElement UnitTo => TryFindElement(By.XPath("//android.widget.Spinner[@resource-id='com.ba.universalconverter:id/to_units_spinner']//android.widget.TextView[@resource-id='com.ba.universalconverter:id/select_unit_spinner']"));
        private AppiumWebElement ChangeSignKey => TryFindElement(By.XPath("//android.widget.Button[@text='+/-']"));
        private AppiumWebElement SourceValue => TryFindElement(By.Id("source_value"));
        private AppiumWebElement TargetValue => TryFindElement(By.Id("target_value"));
        
        private const string XpathUnitFromAndToOptions = "//android.widget.TextView[@resource-id='com.ba.universalconverter:id/select_unit_spinner_menu_name' and @text='{0}']";
        private const string XpathMenuOptions = "//android.widget.TextView[@resource-id='com.ba.universalconverter:id/drawerCategoryName' and @text='{0}']";
        
        #endregion

        #region Public Methods

        public void TapMenuButton()
        {
            Logger.WriteLine("Tap Menu button");
            TapElement(MenuButton);
        }

        public void SelectMenuOption(string option)
        {
            Logger.WriteLine($"Looking for option [{option}] from Menu.");
            FindElementByText(XpathMenuOptions, option);
        }

        public string GetTitle()
        {
            Logger.WriteLine("Get app title");
            return Title.Text;
        }

        public void SelectUnitFrom(string unitName)
        {
            if (unitName.Equals(UnitFrom.Text)) return;
            Logger.WriteLine("Tapping in 'Unit From' dropdown");
            TapElement(UnitFrom);
            Logger.WriteLine($"Selecting the option [{unitName}]");
            FindElementByText(XpathUnitFromAndToOptions, unitName);
        }

        public string GetUnitFrom()
        {
            return UnitFrom.Text;
        }

        public void SelectUnitTo(string unitName)
        {
            if (unitName.Equals(UnitTo.Text)) return;
            Logger.WriteLine("Tapping in 'Unit To' dropdown");
            TapElement(UnitTo);
            Logger.WriteLine($"Selecting the option [{unitName}]");
            FindElementByText(XpathUnitFromAndToOptions, unitName);
        }

        public string GetUnitTo()
        {
            return UnitTo.Text;
        }

        public void Clear()
        {
            Logger.WriteLine("Clearing.");
            EntryValue("C");
        }

        public void EntryValue(string value)
        {
            Logger.WriteLine($"Entry the value {value} into keypad");
            var negative = value.StartsWith("-");
            if (negative) value = value.Replace("-", "");
            foreach (var val in value)
            {
                TapElement(TryFindElement(By.XPath($"//android.widget.Button[@text='{val}']")));
            }
            if(negative) TapElement(ChangeSignKey);
        }

        public string GetSourceValue()
        {
            return SourceValue.Text;
        }

        public double GetTargetValue()
        {
            Logger.WriteLine("Getting the target value");
            return double.Parse(TargetValue.Text.Replace(" ", ""));
        }

        public bool IsChangeSignKeyEnabled()
        {
            return ChangeSignKey.IsElementEnabled();
        }

        #endregion
    }
}