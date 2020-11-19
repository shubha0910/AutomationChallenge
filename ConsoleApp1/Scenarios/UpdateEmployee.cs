using NUnit.Framework;
using OpenQA.Selenium;
using PaylocityBenifitsDashboard.UIElements;
using System;
using System.Threading;

namespace PaylocityBenifitsDashboard.Scenarios
{
    [Parallelizable]
    public class T4UpdateEmployee
    {
        
        public IWebDriver driver { get; set; }
        public T4UpdateEmployee()
        {

        }

        [OneTimeSetUp]
        public void Initialize()
        {
            driver = Actions.InitializeDriver();
        }

        [Test]
        public void AddEmployeeDialogBoxDisplayValidation()
        {
            EmployeeBenifitDashboardPage dashboard = new EmployeeBenifitDashboardPage(driver);
            UpdateEmployeeDialogBox updateEmp = new UpdateEmployeeDialogBox(driver);

            Actions.LoginToEmployeeBenifitDashboard(Config.Credentials.Valid.Username, Config.Credentials.Valid.Password, driver);
            dashboard.AddEmployeeButton.Click();
            try
            {
                Assert.IsTrue(updateEmp.UpdateEmployeeDialogBoxHeader.Displayed);
                Assert.AreEqual(updateEmp.UpdateEmployeeDialogBoxHeader.Text, "Update Employee");

                Assert.IsTrue(updateEmp.FirstNameLabel.Displayed);
                Assert.AreEqual(updateEmp.FirstNameLabel.Text, "First Name:");

                Assert.IsTrue(updateEmp.LastNameLabel.Displayed);
                Assert.AreEqual(updateEmp.LastNameLabel.Text, "Last Name:");

                Assert.IsTrue(updateEmp.DependentsLabel.Displayed);
                Assert.AreEqual(updateEmp.DependentsLabel.Text, "Dependents");

                Assert.IsTrue(updateEmp.UpdateButton.Displayed);
                Assert.AreEqual(updateEmp.UpdateButton.Text, "Add");

                Assert.IsTrue(updateEmp.CancelButton.Displayed);
                Assert.AreEqual(updateEmp.CancelButton.Text, "Cancel");

                Assert.IsTrue(updateEmp.CrossButton.Displayed);
            }
            catch (Exception)
            {
                updateEmp.CancelButton.Click();
                Thread.Sleep(2000);
                dashboard.LogOutLink.Click();
            }

        }

        [Test]
        public void ValidateUpdateEmployeeInfo()
        {
            AddEmployeeDialogBox addEmp = new AddEmployeeDialogBox(driver);
            EmployeeBenifitDashboardPage dashboard = new EmployeeBenifitDashboardPage(driver);

            Actions.LoginToEmployeeBenifitDashboard(Config.Credentials.Valid.Username, Config.Credentials.Valid.Password, driver);

            //Get count before adding an employee
            int countOfLastNames = dashboard.LastNameList.Count;
            int countOfFirstNames = dashboard.FirstNameList.Count;
            int countOfDependents = dashboard.DependentsList.Count;
            int i;

            string UpdateFirstName = "Mike";
            string UpdateLastName = "Scott";

            string existingFirstName = "";
            string existingLastName = "";
            string existingDependent = "";
            string existingID;
            string Id;
            int j;
            int dependents;
            decimal BenifitsCost;
            decimal NetPay;
            string updatedFirstName = Config.EmployeeInfo.UpdateEmployeeInfo.FirstName;
            string updatedLastName = Config.EmployeeInfo.UpdateEmployeeInfo.LastName;
            string updatedDependents = Config.EmployeeInfo.UpdateEmployeeInfo.NumberOfDependents;

            try
            {
                for (i = 0; i <= countOfLastNames; i++)
                {
                    existingLastName = dashboard.FirstNameList[i].Text;
                    if (existingLastName == UpdateLastName)
                    {
                        existingFirstName = dashboard.LastNameList[i].Text;
                        if (existingFirstName == UpdateFirstName)
                        {
                            existingDependent = dashboard.DependentsList[i].Text;
                            if (existingDependent == "2")
                            {
                                dashboard.EditActionList[i].Click();
                                Actions.UpdateEmployee(Config.EmployeeInfo.UpdateEmployeeInfo.FirstName, Config.EmployeeInfo.UpdateEmployeeInfo.LastName, Config.EmployeeInfo.UpdateEmployeeInfo.NumberOfDependents, driver);
                                Id = dashboard.IdList[i].Text;

                                for (j = 0; j <= countOfLastNames; j++)
                                {
                                    existingLastName = dashboard.FirstNameList[j].Text;
                                    if (existingLastName == updatedLastName)
                                    {
                                        existingFirstName = dashboard.LastNameList[i].Text;
                                        if (existingFirstName == updatedFirstName)
                                        {
                                            existingDependent = dashboard.DependentsList[i].Text;
                                            if (existingDependent == updatedDependents)
                                            {
                                                existingID = dashboard.IdList[i].Text;
                                                if (Id == existingID)
                                                {
                                                    Assert.IsTrue(true);
                                                    dependents = Int32.Parse(updatedDependents);
                                                    BenifitsCost = Actions.BenifitCalculation(dependents, driver);
                                                    string CalBenifitCost = BenifitsCost.ToString();
                                                    Assert.AreEqual(CalBenifitCost, dashboard.BenefitsCostList[i].Text);
                                                    NetPay = Actions.NetPayCalcualtion(BenifitsCost, driver);
                                                    string CalNetPay = NetPay.ToString();
                                                    Assert.AreEqual(CalNetPay, dashboard.NetPayList[i].Text);
                                                    break;
                                                }
                                            }

                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                dashboard.LogOutLink.Click();
            }

        }
        [OneTimeTearDown]
        public void CleanUp()
        {
            driver.Quit();
        }

    }
}


