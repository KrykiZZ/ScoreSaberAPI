using System.Text.Json.Serialization;

namespace ScoreSaberAPI.Models
{
    public class ScoreStats
    {
        [JsonPropertyName("totalScore")]
        public long TotalScore;

        [JsonPropertyName("totalRankedScore")]
        public long TotalRankedScore;

        [JsonPropertyName("averageRankedAccuracy")]
        public double AverageRankedAccuracy;

        [JsonPropertyName("totalPlayCount")]
        public int TotalPlayCount;

        [JsonPropertyName("rankedPlayCount")]
        public int RankedPlayCount;

        [JsonPropertyName("replaysWatched")]
        public int ReplaysWatched;
    }
}
