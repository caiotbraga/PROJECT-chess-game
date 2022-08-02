using System;
using board;
using Chess;
namespace console_chess
{
    internal class Screen
    {
        public static void PrintBoard(Board board) 
        {
            for(int i = 0; i < board.Lines; i++)
            {
                Console.Write(8 - i + " "); 
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
            Console.WriteLine("  A B C D E F G H"); 
        }

        public static ChessPosition ReadChessPosition() //Method to read the position as in the chess game by the user.
        {
            string s = Console.ReadLine();
            char column = s[0]; //Getting the string piece (0) as a char letter.
            int line = int.Parse(s[1] + ""); //Getting the string piece (1) as a int number. 
            return new ChessPosition(column, line); //Inserting the position as a chess game readed by the user.
        }

        public static void PrintPiece(Piece piece) 
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
