using Microsoft.Extensions.Primitives;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TestRailProject.Elements;
using TestRailProject.Models;
using TestRailProject.Pages;
using TestRailProject.Pages.ProjectPages;

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

    /*
    public void SelectElement(IWebElement element, string value)
    {
        var selectedElement = Driver.FindElement(By.Name(id));
        var SelectElement = new SelectElement(selectedElement);

        SelectElement.SelectByValue(value);
    }*/

    public ProjectDetailsPage MoveToProjectDetailsPage()
    {   
        return new ProjectDetailsPage(Driver);
    }

    public AddTestCasePage MoveToAddTestCasePage()
    {
        return new AddTestCasePage(Driver);
    }

    public TestSuitesPage MoveToTestSuitesPage()
    {
        return new TestSuitesPage(Driver);
    }

    public ProjectDetailsPage ClickOnProject(IWebElement webElement)
    {
        DashboardPage.TargetProject.Click();
        return new ProjectDetailsPage(Driver);
    }

    public DeleteDialog ClickOnDelete()
    {
        TestSuitesPage.DeleteCases.Click();
        return new DeleteDialog(Driver, By.Id("deleteCases"));
    }

    public void SelectSection(IWebDriver driver, string value)
    {

    }

}

