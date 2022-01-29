using ScoreSaberAPI.Models;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ScoreSaberAPI.Responses
{
    public class GetPlayerScoresResponse
    {
        [JsonPropertyName("playerScores")]
        public List<PlayerScore> PlayerScores;

        [JsonPropertyName("metadata")]
        public Metadata Metadata;
    }
}
