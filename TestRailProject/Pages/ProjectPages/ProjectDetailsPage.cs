using OpenQA.Selenium;

namespace TestRailProject.Pages.ProjectPages;

public class ProjectDetailsPage(IWebDriver? driver, bool openByURL = false) : BasePage(driver, openByURL)
{
    private const string END_POINT = "";
    
    // Описание элементов
    private static readonly By OverviewTabBy = By.Id("navigation-projects");

    
    protected override bool EvaluateLoadedStatus()
    {
        return OverviewTab.Displayed;
    }

    protected override string GetEndpoint()
    {
        return END_POINT;
    }
    
    public IWebElement OverviewTab => WaitsHelper.WaitForExists(OverviewTabBy);
}