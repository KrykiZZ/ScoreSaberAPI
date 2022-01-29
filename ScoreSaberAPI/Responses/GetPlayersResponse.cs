using ScoreSaberAPI.Models;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ScoreSaberAPI.Responses
{
    public class GetPlayersResponse
    {
        [JsonPropertyName("players")]
        public List<Player> Players;

        [JsonPropertyName("metadata")]
        public Metadata Metadata;
    }
}
