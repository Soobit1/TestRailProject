using Allure.Net.Commons;
using AngleSharp.Dom;
using NUnit.Framework;
using TestRailProject.Helpers;
using TestRailProject.Models;

namespace TestRailProject.Tests.GUI;

public class LoginTest : BaseTest
{
    [Test]
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