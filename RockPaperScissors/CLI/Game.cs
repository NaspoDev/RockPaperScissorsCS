using AthanasiosT.RockPaperScissors.CLI;

namespace AthanasiosT.RockerPaperScissors.CLI
{
    // A rock paper scissors game.
    internal class Game
    {
        private Random rand = new Random();
        private const int BestOfPointsOdd = 3; // Amount of rounds played (takes best of). Must be odd and >= 3.
        private int playerScore = 0;
        private int computerScore = 0;

        // Game stats, fields. (Any form of data the we keep track of for a game)
        private int rockPlayedAmount;
        private int paperPlayedAmount;
        private int scissorsPlayedAmount;
        private bool playerWon; // set after game finishes.

        // Game stats, properties.
        internal int RockPlayedAmount { get { return rockPlayedAmount; } }
        internal int PaperPlayedAmount { get { return paperPlayedAmount; } }
        internal int ScissorsPlayedAmount { get { return scissorsPlayedAmount; } }
        internal bool PlayerWon { get { return playerWon; } }

        // Run the game process. Best of style, against randomly generated moves.
        internal void Start()
        {
            Console.WriteLine($"\n=== Let's play Rock-Paper-Scissors! Best of {BestOfPointsOdd} wins. ===");

            // Play amount of rounds specified.
            int roundCount = 1;
            while (true)
            {
                PlayRound(roundCount);

                // Check if game is over. (Check if best of is achieved).
                int bestOfThreshold = (int)Math.Ceiling((double)BestOfPointsOdd / 2);
                if (playerScore >= bestOfThreshold || computerScore >= bestOfThreshold)
                {
                    // Get the winner
                    if (playerScore >= 2)
                    {
                        // Player won
                        Console.WriteLine("\nGame over. You win!");
                        playerWon = true;
                    }
                    else
                    {
                        // Player lost
                        Console.WriteLine("\nGame over. You lost :(");
                        playerWon = false;
                    }
                    // Print the score.
                    Console.WriteLine($"Your score: {playerScore} | Computer's score: {computerScore}");
                    return;
                }

                roundCount++;
            }
        }

        // Play a round of rock paper scissors.
        private void PlayRound(int roundNumber)
        {
            Moves computerMove = (Moves)rand.Next(0, 3); // Generate a random computer move.

            // Prompt and get the player input.
            Console.WriteLine($"\nRound {roundNumber}. Score: {playerScore} - {computerScore}");
            Console.WriteLine("(1) rock | (2) paper | (3) scissors");
            Console.Write($"\nEnter your move (\"quit\" to quit): ");
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

            Console.WriteLine($"Computer chose {computerMove}."); // display the computer's move.

            // Find the winner of this round. (And log the player's move, for game stat tracking).
            switch (playerMove)
            {
                case Moves.ROCK:
                    // if computer won
                    if (computerMove == Moves.PAPER)
                    {
                        computerScore++;
                    }
                    // otherwise, if computer and player moves are not equal, then player won.
                    else if (computerMove != playerMove)
                    {
                        playerScore++;
                    }
                    // Otherwise its a tie.
                    else
                    {
                        Console.WriteLine("Tie!");
                    }
                    rockPlayedAmount++; // logging
                    break;

                case Moves.PAPER:
                    // if computer won
                    if (computerMove == Moves.SCISSORS)
                    {
                        computerScore++;
                    }
                    // otherwise, if computer and player moves are not equal, then player won.
                    else if (computerMove != playerMove)
                    {
                        playerScore++;
                    }
                    // Otherwise its a tie.
                    else
                    {
                        Console.WriteLine("Tie!");
                    }
                    paperPlayedAmount++; // logging
                    break;

                case Moves.SCISSORS:
                    // if computer won
                    if (computerMove == Moves.ROCK)
                    {
                        computerScore++;
                    }
                    // otherwise, if computer and player moves are not equal, then player won.
                    else if (computerMove != playerMove)
                    {
                        playerScore++;
                    }
                    // Otherwise its a tie.
                    else
                    {
                        Console.WriteLine("Tie!");
                    }
                    scissorsPlayedAmount++; // logging
                    break;
            }
        }
    }
}