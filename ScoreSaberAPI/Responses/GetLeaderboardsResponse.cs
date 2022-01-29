using ScoreSaberAPI.Models;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ScoreSaberAPI.Responses
{
    public class GetLeaderboardsResponse
    {
        [JsonPropertyName("leaderboards")]
        public List<LeaderboardInfo> Leaderboards { get; set; }

        [JsonPropertyName("metadata")]
        public Metadata Metadata { get; set; }
    }
}
