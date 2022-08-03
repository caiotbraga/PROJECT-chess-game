using board;
namespace Chess
{
    internal class ChessMatch
    {
        public Board board { get; private set; } 
        public int round { get; private set; } //Changed to public to show on console but without can be changed.
        public Color currentPlayer { get; private set; }//Changed to public to show on console but without can be changed.
        public bool finished { get; private set; } 

        public ChessMatch() 
        {
            board = new Board(8, 8); 
            round = 1;
            currentPlayer = Color.White; 
            finished = false;
            insertPiece();
        }

        public void peformMovement(Position origin, Position destiny) 
        {
            Piece p = board.RemovePiece(origin); 
            p.incrementMovimentQuantity();
            Piece capturedPiece = board.RemovePiece(destiny); 
            board.PutPiece(p, destiny); 
        }

        public void makeMovement(Position origin, Position destiny) //Method to make the movement happen changing the rounds.
        {
            peformMovement(origin, destiny);
            round++;
            switchPlayer();
        }

        public void validateOriginPosition(Position pos) //Method to print the exception according to the origin error
        {
            if(board.piece(pos) == null) 
            {
                throw new BoardExceptions("There is no piece in the chosen position");
            }
            if(currentPlayer != board.piece(pos).Color)
            {
                throw new BoardExceptions("The origin piece chosen isn't yours.");
            }
            if (!board.piece(pos).existPossibleMoves())
            {
                throw new BoardExceptions("Don't have any possible move to the origin piece chosen!");
            }
        }

        public void validateDestinyPosition(Position origin, Position destiny) //Method to print the exception according to destination the error
        {
            if (!board.piece(origin).canMoveTo(destiny))
            {
                throw new BoardExceptions("Destination position invalid");
            }
        }


        public void switchPlayer() //Method to change the current player
        {
            if(currentPlayer == Color.White)
            {
                currentPlayer = Color.Black;
            }
            else
            {
                currentPlayer = Color.White;
            }
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
