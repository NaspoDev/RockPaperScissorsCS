using Newtonsoft.Json;

namespace AthanasiosT.RockerPaperScissors.Data
{
    // Manages data. (Storing high score).
    internal class DataManager
    {
        // Data is stored in one file, rps-data.json.
        const string DataFileLocation = @"%USERPROFILE%\Documents\RockPaperScissorsGame\";
        const string DataFileName = "rps-data.json";
        const string CompleteDataFilePath = DataFileLocation + DataFileName;

        readonly GameData gameData; // GameData field
        internal GameData GameData { get { return gameData; } }

        // Constructor restores the game data from save file data.
        public DataManager()
        {
            // If the data file exists, read from it. Otherwise create a fresh GameData object.
            if (File.Exists(CompleteDataFilePath))
            {
                // Read the file contents to get the raw json data.
                string fileContents = File.ReadAllText(CompleteDataFilePath);
                gameData = DeserializeLocalGameData(fileContents);
            }
            else
            {
                gameData = new GameData();
            }
            
        }

        // De-serializes and returns a new GameData object.
        private GameData DeserializeLocalGameData(string rawJson)
        {
            return JsonConvert.DeserializeObject<GameData>(rawJson);
        }

        // Destructor saves the game data to the file.
        ~DataManager()
        {
            string serializedJson = JsonConvert.SerializeObject(gameData);
            File.WriteAllText(CompleteDataFilePath, serializedJson);
        }
    }
}
