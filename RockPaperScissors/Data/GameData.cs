using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AthanasiosT.RockerPaperScissors.Data
{
    // Data class for local game data. (To be JSON deserialized and serialized)
    internal class LocalGameData
    {
        internal int HighScore { get; set; }
        internal int RockPlayedAmount { get; set; }
        internal int PaperPlayedAmount { get; set; }
        internal int ScissorsPlayedAmount { get; set; }
    }
}
