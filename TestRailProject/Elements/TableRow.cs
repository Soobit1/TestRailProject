using OpenQA.Selenium;

namespace TestRailProject.Elements;

public class TableRow
{
    private UIElement _uiElement;
    private List<TableCell> _cells;
    
    public TableRow(UIElement uiElement)
    {
        _uiElement = uiElement;
        _cells = new List<TableCell>();

        foreach (var cellElement in _uiElement.FindUIElements(By.TagName("td")))
        {
            _cells.Add(new TableCell(cellElement)); 
        }
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="columnName"></param>
    /// <returns></returns>
    public TableCell GetCell(int columnIndex)
    {
        return _cells[columnIndex];
    }

}