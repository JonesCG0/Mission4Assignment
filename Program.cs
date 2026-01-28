using System;

namespace Mission4Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            // Display a welcome message to the players
            Console.WriteLine("Welcome to Tic-Tac-Toe!");

            // Create the game board as a 1D array with 9 spaces
            // Each space starts as empty (' ')
            char[] board = new char[9];
            for (int i = 0; i < board.Length; i++)
            {
                board[i] = ' ';
            }

            // Create an instance
            GameHelper helper = new GameHelper();

            // X first
            char currentPlayer = 'X';

            while (true)
            {
                helper.PrintBoard(board);

                int move = GetValidMove(board, currentPlayer);


                board[move] = currentPlayer;

                char result = helper.CheckWinner(board);

                // If X or O wins, announce the winner and end the game
                if (result == 'X' || result == 'O')
                {
                    helper.PrintBoard(board);
                    Console.WriteLine($"Player {result} wins!");
                    break;
                }
                // If the game is a tie, announce it and end the game
                else if (result == 'T')
                {
                    helper.PrintBoard(board);
                    Console.WriteLine("It's a tie!");
                    break;
                }

                // Switch turns between X and O
                currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
            }
        }

        // This method asks the user for a move and ensures it is valid
        private static int GetValidMove(char[] board, char currentPlayer)
        {
            while (true)
            {
                // Prompt the current player for their move
                Console.Write($"Player {currentPlayer}, enter your move (1-9): ");
                string input = Console.ReadLine();

                // Check that the input is a number
                if (!int.TryParse(input, out int choice))
                {
                    Console.WriteLine("Please enter a number between 1 and 9.");
                    continue;
                }

                // Check that the number is within range
                if (choice < 1 || choice > 9)
                {
                    Console.WriteLine("Move must be between 1 and 9.");
                    continue;
                }

                int index = choice - 1;

                // Check that the chosen spot is empty
                if (board[index] != ' ')
                {
                    Console.WriteLine("That spot is already taken. Try again.");
                    continue;
                }


                return index;
            }
        }
    }
}
