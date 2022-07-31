namespace board
{
    internal class Piece //This class is generic that must have specific pieces of the chess game. Ex: King, tower...
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int MovementQuantity { get; protected set; }
        public Board Board { get; protected set; }

        public Piece(Board board, Color color) // alteration: when you create a Piece the Position must be null.
        {
            Position = null;
            Color = color;
            Board = board;
            MovementQuantity = 0;
        }
    }
}
