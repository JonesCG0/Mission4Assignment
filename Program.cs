using System;

namespace Mission4Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Tic-Tac-Toe!");

            // Initialize board (1D array of 9 spaces)
            char[] board = new char[9];
            for (int i = 0; i < board.Length; i++)
            {
                board[i] = ' ';
            }

            GameHelper helper = new GameHelper();

            char currentPlayer = 'X';

            while (true)
            {
                helper.PrintBoard(board);

                int move = GetValidMove(board, currentPlayer);

                board[move] = currentPlayer;

                char result = helper.CheckWinner(board);

                if (result == 'X' || result == 'O')
                {
                    helper.PrintBoard(board);
                    Console.WriteLine($"Player {result} wins!");
                    break;
                }
                else if (result == 'T')
                {
                    helper.PrintBoard(board);
                    Console.WriteLine("It's a tie!");
                    break;
                }

                // Switch player
                currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
            }
        }

        private static int GetValidMove(char[] board, char currentPlayer)
        {
            while (true)
            {
                Console.Write($"Player {currentPlayer}, enter your move (1-9): ");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out int choice))
                {
                    Console.WriteLine("Please enter a number 1-9.");
                    continue;
                }

                if (choice < 1 || choice > 9)
                {
                    Console.WriteLine("Move must be between 1 and 9.");
                    continue;
                }

                int index = choice - 1;

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
