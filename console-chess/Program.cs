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
                    try
                    {
                        Console.Clear();
                        Screen.printMatch(match);

                        Console.WriteLine();
                        Console.Write("Origin:");
                        Position origin = Screen.ReadChessPosition().ToPositon();
                        match.validateOriginPosition(origin); 

                        bool[,] possiblePositions = match.board.piece(origin).possibleMoves();

                        Console.Clear();
                        Screen.PrintBoard(match.board, possiblePositions);

                        Console.WriteLine();
                        Console.Write("Destiny:");
                        Position destiny = Screen.ReadChessPosition().ToPositon();
                        match.validateDestinyPosition(origin, destiny);

                        match.makeMovement(origin, destiny);
                    }
                    catch(BoardExceptions e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
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
