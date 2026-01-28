using System;
using System.Collections.Generic;
using System.Text;

namespace Mission4Assignment
{
    internal class GameHelper
    {
        // prints Tic-Tac-Toe board
        public void PrintBoard(char[] board)
        {
            Console.WriteLine();
            Console.WriteLine($" {board[0]} | {board[1]} | {board[2]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {board[3]} | {board[4]} | {board[5]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {board[6]} | {board[7]} | {board[8]} ");
            Console.WriteLine();
        }

        // Checks for a winner
       
        // 'X' if X wins
        // 'O' if O wins
        // 'T' if tie
        // ' ' if no winner yet
        public char CheckWinner(char[] board)
        {
            int[,] wins =
            {
                {0,1,2}, {3,4,5}, {6,7,8}, 
                {0,3,6}, {1,4,7}, {2,5,8}, 
                {0,4,8}, {2,4,6}           
            };

            for (int i = 0; i < wins.GetLength(0); i++)
            {
                char a = board[wins[i, 0]];
                char b = board[wins[i, 1]];
                char c = board[wins[i, 2]];

                if (a != ' ' && a == b && b == c)
                {
                    // winner found
                    return a; 
                }
            }

            // check for tie
            foreach (char cell in board)
            {
                if (cell == ' ')
                {
                    return ' '; 
                }
            }

            return 'T';
        }

    }
}