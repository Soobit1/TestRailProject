using OpenQA.Selenium;
using TestRailProject.Helpers;

namespace TestRailProject.Elements;

public class TableTestSuites
{
    private List<UIElement> _uiElements;
    private List<string> _columns;
    private List<TableRow> _rows;

    
    public TableTestSuites(IWebDriver driver, By by, By sectionName)
    {

        _columns = new List<string>();
        _rows = new List<TableRow>();

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


    public TableCell GetCell(string targetColumn, string uniqueValue, string columnName)
    {
        return GetCell(targetColumn, uniqueValue, _columns.IndexOf(columnName));
    }

    public TableCell GetCell(string targetColumn, string uniqueValue, int columnIndex)
    {
        TableRow tableRow = GetRow(targetColumn, uniqueValue); 
        return tableRow.GetCell(columnIndex);
    }

    public TableRow GetRow(string targetColumn, string uniqueValue)
    {
        foreach (var row in _rows)
        {
            if (row.GetCell(_columns.IndexOf(targetColumn)).Text.Equals(uniqueValue))
            {
                return row;
            }
        }

        return null;
    }
}