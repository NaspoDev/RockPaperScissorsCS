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

        public MenuCLI()
        {
            MenuOptions.Add("Play", new Action(StartGame));
            MenuOptions.Add("View Stats", new Action(ViewStats));
        }

        void startMenuCli()
        {
            // List of keys
            List<string> keys = MenuOptions.Keys.Cast<string>().ToList();

            Console.WriteLine("What would you like to do?");
            while (true)
            {
                for (int i = 0; i < MenuOptions.Count; i++)
                {
                    Console.WriteLine($"{i + 1} - {keys.ElementAt(i)}");
                }

                Console.WriteLine(($"Enter your choice (\"{CLIUtils.QuitInputValue}\" to quit): "));

                string input = CLIUtils.GetValidCliInput(1, MenuOptions.Count);
                if (input.Equals(CLIUtils.QuitInputValue))
                {
                    break;
                } 
                else
                {
                    int numberInput = Convert.ToInt32(input);
                    Action action = (Action) MenuOptions[keys[numberInput - 1]];
                    action();
                }
            }
        }

        private void StartGame()
        {

        }

        private void ViewStats()
        {

        }
    }
}
