using System.Text.Json.Serialization;

namespace ScoreSaberAPI.Models
{
    public class LeaderboardDifficulty
    {
        [JsonPropertyName("leaderboardId")]
        public int LeaderboardId { get; set; }

        [JsonPropertyName("difficulty")]
        public int Difficulty { get; set; }

        [JsonPropertyName("gameMode")]
        public string GameMode { get; set; }

        [JsonPropertyName("difficultyRaw")]
        public string DifficultyRaw { get; set; }
    }
}
