using System;
using board;
namespace console_chess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(8, 8);
            Console.WriteLine();
            Screen.PrintBoard(board);
        }
    }
}
