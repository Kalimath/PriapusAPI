using System.Text.Json.Serialization;

namespace MbDevelopment.Greenmaster.Contracts.WebApi.Dto;

public class AddGenusDto
{
    [JsonPropertyName(name: "latinName")] 
    public string LatinName { get; set; }

    [JsonPropertyName(name: "description")]
    public string? Description { get; set; }
}