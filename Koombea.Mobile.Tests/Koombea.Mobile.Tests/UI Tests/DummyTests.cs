using NUnit.Framework;
using TestAutomationFramework.Common;
using TestAutomationFramework.Containers;
using UnitConverter.Mobile.Tests.Initializer;

namespace UnitConverter.Mobile.Tests.UI_Tests
{
    [TestFixture]
    public class DummyTests : TestInitializer
    {
        [Test]
        public void Test1()
        {
            Logging.WriteLine(AppContainer.Driver.PageSource);
            Logging.WriteLine("Test 1");
            Assert.IsTrue(AppContainer.Driver != null, "driver created");
        }

        [Test]
        public void Test2()
        {
            Logging.WriteLine("This is the test 2");
            Assert.IsTrue(AppContainer.Driver != null, "driver created 2");
        }
    }
}
