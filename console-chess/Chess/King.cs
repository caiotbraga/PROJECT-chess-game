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

        private bool canMove(Position pos) //Method to increment when the king can move.
        {
            Piece p = Board.piece(pos);
            return p == null || p.Color != Color; //Veiry if have some piece in the board at position pos or if the piece at position pos is an enemy.

        }
        public override bool[,] possibleMoves() //A boolean method to check if the moviments are posible(must return true if it is).
        {
            bool[,] mat = new bool[Board.Lines, Board.Columns];

            Position pos = new Position(0, 0);

            //up
            pos.setValues(Position.Line - 1, Position.Column);
            if(Board.ValidPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //north east
            pos.setValues(Position.Line - 1, Position.Column + 1);
            if (Board.ValidPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //right
            pos.setValues(Position.Line, Position.Column + 1);
            if (Board.ValidPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //southeast
            pos.setValues(Position.Line + 1, Position.Column + 1);
            if (Board.ValidPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //down
            pos.setValues(Position.Line + 1, Position.Column);
            if (Board.ValidPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //south-west
            pos.setValues(Position.Line + 1, Position.Column - 1);
            if (Board.ValidPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //left
            pos.setValues(Position.Line, Position.Column - 1);
            if (Board.ValidPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //northwest
            pos.setValues(Position.Line - 1, Position.Column - 1);
            if (Board.ValidPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            return mat;
        }
    }
}
