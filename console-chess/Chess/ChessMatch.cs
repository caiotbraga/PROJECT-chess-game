using System.Collections.Generic;
using board;

namespace Chess
{
    class ChessMatch
    {

        public Board Board { get; private set; }
        public int Round { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool Finished { get; private set; }
        private HashSet<Piece> Pieces;
        private HashSet<Piece> Captured;
        public bool Checkmate { get; private set; }

        public ChessMatch()
        {
            Board = new Board(8, 8);
            Round = 1;
            CurrentPlayer = Color.White;
            Finished = false;
            Checkmate = false;
            Pieces = new HashSet<Piece>();
            Captured = new HashSet<Piece>();
            insertPiece();
        }

        public Piece peformMovement(Position origin, Position destiny) //SpecialPlay added codes to castling  
        {
            Piece p = Board.removePiece(origin);
            p.incrementMovementQuantity();
            Piece capturedPiece = Board.removePiece(destiny);
            Board.putPiece(p, destiny);
            if (capturedPiece != null)
            {
                Captured.Add(capturedPiece);
            }

            //#SPECIALPLAY small castling
            if(p is King && destiny.Column == origin.Column + 2)
            {
                Position originT = new Position(origin.Line, origin.Column + 3);
                Position destinyT = new Position(origin.Line, origin.Column + 1);
                Piece T = Board.removePiece(originT);
                T.incrementMovementQuantity();
                Board.putPiece(T, destinyT);
            }

            //#SPECIALPLAY big castling
            if (p is King && destiny.Column == origin.Column - 2)
            {
                Position originT = new Position(origin.Line, origin.Column - 4);
                Position destinyT = new Position(origin.Line, origin.Column - 1);
                Piece T = Board.removePiece(originT);
                T.incrementMovementQuantity();
                Board.putPiece(T, destinyT);
            }

            return capturedPiece;
        }

        public void undoMove(Position origin, Position destiny, Piece capturedPiece) //SpecialPlay added codes to castling  
        {
            Piece p = Board.removePiece(destiny);
            p.decrementMovementQuantity();
            if (capturedPiece != null)
            {
                Board.putPiece(capturedPiece, destiny);
                Captured.Remove(capturedPiece);
            }
            Board.putPiece(p, origin);

            //#SPECIALPLAY small castling
            if (p is King && destiny.Column == origin.Column + 2)
            {
                Position originT = new Position(origin.Line, origin.Column + 3);
                Position destinyT = new Position(origin.Line, origin.Column + 1);
                Piece T = Board.removePiece(destinyT);
                T.decrementMovementQuantity();
                Board.putPiece(T, originT);
            }

            //#SPECIALPLAY big castling
            if (p is King && destiny.Column == origin.Column - 2)
            {
                Position originT = new Position(origin.Line, origin.Column - 4);
                Position destinyT = new Position(origin.Line, origin.Column - 1);
                Piece T = Board.removePiece(destinyT);
                T.decrementMovementQuantity();
                Board.putPiece(T, originT);
            }
        }

        public void makePlay(Position origin, Position destiny)
        {
            Piece capturedPiece = peformMovement(origin, destiny);

            if (isCheckmate(CurrentPlayer))
            {
                undoMove(origin, destiny, capturedPiece);
                throw new BoardExceptions("You can't put yourself in checkmate!");
            }

            if (isCheckmate(adversary(CurrentPlayer)))
            {
                Checkmate = true;
            }
            else
            {
                Checkmate = false;
            }

            if (checkmateTest(adversary(CurrentPlayer))) 
            {
                Finished = true;
            }
            else
            {
                Round++;
                switchPlayer();
            }
        }

        public void validateOriginPosition(Position pos) 
        {
            if (Board.piece(pos) == null)
            {
                throw new BoardExceptions("There is no piece in the origin position chosen"); //redone
            }
            if (CurrentPlayer != Board.piece(pos).Color)
            {
                throw new BoardExceptions("The origin piece chosen isn't yours.");
            }
            if (!Board.piece(pos).existPossibleMoves())
            {
                throw new BoardExceptions("Don't have any possible move to the origin piece chosen!");
            }
        }

        public void validateDestinyPosition(Position origin, Position destiny) 
        {
            if (!Board.piece(origin).possibleMovement(destiny)) 
            {
                throw new BoardExceptions("Destination position invalid");
            }
        }

        public void switchPlayer()
        {
            if (CurrentPlayer == Color.White)
            {
                CurrentPlayer = Color.Black;
            }
            else
            {
                CurrentPlayer = Color.White;
            }
        }

        public HashSet<Piece> capturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in Captured)
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
            foreach (Piece x in Pieces)
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
                for (int i = 0; i < Board.Lines; i++)
                {
                    for (int j = 0; j < Board.Columns; j++)
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
            Board.putPiece(piece, new ChessPosition(column, line).ToPositon());
            Pieces.Add(piece);
        }

        public void insertPiece() //correcting and changing King and Queen's position. Was giving error 
        {
            insertNewPiece('a', 1, new Tower(Board, Color.White));
            insertNewPiece('b', 1, new Horse(Board, Color.White));
            insertNewPiece('c', 1, new Bishop(Board, Color.White));
            insertNewPiece('d', 1, new Queen(Board, Color.White)); //'e' --> 'd'
            insertNewPiece('e', 1, new King(Board, Color.White, this)); //'d' --> 'e'
            insertNewPiece('f', 1, new Bishop(Board, Color.White));
            insertNewPiece('g', 1, new Horse(Board, Color.White));
            insertNewPiece('h', 1, new Tower(Board, Color.White));
            insertNewPiece('a', 2, new Pawn(Board, Color.White));
            insertNewPiece('b', 2, new Pawn(Board, Color.White));
            insertNewPiece('c', 2, new Pawn(Board, Color.White));
            insertNewPiece('d', 2, new Pawn(Board, Color.White));
            insertNewPiece('e', 2, new Pawn(Board, Color.White));
            insertNewPiece('f', 2, new Pawn(Board, Color.White));
            insertNewPiece('g', 2, new Pawn(Board, Color.White));
            insertNewPiece('h', 2, new Pawn(Board, Color.White));

            insertNewPiece('a', 8, new Tower(Board, Color.Black));
            insertNewPiece('b', 8, new Horse(Board, Color.Black));
            insertNewPiece('c', 8, new Bishop(Board, Color.Black));
            insertNewPiece('d', 8, new Queen(Board, Color.Black)); //'e' --> 'd'
            insertNewPiece('e', 8, new King(Board, Color.Black, this)); //'d' --> 'e'
            insertNewPiece('f', 8, new Bishop(Board, Color.Black));
            insertNewPiece('g', 8, new Horse(Board, Color.Black));
            insertNewPiece('h', 8, new Tower(Board, Color.Black));
            insertNewPiece('a', 7, new Pawn(Board, Color.Black));
            insertNewPiece('b', 7, new Pawn(Board, Color.Black));
            insertNewPiece('c', 7, new Pawn(Board, Color.Black));
            insertNewPiece('d', 7, new Pawn(Board, Color.Black));
            insertNewPiece('e', 7, new Pawn(Board, Color.Black));
            insertNewPiece('f', 7, new Pawn(Board, Color.Black));
            insertNewPiece('g', 7, new Pawn(Board, Color.Black));
            insertNewPiece('h', 7, new Pawn(Board, Color.Black));
        }
    }
}
