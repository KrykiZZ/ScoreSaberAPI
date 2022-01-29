using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ScoreSaberAPI.Models
{
    public class Player
    {
        [JsonPropertyName("id")]
        public string Id;

        [JsonPropertyName("name")]
        public string Name;

        [JsonPropertyName("profilePicture")]
        public string ProfilePicture;

        [JsonPropertyName("country")]
        public string Country;

        [JsonPropertyName("pp")]
        public double PP;

        [JsonPropertyName("rank")]
        public int Rank;

        [JsonPropertyName("countryRank")]
        public int CountryRank;

        [JsonPropertyName("role")]
        public string Role;

        [JsonPropertyName("badges")]
        public List<Badge> Badges;

        [JsonPropertyName("histories")]
        public string Histories;

        [JsonPropertyName("permissions")]
        public int Permissions;

        [JsonPropertyName("banned")]
        public bool Banned;

        [JsonPropertyName("inactive")]
        public bool Inactive;

        [JsonPropertyName("scoreStats")]
        public ScoreStats ScoreStats;
    }
}
