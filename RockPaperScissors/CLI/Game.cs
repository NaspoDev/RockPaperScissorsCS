﻿using AthanasiosT.RockPaperScissors.CLI;
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
        private bool isFinished = false; // marked as true when the game finished, so it cannot be run again.

        // Run the game process. Best of 3 against randomly generated moves.
        internal void Run()
        {
            Console.WriteLine($"Let's play Rock-Paper-Scissors! Best of {AmountOfRoundsOdd} wins.");

            for (int i = 0; i < AmountOfRoundsOdd; i++)
            {
                playRound(i + 1);

                // Check if game is over. (Check if best of 3 is achieved).
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
        private void playRound(int roundNumber)
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

            Moves playerMove = (Moves)(Convert.ToInt32(playerInput) - 1); // extract the valid player move from the input.

            // Otherwise, find the winner.
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