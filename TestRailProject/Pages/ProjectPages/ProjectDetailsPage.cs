using OpenQA.Selenium;

namespace TestRailProject.Pages.ProjectPages;

public class ProjectDetailsPage(IWebDriver? driver, bool openByURL = false) : BasePage(driver, openByURL)
{
    private const string END_POINT = "/index.php?/projects/overview/";
    
    // Описание элементов
    private static readonly By OverviewTabBy = By.Id("navigation-projects");
    private static readonly By SuitesTabBy = By.Id("navigation-suites");
    private static readonly By TestAddBy = By.Id("sidebar-cases-add");

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