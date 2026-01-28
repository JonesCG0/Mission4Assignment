using System;

namespace Mission4Assignment
{

    class Program
    {
        static void Main(string[] args)
        {
            // Initialize board
            char[,] board = new char[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = '-';
                }
            }

            // Create instance of GameHelper to handle game logic
            GameHelper helper = new GameHelper(board);


            bool gameOver = false;
            char currentPlayer = 'X';

            while (!gameOver)
            {
                // Display the current state of the board
                helper.PrintBoard();

                Console.Write($"Player {currentPlayer}, enter your move (row and column, separated by a space): ");
                string[] input = Console.ReadLine().Split();
                int row = int.Parse(input[0]);
                int col = int.Parse(input[1]);

                // Check if the move is valid
                if (board[row, col] == '-')
                {
                    board[row, col] = currentPlayer;

                    // Check for a winner
                    gameOver = helper.CheckWinner(currentPlayer);

                    // Switch to the other player
                    currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
                }
                else
                {
                    Console.WriteLine("Invalid move! Please try again.");
                }
            }

            // Display final board state and announce winner
            helper.PrintBoard();
            if (currentPlayer == 'X')
            {
                Console.WriteLine("Player O wins!");
            }
            else
            {
                Console.WriteLine("Player X wins!");
            }
        }
    }
}