﻿namespace board
{
    internal class Board
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
        private Piece[,] Pieces;

        public Board(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            Pieces = new Piece[lines, columns];
        }

        public Piece piece(int lines, int columns)
        {
            return Pieces[lines, columns];
        }

        public Piece piece(Position pos) // Improvement: Overload of the piece method to only recieve the parameter pos.
        {
            return Pieces[pos.Line, pos.Column];
        }

        public bool ExistPiece(Position pos) // Method to see if exist a piece on the position pos.
        {
            ValidatePosition(pos); //If the validate is not valid the exception will cut and print the exception message
            return piece(pos) != null; 
        }

        public void PutPiece(Piece p, Position pos) //Improvement: Validation if exists a piece at the position pos.
        {
            if (ExistPiece(pos)){
                throw new BoardExceptions("Already exists a piece on this position!");
            }
            Pieces[pos.Line, pos.Column] = p; 
            p.Position = pos;
        }

        public bool ValidPosition(Position pos) // Validation: To check if the position is valid
        {
            if(pos.Line < 0 || pos.Line >= Lines ||pos.Column < 0 || pos.Column >= Columns)
            {
                return false;
            }
            return true;
        }

        public void ValidatePosition(Position pos) //Created the method of Exception personalizated
        {
            if (!ValidPosition(pos))
            {
                throw new BoardExceptions("Invalid position!");
            }
        }
    }
}