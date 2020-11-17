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

            Assert.IsTrue(addEmp.FirstNameLabel.Displayed);
            Assert.AreEqual(addEmp.FirstNameLabel.Text, "First Name:");

            Assert.IsTrue(addEmp.LastNameLabel.Displayed);
            Assert.AreEqual(addEmp.LastNameLabel.Text, "Last Name:");

            Assert.IsTrue(addEmp.DependentsLabel.Displayed);
            Assert.AreEqual(addEmp.DependentsLabel.Text, "Dependents");

            Assert.IsTrue(addEmp.AddButton.Displayed);
            Assert.AreEqual(addEmp.AddButton.Text, "Add");

            Assert.IsTrue(addEmp.CancelButton.Displayed);
            Assert.AreEqual(addEmp.CancelButton.Text, "Cancel");

            Assert.IsTrue(addEmp.CrossButton.Displayed);

        }

        [Test]
        public void AddValidEmployee()
        {
            AddEmployeeDialogBox addEmp = new AddEmployeeDialogBox(driver);
            EmployeeBenifitDashboardPage dashboard = new EmployeeBenifitDashboardPage(driver);

            Actions.LoginToEmployeeBenifitDashboard(Config.Credentials.Valid.Username, Config.Credentials.Valid.Password, driver);
            dashboard.AddEmployeeButton.Click();

            Actions.ValidAddEmployee(Config.EmployeeInfo.ValidEmployeeInfo.FirstName, Config.EmployeeInfo.ValidEmployeeInfo.LastName, Config.EmployeeInfo.ValidEmployeeInfo.NumberOfDependents,driver);

            Thread.Sleep(3000);
            
        }


        [OneTimeTearDown]
        public void CleanUp()
        {
            driver.Quit();
        }

    }
}
