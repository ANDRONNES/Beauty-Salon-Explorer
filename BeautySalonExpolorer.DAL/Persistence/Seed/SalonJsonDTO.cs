using System.Text.Json.Serialization;

namespace BeautySalonExpolorer.DAL.Persistence.Seed;

public class SalonJsonDTO
{
    [JsonPropertyName("title")]
    public required string Title { get; set; }

    [JsonPropertyName("totalScore")]
    public double? TotalScore { get; set; }

    [JsonPropertyName("reviewsCount")]
    public double? ReviewsCount { get; set; }

    [JsonPropertyName("street")]
    public required string Street { get; set; }

    [JsonPropertyName("website")]
    public string? Website { get; set; }

    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    [JsonPropertyName("categories")]
    public List<string> Categories { get; set; } = new();

    [JsonPropertyName("url")]
    public string? LocationUrl { get; set; }

    [JsonPropertyName("neighborhood")]
    public required string District { get; set; }

    [JsonPropertyName("imageUrl")]
    public required string ImageUrl { get; set; }
}