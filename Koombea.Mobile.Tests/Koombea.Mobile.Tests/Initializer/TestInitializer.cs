using NUnit.Framework;
using TestAutomationFramework.Common;
using TestAutomationFramework.Containers;

namespace UnitConverter.Mobile.Tests.Initializer
{
    [SetUpFixture]
    public class TestInitializer
    {
        [OneTimeSetUp]
        public static void Start()
        {
            AppContainer.SetUpDriver();
        }

        [SetUp]
        public static void SetUp()
        {
            Logging.WriteLine("Reset the app");
            AppContainer.Driver.ResetApp();
            Logging.WriteLine("******** Start test script execution ********");
        }

        [TearDown]
        public static void TearDown()
        {
            Logging.WriteLine("********  End test script execution  ********");
            Logging.WriteLine("Close the App");
            AppContainer.Driver.CloseApp();
            Logging.CreateFile();
        }

        [OneTimeTearDown]
        public static void End()
        {
            AppContainer.Driver.Quit();
        }
    }
}
