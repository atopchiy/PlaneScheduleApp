using System.Text.Json.Serialization;

namespace PlaneScheduleApp.Models;

public class OrderInfo
{
    [JsonPropertyName("destination")]
    public string Destination { get; set; } = null!;
}