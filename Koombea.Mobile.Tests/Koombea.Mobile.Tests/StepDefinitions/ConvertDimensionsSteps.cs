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

        [When(@"the operation is Speed")]
        public void TheOperationIsSpeed()
        {
            Logger.WriteLine("When the operation is Speed", LogType.Step);
            var calculatorScreen = new CalculatorScreen();
            if(!"Speed".Equals(calculatorScreen.GetTitle()))
            {
                calculatorScreen.TapMenuButton();
                calculatorScreen.SelectMenuOption("Speed");
            }
            Assert.AreEqual("Speed", calculatorScreen.GetTitle());
        }

        [Then(@"the change sign key is disabled")]
        public void SelectAnOperationAndValidateTitle()
        {
            Logger.WriteLine($"Then the change sign key is disabled", LogType.Step);
            var calculatorScreen = new CalculatorScreen();
            Assert.IsFalse(calculatorScreen.IsChangeSignKeyEnabled(), "Change Sign key is disabled");
            Logger.WriteLine("Change Sign key is disabled", LogType.Success);
        }

        [Given(@"a user that selects a conversion (.*) from menu")]
        public void UserSelectConversionOperationFromMenu(string operation)
        {
            Logger.WriteLine($"Given a user that selects a conversion {operation} from menu", LogType.Step);
            var calculatorScreen = new CalculatorScreen();
            if (!operation.Equals(calculatorScreen.GetTitle()))
            {
                calculatorScreen.TapMenuButton();
                calculatorScreen.SelectMenuOption(operation);
            }

            Assert.AreEqual(operation, calculatorScreen.GetTitle(), "Operation selected successfully");
        }

        [When(@"the (origin|desired) unit (.*) is selected")]
        public void SelectOriginUnit(string source, string unit)
        {
            Logger.WriteLine($"When the {source} unit {unit} is selected", LogType.Step);
            var calculatorScreen = new CalculatorScreen();
            if (source.Equals("origin"))
            {
                calculatorScreen.SelectUnitFrom(unit);
                Assert.AreEqual(unit, calculatorScreen.GetUnitFrom(), "Unit 'From' selected successfully");
            }
            else
            {
                calculatorScreen.SelectUnitTo(unit);
                Assert.AreEqual(unit, calculatorScreen.GetUnitTo(), "Unit 'To' selected successfully");
            }
        }

        [When(@"the (.*) is inserted")]
        public void TheEntryValueIsInserted(string entryValue)
        {
            Logger.WriteLine($"When the Entry Value {entryValue} is inserted", LogType.Step);
            var calculatorScreen = new CalculatorScreen();
            calculatorScreen.Clear();
            calculatorScreen.EntryValue(entryValue);
            Assert.AreEqual(entryValue, calculatorScreen.GetSourceValue(), "Entry value entered successfully.");
        }

        [Then(@"the result should be (.*)")]
        public void TheResultShouldBe(string result)
        {
            Logger.WriteLine($"Then the result should be {result}", LogType.Step);
            var calculatorScreen = new CalculatorScreen();
            Assert.AreEqual(double.Parse(result), calculatorScreen.GetTargetValue(), "Conversion is valid");
            Logger.WriteLine("Number converted successfully.", LogType.Success);
        }
    }
}
