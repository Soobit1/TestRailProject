using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Web;
using TestRailProject.Models;
using TestRailProject.Pages.ProjectPages;
using Bogus;
using NUnit.Allure.Attributes;
using Allure.Commons;


namespace TestRailProject.Tests.GUI;
[AllureSuite("UI Test case tests")]
internal class GUITests : BaseTest
{
    private const string ExpectedLogInErrorMessage = "Sorry, there was a problem.";
    private const string ExpectedLogInErrorDescription = "Email/Login or Password is incorrect. Please try again.";
    private const string ExpectedValidationErrorMessage = "Email/Login is required.";

    [Test]
    [Order(2)]
    [Category("Regression")]
    [Description("Adding a new test case")]
    [AllureFeature("Positive UI Tests")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureOwner("Admin")]
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
    [Order(4)]
    [Category("Regression")]
    [Description("File upload function for new test case")]
    [AllureFeature("Positive UI Tests")]
    [AllureSeverity(SeverityLevel.normal)]
    [AllureOwner("Admin")]
    public void TestCaseUploadFile()
    {

        _navigationSteps.SuccessfulLogin(Admin);
        _navigationSteps.MoveToAddTestCasePage(9);

        Assert.That(_testCaseSteps.FileUpload("kitten.jpg", 9));
        //Thread.Sleep(4000);
    }

    [Test]
    [Order(3)]
    [Category("Smoke")]
    [Category("Regression")]
    [Description("Test case title boundary")]
    [AllureFeature("Negative UI Tests")]
    [AllureSeverity(SeverityLevel.minor)]
    [AllureOwner("Admin")]
    public void AddTestCaseBoundary()
    {

        _navigationSteps.SuccessfulLogin(Admin);
        _navigationSteps.MoveToAddTestCasePage(9);

        var f = new Faker();
        var title = f.Random.String2(260);

        testCase expectedTestCase = new testCase()
        {
            Id = title,
            Section = "Test Cases",
            Template = "Test Case (Steps)",
            Type = "Functional",
            Priority = "High",
        };

        TestCasePage testCasePage = _testCaseSteps.AddTestCase(expectedTestCase);
        Thread.Sleep(2000);
        Assert.That(testCasePage.Name.Text.Length, Is.InRange(0,250));
    }

    [Test]
    [Order(1)]
    [Category("Regression")]
    [Description("Deleteing a test case")]
    [AllureFeature("Positive UI Tests")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureOwner("Admin")]
    public void DeleteTestCase()
    {
        var sectionId = 369;
       
        _navigationSteps.SuccessfulLogin(Admin);
        var page = _navigationSteps.MoveToTestSuitesPage(9);

        var tempRow = page.GetSections().First().Rows.First();

        Console.WriteLine(tempRow.ID);
        var testrowId = tempRow.ID;
  

        tempRow.Delete();
        page.DeleteDialog.Submit();
        Thread.Sleep(2000);

        Assert.That(page.GetSectionByID(sectionId)?.GetTestRow(testrowId), Is.Null);
    }

    [Test]
    [Order(5)]
    [Category("Regression")]
    [Description("Dialog box display when deleting a test case")]
    [AllureFeature("Positive UI Tests")]
    [AllureSeverity(SeverityLevel.normal)]
    [AllureOwner("Admin")]
    public void DialogBoxTest()
    {
        _navigationSteps.SuccessfulLogin(Admin);
        var page = _navigationSteps.MoveToTestSuitesPage(9);
        page.GetSections().First().SelectAll();
        page.DeleteCases.Click();

        Assert.That(page.DeleteDialog.IsDisplayed, Is.True);
    }


    [Test]
    [Order(6)]
    [Category("Smoke")]
    [Category("Regression")]
    [Description("Tooltip display after hover on test suites page")]
    [AllureFeature("Positive UI Tests")]
    [AllureSeverity(SeverityLevel.minor)]
    [AllureOwner("Admin")]
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
