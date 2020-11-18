using NUnit.Framework;
using OpenQA.Selenium;
using PaylocityBenifitsDashboard.UIElements;
using System;
using System.Threading;

namespace PaylocityBenifitsDashboard.Scenarios
{
    public class UpdateEmployee
    {
        public IWebDriver driver { get; set; }
        public UpdateEmployee()
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

            string UpdateLastName = "Mike";
            string UpdateFirstName = "Scott";

            string existingFirstName = "";
            string existingLastName = "";
            string existingDependent = "";

            for (i=0; i <= countOfLastNames; i++)
            {
                existingLastName = dashboard.LastNameList[i].Text;
                if(existingLastName == UpdateLastName)
                {
                    if(existingFirstName == UpdateFirstName)
                    {
                        if(existingDependent == "2")
                        {
                            dashboard.EditActionList[i].Click();
                            Actions.UpdateEmployee(Config.EmployeeInfo.UpdateEmployeeInfo.LastName, Config.EmployeeInfo.UpdateEmployeeInfo.NumberOfDependents, driver);
                            break;
                        }
                    }
                }
            }

        }
    }
}
