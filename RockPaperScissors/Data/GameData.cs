namespace AthanasiosT.RockerPaperScissors.Data
{
    // Data class for local game data. (To be JSON deserialized and serialized)
    internal class GameData
    {
        internal int TotalWins { get; set; }
        internal int RockPlayedAmount { get; set; }
        internal int PaperPlayedAmount { get; set; }
        internal int ScissorsPlayedAmount { get; set; }
    }
}
