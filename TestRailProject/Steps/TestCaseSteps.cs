using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V122.Runtime;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TestRailProject.Elements;
using TestRailProject.Models;
using TestRailProject.Pages.ProjectPages;
using static System.Collections.Specialized.BitVector32;

namespace TestRailProject.Steps;

public class TestCaseSteps(IWebDriver? driver) : BaseStep(driver)
{
    public TestCasePage AddTestCase(testCase testCase)
    {
        AddTestCasePage = new AddTestCasePage(driver);

        AddTestCasePage.Title.SendKeys(testCase.Id);

        AddTestCasePage.SectionDropDown.SelectByValue(testCase.Section);

        AddTestCasePage.TemplateDropDown.SelectByValue(testCase.Template);
        //todo Fix Element not found for TypeDropDown
        Thread.Sleep(1000);
        AddTestCasePage.TypeDropDown.SelectByValue(testCase.Type);

        AddTestCasePage.PriorityDropDown.SelectByValue(testCase.Priority);
        Thread.Sleep(1000);

        AddTestCasePage.AddButton.Click();

        return new TestCasePage(driver);
    }

    public TestSuitesPage DeleteTestCase(int sectionId, int rowId)
    {

        TestSuitesPage = new TestSuitesPage(driver);

        TestSuitesPage.GetSectionByID(sectionId)?
            .GetTestRow(rowId)?
            .Delete();

        TestSuitesPage.DeleteDialog.Submit();

        return TestSuitesPage;
    }
    public TestSuitesPage DeleteTestCaseFirst()
    {

        TestSuitesPage = new TestSuitesPage(driver);

        var tempRow = TestSuitesPage.GetSections().First().Rows.First();

        tempRow.Delete();
        TestSuitesPage.DeleteDialog.Submit();

        return TestSuitesPage;
    }

    public TestSuitesPage DeleteTestCaseLast()
    {

        TestSuitesPage = new TestSuitesPage(driver);

        var tempRow = TestSuitesPage.GetSections().First().Rows.Last();

        tempRow.Delete();
        TestSuitesPage.DeleteDialog.Submit();

        return TestSuitesPage;
    }

    public bool FileUpload(string fileName, int suiteId)
    {
        string assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        string filePath = Path.Combine(assemblyPath, "Resources", fileName);

        AddTestCasePage = new AddTestCasePage(Driver, suiteId, true);

        AddTestCasePage.Attachment.SendKeys(filePath);

        return AddTestCasePage.AttachedItem.Displayed;
    }
}