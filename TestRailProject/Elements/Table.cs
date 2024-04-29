using OpenQA.Selenium;

namespace TestRailProject.Elements;

public class Table
{
    private UIElement _uiElement;
    private List<string> _columns;
    private List<TableRow> _rows;
    
    
    /// <summary>
    /// Локатор данного элемента должен использовать тэг table
    /// </summary>
    /// <param name="webDriver"></param>
    /// <param name="by"></param>
    public Table(IWebDriver webDriver, By by)
    {
        _uiElement = new UIElement(webDriver, by);
        _columns = new List<string>();
        _rows = new List<TableRow>();

        foreach (var columnElement in _uiElement.FindUIElements(By.TagName("th")))
        {
            _columns.Add(columnElement.Text.Trim());
        }

        foreach (var rowElement in _uiElement.FindUIElements(By.XPath("//tr[@class!='header']")))
        {
            _rows.Add(new TableRow(rowElement));
        }
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="targetColumn"></param>
    /// <param name="uniqueValue"></param>
    /// <param name="columnName"></param>
    /// <returns></returns>
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