using System;
using board;
using Chess;
namespace console_chess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try //Testing if the exception of the board is working.
            {
                Board board = new Board(8, 8);

                board.PutPiece(new Tower(board, Color.Black), new Position(0, 0));
                board.PutPiece(new Tower(board, Color.Black), new Position(12, 3));
                board.PutPiece(new King(board, Color.Black), new Position(0, 2));

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
