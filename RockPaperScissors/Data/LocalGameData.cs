using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.Data
{
    // Data class for local game data. (JSON serialized)
    internal class LocalGameData
    {
        internal int HighScore { get; set; }
        internal int RockPlayedAmount { get; set; }
        internal int PaperPlayedAmount { get; set; }
        int ScissorsPlayedAmount { get; set; }
    }
}
