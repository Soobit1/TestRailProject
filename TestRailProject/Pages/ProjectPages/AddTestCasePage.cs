using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TestRailProject.Elements;
using TestRailProject.Helpers;

namespace TestRailProject.Pages.ProjectPages
{
    public class AddTestCasePage(IWebDriver? driver, int? suiteId = null, bool openByURL = false) : BasePage(driver, openByURL)
    {
        private const string END_POINT = "/index.php?/cases/add/";

        private static readonly By AddButtonBy = By.Id("accept");

        private static readonly By TitleBy = By.Id("title");
        private static readonly By SectionBy = By.Id("section_id_chzn");
        private static readonly By TemplateBy = By.Id("template_id_chzn");
        private static readonly By TypeBy = By.Id("type_id_chzn");
        private static readonly By PriorityBy = By.Id("priority_id_chzn");
        private static readonly By AttachmentBy = By.ClassName("dz-hidden-input");
        private static readonly By AttachedItemBy = By.XPath(".//div[contains(@data-testid,'attachmentListItem')]");


        protected override bool EvaluateLoadedStatus()
        {
            return WaitsHelper.WaitForVisibilityLocatedBy(TitleBy).Displayed;
        }

        protected override string GetEndpoint()
        {
            return END_POINT + suiteId;
        }

        public IWebElement Title => WaitsHelper.WaitForExists(TitleBy);
        public IWebElement Attachment => WaitsHelper.WaitForExists(AttachmentBy);
        public IWebElement AttachedItem => WaitsHelper.WaitForExists(AttachedItemBy);
        public Button AddButton => new Button(Driver, AddButtonBy);
        public DropDown SectionDropDown => new DropDown(Driver, SectionBy, By.TagName("li"));
        public DropDown TemplateDropDown => new DropDown(Driver, TemplateBy, By.TagName("li"));
        public DropDown TypeDropDown => new DropDown(Driver, WaitsHelper.WaitForExists(TypeBy), By.TagName("li"));
        public DropDown PriorityDropDown => new DropDown(Driver, PriorityBy, By.TagName("li"));

    }
}
