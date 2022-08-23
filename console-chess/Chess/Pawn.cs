using board;

namespace Chess
{

    class Pawn : Piece
    {

        private ChessMatch Match; 

        public Pawn(Board board, Color color, ChessMatch match) : base(board, color) 
        {
            Match = match;
        }

        public override string ToString()
        {
            return "P";
        }

        private bool existEnemy(Position pos)
        {
            Piece p = Board.piece(pos);
            return p != null && p.Color != Color;
        }

        private bool free(Position pos)
        {
            return Board.piece(pos) == null;
        }

        public override bool[,] possibleMoves()
        {
            bool[,] mat = new bool[Board.Lines, Board.Columns];

            Position pos = new Position(0, 0);

            if (Color == Color.White)
            {
                pos.setValues(Position.Line - 1, Position.Column);
                if (Board.validPosition(pos) && free(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.setValues(Position.Line - 2, Position.Column);
                Position p2 = new Position(Position.Line - 1, Position.Column);
                if (Board.validPosition(p2) && free(p2) && Board.validPosition(pos) && free(pos) && MovementQuantity == 0)
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.setValues(Position.Line - 1, Position.Column - 1);
                if (Board.validPosition(pos) && existEnemy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.setValues(Position.Line - 1, Position.Column + 1);
                if (Board.validPosition(pos) && existEnemy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                
                //#SpecialPlay en passant (white piece)
                if(Position.Line == 3)
                {
                    Position left = new Position(Position.Line, Position.Column - 1);
                    if(Board.validPosition(left) && existEnemy(left) && Board.piece(left) == Match.vulnerableEnPassant) { 
                        mat[left.Line - 1, left.Column] = true; 
                    }
                    Position right = new Position(Position.Line, Position.Column + 1);
                    if (Board.validPosition(right) && existEnemy(right) && Board.piece(right) == Match.vulnerableEnPassant)
                    {
                        mat[right.Line - 1, right.Column] = true; 
                    }
                }
            }
            else
            {
                pos.setValues(Position.Line + 1, Position.Column);
                if (Board.validPosition(pos) && free(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.setValues(Position.Line + 2, Position.Column);
                Position p2 = new Position(Position.Line + 1, Position.Column);
                if (Board.validPosition(p2) && free(p2) && Board.validPosition(pos) && free(pos) &&  MovementQuantity == 0)
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.setValues(Position.Line + 1, Position.Column - 1);
                if (Board.validPosition(pos) && existEnemy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.setValues(Position.Line + 1, Position.Column + 1);
                if (Board.validPosition(pos) && existEnemy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                //#SpecialPlay en passant (black piece)
                if (Position.Line == 4)
                {
                    Position left = new Position(Position.Line, Position.Column - 1);
                    if (Board.validPosition(left) && existEnemy(left) && Board.piece(left) == Match.vulnerableEnPassant)
                    {
                        mat[left.Line + 1, left.Column] = true; 
                    }
                    Position right = new Position(Position.Line, Position.Column + 1);
                    if (Board.validPosition(right) && existEnemy(right) && Board.piece(right) == Match.vulnerableEnPassant)
                    {
                        mat[right.Line + 1, right.Column] = true; 
                    }
                }
            }

            return mat;
        }
    }
}
