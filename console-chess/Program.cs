using System;
using board;
using Chess;
namespace console_chess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try 
            {
                Board board = new Board(8, 8);

                board.PutPiece(new Tower(board, Color.Black), new Position(0, 0));
                board.PutPiece(new Tower(board, Color.Black), new Position(1, 3));
                board.PutPiece(new King(board, Color.Black), new Position(0, 2));

                board.PutPiece(new Tower(board, Color.White), new Position(7, 0));

                Screen.PrintBoard(board);

                Console.WriteLine();
            }
            catch (BoardExceptions m)
            {
                Console.WriteLine(m.Message);
            }
            
        }
    }
}
