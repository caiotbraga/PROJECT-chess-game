using board;
namespace Chess
{
    internal class Horse : Piece
    {

        public Horse(Board board, Color color) :base(board, color)
        {

        }

        public override string ToString()
        {
            return "H";
        }

        public override bool canMove(Position pos)
        {
            Piece p = Board.piece(pos);
            return p == null || p.Color != Color;

        }

        public override bool[,] possibleMoves()
        {
            bool[,] mat = new bool[Board.Lines, Board.Columns];

            Position pos = new Position(0, 0);

            //L move(north east 1)
            pos.setValues(Position.Line - 2, Position.Column + 1);
            if (Board.ValidPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            pos.setValues(pos.Line - 2, pos.Column + 1);

            //L move(north east 2)
            pos.setValues(Position.Line - 1, Position.Column + 2);
            if (Board.ValidPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            pos.setValues(pos.Line - 1, pos.Column + 2);

            //L move(southeast 1)
            pos.setValues(Position.Line + 1, Position.Column + 2);
            if (Board.ValidPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            pos.setValues(pos.Line + 1, pos.Column + 2);

            //L move(southeast 2)
            pos.setValues(Position.Line + 2, Position.Column + 1);
            if (Board.ValidPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            pos.setValues(pos.Line + 2, pos.Column + 1);

            //L move(northwest 1)
            pos.setValues(Position.Line - 2, Position.Column - 1);
            if (Board.ValidPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            pos.setValues(pos.Line - 2, pos.Column - 1);

            //L move(northwest 2)
            pos.setValues(Position.Line - 1, Position.Column - 2);
            if (Board.ValidPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            pos.setValues(pos.Line - 1, pos.Column - 2);

            //L move(south-west 1)
            pos.setValues(Position.Line + 1, Position.Column - 2);
            if (Board.ValidPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            pos.setValues(pos.Line + 1, pos.Column - 2);

            //L move(south-west 2)
            pos.setValues(Position.Line + 2, Position.Column - 1);
            if (Board.ValidPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            pos.setValues(pos.Line + 2, pos.Column - 1);
            return mat;
        }


    }
}
