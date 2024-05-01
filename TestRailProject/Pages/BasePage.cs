using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TestRailProject.Helpers;


namespace TestRailProject.Pages;

public abstract class BasePage : LoadableComponent<BasePage>
{
    protected IWebDriver Driver { get; }
    protected WaitsHelper WaitsHelper { get; private set; }

    protected BasePage(IWebDriver driver, bool openByURL = false)
    {
        Driver = driver;
        WaitsHelper = new WaitsHelper(Driver, TimeSpan.FromSeconds(Configurator.WaitsTimeout));

        if (openByURL) Load();
    }

    protected abstract string GetEndpoint();

    protected override void ExecuteLoad()
    {
        Driver.Navigate().GoToUrl(Configurator.AppSettings.URL + GetEndpoint());
    }
}