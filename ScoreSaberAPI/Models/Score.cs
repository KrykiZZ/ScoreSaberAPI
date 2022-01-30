using System;
using System.Text.Json.Serialization;

namespace ScoreSaberAPI.Models
{
    public class Score
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("leaderboardPlayerInfo")]
        public LeaderboardPlayerInfo LeaderboardPlayerInfo { get; set; }

        [JsonPropertyName("rank")]
        public int Rank { get; set; }

        [JsonPropertyName("baseScore")]
        public int BaseScore { get; set; }

        [JsonPropertyName("modifiedScore")]
        public int ModifiedScore { get; set; }

        [JsonPropertyName("pp")]
        public double PP { get; set; }

        [JsonPropertyName("weight")]
        public double Weight { get; set; }

        [JsonPropertyName("modifiers")]
        public string Modifiers { get; set; }

        [JsonPropertyName("multiplier")]
        public int Multiplier { get; set; }

        [JsonPropertyName("badCuts")]
        public int BadCuts { get; set; }

        [JsonPropertyName("missedNotes")]
        public int MissedNotes { get; set; }

        [JsonPropertyName("maxCombo")]
        public int MaxCombo { get; set; }

        [JsonPropertyName("fullCombo")]
        public bool FullCombo { get; set; }

        [JsonPropertyName("hmd")]
        public int Hmd { get; set; }

        [JsonPropertyName("timeSet")]
        public DateTime TimeSet { get; set; }

        [JsonPropertyName("hasReplay")]
        public bool HasReplay { get; set; }
    }
}
