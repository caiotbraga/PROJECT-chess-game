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
        public bool checkmate { get; private set; }

        public ChessMatch()
        {
            board = new Board(8, 8);
            round = 1;
            currentPlayer = Color.White;
            finished = false;
            checkmate = false;
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            insertPiece();
        }

        public Piece peformMovement(Position origin, Position destiny)
        {
            Piece p = board.RemovePiece(origin);
            p.incrementMovementQuantity();
            Piece capturedPiece = board.RemovePiece(destiny);
            board.PutPiece(p, destiny);
            if (capturedPiece != null)
            {
                captured.Add(capturedPiece);
            }
            return capturedPiece;
        }

        public void undoMove(Position origin, Position destiny, Piece capturedPiece)
        {
            Piece p = board.RemovePiece(destiny);
            p.decrementMovementQuantity();
            if (capturedPiece != null)
            {
                board.PutPiece(capturedPiece, destiny);
                captured.Remove(capturedPiece);
            }
            board.PutPiece(p, origin);
        }

        public void makePlay(Position origin, Position destiny)
        {
            Piece capturedPiece = peformMovement(origin, destiny);

            if (isCheckmate(currentPlayer))
            {
                undoMove(origin, destiny, capturedPiece);
                throw new BoardExceptions("You can't put yourself in checkmate!");
            }

            if (isCheckmate(adversary(currentPlayer)))
            {
                checkmate = true;
            }
            else
            {
                checkmate = false;
            }

            if (checkmateTest(adversary(currentPlayer))) 
            {
                finished = true;
            }
            else
            {
                round++;
                switchPlayer();
            }
        }

        public void validateOriginPosition(Position pos)
        {
            if (board.piece(pos) == null)
            {
                throw new BoardExceptions("There is no piece in the chosen position");
            }
            if (currentPlayer != board.piece(pos).Color)
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
            if (!board.piece(origin).possibleMovement(destiny))
            {
                throw new BoardExceptions("Destination position invalid");
            }
        }


        public void switchPlayer()
        {
            if (currentPlayer == Color.White)
            {
                currentPlayer = Color.Black;
            }
            else
            {
                currentPlayer = Color.White;
            }
        }

        public HashSet<Piece> capturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in captured)
            {
                if (x.Color == color)
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
            aux.ExceptWith(capturedPieces(color));
            return aux;
        }

        private Color adversary(Color color)
        {
            if (color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }

        private Piece king(Color color)
        {
            foreach (Piece x in pieceInGame(color))
            {
                if (x is King)
                {
                    return x;
                }
            }
            return null;
        }

        public bool isCheckmate(Color color)
        {
            Piece K = king(color);
            if (K == null)
            {
                throw new BoardExceptions("There's no king of color " + color + " on the board!");
            }

            foreach (Piece x in pieceInGame(adversary(color)))
            {
                bool[,] mat = x.possibleMoves();
                if (mat[K.Position.Line, K.Position.Column])
                {
                    return true;
                }
            }
            return false;
        }

        public bool checkmateTest(Color color)
        {
            if (!isCheckmate(color))
            {
                return false;
            }
            foreach (Piece x in pieceInGame(color))
            {
                bool[,] mat = x.possibleMoves(); 
                for (int i = 0; i < board.Lines; i++)
                {
                    for (int j = 0; j < board.Columns; j++)
                    {
                        if (mat[i, j]) 
                        {
                            Position origin = x.Position;
                            Position destiny = new Position(i, j);
                            Piece capturedPiece = peformMovement(origin, destiny); 
                            bool checkmateTest = isCheckmate(color); 
                            undoMove(origin, destiny, capturedPiece);
                            if (!checkmateTest)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true; 
        }



        public void insertNewPiece(char column, int line, Piece piece)
        {
            board.PutPiece(piece, new ChessPosition(column, line).ToPositon());
            pieces.Add(piece);
        }

        public void insertPiece()
        {
            insertNewPiece('c', 1, new Tower(board, Color.White));
            insertNewPiece('e', 1, new Tower(board, Color.White));
            insertNewPiece('d', 1, new King(board, Color.White));

           
            insertNewPiece('c', 8, new Tower(board, Color.Black));
            insertNewPiece('d', 8, new King(board, Color.Black));
            insertNewPiece('e', 8, new Tower(board, Color.Black));
        }
    }
}
