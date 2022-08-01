using System;
using board;
namespace console_chess
{
    internal class Screen
    {
        public static void PrintBoard(Board board) //Improving the method to print the board as a chess game.
        {
            for(int i = 0; i < board.Lines; i++)
            {
                Console.Write(8 - i + " "); //Printing the numbers in the left of the board
                for(int j = 0; j < board.Columns; j++)
                {
                    if(board.piece(i,j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                       PrintPiece(board.piece(i, j));
                       Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H"); // Printing the letters under the board
        }

        public static void PrintPiece(Piece piece) //Print the piece with the right color that i choose.
        {
            if(piece.Color == Color.White)
            {
                Console.Write(piece);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(piece);
                Console.ForegroundColor = aux;
            }
        }
    }
}
