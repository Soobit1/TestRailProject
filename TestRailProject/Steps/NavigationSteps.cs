using Microsoft.Extensions.Primitives;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TestRailProject.Elements;
using TestRailProject.Models;
using TestRailProject.Pages;

namespace TestRailProject.Steps;

public class NavigationSteps(IWebDriver? driver) : BaseStep(driver)
{
    public T Login<T>(User user) where T : BasePage
    {
        var loginPage = new LoginPage(Driver);
        
        loginPage.EmailInput.SendKeys(user.UserName);
        loginPage.PswInput.SendKeys(user.Password);
        loginPage.LoginInButton.Click();

        return (T)Activator.CreateInstance(typeof(T), Driver, false);
    }

    public DashboardPage SuccessfulLogin(User user)
    {
        return Login<DashboardPage>(user);
    }

    public LoginPage IncorrectLogin(User user)
    {
        return Login<LoginPage>(user);
    }

    public LoginPage IncorrectPassword(User user)
    {
        return Login<LoginPage>(user);
    }


    public AddTestCasePage MoveToAddTestCasePage(int suiteId)
    {
        return new AddTestCasePage(Driver, suiteId, true);
    }

    public TestSuitesPage MoveToTestSuitesPage(int suiteId)
    {
        return new TestSuitesPage(Driver, suiteId, true);
    }

}

