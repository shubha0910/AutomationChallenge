using NUnit.Framework;
using OpenQA.Selenium;
using PaylocityBenifitsDashboard.UIElements;

namespace PaylocityBenifitsDashboard.Scenarios
{
    [Parallelizable]
    public class LoginPageLayoutValidations
    {
        public IWebDriver  driver { get; set; }
        public LoginPageLayoutValidations()
        {

        }
        

        [OneTimeSetUp]
        public void Initialize()
        {
            driver = Actions.InitializeDriver();
        }

        [Test]
        public void LogInPageHeaderCheck()
        {

            LogInPage logIn = new LogInPage(driver);
            Assert.IsTrue(logIn.LoginPageHeader.Displayed);
            Assert.AreEqual(logIn.LoginPageHeader.Text, "Paylocity Benefits Dashboard");
            
        }

        [Test]
        public void LogInPageUsernameLabelCheck()
        {
            LogInPage logIn = new LogInPage(driver);
            Assert.IsTrue(logIn.UserNameLabel.Displayed);
            Assert.AreEqual(logIn.UserNameLabel.GetAttribute("name"), "Username");
        }

        [Test]
        public void LogInPagePasswordLabelCheck()
        {
            LogInPage logIn = new LogInPage(driver);
            Assert.IsTrue(logIn.PasswordLabel.Displayed);
            Assert.AreEqual(logIn.PasswordLabel.GetAttribute("name"), "Password");
        }

        [Test]
        public void LogInButtonCheck()
        {
            LogInPage logIn = new LogInPage(driver);
            Assert.IsTrue(logIn.LoginButton.Displayed);
            Assert.AreEqual(logIn.LoginButton.Text, "Log In");
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
