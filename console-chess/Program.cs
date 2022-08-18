using System;
using board;
using Chess;

namespace console_chess
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                ChessMatch match = new ChessMatch();

                while (!match.Finished)
                {

                    try
                    {
                        Console.Clear();
                        Screen.printMatch(match);

                        Console.WriteLine();
                        Console.Write("Origin:");
                        Position origin = Screen.ReadChessPosition().ToPositon();
                        match.validateOriginPosition(origin); 

                        bool[,] possiblePositions = match.Board.piece(origin).possibleMoves();

                        Console.Clear();
                        Screen.PrintBoard(match.Board, possiblePositions);

                        Console.WriteLine();
                        Console.Write("Destiny:");
                        Position destiny = Screen.ReadChessPosition().ToPositon();
                        match.validateDestinyPosition(origin, destiny);

                        match.makePlay(origin, destiny);
                    }
                    catch(BoardExceptions e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
                Console.Clear();
                Screen.printMatch(match);
            }
            catch (BoardExceptions e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine();
        }
    }
}