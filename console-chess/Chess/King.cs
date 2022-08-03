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

        private bool canMove(Position pos) 
        {
            Piece p = Board.piece(pos);
            return p == null || p.Color != Color; 

        }
        public override bool[,] possibleMoves() 
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
