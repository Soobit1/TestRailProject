using NLog;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TestRailProject.Helpers;
using TestRailProject.Models;

namespace TestRailProject.Tests.API;

public class UserTestApi : BaseApiTest
{

    [Test]
    [Category("NFE")]
    [Description("GET Current user")]
    public void GetCurrentUserTest()
    {
        int user = 1;
        var actualUser = _userService.GetCurrentUser(user);
        Console.WriteLine("Actual User: " + actualUser?.ToString());
       
        Assert.Multiple(() =>
        {
            Assert.That(actualUser?.Id, Is.EqualTo(user));
            Assert.That(actualUser?.Name, Is.EqualTo("Good Day"));
        });
    }

    [Test]
    [Category("NFE")]
    [Description("GET User by email")]
    public void GetUserByEmail()
    {
        var email = "fevogi5662@losvtn.com";
        var actualUser = _userService.GetUserByEmail(email);

        Console.WriteLine("Actual User: " + actualUser?.ToString());

        Assert.Multiple(() =>
        {
            Assert.That(actualUser?.Id, Is.EqualTo(1));
            Assert.That(actualUser?.Email, Is.EqualTo(email));
        });
    }

    [Test]
    [Category("NFE")]
    [Description("POST Update user params")]
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
        Console.WriteLine("Actual User: " + actualUser?.ToString());

        Assert.Multiple(() =>
        {
            Assert.That(actualUser?.Id, Is.EqualTo(userId));
            Assert.That(actualUser?.EmailNotifications, Is.EqualTo(EmailNotifications));
        });
    }
    
    [Test]
    [Category("AFE")]
    [Description("GET non-existing user")]
    public void GetInvalidUserTest()
    {
        int userId = 10;

        var actualUser = _userService.GetUserAsync(userId);

        Assert.That(actualUser.Result.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
    }
}
