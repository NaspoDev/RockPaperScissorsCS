using System;
using System.Collections.Generic;
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
        OrderedDictionary<string, Action> MenuOptions = new OrderedDictionary<string, string>();

        public MenuCLI()
        {
            MenuOptions.Add("", )
        }

        void startMenuCli()
        {
            while (true)
            {

            }
        }
    }
}
