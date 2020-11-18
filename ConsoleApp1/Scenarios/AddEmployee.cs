using NUnit.Framework;
using OpenQA.Selenium;
using PaylocityBenifitsDashboard.UIElements;
using System;
using System.Threading;

namespace PaylocityBenifitsDashboard.Scenarios
{
    [Parallelizable]
    public class AddEmployee
    {
        public IWebDriver driver { get; set; }
        public AddEmployee()
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
            AddEmployeeDialogBox addEmp = new AddEmployeeDialogBox(driver);

            Actions.LoginToEmployeeBenifitDashboard(Config.Credentials.Valid.Username, Config.Credentials.Valid.Password, driver);
            dashboard.AddEmployeeButton.Click();
            try
            {
                Assert.IsTrue(addEmp.AddEmployeeDialogBoxHeader.Displayed);
                Assert.AreEqual(addEmp.AddEmployeeDialogBoxHeader.Text, "Add Employee");

                Assert.IsTrue(addEmp.FirstNameLabel.Displayed);
                Assert.AreEqual(addEmp.FirstNameLabel.Text, "First Name:");

                Assert.IsTrue(addEmp.LastNameLabel.Displayed);
                Assert.AreEqual(addEmp.LastNameLabel.Text, "Last Name:");

                Assert.IsTrue(addEmp.DependentsLabel.Displayed);
                Assert.AreEqual(addEmp.DependentsLabel.Text, "Dependents");

                Assert.IsTrue(addEmp.AddButton.Displayed);
                Assert.AreEqual(addEmp.AddButton.Text, "Add");

                Assert.IsTrue(addEmp.CancelButton.Displayed);
                Assert.AreEqual(addEmp.CancelButton.Text, "Cancel");

                Assert.IsTrue(addEmp.CrossButton.Displayed);
            }
            catch(Exception)
            {
                addEmp.CancelButton.Click();
                Thread.Sleep(2000);
                dashboard.LogOutLink.Click();
            }

            

        }

        [Test]
        public void AddBlankEmployee()
        {
            AddEmployeeDialogBox addEmp = new AddEmployeeDialogBox(driver);
            EmployeeBenifitDashboardPage dashboard = new EmployeeBenifitDashboardPage(driver);

            Actions.LoginToEmployeeBenifitDashboard(Config.Credentials.Valid.Username, Config.Credentials.Valid.Password, driver);
            dashboard.AddEmployeeButton.Click();

            try
            {
                Actions.AddEmployee(Config.EmployeeInfo.BlankEmployeeInfo.FirstName, Config.EmployeeInfo.BlankEmployeeInfo.LastName, Config.EmployeeInfo.BlankEmployeeInfo.NumberOfDependents, driver);
                Assert.IsTrue(false);
                addEmp.CancelButton.Click();
                Thread.Sleep(2000);
                dashboard.LogOutLink.Click();
            }
            catch(Exception)
            {
                Assert.IsTrue(true);
                addEmp.CancelButton.Click();
                Thread.Sleep(2000);
                dashboard.LogOutLink.Click();

            }
            
            Thread.Sleep(3000);

        }

        [Test]
        public void OutofRangeDependent()
        {
            AddEmployeeDialogBox addEmp = new AddEmployeeDialogBox(driver);
            EmployeeBenifitDashboardPage dashboard = new EmployeeBenifitDashboardPage(driver);

            Actions.LoginToEmployeeBenifitDashboard(Config.Credentials.Valid.Username, Config.Credentials.Valid.Password, driver);
            dashboard.AddEmployeeButton.Click();

            try
            {
                Actions.AddEmployee(Config.EmployeeInfo.OutofRangeDependentInfo.FirstName, Config.EmployeeInfo.OutofRangeDependentInfo.LastName, Config.EmployeeInfo.OutofRangeDependentInfo.NumberOfDependents, driver);
                addEmp.CancelButton.Click();
                Thread.Sleep(2000);
                dashboard.LogOutLink.Click();
            }
            catch (Exception)
            {
                Assert.IsTrue(true);
                addEmp.CancelButton.Click();
                Thread.Sleep(2000);
                dashboard.LogOutLink.Click();

            }

            Thread.Sleep(3000);
        }

        [Test]
        public void ValidateAddedValidEmployee()
        {
            AddEmployeeDialogBox addEmp = new AddEmployeeDialogBox(driver);
            EmployeeBenifitDashboardPage dashboard = new EmployeeBenifitDashboardPage(driver);

            Actions.LoginToEmployeeBenifitDashboard(Config.Credentials.Valid.Username, Config.Credentials.Valid.Password, driver);

            //Get count before adding an employee
            int countOfLastNames = dashboard.LastNameList.Count;
            int countOfFirstNames = dashboard.FirstNameList.Count;
            int countOfDependents = dashboard.DependentsList.Count;


            dashboard.AddEmployeeButton.Click();
            string fntext = Config.EmployeeInfo.ValidEmployeeInfo.FirstName;
            string lntext = Config.EmployeeInfo.ValidEmployeeInfo.LastName;
            string deptext = Config.EmployeeInfo.ValidEmployeeInfo.NumberOfDependents;

            Actions.AddEmployee(Config.EmployeeInfo.ValidEmployeeInfo.FirstName, Config.EmployeeInfo.ValidEmployeeInfo.LastName, Config.EmployeeInfo.ValidEmployeeInfo.NumberOfDependents, driver);

            Thread.Sleep(3000);

            int countofLastNameafterAddition = dashboard.LastNameList.Count;
            int countOfFirstNameafterAddition = dashboard.FirstNameList.Count;

            countOfFirstNames = countOfFirstNames + 1;
            countOfLastNames = countOfLastNames + 1;

            Assert.AreEqual(countOfFirstNameafterAddition, countOfFirstNames);

            Assert.AreEqual(countofLastNameafterAddition, countOfLastNames);
            string addedFirstName = "";
            string addedLastName = "";
            string addedDependent = "";
            int i;
            int dependents;
            decimal BenifitsCost;
            decimal NetPay;

            for (i = 0; i <= countOfLastNames; i++)
            {
                addedFirstName = dashboard.LastNameList[i].Text;
                
                

                if (fntext == addedFirstName)
                {
                    addedLastName = dashboard.FirstNameList[i].Text;
                    if (lntext == addedLastName)
                    {
                        addedDependent = dashboard.DependentsList[i].Text;
                        if (deptext == addedDependent)
                        {
                            Assert.IsTrue(true);
                            dependents = Int32.Parse(addedDependent);
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

            Thread.Sleep(3000);

        }
        [Test]
        public void CalculationCheck()
        {
            
        }


        [OneTimeTearDown]
        public void CleanUp()
        {
            driver.Quit();
        }

    }
}
