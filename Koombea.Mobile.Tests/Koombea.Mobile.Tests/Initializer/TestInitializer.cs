using TechTalk.SpecFlow;
using TestAutomationFramework.Common;
using TestAutomationFramework.Containers;

namespace UnitConverter.Mobile.Tests.Initializer
{
    [Binding]
    public class TestInitializer
    {
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            AppContainer.SetUpDriver();
        }

        [BeforeScenario]
        public static void BeforeFeature()
        {
            Logger.WriteLine("******** Start test script execution ********");
        }

        [AfterScenario]
        public static void AfterFeature()
        {
            Logger.WriteLine("********  End test script execution  ********");
            Logger.CreateFile();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            AppContainer.Driver.Quit();
        }
    }
}
