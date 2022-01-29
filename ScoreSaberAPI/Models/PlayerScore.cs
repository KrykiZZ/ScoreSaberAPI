using System.Text.Json.Serialization;

namespace ScoreSaberAPI.Models
{
    public class PlayerScore
    {
        [JsonPropertyName("score")]
        public Score Score;

        [JsonPropertyName("leaderboard")]
        public LeaderboardInfo Leaderboard;
    }
}
