using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRail.Elements;
using TestRailProject.Helpers;

namespace TestRailProject.Elements;

public class Section
{
    private UIElement _uiElement;
    private List<TestRow> _rows;

    public Section(IWebDriver webDriver, IWebElement element)
    {
        _uiElement = new UIElement(webDriver, element);
        _rows = new List<TestRow>();

        foreach (var rowElement in _uiElement.FindUIElements(By.XPath("//tr[@class!='header']")))
        {
            _rows.Add(new TestRow(webDriver, rowElement));
        }
    }

    public Section(IWebDriver webDriver, By by)
    {
        _uiElement = new UIElement(webDriver, by);
        _rows = new List<TestRow>();

        foreach (var rowElement in _uiElement.FindUIElements(By.XPath("//tr[@class!='header']")))
        {
            _rows.Add(new TestRow(webDriver, rowElement));
        }
    }

    public TestRow? GetTestRow(int testId)
    {
        return _rows.FirstOrDefault(row => row.ID.Equals("row-" + testId));
    }

    public void SelectAll()
    {
        _uiElement.FindElement(By.ClassName("header")).FindElement(By.ClassName("selectionCheckbox")).Click();
    }

    public IList<TestRow> Rows => _rows;
    public String ID => _uiElement.GetAttribute("id");
}
