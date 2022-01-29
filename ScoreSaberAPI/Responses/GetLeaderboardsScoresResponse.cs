using ScoreSaberAPI.Models;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ScoreSaberAPI.Responses
{
    public class GetLeaderboardsScoresResponse
    {
        [JsonPropertyName("scores")]
        public List<Score> Scores;

        [JsonPropertyName("metadata")]
        public Metadata Metadata;
    }
}
