using OpenQA.Selenium;
using TestRailProject.Elements;

namespace TestRailProject.Pages.ProjectPages;

public class AddProjectPage(IWebDriver? driver, bool openByURL = false) : ProjectBasePage(driver, openByURL)
{
    private const string END_POINT = "index.php?/admin/projects/add";

    // Описание элементов
    private static readonly By AddButtonBy = By.Id("accept");

    protected override string GetEndpoint()
    {
        return END_POINT;
    }
    
    protected override bool EvaluateLoadedStatus()
    {
        return WaitsHelper.WaitForVisibilityLocatedBy(AddButtonBy).Displayed;
    }
    
    // Атомарные Методы
    public Button AddButton => new Button(Driver, AddButtonBy);
}