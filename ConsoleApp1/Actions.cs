using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PaylocityBenifitsDashboard.UIElements;
using System;
using System.Threading;

namespace PaylocityBenifitsDashboard
{
    public static class Actions
    {
        public static IWebDriver InitializeDriver()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(Config.BaseURL);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            return driver;
        }

        
        public static void LoginToEmployeeBenifitDashboard(string username, string password,IWebDriver driver)
        {
            LogInPage login = new LogInPage(driver);

            login.UserNameTextBox.Clear();
            login.UserNameTextBox.SendKeys(username);

            login.PasswordTextBox.Clear();
            login.PasswordTextBox.SendKeys(password);

            login.LoginButton.Click();

            Thread.Sleep(3000);
            

        }

    }
}
