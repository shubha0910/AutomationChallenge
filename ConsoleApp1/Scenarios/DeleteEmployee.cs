using NUnit.Framework;
using OpenQA.Selenium;
using PaylocityBenifitsDashboard.UIElements;
using System;

namespace PaylocityBenifitsDashboard.Scenarios
{
    public class DeleteEmployee
    {
        public IWebDriver driver { get; set; }
        public DeleteEmployee()
        {

        }

        [OneTimeSetUp]
        public void Initialize()
        {
            driver = Actions.InitializeDriver();
        }
        [Test]
        public void DeleteEmployeeDialogboxLayoutValidation()
        {
            EmployeeBenifitDashboardPage dashboard = new EmployeeBenifitDashboardPage(driver);
            DeleteEmployeeDialogBox delEmp = new DeleteEmployeeDialogBox(driver);
            Actions.LoginToEmployeeBenifitDashboard(Config.Credentials.Valid.Username, Config.Credentials.Valid.Password, driver);

            int countOfLastNames = dashboard.LastNameList.Count;
            string DeleteLastName = "Halpert";
            string existingLastName = "";
            int i;
            try
            {
                for (i = 0; i <= countOfLastNames; i++)
                {
                    existingLastName = dashboard.FirstNameList[i].Text;
                    if (existingLastName == DeleteLastName)
                    {
                        dashboard.DeleteActionList[i].Click();


                        Assert.AreEqual(delEmp.DeleteEmployeeHeader.Text, "Delete Employee");

                        Assert.IsTrue(delEmp.DeleteButton.Displayed);

                        Assert.IsTrue(delEmp.CancelButton.Displayed);

                        Assert.IsTrue(delEmp.CrossButton.Displayed);
                        delEmp.CancelButton.Click();
                        break;
                    }
                }

            }
            catch(Exception)
            {
                delEmp.CancelButton.Click();
            }
            

        }

        [Test]
        public void ValidateDeleteEmployee()
        {
            EmployeeBenifitDashboardPage dashboard = new EmployeeBenifitDashboardPage(driver);
            DeleteEmployeeDialogBox delEmp = new DeleteEmployeeDialogBox(driver);

            //Actions.LoginToEmployeeBenifitDashboard(Config.Credentials.Valid.Username, Config.Credentials.Valid.Password, driver);

            //Get count before adding an employee
            int countOfLastNames = dashboard.LastNameList.Count;
            int countOfFirstNames = dashboard.FirstNameList.Count;
            int countOfDependents = dashboard.DependentsList.Count;
            int i;
            string existingFirstName = "";
            string existingLastName = "";
            string existingDependent = "";
            
            string DeleteFirstName = "Jim";
            string DeleteLastName = "Halpert";
            string DeleteDependent = "4";
            string ID;
            int j;
            string searchID;

            try
            {
                for(i =0; i<=countOfLastNames; i++)
                {
                    existingLastName = dashboard.FirstNameList[i].Text;
                    if(existingLastName == DeleteLastName)
                    {
                        existingFirstName = dashboard.LastNameList[i].Text;
                        if(existingFirstName == DeleteFirstName)
                        {
                            existingDependent = dashboard.DependentsList[i].Text;
                            if(existingDependent == DeleteDependent )
                            {
                                ID = dashboard.IdList[i].Text;
                                dashboard.DeleteActionList[i].Click();
                                Actions.DeleteEmployee(ID, driver);

                                for(j = 0; j<= countOfLastNames; j++)
                                {
                                    searchID = dashboard.IdList[i].Text;
                                    if(searchID ==ID)
                                    {
                                        Assert.IsTrue(false);
                                    }
                                    else
                                    {
                                        Assert.IsTrue(true);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch(Exception)
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
