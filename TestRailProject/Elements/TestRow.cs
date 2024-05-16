using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using TestRailProject.Helpers;

namespace TestRail.Elements;

public class TestRow
{
    private IWebDriver _webDriver;
    private WaitsHelper _waitsHelper;
    private IWebElement _webElement;
    private Actions _actions;

    private TestRow(IWebDriver webDriver)
    {
        _webDriver = webDriver;
        _waitsHelper = new WaitsHelper(webDriver, TimeSpan.FromSeconds(Configurator.WaitsTimeout));
        _actions = new Actions(webDriver);
    }

    public TestRow(IWebDriver webDriver, By by) : this(webDriver)
    {
        _webElement = _waitsHelper.WaitForExists(by);
    }

    public TestRow(IWebDriver webDriver, IWebElement webElement) : this(webDriver)
    {
        _webElement = webElement;
    }

    public void Click()
    {
        _webElement.Click();
    }

    public void Edit()
    {
        _actions.MoveToElement(_webElement).Perform();
        _waitsHelper.WaitChildElement(_webElement, By.CssSelector(".action.icon-small-edit")).Click();
    }

    public void Delete()
    {
        _actions.MoveToElement(_webElement).Perform();
        _waitsHelper.WaitChildElement(_webElement, By.ClassName("deleteLink")).Click();
    }

    public void Select()
    {
        _waitsHelper.WaitChildElement(_webElement, By.ClassName("selectionCheckbox")).Click();
    }

    public bool IsSelected()
    {
        var className = _webElement.GetAttribute("class");
        return className.Contains("oddSelected") || className.Contains("evenSelected");
    }

    public string ID => _webElement.GetAttribute("id");
    public IWebElement TitleText => _waitsHelper.WaitChildElement(_webElement, By.ClassName("title"));
}