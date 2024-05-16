using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRailProject.Elements;

public class DeleteDialog
{

    private UIElement _uiElement;

    public DeleteDialog(IWebDriver webDriver, By by)
    {
        _uiElement = new UIElement(webDriver, by);
    }

    public DeleteDialog(IWebDriver webDriver, IWebElement webElement)
    {
        _uiElement = new UIElement(webDriver, webElement);
    }

    public void Cancel() => _uiElement.FindElement(By.ClassName("button-cancel")).Click();
    public void Submit() => _uiElement.FindElement(By.ClassName("button-ok")).Click();
    public bool IsDisplayed => _uiElement.Displayed;

}
