using System.Text.Json.Serialization;

namespace ScoreSaberAPI.Models
{
    public class LeaderboardPlayerInfo
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("profilePicture")]
        public string ProfilePicture { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("permissions")]
        public int Permissions { get; set; }

        [JsonPropertyName("badges")]
        public string Badges { get; set; }

        [JsonPropertyName("role")]
        public string Role { get; set; }
    }
}
