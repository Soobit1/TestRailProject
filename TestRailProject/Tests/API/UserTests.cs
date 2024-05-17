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

    [Test(Description = "NFE GET api_test")]
    [Category("API")]
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

    [Test(Description = "NFE GET by email")]
    public void GetUserByEmail()
    {
        var email = "fevogi5662@losvtn.com";
        var actualUser = _userService.GetUserByEmail(email);
        Console.WriteLine("Actual User: " + actualUser?.ToString());

        //Console.WriteLine("Username: " + actualUser?.UserName);
        //Console.WriteLine("Email: " + actualUser?.Email);

        Assert.Multiple(() =>
        {
            Assert.That(actualUser?.Id, Is.EqualTo(1));
            Assert.That(actualUser?.Email, Is.EqualTo(email));
        });
    }

    [Test(Description = "NFE POST api_test")]
    [Category("API")]
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

    [Test(Description = "AFE GET api_test")]
    [Category("API")]
    public void GetInvalidUserTest()
    {
        int userId = 10;

        var actualUser = _userService.GetUserAsync(userId);

        Assert.That(actualUser.Result.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
    }
}
