using System;
using board;
using Chess;
namespace console_chess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(8, 8);
            
            board.PutPiece(new Tower(board, Color.Black), new Position(0, 0)); //Inserting a Piece at Position(0,0) using the method PutPiece of the class Board
            board.PutPiece(new Tower(board, Color.Black), new Position(1, 3));
            board.PutPiece(new King(board, Color.Black), new Position(2, 4));
            
            Screen.PrintBoard(board);

            Console.WriteLine();
        }
    }
}
