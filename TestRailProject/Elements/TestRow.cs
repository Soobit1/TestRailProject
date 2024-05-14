using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRailProject.Helpers;

namespace TestRailProject.Elements;

public class TestRow : UIElement
{
    public TestRow(IWebDriver driver, By by) : base(driver, by)   {    }

    public TestRow(IWebDriver driver, IWebElement webElement) : base(driver, webElement) { }
    public string GetId()
    {
        return FindElement(By.XPath("//td[@class='id']")).Text;
    }

    public string GetTitle()
    {
        return FindElement(By.XPath("//td[@class='title']")).Text;
    }

    //public IWebElement Title => _waitsHelper.WaitForExists(By.XPath("//td[@class='title']"));

    public RadioButton CheckBox()
    {
        return new RadioButton(_webDriver, By.XPath(""));
    }

    public void Select()
    {
        FindElement(By.ClassName("selectionCheckbox")).Click();
    }

    public bool IsSelected()
    {
        return FindElement(By.ClassName("selectionCheckbox")).Selected;
    }

  
}


