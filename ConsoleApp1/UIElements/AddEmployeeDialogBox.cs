using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace PaylocityBenifitsDashboard.UIElements
{
    public class AddEmployeeDialogBox
    {
        public AddEmployeeDialogBox(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "#employeeModal > div > div > div.modal-header > h5")]
        public IWebElement AddEmployeeDialogBoxHeader { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#employeeModal > div > div > div.modal-body > form > div:nth-child(2) > label")]
        public IWebElement FirstNameLabel { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#employeeModal > div > div > div.modal-body > form > div:nth-child(3) > label")]
        public IWebElement LastNameLabel { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#employeeModal > div > div > div.modal-body > form > div:nth-child(4) > label")]
        public IWebElement DependentsLabel { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#employeeModal > div > div > div.modal-header > button > span")]
        public IWebElement CrossButton { get; set; }

        [FindsBy(How = How.Id, Using = "addEmployee")]
        public IWebElement AddButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#employeeModal > div > div > div.modal-footer > button.btn.btn-secondary")]
        public IWebElement CancelButton { get; set; }

        [FindsBy(How = How.Id, Using = "firstName")]
        public IWebElement FirstNameTextbox { get; set; }

        [FindsBy(How = How.Id, Using = "lastName")]
        public IWebElement LastNAmeTextbox { get; set; }

        [FindsBy(How = How.Id, Using = "dependants")]
        public IWebElement DependentsTextbox { get; set; }
    }
}
