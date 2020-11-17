﻿using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;

namespace PaylocityBenifitsDashboard.UIElements
{
    public class EmployeeBenifitDashboardPage
    {
        public EmployeeBenifitDashboardPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.CssSelector, Using = "body > header > nav > div > a")]
        public IWebElement EmployeeDashboardPageHeader { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > header > nav > div > ul > li > a")]
        public IWebElement LogOutLink { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#employeesTable > thead > tr > th:nth-child(1)")]
        public IWebElement IdColumnHeader { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#employeesTable > thead > tr > th:nth-child(2)")]
        public IWebElement LastNameColumnHeader { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#employeesTable > thead > tr > th:nth-child(3)")]
        public IWebElement FirstNameColumnHeader { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#employeesTable > thead > tr > th:nth-child(4)")]
        public IWebElement DependentsColumnHeader { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#employeesTable > thead > tr > th:nth-child(5)")]
        public IWebElement SalaryColumnHeader { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#employeesTable > thead > tr > th:nth-child(6)")]
        public IWebElement GrossPayColumnHeader { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#employeesTable > thead > tr > th:nth-child(7)")]
        public IWebElement BenifitsCostColumnHeader { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#employeesTable > thead > tr > th:nth-child(8)")]
        public IWebElement NetPayColumnHeader { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#employeesTable > thead > tr > th:nth-child(9)")]
        public IWebElement ActionsColumnHeader { get; set; }

        [FindsBy(How =How.CssSelector, Using = "#employeesTable > tbody > tr:nth-child(1) > td:nth-child(9) > i.fas.fa-edit")]
        public IList<IWebElement> EditIcon { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#employeesTable > tbody > tr:nth-child(1) > td:nth-child(9) > i.fas.fa-times")]
        public IList<IWebElement> DeleteIcon { get; set; }

        [FindsBy(How = How.Id, Using = "add")]
        public IWebElement AddEmployeeButton { get; set; }

    }
}
