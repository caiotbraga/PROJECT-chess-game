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
                ChessMatch match = new ChessMatch();

                while (!match.finished)
                {
                    Console.Clear();
                    Screen.PrintBoard(match.board);
                    
                    Console.WriteLine();
                    Console.Write("Origin:");
                    Position origin = Screen.ReadChessPosition().ToPositon();

                    bool[,] possiblePositions = match.board.piece(origin).possibleMoves();
                    //boolean matrix to save the possible moves according to the origin position.

                    Console.Clear();
                    Screen.PrintBoard(match.board, possiblePositions);

                    Console.WriteLine();
                    Console.Write("Destiny:");
                    Position destiny = Screen.ReadChessPosition().ToPositon();

                    match.peformMoviment(origin, destiny);
                }
                
            }
            catch (BoardExceptions m)
            {
                Console.WriteLine(m.Message);
            }
            Console.WriteLine();
        }
    }
}
