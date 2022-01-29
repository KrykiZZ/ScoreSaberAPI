using System.Text.Json.Serialization;

namespace ScoreSaberAPI.Models
{
    public class LeaderboardPlayerInfo
    {
        [JsonPropertyName("id")]
        public string Id;

        [JsonPropertyName("name")]
        public string Name;

        [JsonPropertyName("profilePicture")]
        public string ProfilePicture;

        [JsonPropertyName("country")]
        public string Country;

        [JsonPropertyName("permissions")]
        public int Permissions;

        [JsonPropertyName("badges")]
        public string Badges;

        [JsonPropertyName("role")]
        public string Role;
    }
}
