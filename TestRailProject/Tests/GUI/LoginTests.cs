using AngleSharp.Dom;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using TestRailProject.Helpers;
using TestRailProject.Models;

namespace TestRailProject.Tests.GUI;

[AllureSuite("UI login screen tests")]
public class LoginTest : BaseTest
{
    [Test]
    [Category("Smoke")]
    [Category("Regression")]
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