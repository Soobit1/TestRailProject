using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRailProject.Pages.ProjectPages;
using TestRailProject.Pages;

public class BaseStep(IWebDriver driver)
{
    protected readonly IWebDriver Driver = driver;

    protected LoginPage? LoginPage { get; set; }
    protected DashboardPage? DashboardPage { get; set; }
    protected AddTestCasePage? AddTestCasePage { get; set; }
    protected TestSuitesPage? TestSuitesPage { get; set; }

}
