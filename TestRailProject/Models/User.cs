using TestRailProject.Models.Enums;

namespace TestRailProject.Models;

public record User
{
    public UserType UserType { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}