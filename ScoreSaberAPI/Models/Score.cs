using System;
using System.Text.Json.Serialization;

namespace ScoreSaberAPI.Models
{
    public class Score
    {
        [JsonPropertyName("id")]
        public int Id;

        [JsonPropertyName("leaderboardPlayerInfo")]
        public LeaderboardPlayerInfo LeaderboardPlayerInfo;

        [JsonPropertyName("rank")]
        public int Rank;

        [JsonPropertyName("baseScore")]
        public int BaseScore;

        [JsonPropertyName("modifiedScore")]
        public int ModifiedScore;

        [JsonPropertyName("pp")]
        public double Pp;

        [JsonPropertyName("weight")]
        public double Weight;

        [JsonPropertyName("modifiers")]
        public string Modifiers;

        [JsonPropertyName("multiplier")]
        public int Multiplier;

        [JsonPropertyName("badCuts")]
        public int BadCuts;

        [JsonPropertyName("missedNotes")]
        public int MissedNotes;

        [JsonPropertyName("maxCombo")]
        public int MaxCombo;

        [JsonPropertyName("fullCombo")]
        public bool FullCombo;

        [JsonPropertyName("hmd")]
        public int Hmd;

        [JsonPropertyName("timeSet")]
        public DateTime TimeSet;

        [JsonPropertyName("hasReplay")]
        public bool HasReplay;
    }
}
