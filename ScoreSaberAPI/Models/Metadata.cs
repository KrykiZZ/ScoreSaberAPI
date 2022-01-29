using System.Text.Json.Serialization;

namespace ScoreSaberAPI.Models
{
    public class Metadata
    {
        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("itemsPerPage")]
        public int ItemsPerPage { get; set; }
    }
}
