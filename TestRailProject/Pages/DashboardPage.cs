using OpenQA.Selenium;

namespace TestRailProject.Pages
{
    public class DashboardPage(IWebDriver? driver, bool openByURL = false) : BasePage(driver, openByURL)
    {
        private const string END_POINT = "index.php?/dashboard";
        
        // Описание элементов
        private static readonly By SidebarProjectsAddButtonBy = By.Id("sidebar-projects-add");
        private static readonly By ProjectBy = By.XPath("//div[text() = 'ExampleProject2']");
        
        protected override bool EvaluateLoadedStatus()
        {
            try
            {
                return SidebarProjectsAddButton.Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        protected override string GetEndpoint()
        {
            return END_POINT;
        }

        public IWebElement SidebarProjectsAddButton => WaitsHelper.WaitForExists(SidebarProjectsAddButtonBy);
        public IWebElement TargetProject => WaitsHelper.WaitForExists(ProjectBy);
    }
}