using board;
namespace Chess
{
    internal class Tower : Piece
    {
        public Tower(Board board, Color color) : base(board, color)
        {

        }

        public override string ToString()
        {
            return "T";
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
            while (Board.ValidPosition(pos) && canMove(pos)) //while the position is valid and can move
            {
                mat[pos.Line, pos.Column] = true; //the movement can happen
                if(Board.piece(pos) != null && Board.piece(pos).Color != Color)
                {
                    break;
                }
                pos.Line = pos.Line - 1;
            }
            //down
            pos.setValues(Position.Line + 1, Position.Column);
            while (Board.ValidPosition(pos) && canMove(pos)) //while the position is valid and can move
            {
                mat[pos.Line, pos.Column] = true; //the movement can happen
                if (Board.piece(pos) != null && Board.piece(pos).Color != Color)
                {
                    break;
                }
                pos.Line = pos.Line + 1;
            }
            //right
            pos.setValues(Position.Line, Position.Column + 1);
            while (Board.ValidPosition(pos) && canMove(pos)) //while the position is valid and can move
            {
                mat[pos.Line, pos.Column] = true; //the movement can happen
                if (Board.piece(pos) != null && Board.piece(pos).Color != Color)
                {
                    break;
                }
                pos.Column = pos.Column + 1;
            }
            //left
            pos.setValues(Position.Line, Position.Column - 1);
            while (Board.ValidPosition(pos) && canMove(pos)) //while the position is valid and can move
            {
                mat[pos.Line, pos.Column] = true; //the movement can happen
                if (Board.piece(pos) != null && Board.piece(pos).Color != Color) 
                {
                    break;
                }
                pos.Column = pos.Column - 1;
            }
            return mat;
        }
    }
}