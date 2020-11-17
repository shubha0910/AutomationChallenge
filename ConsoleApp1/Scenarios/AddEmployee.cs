using NUnit.Framework;
using OpenQA.Selenium;
using PaylocityBenifitsDashboard.UIElements;
using System;
using System.Threading;

namespace PaylocityBenifitsDashboard.Scenarios
{
    [Parallelizable]
    public class AddEmployee
    {
        public IWebDriver driver { get; set; }
        public AddEmployee()
        {

        }

        [OneTimeSetUp]
        public void Initialize()
        {
            driver = Actions.InitializeDriver();
        }

        [Test]
        public void AddEmployeeDialogBoxDisplayValidation()
        {
            EmployeeBenifitDashboardPage dashboard = new EmployeeBenifitDashboardPage(driver);
            AddEmployeeDialogBox addEmp = new AddEmployeeDialogBox(driver);

            Actions.LoginToEmployeeBenifitDashboard(Config.Credentials.Valid.Username, Config.Credentials.Valid.Password, driver);
            dashboard.AddEmployeeButton.Click();

            Assert.IsTrue(addEmp.AddEmployeeDialogBoxHeader.Displayed);
            Assert.AreEqual(addEmp.AddEmployeeDialogBoxHeader.Text, "Add Employee");

        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            driver.Quit();
        }

    }
}
