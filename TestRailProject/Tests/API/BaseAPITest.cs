using NLog;
using TestRailProject.Services;
using TestRailProject.Clients;
using NUnit.Framework;

namespace TestRailProject.Tests.API;

public class BaseApiTest
{
    protected readonly Logger _logger = LogManager.GetCurrentClassLogger();
    protected TestSuiteService _testSuiteService;
    protected UserService _userService;

    [OneTimeSetUp]
    public void SetUpApi()
    {
        var restClient = new RestClientExtended();
        _testSuiteService = new TestSuiteService(restClient);
        _userService = new UserService(restClient);
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        _testSuiteService?.Dispose();
        _userService?.Dispose();
    }
}