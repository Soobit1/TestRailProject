using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using TestRailProject.Elements;
using TestRailProject.Helpers;

namespace TestRailProject.Pages
{
    public class TestSuitesPage(IWebDriver? driver, int? suiteId = null, bool openByURL = false) : BasePage(driver, openByURL)
    {
        private const string END_POINT = "/index.php?/suites/view/";

        private static readonly By AddTestCaseButtonBy = By.Id("sidebar-cases-add");
        private static readonly By GroupsBy = By.Id("groups");
        private static readonly By SectionBy = By.XPath("//*[contains(@id, 'section-')]");
        private static readonly By TooltipBy = By.XPath(".//a[contains(@tooltip-header,'Copy or Move Cases')]");
        private static readonly By DeleteCaseBy = By.Id("deleteCases");
        private static readonly By DeletionDialogBy = By.Id("dialog-ident-casesDeletionDialog");

        protected override bool EvaluateLoadedStatus()
        {
            return WaitsHelper.WaitForVisibilityLocatedBy(AddTestCaseButtonBy).Displayed;
        }

        protected override string GetEndpoint()
        {
            return END_POINT + suiteId;
        }

        public Button AddTestCaseButton => new(Driver, AddTestCaseButtonBy);
        public IWebElement Tooltip => WaitsHelper.WaitForExists(TooltipBy);
        public Button DeleteCases => new(driver, DeleteCaseBy);

        public DeleteDialog DeleteDialog => new(Driver, WaitsHelper.WaitForVisibilityLocatedBy(DeletionDialogBy));

        public List<Section> GetSections()
        {
            var result = new List<Section>();
            foreach (var section in WaitsHelper.WaitForAllVisibleElementsLocatedBy(SectionBy))
            {
                result.Add(new Section(Driver, section));
            }
            return result;
        }

        public Section? GetSectionByID(int sectionId)
        {
            return GetSections().FirstOrDefault(section => section.ID.Equals("section-" + sectionId));
        }
    }


}