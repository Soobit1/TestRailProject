using Allure.Net.Commons;
using NUnit.Allure.Core;
using OpenQA.Selenium;
using System.Text;
using TestRailProject.Core;
using TestRailProject.Helpers;
using TestRailProject.Models;
using TestRailProject.Steps;

namespace TestRailProject.Tests.GUI;

[Parallelizable(scope: ParallelScope.Fixtures)]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]

[AllureNUnit]
public class BaseTest
{
    protected IWebDriver Driver { get; private set; }


    protected NavigationSteps _navigationSteps;
    protected TestCaseSteps _testCaseSteps;


    protected User? Admin { get; private set; }

    [SetUp]
    public void Setup()
    {
        Driver = new Browser().Driver;

        _navigationSteps = new NavigationSteps(Driver);
        _testCaseSteps = new TestCaseSteps(Driver);

        Admin = Configurator.Admin;

        Driver.Navigate().GoToUrl(Configurator.AppSettings.URL);
    }

    [TearDown]
    public void TearDown()
    {

        try
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                Screenshot screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                byte[] screenshotBytes = screenshot.AsByteArray;

                AllureApi.AddAttachment("Screenshot", "image/png", screenshotBytes);
                AllureApi.AddAttachment("error.txt", "text/plain", Encoding.UTF8.GetBytes(TestContext.CurrentContext.Result.Message));
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        Driver.Quit();
    }
}