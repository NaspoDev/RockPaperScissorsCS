using AthanasiosT.RockerPaperScissors.Data;
using AthanasiosT.RockPaperScissors.CLI;
using System.Collections.Specialized;

namespace AthanasiosT.RockerPaperScissors.CLI
{
    // Main menu CLI. Options to start game and view high score.
    internal class MenuCLI
    {

        // Ordered dict of menu options with their correlated action. 
        // The Action class in a function delegate with no arguments or return type.
        OrderedDictionary MenuOptions = new OrderedDictionary(); // There is no generic implementation if OrderedDictionary :(
        private DataManager dataManager; // DataManager dependency.

        public MenuCLI(DataManager dataManager)
        {
            this.dataManager = dataManager;

            // Defining menu options.
            MenuOptions.Add("Play", new Action(StartGame));
            MenuOptions.Add("View Stats", new Action(DisplayStats));
        }

        // Start the Menu CLI
        internal void Start()
        {
            // List of cli option keys
            List<string> optionKeys = MenuOptions.Keys.Cast<string>().ToList();

            while (true)
            {
                // Header
                Console.WriteLine("\n=== Main Menu ===");

                // loop and display all the options, numbered.
                for (int i = 0; i < MenuOptions.Count; i++)
                {
                    Console.WriteLine($"{i + 1} - {optionKeys.ElementAt(i)}");
                }

                // Prompt user to select an option
                Console.Write(($"Enter your choice (\"{CLIUtils.QuitInputValue}\" to quit): "));
                string input = CLIUtils.GetValidCliInput(1, MenuOptions.Count + 1);

                // If the input was a quit command, quit.
                if (input.Equals(CLIUtils.QuitInputValue))
                {
                    break;
                }
                // Otherwise, parse the selection, and execute the corresponding Action with that option.
                else
                {
                    int numberInput = Convert.ToInt32(input);
                    Action action = (Action) MenuOptions[optionKeys[numberInput - 1]];
                    action();
                }
            }
        }

        // Create and start a new rock paper scissors game, then add it to the games list when over.
        private void StartGame()
        {
            Game game = new Game();
            game.Start();
            dataManager.games.Add(game);
        }

        // Display the global game stats.
        private void DisplayStats()
        {
            Console.WriteLine("\n=== Lifetime Statistics === ");
            Console.WriteLine($"You've won {dataManager.GameData.TotalWins} out of {dataManager.GameData.TotalGamesPlayed} games.");
            Console.WriteLine($"You played rock {dataManager.GameData.RockPlayedAmount} times.");
            Console.WriteLine($"You played paper {dataManager.GameData.PaperPlayedAmount} times.");
            Console.WriteLine($"You played scissors {dataManager.GameData.ScissorsPlayedAmount} times.");
        }
    }
}
