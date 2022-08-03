namespace board
{
    abstract internal class Piece 
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int MovementQuantity { get; protected set; } 
        public Board Board { get; protected set; }

        public Piece(Board board, Color color) 
        {
            Position = null;
            Color = color;
            Board = board;
            MovementQuantity = 0;
        }

        public void incrementMovimentQuantity() 
        {
            MovementQuantity++;
        }

        public bool existPossibleMoves() //Method to check if have at least 1 possible move
        {
            bool[,] mat = possibleMoves();
            for(int i = 0; i < Board.Lines; i++)
            {
                for(int j = 0; j < Board.Columns; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool canMoveTo(Position pos) //Method to check if the destiny position is valid.
        {
            return possibleMoves()[pos.Line, pos.Column];
        }

        public abstract bool[,] possibleMoves(); 
    }
}
 