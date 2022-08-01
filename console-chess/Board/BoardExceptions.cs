using System;
namespace board
{
    internal class BoardExceptions : Exception 
    {
        public BoardExceptions(string msg) : base(msg)
        {
        }
    }
}
