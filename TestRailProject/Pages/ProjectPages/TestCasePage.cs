using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V122.DOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TestRailProject.Elements;

namespace TestRailProject.Pages.ProjectPages;


public class TestCasePage(IWebDriver? driver, bool openByURL = false) : BasePage(driver, openByURL)
{
    private const string END_POINT = "index.php?/admin/projects/cases/view";

    private static readonly By TitleBy = By.ClassName("content-header-title");
    private static readonly By NameBy = By.ClassName("content-header-title-compact");
    private static readonly By IdBy = By.ClassName("content-header-id");

    private static readonly By SuccessMessageBy = By.ClassName("message-success");
    private static readonly By SectionBy = By.ClassName("content-breadcrumb");
    private static readonly By TypeBy = By.Id("cell_type_id");
    private static readonly By PriorityBy = By.Id("cell_priority_id");
    private static readonly By AssignedBy = By.Id("cell_assignedto");
    private static readonly By EstimateBy = By.Id("cell_estimate");
    private static readonly By RefsBy = By.Id("cell_refs");
    private static readonly By AutoBy = By.Id("cell_custom_automation_type");


    private static readonly By AttachmentBy = By.Id("entityAttachmentList");


    protected override bool EvaluateLoadedStatus()
    {
        return Title.Displayed;
    }

    protected override string GetEndpoint()
    {
        return END_POINT;
    }
    public IWebElement Title => WaitsHelper.WaitForExists(TitleBy);
    public IWebElement Name => WaitsHelper.WaitForExists(NameBy);
    public IWebElement SuccessMessage => WaitsHelper.WaitForExists(SuccessMessageBy);
    public IWebElement Section => WaitsHelper.WaitForExists(SectionBy).FindElement(By.TagName("a"));
    public IWebElement Type => WaitsHelper.WaitForExists(TypeBy);
    public IWebElement Priority => WaitsHelper.WaitForExists(PriorityBy);
    public IWebElement Assigned => WaitsHelper.WaitForExists(AssignedBy);
    public IWebElement Estimate => WaitsHelper.WaitForExists(EstimateBy);
    public IWebElement Refs => WaitsHelper.WaitForExists(RefsBy);
    public IWebElement Auto => WaitsHelper.WaitForExists(AutoBy);
    public IWebElement Attachment => WaitsHelper.WaitForExists(AttachmentBy);
    public IWebElement TestCaseId => WaitsHelper.WaitForExists(IdBy);
}

    
