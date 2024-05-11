using Newtonsoft.Json;

namespace AthanasiosT.RockerPaperScissors.Data
{
    // Manages data. (Storing high score).
    internal class DataManager
    {
        // Data is stored in one file, rps-data.json.
        private readonly string UserPath;
        private readonly string DataFileLocation;
        private const string DataFileName = "rps-data.json";
        private readonly string CompleteDataFilePath;

        readonly GameData gameData; // GameData field
        internal GameData GameData { get { return gameData; } } // GameData property

        // Constructor restores the game data from save file data.
        public DataManager()
        {
            // Initialize path variables.
            try
            {
                UserPath = Environment.GetEnvironmentVariable("USERPROFILE");
                DataFileLocation = $"{UserPath}\\Documents\\RockPaperScissorsGame\\";
                CompleteDataFilePath = DataFileLocation + DataFileName;

            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            // If the data file exists, restore the data.
            if (File.Exists(CompleteDataFilePath))
            {
                // Read the file contents to get the raw json data.
                string fileContents = File.ReadAllText(CompleteDataFilePath);
                gameData = DeserializeLocalGameData(fileContents);
            }
            // Otherwise, if the data file doesn't exist, just create a fresh GameData instance.
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
            // Create the file path. If it already exists this will do nothing.
            Directory.CreateDirectory(DataFileLocation);
            // Serialize GameData and write the data to the file.
            string serializedJson = JsonConvert.SerializeObject(gameData);
            File.WriteAllText(CompleteDataFilePath, serializedJson);
        }
    }
}
