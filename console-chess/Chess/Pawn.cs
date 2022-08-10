using board;
namespace Chess
{
    internal class Pawn : Piece
    {

        public Pawn(Board board, Color color) : base(board, color)
        {

        }

        public override string ToString()
        {
            return "P";
        }

        public override bool canMove(Position pos)
        {
            Piece p = Board.piece(pos);
            return p == null || p.Color != Color;
        }

        private bool existEnemy(Position pos) //method to check if have enemy at "pos"
        {
            Piece p = Board.piece(pos);
            return p != null && p.Color != Color;
        }

        private  bool free(Position pos) //if pos is free to move
        {
            return Board.piece(pos) == null; 
        }

        public override bool[,] possibleMoves()
        {
            bool[,] mat = new bool[Board.Lines, Board.Columns];

            Position pos = new Position(0, 0);

            if(Color == Color.White)
            {
                pos.setValues(Position.Line - 1, Position.Column);
                if(Board.ValidPosition(pos) && free(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.setValues(Position.Line - 2, Position.Column);
                if (Board.ValidPosition(pos) && free(pos) && MovementQuantity == 0)
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.setValues(Position.Line - 1, Position.Column - 1);
                if (Board.ValidPosition(pos) && existEnemy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.setValues(Position.Line - 1, Position.Column + 1);
                if (Board.ValidPosition(pos) && existEnemy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
            }
            else
            {
                pos.setValues(Position.Line + 1, Position.Column);
                if (Board.ValidPosition(pos) && free(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.setValues(Position.Line + 2, Position.Column);
                if (Board.ValidPosition(pos) && free(pos) && MovementQuantity == 0)
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.setValues(Position.Line + 1, Position.Column - 1);
                if (Board.ValidPosition(pos) && existEnemy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.setValues(Position.Line + 1, Position.Column + 1);
                if (Board.ValidPosition(pos) && existEnemy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
            }
            return mat;
        }
    }
}
