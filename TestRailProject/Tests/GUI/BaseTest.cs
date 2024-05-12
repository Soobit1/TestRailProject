using Allure.Net.Commons;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using TestRailProject.Core;
using TestRailProject.Helpers;
using TestRailProject.Models;
using TestRailProject.Steps;

namespace TestRailProject.Tests.GUI;


public class BaseTest
{
    protected IWebDriver Driver { get; private set; }

    //todo
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
        // Проверка, был ли тест сброшен
        try
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                // Создание скриншота
                Screenshot screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                byte[] screenshotBytes = screenshot.AsByteArray;

                // Прикрепление скриншота к отчету Allure
                //AllureApi.AddAttachment("Screenshot", "image/png", screenshotBytes);
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