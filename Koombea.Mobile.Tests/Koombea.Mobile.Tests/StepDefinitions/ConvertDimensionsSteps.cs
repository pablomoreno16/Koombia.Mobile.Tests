using NUnit.Framework;
using TechTalk.SpecFlow;
using TestAutomationFramework.Common;
using UnitConverter.Mobile.Tests.Initializer;
using UnitConverter.Mobile.Tests.ScreenObjects;

namespace UnitConverter.Mobile.Tests.StepDefinitions
{
    [Binding]
    public class ConvertDimensionsSteps : TestInitializer
    {

        [When(@"the menu button is tapped")]
        public void TheMenuButtonIsTapped()
        {
            Logger.WriteLine("When the menu button is tapped.", LogType.Step);
            var calculatorScreen = new CalculatorScreen();
            calculatorScreen.TapMenuButton();
        }

        [Then(@"the (.*) is selected and displayed in the title")]
        public void SelectAnOperationAndValidateTitle(string operation)
        {
            Logger.WriteLine($"Then the {operation} is selected and displayed in the title", LogType.Step);
            var calculatorScreen = new CalculatorScreen();
            calculatorScreen.SelectMenuOption(operation);
            Assert.AreEqual(calculatorScreen.GetTitle(), operation, "Title is valid.");
            Logger.WriteLine("Title changed after selecting the menu option", LogType.Success);
        }
    }
}
