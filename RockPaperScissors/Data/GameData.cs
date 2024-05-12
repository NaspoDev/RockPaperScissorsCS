namespace AthanasiosT.RockerPaperScissors.Data
{
    // Data class for local game data. (To be JSON deserialized and serialized)
    internal class GameData
    {
        public int TotalWins { get; set; }
        public int TotalGamesPlayed { get; set; }
        public int RockPlayedAmount { get; set; }
        public int PaperPlayedAmount { get; set; }
        public int ScissorsPlayedAmount { get; set; }
    }
}
