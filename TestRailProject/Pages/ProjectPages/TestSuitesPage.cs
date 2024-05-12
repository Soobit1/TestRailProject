using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRailProject.Pages.ProjectPages
{
    public class TestSuitesPage(IWebDriver? driver, bool openByURL = false) : BasePage(driver, openByURL)
    {
        private const string END_POINT = "index.php?/suites/view";
        
        private static readonly By TitleBy = By.XPath("/html/head/title");

        protected override bool EvaluateLoadedStatus()
        {
            return Title.Displayed;
        }

        protected override string GetEndpoint()
        {
            return END_POINT;
        }

        public IWebElement Title => WaitsHelper.WaitForExists(TitleBy);
    }
}
