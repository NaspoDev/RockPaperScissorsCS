using AthanasiosT.RockPaperScissors.CLI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AthanasiosT.RockerPaperScissors.CLI
{
    // A rock paper scissors game.
    internal class Game
    {
        private Random rand = new Random();
        private const int AmountOfRoundsOdd = 3; // Amount of rounds played (takes best of). Must be odd and >= 3.
        private int playerScore = 0; 
        private int computerScore = 0;

        // Game stats, fields. (Any form of data the we keep track of for a game)
        private int rockPlayedAmount = 0;
        private int paperPlayedAmount = 0;
        private int scissorsPlayedAmount = 0;

        // Game stats, properties.
        internal int RockPlayedAmount { get; }
        internal int PaperPlayedAmount { get; }
        internal int ScissorsPlayedAmount { get; }

        // Run the game process. Best of style, against randomly generated moves.
        internal void Run()
        {
            Console.WriteLine($"Let's play Rock-Paper-Scissors! Best of {AmountOfRoundsOdd} wins.");

            // Play amount of rounds specified.
            for (int i = 0; i < AmountOfRoundsOdd; i++)
            {
                PlayRound(i + 1);

                // Check if game is over. (Check if best of is achieved).
                int bestOfThreshold = (int)Math.Ceiling((double)AmountOfRoundsOdd / 2);
                if (playerScore >= bestOfThreshold || computerScore >= bestOfThreshold)
                {
                    // Get the winner
                    if (playerScore >= 2)
                    {
                        Console.WriteLine("Game over. You win!");
                    }
                    else
                    {
                        Console.WriteLine("Game over. You lost :(");
                    }
                    // Print the score.
                    Console.WriteLine($"Your score: {playerScore} | Computer's score: {computerScore}");
                }
            }
        }

        // Play a round of rock paper scissors.
        private void PlayRound(int roundNumber)
        {
            Moves computerMove = (Moves)rand.Next(0, 3); // Generate a random computer move.

            // Prompt and get the player input.
            Console.WriteLine($"Round {roundNumber}.");
            Console.WriteLine("(1) rock | (2) paper | (3) scissors");
            Console.Write($"Enter your move (\"quit\" to quit): ");
            string playerInput = CLIUtils.GetValidCliInput(1, 4); // Input range from 1-3 because 0-2 doesnt look as good for the user.

            // If the player quit, set the game score to 0 for both and end.
            if (playerInput.Equals(CLIUtils.QuitInputValue))
            {
                playerScore = 0;
                computerScore = 0;
                return;
            }

            // Otherwise the player did not quit, find their move.
            Moves playerMove = (Moves)(Convert.ToInt32(playerInput) - 1); // extract the valid player move from the input.

            // Log the player move (for game stat tracking)
            switch (playerMove)
            {
                case Moves.ROCK: 
                    rockPlayedAmount++;
                    break;

                case Moves.PAPER:
                    paperPlayedAmount++;
                    break;

                case Moves.SCISSORS:
                    scissorsPlayedAmount++;
                    break;
            }

            // Find the winner of this round.
            switch (computerMove)
            {
                case Moves.ROCK:
                    if (playerMove == Moves.PAPER)
                    {
                        playerScore++;
                    }
                    else
                    {
                        computerScore++;
                    }
                    break;

                case Moves.PAPER:
                    if (playerMove == Moves.SCISSORS)
                    {
                        playerScore++;
                    }
                    else
                    {
                        computerScore++;
                    }
                    break;

                case Moves.SCISSORS:
                    if (playerMove == Moves.ROCK)
                    {
                        playerScore++;
                    }
                    else
                    {
                        computerScore++;
                    }
                    break;
            }
        }
    }
}