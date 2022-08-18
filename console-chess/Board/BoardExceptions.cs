using System;

namespace board
{
    class BoardExceptions : Exception 
    {
        public BoardExceptions(string msg) : base(msg)
        {
        }
    }
}
