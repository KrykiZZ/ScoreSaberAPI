using System.Text.Json.Serialization;

namespace ScoreSaberAPI.Models
{
    public class PlayerScore
    {
        [JsonPropertyName("score")]
        public Score Score { get; set; }

        [JsonPropertyName("leaderboard")]
        public LeaderboardInfo Leaderboard { get; set; }
    }
}
