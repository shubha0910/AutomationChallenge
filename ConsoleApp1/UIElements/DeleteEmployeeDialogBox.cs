using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace PaylocityBenifitsDashboard.UIElements
{
    public class DeleteEmployeeDialogBox
    {
        public DeleteEmployeeDialogBox(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.CssSelector, Using = "#deleteModal > div > div > div.modal-header > h5")]
        public IWebElement DeleteEmployeeHeader { get; set; }

        [FindsBy(How = How.CssSelector,Using = "#deleteModal > div > div > div.modal-body > div > div")]
        public IWebElement DeleteStatement { get; set; }

        [FindsBy(How = How.Id,Using ="deleteEmployee")]
        public IWebElement DeleteButton { get; set; }

        [FindsBy(How = How.CssSelector, Using ="#deleteModal > div > div > div.modal-footer > button.btn.btn-secondary")]
        public IWebElement CancelButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#deleteModal > div > div > div.modal-header > button > span")]
        public IWebElement CrossButton { get; set; }


    }
}
