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


        public static void LoginToEmployeeBenifitDashboard(string username, string password, IWebDriver driver)
        {
            LogInPage login = new LogInPage(driver);

            login.UserNameTextBox.Clear();
            login.UserNameTextBox.SendKeys(username);

            login.PasswordTextBox.Clear();
            login.PasswordTextBox.SendKeys(password);

            login.LoginButton.Click();

            Thread.Sleep(3000);


        }

        public static void AddEmployee(string firstname, string lastname, string dependents, IWebDriver driver)
        {
            AddEmployeeDialogBox addEmp = new AddEmployeeDialogBox(driver);

            addEmp.FirstNameTextbox.Clear();
            addEmp.FirstNameTextbox.SendKeys(firstname);

            addEmp.LastNameTextbox.Clear();
            addEmp.LastNameTextbox.SendKeys(lastname);

            addEmp.DependentsTextbox.Clear();
            addEmp.DependentsTextbox.SendKeys(dependents);

            addEmp.AddButton.Click();

        }
        //struct Calculations
        //{
        //    public int GrossPay;
        //    public int Salary;
        //    public int BenifitsCost;
        //    public int NetPay;

        //}


        //public Calculations BenifitCalculation1(int Dependents,IWebDriver driver)
        //{
        //    Calculations values = new Calculations();

        //    values.GrossPay = 2000;
        //    int NumberOfPaychecks = 26;
        //    //int NumberOfDependents = 0;
        //    int AnnualDeductionForEmployeePerYear = 1000;
        //    int DependentDeductibleAmountPerYear = 500;
        //    values.Salary =0;
        //    values.BenifitsCost = 0;
        //    values.NetPay = 0;
        //    int DeductibleEmployeeBenefitOnlyPerPaycheck = 0;
        //    int DependentDeductibleAmountPerPayCheck = 0;

        //    values.Salary = values.GrossPay * NumberOfPaychecks;
        //    DeductibleEmployeeBenefitOnlyPerPaycheck = AnnualDeductionForEmployeePerYear / NumberOfPaychecks;
        //    DependentDeductibleAmountPerPayCheck = (DependentDeductibleAmountPerYear * Dependents) / NumberOfPaychecks;
        //    values.BenifitsCost = DeductibleEmployeeBenefitOnlyPerPaycheck + DependentDeductibleAmountPerPayCheck;
        //    values.NetPay = values.GrossPay - values.BenifitsCost;

        //    return values;

        //}


        public static decimal BenifitCalculation(int Dependents, IWebDriver driver)
        {
            //decimal GrossPay =2000;
            int NumberOfPaychecks = 26;
            //decimal Salary = 0M;
            decimal AnnualDeductionForEmployeePerYear = 1000M;
            decimal DependentDeductibleAmountPerYear = 500M;
            decimal DeductibleEmployeeBenefitOnlyPerPaycheck;
            decimal DependentDeductibleAmountPerPayCheck;
            decimal BenifitsCost;

            DeductibleEmployeeBenefitOnlyPerPaycheck = AnnualDeductionForEmployeePerYear / NumberOfPaychecks;
            DependentDeductibleAmountPerPayCheck = (DependentDeductibleAmountPerYear * Dependents) / NumberOfPaychecks;
            BenifitsCost = DeductibleEmployeeBenefitOnlyPerPaycheck + DependentDeductibleAmountPerPayCheck;

            return Math.Round(BenifitsCost,2);


        }

        public static decimal NetPayCalcualtion(decimal BenifitsCost, IWebDriver driver)
        {
            decimal GrossPay = 2000M;
            
            decimal NetPay = GrossPay - BenifitsCost;

            return Math.Round(NetPay,2);
        }



    }
}