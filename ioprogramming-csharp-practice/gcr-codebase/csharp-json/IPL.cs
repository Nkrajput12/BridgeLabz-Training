using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

class IPL
{
    static void Main()
    {
        string jsonInputPath = "ipl_data.json";
        string csvInputPath = "ipl_data.csv";

        // 1. Load Data
        List<MatchData> matchesFromJson = JsonConvert.DeserializeObject<List<MatchData>>(File.ReadAllText(jsonInputPath));

        // 2. Process/Censor Data
        foreach (var match in matchesFromJson)
        {
            CensorMatch(match);
        }

        // 3. Write Sanitized JSON
        File.WriteAllText("censored_ipl.json", JsonConvert.SerializeObject(matchesFromJson, Formatting.Indented));

        // 4. Write Sanitized CSV
        WriteToCsv("censored_ipl.csv", matchesFromJson);

        Console.WriteLine("Censorship complete. Files 'censored_ipl.json' and 'censored_ipl.csv' generated.");
    }

    static void CensorMatch(MatchData match)
    {
        // Rule: Redact Player Name
        match.PlayerOfMatch = "REDACTED";

        // Rule: Mask Team Names
        string oldTeam1 = match.Team1;
        string oldTeam2 = match.Team2;

        match.Team1 = MaskTeamName(match.Team1);
        match.Team2 = MaskTeamName(match.Team2);
        match.Winner = MaskTeamName(match.Winner);

        // Update the dictionary keys for the score
        var newScore = new Dictionary<string, int>();
        foreach (var entry in match.Score)
        {
            newScore[MaskTeamName(entry.Key)] = entry.Value;
        }
        match.Score = newScore;
    }

    static string MaskTeamName(string name)
    {
        if (string.IsNullOrEmpty(name)) return name;
        var words = name.Split(' ');
        if (words.Length == 1) return name; // No space to mask middle

        // Example logic: Replace the second word with ***
        // Handles "Mumbai Indians" -> "Mumbai ***"
        // Handles "Royal Challengers Bangalore" -> "Royal *** Bangalore"
        if (words.Length >= 2) words[1] = "***";

        return string.Join(" ", words);
    }

    static void WriteToCsv(string path, List<MatchData> data)
    {
        using (var writer = new StreamWriter(path))
        {
            writer.WriteLine("match_id,team1,team2,score_team1,score_team2,winner,player_of_match");
            foreach (var m in data)
            {
                // Note: We extract the scores from the dictionary based on the masked team names
                int s1 = m.Score.ContainsKey(m.Team1) ? m.Score[m.Team1] : 0;
                int s2 = m.Score.ContainsKey(m.Team2) ? m.Score[m.Team2] : 0;

                writer.WriteLine($"{m.MatchId},{m.Team1},{m.Team2},{s1},{s2},{m.Winner},{m.PlayerOfMatch}");
            }
        }
    }
}