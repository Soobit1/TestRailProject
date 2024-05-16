using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRailProject.Helpers;

namespace TestRailProject.Elements;
public class DropDown
{
    private UIElement _uiElement;
    private List<UIElement> _options;

    public DropDown(IWebDriver? webDriver, By by, By dropdownOptionsLocator)
    {
            _uiElement = new UIElement(webDriver, by);
            _options = _uiElement.FindUIElements(dropdownOptionsLocator);
    }

    public DropDown(IWebDriver? webDriver, IWebElement webElement, By dropdownOptionsLocator)
    {
        _uiElement = new UIElement(webDriver, webElement);
        _options = _uiElement.FindUIElements(dropdownOptionsLocator);
    }
    public void SelectByValue(string value)
    {
        _uiElement.Click();

        foreach (var option in _options)
        {
            if (option.Text.Contains(value))
            {
                option.Click();
                return;
            }
        }
        throw new NoSuchElementException($"Option with text '{value}' not found in the dropdown.");
    }
}
