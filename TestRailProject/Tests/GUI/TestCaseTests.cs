using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TestRailProject.Core;
using TestRailProject.Models;
using TestRailProject.Pages;
using TestRailProject.Pages.ProjectPages;

namespace TestRailProject.Tests.GUI
{
    internal class GUITests : BaseTest
    {
        private const string ExpectedLogInErrorMessage = "Sorry, there was a problem.";
        private const string ExpectedLogInErrorDescription = "Email/Login or Password is incorrect. Please try again.";
        private const string ExpectedValidationErrorMessage = "Email/Login is required.";

        /*[Test]
        public void SuccessfullLogin()
        {
            var username = "boyop75371@picdv.com";
            var password = "#qb^kta*!rP%6B3";

            var loginPage = new LoginPage(Driver);

            loginPage.EmailInput.SendKeys(username);
            loginPage.PswInput.SendKeys(password);
            loginPage.LoginInButton.Click();

            Assert.That(Driver.Url, Is.EqualTo("https://soobit1.testrail.io/index.php?/dashboard"));
            Thread.Sleep(1000);
        }*/

        [Test]
        public void AddTestCase()
        {
            _navigationSteps.SuccessfulLogin(Admin);
            Driver.FindElement(By.XPath("//a[text()='ExampleProject2']")).Click();
            Driver.FindElement(By.Id("navigation-suites")).Click();
            Driver.FindElement(By.XPath("//a[@id='sidebar-cases-add']")).Click();
            
                        
            testCase expectedTestCase = new testCase()
            {
                Id = "NewTest",
                Section = "Installation",
                Template = "Test Case (Steps)",
                Type = "Functional",
                Priority = "High",
            };

            TestCasePage testCasePage = _testCaseSteps.AddTestCase(expectedTestCase);

                Assert.That(testCasePage.SuccessMessage.Text.Trim(),
                Is.EqualTo("Successfully added the new test case. Add another"));

            Assert.That(testCasePage.Section.Text, Is.EqualTo(expectedTestCase.Section));
        }
    }
}
