namespace AthanasiosT.RockerPaperScissors.Data
{
    // Data class for local game data. (To be JSON deserialized and serialized)
    internal class GameData
    {
        // Properties need to be public so that the Newtonsoft.Json library can access them.
        // This is because the Newtonsoft library is actually it's own DLL file, and as we know, public access modifier exposes it to other assemblies.
        // (You can see it's DLL file in the bin/Debug/net8.0 folder).
        public int TotalWins { get; set; }
        public int TotalGamesPlayed { get; set; }
        public int RockPlayedAmount { get; set; }
        public int PaperPlayedAmount { get; set; }
        public int ScissorsPlayedAmount { get; set; }
    }
}
