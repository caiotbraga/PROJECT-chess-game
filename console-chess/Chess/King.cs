using board;

namespace Chess
{
    class King : Piece
    {

        private ChessMatch Match; 

        public King(Board board, Color color, ChessMatch match) : base(board, color){
            Match = match;
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

        private bool testTowerToCastling(Position pos) 
        {
            Piece p = Board.piece(pos);
            return p != null && p is Tower && p.Color == Color && p.MovementQuantity == 0;
        }

        public override bool[,] possibleMoves() 
        {
            bool[,] mat = new bool[Board.Lines, Board.Columns];

            Position pos = new Position(0, 0);

            //up
            pos.setValues(Position.Line - 1, Position.Column);
            if(Board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //north east
            pos.setValues(Position.Line - 1, Position.Column + 1);
            if (Board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //right
            pos.setValues(Position.Line, Position.Column + 1);
            if (Board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //southeast
            pos.setValues(Position.Line + 1, Position.Column + 1);
            if (Board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //down
            pos.setValues(Position.Line + 1, Position.Column);
            if (Board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //south-west
            pos.setValues(Position.Line + 1, Position.Column - 1);
            if (Board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //left
            pos.setValues(Position.Line, Position.Column - 1);
            if (Board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            //northwest
            pos.setValues(Position.Line - 1, Position.Column - 1);
            if (Board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            // Added #SpecialPlay castling
            if (MovementQuantity == 0 && !Match.Checkmate)
            {
                // #specialplay small castle
                Position posT1 = new Position(Position.Line, Position.Column + 3);
                if (testTowerToCastling(posT1))
                {
                    Position p1 = new Position(Position.Line, Position.Column + 1);
                    Position p2 = new Position(Position.Line, Position.Column + 2);
                    if (Board.piece(p1) == null && Board.piece(p2) == null)
                    {
                        mat[Position.Line, Position.Column + 2] = true;
                    }
                }
                // #specialplay big castle
                Position posT2 = new Position(Position.Line, Position.Column - 4);
                if (testTowerToCastling(posT2))
                {
                    Position p1 = new Position(Position.Line, Position.Column - 1);
                    Position p2 = new Position(Position.Line, Position.Column - 2);
                    Position p3 = new Position(Position.Line, Position.Column - 3);
                    if (Board.piece(p1) == null && Board.piece(p2) == null && Board.piece(p3) == null)
                    {
                        mat[Position.Line, Position.Column - 2] = true;
                    }
                }
            }
            return mat;
        }
    }
}
