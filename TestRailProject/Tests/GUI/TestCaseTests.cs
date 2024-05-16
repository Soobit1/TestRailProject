using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Web;
using TestRailProject.Core;
using TestRailProject.Elements;
using TestRailProject.Models;
using TestRailProject.Pages;
using TestRailProject.Pages.ProjectPages;
using TestRailProject.Steps;
using Bogus;
using System.Security.Cryptography;

namespace TestRailProject.Tests.GUI
{
    internal class GUITests : BaseTest
    {
        private const string ExpectedLogInErrorMessage = "Sorry, there was a problem.";
        private const string ExpectedLogInErrorDescription = "Email/Login or Password is incorrect. Please try again.";
        private const string ExpectedValidationErrorMessage = "Email/Login is required.";

        [Test]
        public void AddTestCase()
        {

            _navigationSteps.SuccessfulLogin(Admin);
            _navigationSteps.MoveToAddTestCasePage(9);

            testCase expectedTestCase = new testCase()
             {
                    Id = "NyaTest",
                    Section = "Test Cases",
                    Template = "Test Case (Steps)",
                    Type = "Functional",
                    Priority = "High",
             };

            TestCasePage testCasePage = _testCaseSteps.AddTestCase(expectedTestCase);

            Assert.Multiple(() =>
            {
                Assert.That(testCasePage.SuccessMessage.Text.Trim(),
                    Is.EqualTo("Successfully added the new test case. Add another"));

                Assert.That(testCasePage.Title.Text.Trim, Is.EqualTo(expectedTestCase.Id));
                Assert.That(testCasePage.Section.Text.Trim, Is.EqualTo(expectedTestCase.Section));
                Assert.That(testCasePage.Type.Text.Remove(0, 6), Is.EqualTo(expectedTestCase.Type));
                Assert.That(testCasePage.Priority.Text.Remove(0, 10), Is.EqualTo(expectedTestCase.Priority));
            });

            var temp1 = testCasePage.TestCaseId.Text.Trim();
            int rowId = Int32.Parse(temp1.Remove(0, 1));

            string myUri = testCasePage.Section.GetAttribute("href");
            Uri a = new Uri(myUri);
            string sectionIdUri = HttpUtility.ParseQueryString(a.Query).Get("group_id");
            int sectionId = Int32.Parse(sectionIdUri);

            Console.WriteLine(sectionId);
            Console.WriteLine(rowId);

            _navigationSteps.MoveToTestSuitesPage(9);
            
            _testCaseSteps.DeleteTestCase(sectionId, rowId);
        }

        [Test]
        public void TestCaseUploadFile()
        {

            _navigationSteps.SuccessfulLogin(Admin);
            _navigationSteps.MoveToAddTestCasePage(9);

            Assert.That(_testCaseSteps.FileUpload("kitten.jpg", 9));
            //Thread.Sleep(4000);
        }

        [Test]
        public void AddTestCaseFailed()
        {

            _navigationSteps.SuccessfulLogin(Admin);
            _navigationSteps.MoveToAddTestCasePage(9);

            var f = new Faker();
            var title = f.Random.Words(250);

            testCase expectedTestCase = new testCase()
            {
                Id = title,
                Section = "Test Cases",
                Template = "Test Case (Steps)",
                Type = "Functional",
                Priority = "High",
            };

            TestCasePage testCasePage = _testCaseSteps.AddTestCase(expectedTestCase);

            Assert.That(testCasePage.Title.Text.Trim, Is.EqualTo(expectedTestCase.Id));
        }

        [Test]
        public void DeleteTestCase()
        {
            _navigationSteps.SuccessfulLogin(Admin);
            var page = _navigationSteps.MoveToTestSuitesPage(9);
            var row = page.GetSectionByID(369)?.GetTestRow(4744);
            row?.Delete();
            Assert.That(page.DeleteDialog.IsDisplayed, Is.True);

            page.DeleteDialog.Submit();
             Thread.Sleep(2000);
            Assert.That(page.GetSectionByID(185)?.GetTestRow(2394), Is.Null);
        }

        [Test]
        public void DialogBoxTest()
        {
            _navigationSteps.SuccessfulLogin(Admin);
            var page = _navigationSteps.MoveToTestSuitesPage(9);
            page.GetSections().First().SelectAll();
            page.DeleteCases.Click();

            Assert.That(page.DeleteDialog.IsDisplayed, Is.True);
        }


        [Test]
        public void TooltipHoverTest()
        {
            _navigationSteps.SuccessfulLogin(Admin);

            Driver.FindElement(By.XPath("//a[text()='ExampleProject2']")).Click();
            Driver.FindElement(By.Id("navigation-suites")).Click();

            var toolTip = _navigationSteps.MoveToTestSuitesPage(1).Tooltip;
            
            new Actions(Driver)
            .MoveToElement(toolTip)
            .Perform();

            Thread.Sleep(2000);

            var tooltipText = toolTip.GetAttribute("tooltip-text");

            Assert.That(tooltipText, Is.EqualTo("Copies or moves sections and test cases from another test suite or project."));
        }
    }
}
