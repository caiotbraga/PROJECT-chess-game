using board; 
namespace Chess
{
    internal class King : Piece
    {
        public King(Board board, Color color) : base(board, color){

        }

        public override string ToString()
        {
            return "K";
        }
    }
}
