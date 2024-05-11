using AthanasiosT.RockerPaperScissors.CLI;
using AthanasiosT.RockerPaperScissors.Data;

namespace AthanasiosT.RockerPaperScissors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Initialize data manager. This will also restore game data.
            DataManager dataManager = new DataManager();
            MenuCLI menu = new MenuCLI(dataManager); // Initialize the menu cli.
            
            // Welcome message
            Console.WriteLine("Welcome to Rock Paper Scissors!\n");
            menu.StartMenuCli();
        }
    }
}
