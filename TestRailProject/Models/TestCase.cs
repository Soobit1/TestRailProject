using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TestRailProject.Models;

public record testCase
{
    [JsonPropertyName("id")] public string Id { get; set; }
    [JsonPropertyName("section")] public string Section { get; set; }
    [JsonPropertyName("template")] public string Template { get; set; }
    [JsonPropertyName("type")] public string Type { get; set; }
    [JsonPropertyName("priority")] public string Priority { get; set; }
    [JsonPropertyName("assigned")] public string Assigned { get; set; }
    [JsonPropertyName("estimate")] public string Estimate { get; set; }
    [JsonPropertyName("references")] public string References { get; set; }
    [JsonPropertyName("automation")] public string AutomationType { get; set; }
}