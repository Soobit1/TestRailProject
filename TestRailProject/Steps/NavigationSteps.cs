using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TestRailProject.Models;
using TestRailProject.Pages;
using TestRailProject.Pages.ProjectPages;

namespace TestRailProject.Steps;

public class NavigationSteps(IWebDriver? driver) : BaseStep(driver)
{
    public T Login<T>(User user) where T : BasePage
    {
        var username = "boyop75371@picdv.com";
        var password = "#qb^kta*!rP%6B3";

        var loginPage = new LoginPage(Driver);
        
        loginPage.EmailInput.SendKeys(username);
        loginPage.PswInput.SendKeys(password);
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

    public ProjectDetailsPage ClickOnProject(IWebElement webElement)
    {
        DashboardPage.TargetProject.Click();
        return new ProjectDetailsPage(Driver);
    }

}

