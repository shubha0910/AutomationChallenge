using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace PaylocityBenifitsDashboard.UIElements
{
    public class LogInPage
    {
        public LogInPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.Name, Using = "Username")]
        public IWebElement UserNameLabel { get; set; }

        [FindsBy(How = How.Id, Using = "Username")]
        public IWebElement UserNameTextBox { get; set; }

        [FindsBy(How = How.Id, Using = "Password")]
        public IWebElement PasswordTextBox { get; set; }

        [FindsBy(How = How.Name, Using = "Password")]
        public IWebElement PasswordLabel { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > main > div > div > form > button")]
        public IWebElement LoginButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > header > nav > div > a")]
        public IWebElement LoginPageHeader { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > main > div > div > form > div.validation-summary-errors.text-danger > span")]
        public IWebElement LoginErrorMessage { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > main > div > div > form > div.validation-summary-errors.text-danger > ul > li:nth-child(1)")]
        public IWebElement UsernameRequiredErrorMessage { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > main > div > div > form > div.validation-summary-errors.text-danger > ul > li:nth-child(2)")]
        public IWebElement PasswordRequiredErrorMessage { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > main > div > div > form > div.validation-summary-errors.text-danger > ul > li")]
        public IWebElement InvalidCredentialErrorMessage { get; set; }





    }
}
