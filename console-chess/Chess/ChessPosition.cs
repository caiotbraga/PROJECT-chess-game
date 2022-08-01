using board;
namespace Chess
{
    internal class ChessPosition //Created the class ChessPosiiton to make the Lines and Columns as the board of chess.
    {                            //Columns == Letter && Lines == Numbers
        public char Column { get; set; }
        public int Line { get; set; }

        public ChessPosition(char column, int line)
        {
            Column = column;
            Line = line;
        }

        public Position ToPositon() //Convert matrix position to chess position
        {
            return new Position(8 - Line, Column - 'a'); 
        }

        public override string ToString() // Print the Column and Line like: A1, B2...
        {
            return ""+Column + Line;
        }

    }
}
