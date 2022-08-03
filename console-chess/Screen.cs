using System.Collections.Generic;
using System;
using board;
using Chess;
namespace console_chess
{
    internal class Screen
    {

        public static void printMatch(ChessMatch match) 
        {
            PrintBoard(match.board);
            Console.WriteLine();
            printCapturedPieces(match);
            Console.WriteLine();
            Console.WriteLine("Round " + match.round);
            Console.WriteLine("Round player: " + match.currentPlayer);
            if (match.checkmate)
            {
                Console.WriteLine("CHECKMATE!");
            }
        }

        public static void printCapturedPieces(ChessMatch match)
        {
            Console.WriteLine("Captured pieces: ");
            Console.Write("White: ");
            printSet(match.capturedPieces(Color.White));
            Console.WriteLine();
            Console.Write("Black: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            printSet(match.capturedPieces(Color.Black)); 
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }

        public static void printSet(HashSet<Piece> set) 
        {
            Console.Write("[");
            foreach(Piece x in set)
            {
                Console.Write(x+ " ");
            }
            Console.Write("]");
        }

        public static void PrintBoard(Board board) 
        {
            for(int i = 0; i < board.Lines; i++)
            {
                Console.Write(8 - i + " "); 
                for(int j = 0; j < board.Columns; j++)
                {
                       PrintPiece(board.piece(i, j));                      
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H"); 
        }

        public static void PrintBoard(Board board, bool [,] PossiblePositions) 
        {

            ConsoleColor originalBackground = Console.BackgroundColor;
            ConsoleColor changedBackground = ConsoleColor.DarkGray; 

            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++)
                {
                    if(PossiblePositions[i, j])
                    {
                        Console.BackgroundColor = changedBackground;
                    }
                    else
                    {
                        Console.BackgroundColor = originalBackground;
                    }
                    PrintPiece(board.piece(i, j));
                    Console.BackgroundColor = originalBackground;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
            Console.BackgroundColor = originalBackground;
        }

        public static ChessPosition ReadChessPosition() 
        {
            string s = Console.ReadLine().ToLower();
            char column = s[0]; 
            int line = int.Parse(s[1] + "");  
            return new ChessPosition(column, line);
        }

        public static void PrintPiece(Piece piece) 
        {
            if(piece == null)
            {
                Console.Write("- ");
            }
            else
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
                Console.Write(" ");
            }
        }
    }
}
