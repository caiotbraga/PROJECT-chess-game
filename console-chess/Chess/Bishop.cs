using board;
namespace Chess
{
    internal class Bishop : Piece
    {

        public Bishop(Board board, Color color) : base(board, color)
        {

        }

        public override string ToString()
        {
            return "B";
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

            //north east
            pos.setValues(Position.Line - 1, Position.Column + 1);
            while(Board.ValidPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if(Board.piece(pos) != null && Board.piece(pos).Color != Color)
                {
                    break;
                }
                pos.setValues(pos.Line - 1, pos.Column + 1);
            }
            //southeast
            pos.setValues(Position.Line + 1, Position.Column + 1);
            while(Board.ValidPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.piece(pos) != null && Board.piece(pos).Color != Color)
                {
                    break;
                }
                pos.setValues(pos.Line + 1, pos.Column + 1);
            }
            //northwest
            pos.setValues(Position.Line - 1, Position.Column - 1);
            while(Board.ValidPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.piece(pos) != null && Board.piece(pos).Color != Color)
                {
                    break;
                }
                pos.setValues(pos.Line - 1, pos.Column - 1);
            }
            //south-west
            pos.setValues(Position.Line + 1, Position.Column - 1);
            while(Board.ValidPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.piece(pos) != null && Board.piece(pos).Color != Color)
                {
                    break;
                }
                pos.setValues(pos.Line + 1, pos.Column - 1);
            }
            return mat;
        }
    }
}
