using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRailProject.Elements;

public class Section : UIElement
{
    public Section(IWebDriver driver, By by) : base(driver, by) { }

    public Section(IWebDriver driver, IWebElement e) : base(driver, e) { }

    public IWebElement Title => FindElement(By.ClassName("title"));

    public List<TestRow> TestRows()
    {
        List<TestRow> result = new List<TestRow>();
        foreach (var elem in _webElement.FindElements(By.ClassName("caseRow")))
        {
            result.Add(new TestRow(_webDriver, elem));
        }
        return result;
    }

    public TestRow? RowById(string id)
    {
        foreach (var row in TestRows())
        {
            if (row.GetId().Equals(id))
            {
                return row;
            }
        }
        return null;
    }

    
}
