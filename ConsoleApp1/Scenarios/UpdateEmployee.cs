using NUnit.Framework;
using OpenQA.Selenium;

namespace PaylocityBenifitsDashboard.Scenarios
{
    public class UpdateEmployee
    {
        public IWebDriver driver { get; set; }
        public UpdateEmployee()
        {

        }

        [OneTimeSetUp]
        public void Initialize()
        {
            driver = Actions.InitializeDriver();
        }
    }
}
