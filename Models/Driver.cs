using System.Text.Json.Serialization;

namespace blackfy_API.Models
{
    public class Driver
    {
        // usando JsonPropertyName para fazer a tradução do json para o objeto
        [JsonPropertyName("driver_number")]
        public int DriverNumber { get; set; }

        [JsonPropertyName("full_name")]
        public string FullName { get; set; }

        [JsonPropertyName("team_name")]
        public string TeamName { get; set; }

    }
}