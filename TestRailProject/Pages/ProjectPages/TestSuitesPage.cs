using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using TestRailProject.Elements;
using TestRailProject.Helpers;

namespace TestRailProject.Pages.ProjectPages
{
    public class TestSuitesPage(IWebDriver? driver, bool openByURL = false) : BasePage(driver, openByURL)
    {
        private const string END_POINT = "index.php?/suites/view";

        private static readonly By TitleBy = By.XPath("/html/head/title");
        private static readonly By GroupsBy = By.Id("groups");
        private static readonly By SectionBy = By.CssSelector(".group.grid-container");
        private static readonly By TooltipBy = By.XPath(".//a[contains(@tooltip-header,'Copy or Move Cases')]");
        private static readonly By DeleteCaseBy = By.Id("deleteCases");

        protected override bool EvaluateLoadedStatus()
        {
            return Title.Displayed;
        }

        protected override string GetEndpoint()
        {
            return END_POINT;
        }

        public IWebElement Title => WaitsHelper.WaitForExists(TitleBy);
        public IWebElement Tooltip => WaitsHelper.WaitForExists(TooltipBy);
        public Button DeleteCases = new Button(driver, DeleteCaseBy);

        public List<Section> GetSections()
        {
            var result = new List<Section>();
            foreach (var section in WaitsHelper.WaitForAllVisibleElementsLocatedBy(SectionBy))
            {
                result.Add(new Section(Driver, section));
            }
            return result;
        }

        public Section? SectionByTitle(string title)
        {
            //return GetSections().First(s => s.Title.Text.Equals(title)); 
            foreach (var section in GetSections())
            {
                if (section.Title.Text.Trim().Equals(title))
                {
                    return section;
                }
            }
            return null;
        }


    }
}
