using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TestRailProject.Core;
using TestRailProject.Elements;
using TestRailProject.Models;
using TestRailProject.Pages;
using TestRailProject.Pages.ProjectPages;
using TestRailProject.Steps;

namespace TestRailProject.Tests.GUI
{
    internal class GUITests : BaseTest
    {
        private const string ExpectedLogInErrorMessage = "Sorry, there was a problem.";
        private const string ExpectedLogInErrorDescription = "Email/Login or Password is incorrect. Please try again.";
        private const string ExpectedValidationErrorMessage = "Email/Login is required.";

        [Test, Order(1)]
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

            Assert.Multiple(() =>
            {
                Assert.That(testCasePage.SuccessMessage.Text.Trim(),
                    Is.EqualTo("Successfully added the new test case. Add another"));

                Assert.That(testCasePage.Title.Text, Is.EqualTo(expectedTestCase.Id));
                Assert.That(testCasePage.Section.Text, Is.EqualTo(expectedTestCase.Section));
                Assert.That(testCasePage.Type.Text, Is.EqualTo(expectedTestCase.Type));
                Assert.That(testCasePage.Priority.Text, Is.EqualTo(expectedTestCase.Priority));
            });

                string testId = testCasePage.TestCaseId.Text;

        }
        /*
            [Test, Order(2)]
            public void RemoveTestCase()
            {

            _navigationSteps.MoveToTestSuitesPage()
                .SectionByTitle("Installation")
                .RowById("C4727")
                .Select();

            DeleteDialog delete = _navigationSteps.ClickOnDelete();
            delete.ClickDeletePermanently();
            delete.ClickDeletePermanently();

            Assert.That(_navigationSteps.MoveToTestSuitesPage()
                .SectionByTitle("Installation")
                .RowById("C4727") == null);
        }*/

        [Test]
        public void TooltipHoverTest()
        {
            _navigationSteps.SuccessfulLogin(Admin);
            var toolTip = _navigationSteps.MoveToTestSuitesPage().Tooltip;

            new Actions(Driver)
            .MoveToElement(toolTip)
            .Perform();

            var tooltipText = toolTip.GetAttribute("tooltip-text");

            Assert.That(tooltipText, Is.EqualTo("Copies or moves sections and test cases from another test suite or project."));
        }
    }
}
