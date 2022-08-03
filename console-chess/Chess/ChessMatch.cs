using System.Collections.Generic;
using board;
namespace Chess
{
    internal class ChessMatch
    {
        public Board board { get; private set; } 
        public int round { get; private set; } 
        public Color currentPlayer { get; private set; }
        public bool finished { get; private set; }
        private HashSet<Piece> pieces; 
        private HashSet<Piece> captured;

        public ChessMatch() 
        {
            board = new Board(8, 8); 
            round = 1;
            currentPlayer = Color.White; 
            finished = false;
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            insertPiece();
        }

        public void peformMovement(Position origin, Position destiny) 
        {
            Piece p = board.RemovePiece(origin); 
            p.incrementMovimentQuantity();
            Piece capturedPiece = board.RemovePiece(destiny); 
            board.PutPiece(p, destiny); 
            if(capturedPiece != null)
            {
                captured.Add(capturedPiece); //add to set(HashSet)
            }
        }

        public void makeMovement(Position origin, Position destiny) 
        {
            peformMovement(origin, destiny);
            round++;
            switchPlayer();
        }

        public void validateOriginPosition(Position pos) 
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

        public void validateDestinyPosition(Position origin, Position destiny) 
        {
            if (!board.piece(origin).canMoveTo(destiny))
            {
                throw new BoardExceptions("Destination position invalid");
            }
        }


        public void switchPlayer() 
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

        public HashSet<Piece> capturedPieces(Color color) //Method to set division by colors 
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach(Piece x in captured)
            {
                if(x.Color == color)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Piece> pieceInGame(Color color) 
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in pieces)
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(capturedPieces(color)); //Remove all pieces removed with the same color.
            return aux;
        }


        public void insertNewPiece(char column, int line, Piece piece)
        {
            board.PutPiece(piece, new ChessPosition(column, line).ToPositon());
            pieces.Add(piece);
        }

        public void insertPiece() //improvement
        {
            insertNewPiece('c', 1, new Tower(board, Color.White));
            insertNewPiece('c', 2, new Tower(board, Color.White));
            insertNewPiece('d', 2, new Tower(board, Color.White));
            insertNewPiece('e', 2, new Tower(board, Color.White));
            insertNewPiece('e', 1, new Tower(board, Color.White));
            insertNewPiece('d', 1, new King(board, Color.White));           

            insertNewPiece('c', 7, new Tower(board, Color.Black));
            insertNewPiece('c', 8, new Tower(board, Color.Black));
            insertNewPiece('d', 7, new Tower(board, Color.Black));
            insertNewPiece('e', 7, new Tower(board, Color.Black));
            insertNewPiece('e', 8, new Tower(board, Color.Black));
            insertNewPiece('d', 8, new King(board, Color.Black));

        }
    }
}
