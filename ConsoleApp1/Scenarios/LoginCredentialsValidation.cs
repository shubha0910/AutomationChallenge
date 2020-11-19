using NUnit.Framework;
using OpenQA.Selenium;
using PaylocityBenifitsDashboard.UIElements;
using System;
using System.Threading;

namespace PaylocityBenifitsDashboard.Scenarios
{
    [Parallelizable]
    public class T2LoginCredentialsValidation
    {
        public IWebDriver driver { get; set; }
        public T2LoginCredentialsValidation()
        {

        }

        [OneTimeSetUp]
        public void Initialize()
        {
            driver = Actions.InitializeDriver();
        }

        

        [Test,Order(1)]
        public void BlankCredentials()
        {
            EmployeeBenifitDashboardPage dashboard = new EmployeeBenifitDashboardPage(driver);
            LogInPage logIn = new LogInPage(driver);
            Actions.LoginToEmployeeBenifitDashboard(Config.Credentials.Invalid.Username.BlankUserName, Config.Credentials.Invalid.Password.BlankPassword,driver);

            Assert.AreEqual(logIn.LoginErrorMessage.Text, "There were one or more problems that prevented you from logging in:");
            String text1 =logIn.UsernameRequiredErrorMessage.Text;
            Assert.AreEqual(logIn.UsernameRequiredErrorMessage.Text, "The Username field is required.");
            Assert.AreEqual(logIn.PasswordRequiredErrorMessage.Text, "The Password field is required.");
        }

        [Test,Order(2)]
        public void InvalidCredentials()
        {
            EmployeeBenifitDashboardPage dashboard = new EmployeeBenifitDashboardPage(driver);
            LogInPage logIn = new LogInPage(driver);

            Actions.LoginToEmployeeBenifitDashboard(Config.Credentials.Invalid.Username.SpecialCharUserName, Config.Credentials.Invalid.Password.NumericPassword, driver);
            Assert.AreEqual(logIn.LoginErrorMessage.Text, "There were one or more problems that prevented you from logging in:");
            Assert.AreEqual(logIn.InvalidCredentialErrorMessage.Text, "The specified username or password is incorrect.");


        }

        [Test, Order(3)]
        public void ValidCredentials()
        {
            EmployeeBenifitDashboardPage dashboard = new EmployeeBenifitDashboardPage(driver);
            //Thread.Sleep(5000);
            Actions.LoginToEmployeeBenifitDashboard(Config.Credentials.Valid.Username, Config.Credentials.Valid.Password, driver);

            Assert.AreEqual(dashboard.EmployeeDashboardPageHeader.Text, "Paylocity Benefits Dashboard");
            Assert.AreEqual(dashboard.LogOutLink.Text, "Log Out");
            Assert.AreEqual(dashboard.IdColumnHeader.Text, "Id");
        }

        [Test, Order(4)]
        public void DashboardCoulmnHeaderValiadtion()
        {
            EmployeeBenifitDashboardPage dashboard = new EmployeeBenifitDashboardPage(driver);

            Assert.AreEqual(dashboard.IdColumnHeader.Text, "Id");
            Assert.AreEqual(dashboard.LastNameColumnHeader.Text, "Last Name");
            Assert.AreEqual(dashboard.FirstNameColumnHeader.Text, "First Name");
            Assert.AreEqual(dashboard.DependentsColumnHeader.Text, "Dependents");
            Assert.AreEqual(dashboard.SalaryColumnHeader.Text, "Salary");
            Assert.AreEqual(dashboard.GrossPayColumnHeader.Text, "Gross Pay");
            Assert.AreEqual(dashboard.BenifitsCostColumnHeader.Text, "Benefits Cost");
            Assert.AreEqual(dashboard.NetPayColumnHeader.Text, "Net Pay");
            Assert.AreEqual(dashboard.ActionsColumnHeader.Text, "Actions");

        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            driver.Quit();
        }

    }
}
