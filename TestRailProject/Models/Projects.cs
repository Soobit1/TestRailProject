using System.Text.Json.Serialization;
using TestRailProject.Models;

namespace TestRail.Models;

public record Projects
{
    [JsonPropertyName("offset")] public int Offset { get; set; }
    [JsonPropertyName("limit")] public int Limit { get; set; }
    [JsonPropertyName("size")] public int Size { get; set; }
    [JsonPropertyName("_links")] public Links Links { get; set; }
    [JsonPropertyName("projects")] public Project[] ProjectsList { get; set; }
}