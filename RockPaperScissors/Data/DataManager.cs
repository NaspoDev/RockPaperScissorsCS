using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RockPaperScissors.Data
{
    // Manages data. (Storing high score).
    internal class DataManager
    {
        // Data is stored in one file, rps-data.json.
        const string DataFilePath = "%USERPROFILE%\\Documents\\RockPaperScissorsGame\\";
        const string DataFileName = "rps-data.json";

        private LocalGameData gameData;

        public DataManager()
        {
            // set the high score variable upon creation (get it from the file
            this.gameData = new LocalGameData();
            gameData
        }
    }
}
