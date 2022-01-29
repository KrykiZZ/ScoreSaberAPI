using System.Text.Json.Serialization;

namespace ScoreSaberAPI.Models
{
    public class Badge
    {
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }
    }
}
