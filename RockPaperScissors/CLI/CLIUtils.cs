using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.CLI
{
    internal class CLIUtils
    {

        const string QuitInputValue = "quit";

        // Gets and returns a valid CLI input from the user.
        // Takes in a number range argument and also checks for a quit input.
        static string GetValidCliInput(int floorRange, int ceilRange)
        {
            while (true)
            {
                string? input = Console.ReadLine();

                // If input is blank, print error message.
                if (input == null)
                {
                    Console.WriteLine("You have to enter something!");
                    continue;
                }

                // If quit command received, return quit;
                if (input.Equals(QuitInputValue, StringComparison.InvariantCultureIgnoreCase))
                {
                    return QuitInputValue;
                }

                // Otherwise, try and parse the input for a number and verify that it is between the 
                // specified range.
                try
                {
                    int value = Convert.ToInt32(input);

                    // Verify range.
                    if (value >= floorRange && value <= ceilRange)
                    {
                        return Convert.ToString(value);
                    }
                }
                // Catch integer parse. Therefore input was invalid. 
                catch (Exception e)
                {
                    Console.WriteLine("Please enter a valid option.");
                }
            }
            
        }
    }
}
