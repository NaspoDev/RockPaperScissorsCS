using AthanasiosT.RockerPaperScissors.Data;
using AthanasiosT.RockPaperScissors.CLI;
using System;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AthanasiosT.RockerPaperScissors.CLI
{
    // Main menu CLI. Options to start game and view high score.
    internal class MenuCLI
    {

        // Ordered dict of menu options with their correlated action. 
        // The Action class in a function delegate with no arguments or return type.
        OrderedDictionary MenuOptions = new OrderedDictionary(); // There is no generic implementation if OrderedDictionary :(
        internal List<Game> games = new List<Game>(); // List of games for this session.
        private DataManager dataManager; // DataManager dependency.

        public MenuCLI(DataManager dataManager)
        {
            MenuOptions.Add("Play", new Action(StartGame));
            MenuOptions.Add("View Stats", new Action(ViewStats));
        }

        internal void StartMenuCli()
        {
            // List of cli option keys
            List<string> optionKeys = MenuOptions.Keys.Cast<string>().ToList();

            Console.WriteLine("What would you like to do?");
            while (true)
            {
                // loop and display all the options, numbered.
                for (int i = 0; i < MenuOptions.Count; i++)
                {
                    Console.WriteLine($"{i + 1} - {optionKeys.ElementAt(i)}");
                }

                // Prompt user to select an option
                Console.WriteLine(($"Enter your choice (\"{CLIUtils.QuitInputValue}\" to quit): "))
                string input = CLIUtils.GetValidCliInput(1, MenuOptions.Count);
                
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
            games.Add(game);
        }

        // Display the global game stats.
        private void DisplayStats()
        {

            Console.WriteLine("Game Stats:");
            Console.WriteLine("Total Wins: ");
        }
    }
}
