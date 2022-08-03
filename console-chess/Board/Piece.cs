namespace board
{
    abstract internal class Piece //It's a abstract class beacuse have an abstract method.
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

        public abstract bool[,] possibleMoves(); //Created a abstract method that has no implementation here.
    }
}
 