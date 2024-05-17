using RestSharp;
using TestRailProject.Clients;
using TestRailProject.Models;

namespace TestRailProject.Services;

public class UserService : IUserService
{
    private readonly RestClientExtended _client;

    private static readonly string GET_USER = "index.php?/api/v2/get_user/{user_id}";
    private static readonly string GET_CURRENT_USER = "index.php?/api/v2/get_current_user/{user_id}";
    private static readonly string GET_USER_BY_EMAIL = "index.php?/api/v2/get_user_by_email&email={email}";
    private static readonly string UPDATE_USER = "index.php?/api/v2/update_user/{user_id}";

    public UserService(RestClientExtended client)
    {
        _client = client;
    }

    public User GetUser(int userId)
    {
        var request = new RestRequest(GET_USER)
            .AddUrlSegment("user_id", userId);

        return _client.Execute<User>(request);
    }

    public User GetCurrentUser(int userId)
    {
        var request = new RestRequest(GET_CURRENT_USER)
            .AddUrlSegment("user_id", userId);

        return _client.Execute<User>(request);
    }

    public User GetUserByEmail(string email)
    {
        var request = new RestRequest(GET_USER_BY_EMAIL)
           .AddQueryParameter("email", email);
        

        return _client.Execute<User>(request);
    }

    public User UpdateUser(User user, int userId)
    {
        var request = new RestRequest(UPDATE_USER, Method.Post)
            .AddUrlSegment("user_id", userId)
            .AddHeader("Content-Type", "application/json")
            .AddBody(user);

        return _client.Execute<User>(request);
    }

    public async Task<RestResponse> GetUserAsync(int userId)
    {
        var request = new RestRequest(GET_USER)
            .AddUrlSegment("project_id", userId);

        return await _client.ExecuteAsync<RestResponse>(request);
    }
    public void Dispose()
    {
        _client?.Dispose();
        GC.SuppressFinalize(this);
    }
}
