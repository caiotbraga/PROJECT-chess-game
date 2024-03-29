﻿using board;

namespace Chess
{

    class Queen : Piece
    {

        public Queen (Board board, Color color) :base(board, color)
        {
        }

        public override string ToString()
        {
            return "Q";
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
            while (Board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.piece(pos) != null && Board.piece(pos).Color != Color)
                {
                    break;
                }
                pos.setValues(pos.Line - 1, pos.Column);
            }

            //down
            pos.setValues(Position.Line + 1, Position.Column);
            while (Board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.piece(pos) != null && Board.piece(pos).Color != Color)
                {
                    break;
                }
                pos.setValues(pos.Line + 1, pos.Column);
            }

            //right
            pos.setValues(Position.Line, Position.Column + 1);
            while (Board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.piece(pos) != null && Board.piece(pos).Color != Color)
                {
                    break;
                }
                pos.setValues(pos.Line, pos.Column + 1);
            }

            //left
            pos.setValues(Position.Line, Position.Column - 1);
            while (Board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.piece(pos) != null && Board.piece(pos).Color != Color)
                {
                    break;
                }
                pos.setValues(pos.Line, pos.Column - 1);
            }

            //north east
            pos.setValues(Position.Line - 1, Position.Column + 1);
            while (Board.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.piece(pos) != null && Board.piece(pos).Color != Color)
                {
                    break;
                }
                pos.setValues(pos.Line - 1, pos.Column + 1);
            }

            //southeast
            pos.setValues(Position.Line + 1, Position.Column + 1);
            while (Board.validPosition(pos) && canMove(pos))
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
            while (Board.validPosition(pos) && canMove(pos))
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
            while (Board.validPosition(pos) && canMove(pos))
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
