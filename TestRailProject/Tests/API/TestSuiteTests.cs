using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using TestRailProject.Tests.API;
using TestRailProject.Helpers;
using TestRailProject.Models;
using RestSharp;
using NUnit.Framework;


namespace TestRailProject.Tests.APITests;
public class TestSuiteTest : BaseApiTest
{

    [Test(Description = "NFE POST api_test")]
    public void AddSuiteTest()
    {
        var expectedSuite = TestDataHelper.AddTestSuite("SuiteTestJson.json");
        _logger.Info("Expected Suite: " + expectedSuite);

        var actualSuite = _testSuiteService?.AddSuite(expectedSuite, 4);
        _logger.Info("Actual Suite: " + actualSuite?.ToString());

        Console.WriteLine($"Suite Name: {actualSuite?.Result.Name}," +
                          $"Suite Description: {actualSuite?.Result.Description}, Suite Id: {actualSuite?.Id}");
        
        Assert.Multiple(() =>
        {
            Assert.That(actualSuite?.Result.Name, Is.EqualTo(expectedSuite.Name));
            Assert.That(actualSuite?.Result.Description, Is.EqualTo(expectedSuite.Description));
        });
    }

    [Test(Description = "AFE GET api_test")]
    public void GetInvalidSuitTest()
    {
        var actualSuite = _testSuiteService?.GetSuiteAsync(0);

        Assert.That(actualSuite.Result.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
    }
}