using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRailProject.Elements;

public class CheckBox
{
    private UIElement _uiElement;

    public CheckBox(IWebDriver driver, By by)
    {
        _uiElement = new UIElement(driver, by);
    }

    public void CheckBoxCheck()
    {
        _uiElement.Click();
    }

    public bool Check()
    {
        if (_uiElement.Selected) 
        { 
            return true; 
        }
        else return false;
    }
}
