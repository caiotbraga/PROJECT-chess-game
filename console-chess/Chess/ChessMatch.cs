using board;
namespace Chess
{
    internal class ChessMatch //Created the class ChessMatch where have the game mechanics.
    {
        public Board board { get; private set; } 
        private int round;
        private Color currentPlayer;
        public bool finished { get; private set; } //Attribute to check if the match is finished.

        public ChessMatch() //Created the constructor with the predefined parameters.
        {
            board = new Board(8, 8); 
            round = 1;
            currentPlayer = Color.White; //The player that start(white).
            finished = false;
            insertPiece();
        }

        public void peformMoviment(Position origin, Position destiny) //Method to make the moviment happen.
        {
            Piece p = board.RemovePiece(origin); //Removed the piece at position origin.
            p.incrementMovimentQuantity(); //Added the moviment quantity.
            Piece capturedPiece = board.RemovePiece(destiny); //Removed the piece that i captured.
            board.PutPiece(p, destiny); //Put the piece where i captured the other piece.
        }

        public void insertPiece() //Method to insert a piece as a chess game(ex: a1, c3, d3)
        {
            board.PutPiece(new Tower(board, Color.White), new ChessPosition('c', 1).ToPositon());
            board.PutPiece(new Tower(board, Color.White), new ChessPosition('c', 2).ToPositon());
            board.PutPiece(new Tower(board, Color.White), new ChessPosition('d', 2).ToPositon());
            board.PutPiece(new Tower(board, Color.White), new ChessPosition('e', 2).ToPositon());
            board.PutPiece(new Tower(board, Color.White), new ChessPosition('e', 1).ToPositon());
            board.PutPiece(new King(board, Color.White), new ChessPosition('d', 1).ToPositon());

            board.PutPiece(new Tower(board, Color.Black), new ChessPosition('c', 7).ToPositon());
            board.PutPiece(new Tower(board, Color.Black), new ChessPosition('c', 8).ToPositon());
            board.PutPiece(new Tower(board, Color.Black), new ChessPosition('d', 7).ToPositon());
            board.PutPiece(new Tower(board, Color.Black), new ChessPosition('e', 7).ToPositon());
            board.PutPiece(new Tower(board, Color.Black), new ChessPosition('e', 8).ToPositon());
            board.PutPiece(new King(board, Color.Black), new ChessPosition('d', 8).ToPositon());
        }
    }
}
