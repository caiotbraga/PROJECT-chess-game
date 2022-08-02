namespace board
{
    internal class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int MovementQuantity { get; protected set; } //If im moving a piece i need add at movementQuantity.
        public Board Board { get; protected set; }

        public Piece(Board board, Color color) 
        {
            Position = null;
            Color = color;
            Board = board;
            MovementQuantity = 0;
        }

        public void incrementMovimentQuantity() //Created the method to add the MovimentQuantity.
        {
            MovementQuantity++;
        }
    }
}
 