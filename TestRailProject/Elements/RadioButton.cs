using OpenQA.Selenium;
using TestRailProject.Helpers;

namespace TestRailProject.Elements;

public class RadioButton
{
    private List<UIElement> _uiElements;
    private List<string> _values;
    private List<string> _texts;
    
    /// <summary>
    /// Локатор данного элемента должен использовать атрибут name
    /// </summary>
    /// <param name="webDriver"></param>
    /// <param name="by"></param>
    public RadioButton(IWebDriver webDriver, By by)
    {
        _uiElements = new List<UIElement>();
        _values = new List<string>();
        _texts = new List<string>();
        
        WaitsHelper _waitsHelper = new WaitsHelper(webDriver, TimeSpan.FromSeconds(Configurator.WaitsTimeout));
            
        foreach (var webElement in _waitsHelper.WaitForPresenceOfAllElementsLocatedBy(by))
        {
            UIElement uiElement = new UIElement(webDriver, webElement);
            _uiElements.Add(uiElement);
            _values.Add(uiElement.GetAttribute("value"));
            _texts.Add(uiElement.FindUIElement(By.XPath("parent::*/strong")).Text.Trim());
        }
    }

    public void SelectByIndex(int index)
    {
        if (index < _uiElements.Count)
        {
            _uiElements[index].Click();
        }
        else
        {
            throw new AssertionException("Превышен индекс");
        }
    }

    public void SelectByValue(string value)
    {
        _uiElements[_values.IndexOf(value)].Click();
    }

    public void SelectByText(string text)
    {
        var index = _texts.IndexOf(text);
        _uiElements[index].Click();
    }

    public List<string> GetOptions()
    {
        return _texts;
    }
}