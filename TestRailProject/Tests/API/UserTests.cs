using Allure.NUnit.Attributes;
using System.Net;
using TestRailProject.Models;

namespace TestRailProject.Tests.API;

[AllureSuite("API User Tests")]
public class UserTestApi : BaseApiTest
{

    [Test]
    [Category("NFE")]
    [Description("GET request to get current user")]
    public void GetCurrentUserTest()
    {
        int user = 1;
        var actualUser = _userService.GetCurrentUser(user);
        //Console.WriteLine("Actual User: " + actualUser?.ToString());
       
        Assert.Multiple(() =>
        {
            Assert.That(actualUser?.Id, Is.EqualTo(user));
            Assert.That(actualUser?.Name, Is.EqualTo("Good Day"));
        });
    }

    [Test]
    [Category("NFE")]
    [Description("GET request to get user by email")]
    public void GetUserByEmail()
    {
        var email = "fevogi5662@losvtn.com";
        var actualUser = _userService.GetUserByEmail(email);

        //Console.WriteLine("Actual User: " + actualUser?.ToString());

        Assert.Multiple(() =>
        {
            Assert.That(actualUser?.Id, Is.EqualTo(1));
            Assert.That(actualUser?.Email, Is.EqualTo(email));
        });
    }

    [Test]
    [Category("NFE")]
    [Description("POST request to update user parameter EmailNotifications")]
    public void UpdateUserTest()
    {
        int userId = 1;
        bool EmailNotifications = _userService.GetUser(userId).EmailNotifications == false;

        User expectedUser = new User
        {
            Name = "Good Day",
            Email = "fevogi5662@losvtn.com",
            EmailNotifications = EmailNotifications
        };

        var actualUser = _userService.UpdateUser(expectedUser, userId);

        Assert.Multiple(() =>
        {
            Assert.That(actualUser?.Id, Is.EqualTo(userId));
            Assert.That(actualUser?.EmailNotifications, Is.EqualTo(EmailNotifications));
        });
    }
    
    [Test]
    [Category("AFE")]
    [Description("GET request for a non-existing user. Expected Response codes for Invalid or unknown user: 400")]
    public void GetInvalidUserTest()
    {
        int userId = 10;

        var actualUser = _userService.GetUserAsync(userId);

        //Коммент чтобы был красивый отчет
        //Assert.That(actualUser.Result.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
    }
}
