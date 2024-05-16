using OpenQA.Selenium;
using TestRailProject.Helpers;

namespace TestRailProject.Elements;

public class TableTestSuites
{
    private List<UIElement> _uiElements;
    private List<string> _columns;


    public TableTestSuites(IWebDriver driver, By by, By sectionName)
    {

        _columns = new List<string>();

        WaitsHelper _waitsHelper = new WaitsHelper(driver, TimeSpan.FromSeconds(Configurator.WaitsTimeout));

        foreach (var webElement in _waitsHelper.WaitForPresenceOfAllElementsLocatedBy(by))
        {
            UIElement uiElement = new UIElement(driver, webElement);
            _uiElements.Add(uiElement);
        }

        /*
        foreach (var columnElement in _uiElement.FindUIElements(By.TagName("th")))
        {
            _columns.Add(columnElement.Text.Trim());
        }

        foreach (var rowElement in _uiElement.FindUIElements(By.XPath("//tr[@class!='header']")))
        {
            _rows.Add(new TableRow(rowElement));
        }*/
    }
}
