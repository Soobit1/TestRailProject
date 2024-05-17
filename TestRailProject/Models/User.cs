using System.Text.Json.Serialization;
using TestRailProject.Models.Enums;

namespace TestRailProject.Models;

public record User
{
    public UserType UserType { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    [JsonPropertyName("id")] public int Id { get; set; }
    [JsonPropertyName("name")] public string Name { get; set; }
    [JsonPropertyName("email")] public string Email { get; set; }
    [JsonPropertyName("email_notifications")] public bool EmailNotifications { get; set; }
}