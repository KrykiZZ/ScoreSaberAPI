using System.Text.Json.Serialization;

namespace ScoreSaberAPI.Models
{
    public class ScoreStats
    {
        [JsonPropertyName("totalScore")]
        public long TotalScore { get; set; }

        [JsonPropertyName("totalRankedScore")]
        public long TotalRankedScore { get; set; }

        [JsonPropertyName("averageRankedAccuracy")]
        public double AverageRankedAccuracy { get; set; }

        [JsonPropertyName("totalPlayCount")]
        public int TotalPlayCount { get; set; }

        [JsonPropertyName("rankedPlayCount")]
        public int RankedPlayCount { get; set; }

        [JsonPropertyName("replaysWatched")]
        public int ReplaysWatched { get; set; }
    }
}
