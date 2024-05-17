using RestSharp;
using System.Net;
using TestRailProject.Clients;
using TestRailProject.Models;

namespace TestRailProject.Services;
public class TestSuiteService : ITestSuitesService, IDisposable
{
    private readonly RestClientExtended _client;

    public TestSuiteService(RestClientExtended client)
    {
        _client = client;
    }

    private static readonly string GET_SUITE = "index.php?/api/v2/get_suite/{suite_id}";
    private static readonly string GET_SUITES = "index.php?/api/v2/get_suites/{project_id}";
    private static readonly string ADD_SUITE = "index.php?/api/v2/add_suite/{project_id}";
    private static readonly string UPDATE_SUITE = "index.php?/api/v2/update_suite/{suite_id}";
    private static readonly string DELETE_SUITE = "index.php?/api/v2/delete_suite/{suite_id}";

    public Task<TestSuite> GetSuite(int suiteId)
    {
        var request = new RestRequest(GET_SUITE)
            .AddUrlSegment("suite_id", suiteId);

        return _client.ExecuteAsync<TestSuite>(request);
    }

    public async Task<RestResponse> GetSuiteAsync(int suiteId)
    {
        var request = new RestRequest(GET_SUITE)
            .AddUrlSegment("suite_id", suiteId);

        return await _client.ExecuteAsync(request);
    }

    public Task<TestSuite> GetSuites(int projectId)
    {
        var request = new RestRequest(GET_SUITES)
            .AddUrlSegment("project_id", projectId);

        var suites = _client.ExecuteAsync<TestSuite>(request);
        return suites;
    }

    public Task<TestSuite> AddSuite(TestSuite suite, int projectId)
    {
        var request = new RestRequest(ADD_SUITE, Method.Post)
            .AddHeader("Content-Type", "application/json")
            .AddUrlSegment("project_id", projectId)
            .AddBody(suite);

        return _client.ExecuteAsync<TestSuite>(request);
    }

    public Task<TestSuite> UpdateSuite(TestSuite suite, int suiteId)
    {
        var request = new RestRequest(UPDATE_SUITE, Method.Post)
            .AddHeader("Content-Type", "application/json")
            .AddUrlSegment("suite_id", suite.Id)
            .AddBody(suite);

        return _client.ExecuteAsync<TestSuite>(request);
    }
    public HttpStatusCode DeleteSuite(int suiteId)
    {
        var request = new RestRequest(DELETE_SUITE, Method.Post)
            .AddUrlSegment("suite_id", suiteId)
            .AddJsonBody("{}");

        return _client.ExecuteAsync(request).Result.StatusCode;
    }

    public void Dispose()
    {
        _client?.Dispose();
        GC.SuppressFinalize(this);
    }
}