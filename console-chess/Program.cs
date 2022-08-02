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
                    Position origin = Screen.ReadChessPosition().ToPositon(); //Usinging the method ToPosition(); to read as a matrix
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
