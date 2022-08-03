using board;
namespace Chess
{
    internal class ChessMatch
    {
        public Board board { get; private set; } 
        private int round;
        private Color currentPlayer;
        public bool finished { get; private set; } 

        public ChessMatch() 
        {
            board = new Board(8, 8); 
            round = 1;
            currentPlayer = Color.White; 
            finished = false;
            insertPiece();
        }

        public void peformMoviment(Position origin, Position destiny) 
        {
            Piece p = board.RemovePiece(origin); 
            p.incrementMovimentQuantity();
            Piece capturedPiece = board.RemovePiece(destiny); 
            board.PutPiece(p, destiny); 
        }

        public void insertPiece() 
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
