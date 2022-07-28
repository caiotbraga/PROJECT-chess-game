using System;
using Board;
namespace console_chess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Position p = new Position(3, 4);
            Console.WriteLine("Position :"+p);
            Console.ReadLine();
        }
    }
}
