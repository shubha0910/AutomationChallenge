using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace PaylocityBenifitsDashboard.UIElements
{
    public class UpdateEmployeeDialogBox
    {
        public UpdateEmployeeDialogBox(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector,Using = "#employeeModal > div > div > div.modal-header > h5")]
        public IWebElement UpdateEmployeeDialogBoxHeader { get; set; }

        [FindsBy(How = How.CssSelector,Using = "#employeeModal > div > div > div.modal-body > form > div:nth-child(2) > label")]
        public IWebElement FirstNameLabel { get; set; }

        [FindsBy(How = How.CssSelector,Using = "#employeeModal > div > div > div.modal-body > form > div:nth-child(3) > label")]
        public IWebElement LastNameLabel { get; set; }

        [FindsBy(How = How.CssSelector,Using = "#employeeModal > div > div > div.modal-body > form > div:nth-child(4) > label")]
        public IWebElement DependentsLabel { get; set; }

        [FindsBy(How = How.Id,Using = "firstName")]
        public IWebElement FirstNameTextBox { get; set; }

        [FindsBy(How = How.Id,Using = "lastName")]
        public IWebElement LastNameTextBox { get; set; }

        [FindsBy(How = How.Id,Using = "updateEmployee")]
        public IWebElement UpdateButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#employeeModal > div > div > div.modal-footer > button.btn.btn-secondary")]
        public IWebElement CancelButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#employeeModal > div > div > div.modal-header > button > span")]
        public IWebElement CrossButton { get; set; }

    }
}
