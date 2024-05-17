using Allure.Net.Commons;
using Allure.NUnit.Attributes;
using TestRailProject.Models;

namespace TestRailProject.Tests.GUI;

[AllureSuite("UI login screen tests")]
public class LoginTest : BaseTest
{
    [Test]
    [Category("Smoke")]
    [Category("Regression")]
    [Description("Successful login test")]
    [AllureFeature("Positive UI Tests")]
    [AllureSeverity(SeverityLevel.normal)]
    [AllureOwner("Admin")]
    public void SuccessfulLoginTest()
    {
        Assert.That(
            _navigationSteps
                .SuccessfulLogin(Admin)
                .SidebarProjectsAddButton
                .Displayed
        );
    }

    [Test]
    [Category("Regression")]
    [Description("Login with incorrect password")]
    [AllureFeature("Negative UI Tests")]
    [AllureSeverity(SeverityLevel.normal)]
    [AllureOwner("Admin")]
    public void InvalidPasswordLoginTest()
    {
        Assert.That(
            _navigationSteps
                .IncorrectPassword(new User
                {
                    UserName = Admin.UserName,
                    Password = "wrongPassword",
                })
                .GetErrorLabelText(),
            Is.EqualTo("Email/Login or Password is incorrect. Please try again."));
    }

    [Test]
    [Category("Regression")]
    [Description("Login with incorrect username")]
    [AllureFeature("Negative UI Tests")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureOwner("Admin")]
    public void InvalidUsernameLoginTest()
    {
        Assert.That(
            _navigationSteps
                .IncorrectLogin(new User
                {
                    UserName = "ThisIsAWrongName",
                    Password = Admin.Password,
                })
                .GetErrorLabelText(),
        Is.EqualTo("Email/Login or Password is incorrect. Please try again."));
    }
    
}