using NLog;
using TestRailProject.Services;
using TestRailProject.Clients;

namespace TestRailProject.Tests.API;

public class BaseApiTest
{
    private readonly Logger _logger = LogManager.GetCurrentClassLogger();
    protected TestSuiteService? _testSuiteService;


    [OneTimeSetUp]
    public void SetUpApi()
    {
        var restClient = new RestClientExtended();
        _testSuiteService = new TestSuiteService(restClient);
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        _testSuiteService?.Dispose();
    }
}