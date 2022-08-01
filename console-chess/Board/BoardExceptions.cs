using System;
namespace board
{
    internal class BoardExceptions : Exception //Created a personalizated exception of board exceptions.
    {
        public BoardExceptions(string msg) : base(msg)
        {
        }
    }
}
