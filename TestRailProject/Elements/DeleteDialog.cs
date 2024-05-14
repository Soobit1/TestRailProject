using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRailProject.Elements;

public class DeleteDialog : UIElement
{
    public DeleteDialog(IWebDriver? webDriver, By by) : base(webDriver, by)
    {

    }

    public void ClickMarkAsDelete()
    {
        _webDriver.FindElement(By.Id("deleteCaseDialogActionDefault")).Click();
    }
    public void ClickDeletePermanently()
    {
        _webDriver.FindElement(By.Id("deleteCaseDialogActionSecondary")).Click();
    }
    public void ClickCancel()
    {
        _webDriver.FindElement(By.Id("deleteCaseDialogActionClose")).Click();  
    }
}
