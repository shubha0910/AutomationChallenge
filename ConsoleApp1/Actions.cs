﻿using NUnit.Framework;
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
            bool HeadlessBrowser= Config.HeadlessBrowserOption.HeadlessBrowser;

            if(HeadlessBrowser == true)
            {
                ChromeOptions options = new ChromeOptions();

                //add the headless argument
                options.AddArgument("headless");

                //pass the options parameter in the Chrome driver declaration
                IWebDriver driver = new ChromeDriver(options);

                driver.Navigate().GoToUrl(Config.BaseURL);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                return driver;
            }
            else
            {
                IWebDriver driver = new ChromeDriver();

                driver.Navigate().GoToUrl(Config.BaseURL);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                driver.Manage().Window.Maximize();
                return driver;
            }

            
            
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

        public static void UpdateEmployee(string firstname,string lastname,string dependents,IWebDriver driver)
        {
            AddEmployeeDialogBox addEmp = new AddEmployeeDialogBox(driver);
            UpdateEmployeeDialogBox updateEmp = new UpdateEmployeeDialogBox(driver);

            addEmp.FirstNameTextbox.Clear();
            addEmp.FirstNameTextbox.SendKeys(firstname);

            addEmp.LastNameTextbox.Clear();
            addEmp.LastNameTextbox.SendKeys(lastname);

            addEmp.DependentsTextbox.Clear();
            addEmp.DependentsTextbox.SendKeys(dependents);

            updateEmp.UpdateButton.Click();

        }

        public static void DeleteEmployee(string ID,IWebDriver driver)
        {
            DeleteEmployeeDialogBox delEmp = new DeleteEmployeeDialogBox(driver);

            delEmp.DeleteButton.Click();
        }

    }
}