namespace board
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

        public void PutPiece(Piece p, Position pos)
        {
            Pieces[pos.Line, pos.Column] = p; // Get the matrix Pieces at pos.Line and pos.Column and receive p.
            p.Position = pos; // The Position in the class Piece will be pos now;
        }
    }
}
