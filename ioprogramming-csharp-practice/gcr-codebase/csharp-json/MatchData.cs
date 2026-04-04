using Newtonsoft.Json;
using System.Collections.Generic;

public class MatchData
{
    [JsonProperty("match_id")]
    public int MatchId { get; set; }

    [JsonProperty("team1")]
    public string Team1 { get; set; }

    [JsonProperty("team2")]
    public string Team2 { get; set; }

    [JsonProperty("score")]
    public Dictionary<string, int> Score { get; set; }

    [JsonProperty("winner")]
    public string Winner { get; set; }

    [JsonProperty("player_of_match")]
    public string PlayerOfMatch { get; set; }
}