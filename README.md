<h1 align="center">Chess Game Documentation ♟️</h1>

<p>Welcome to the Console Chess project! This project aims to provide a classic game of chess with a graphical representation using the console interface. Chess is a timeless game known for its complexity, strategic depth, and rich history. With this project, players can enjoy the game of chess right from their command line interface.It can be played by 2 peoples.
</p>

<h2 align="center">💻Technologies useds</h2>
<p align="center">
  <a href="https://learn.microsoft.com/pt-br/dotnet/csharp" target="blank"><img src="https://img.shields.io/badge/C%23-purple?logo=c-sharp&logoColor=white&labelColor=421e6b" alt="C# Badge"></a>
<a href="https://dotnet.microsoft.com/download/dotnet-core/3.1" target="_blank"><img src="https://img.shields.io/badge/ASP.NET_Core-3.1-grey?logo=.net&logoColor=white&labelColor=purple" alt="ASP.NET Core 3.1 Badge"></a>

## Board Class

The `Board` class represents the chessboard and handles the placement and movement of pieces on it.

### Properties

- `Lines`: Represents the number of lines (rows) on the chessboard.
- `Columns`: Represents the number of columns on the chessboard.

### Fields

- `pieces`: A 2D array of `Piece` objects representing the pieces placed on the board.

### Constructor

- `Board(int lines, int columns)`: Initializes a new instance of the `Board` class with the specified number of lines and columns. It also initializes the `pieces` array.

### Methods

- `Piece piece(int line, int column)`: Returns the piece located at the specified position.
- `Piece piece(Position pos)`: Returns the piece located at the specified position.
- `bool existPiece(Position pos)`: Checks if there is a piece at the specified position.
- `void putPiece(Piece p, Position pos)`: Places the specified piece at the specified position on the board.
- `Piece removePiece(Position pos)`: Removes the piece from the specified position and returns it.
- `bool validPosition(Position pos)`: Checks if the specified position is valid on the board.
- `void validatePosition(Position pos)`: Validates if the specified position is valid, throwing a `BoardExceptions` if not.

## BoardExceptions Class

The `BoardExceptions` class represents an exception specific to the board operations.

### Constructor

- `BoardExceptions(string msg)`: Initializes a new instance of the `BoardExceptions` class with the specified error message.

## Color Enum

The `Color` enum represents the color of the chess pieces.

## Piece Class

The `Piece` class represents a chess piece.

### Properties

- `Position`: Represents the current position of the piece.
- `Color`: Represents the color of the piece.
- `MovementQuantity`: Represents the number of movements made by the piece.
- `Board`: Represents the board on which the piece is placed.

### Constructor

- `Piece(Board boa, Color color)`: Initializes a new instance of the `Piece` class with the specified board and color.

### Methods

- `void incrementMovementQuantity()`: Increments the movement quantity of the piece.
- `void decrementMovementQuantity()`: Decrements the movement quantity of the piece.
- `bool existPossibleMoves()`: Checks if there are possible moves for the piece.
- `bool possibleMovement(Position pos)`: Checks if the specified position is a possible movement for the piece.
- `abstract bool[,] possibleMoves()`: Abstract method to be implemented by subclasses to calculate possible moves for the piece.

## Position Class

The `Position` class represents a position on the chessboard.

### Properties

- `Line`: Represents the line (row) of the position.
- `Column`: Represents the column of the position.

### Constructor

- `Position(int line, int column)`: Initializes a new instance of the `Position` class with the specified line and column.

### Methods

- `void setValues(int line, int column)`: Sets the values of the position.
- `override string ToString()`: Returns a string representation of the position.


## Chess Pieces

### Bishop Class

The `Bishop` class represents a bishop chess piece.

#### Constructor

- `Bishop(Board board, Color color)`: Initializes a new instance of the `Bishop` class with the specified board and color.

#### Methods

- `override string ToString()`: Returns the string representation of the bishop.
- `private bool canMove(Position pos)`: Checks if the bishop can move to the specified position.
- `override bool[,] possibleMoves()`: Calculates and returns a boolean matrix indicating the possible moves for the bishop on the board.

### Horse Class

The `Horse` class represents a knight chess piece.

#### Constructor

- `Horse(Board board, Color color)`: Initializes a new instance of the `Horse` class with the specified board and color.

#### Methods

- `override string ToString()`: Returns the string representation of the knight.
- `private bool canMove(Position pos)`: Checks if the knight can move to the specified position.
- `override bool[,] possibleMoves()`: Calculates and returns a boolean matrix indicating the possible moves for the knight on the board.

### King Class

The `King` class represents a king chess piece.

#### Constructor

- `King(Board board, Color color, ChessMatch match)`: Initializes a new instance of the `King` class with the specified board, color, and chess match.

#### Methods

- `override string ToString()`: Returns the string representation of the king.
- `private bool canMove(Position pos)`: Checks if the king can move to the specified position.
- `private bool testTowerToCastling(Position pos)`: Checks if there is a tower eligible for castling at the specified position.
- `override bool[,] possibleMoves()`: Calculates and returns a boolean matrix indicating the possible moves for the king on the board.

### Pawn Class

The `Pawn` class represents a pawn chess piece.

#### Constructor

- `Pawn(Board board, Color color, ChessMatch match)`: Initializes a new instance of the `Pawn` class with the specified board, color, and chess match.

#### Methods

- `override string ToString()`: Returns the string representation of the pawn.
- `private bool existEnemy(Position pos)`: Checks if there is an enemy piece at the specified position.
- `private bool free(Position pos)`: Checks if the specified position is free.
- `override bool[,] possibleMoves()`: Calculates and returns a boolean matrix indicating the possible moves for the pawn on the board.

### Queen Class

The `Queen` class represents a queen chess piece.

#### Constructor

- `Queen(Board board, Color color)`: Initializes a new instance of the `Queen` class with the specified board and color.

#### Methods

- `override string ToString()`: Returns the string representation of the queen.
- `private bool canMove(Position pos)`: Checks if the queen can move to the specified position.
- `override bool[,] possibleMoves()`: Calculates and returns a boolean matrix indicating the possible moves for the queen on the board.

### Tower Class

The `Tower` class represents a rook (or tower) chess piece.

#### Constructor

- `Tower(Board board, Color color)`: Initializes a new instance of the `Tower` class with the specified board and color.

#### Methods

- `override string ToString()`: Returns the string representation of the rook.
- `private bool canMove(Position pos)`: Checks if the rook can move to the specified position.
- `override bool[,] possibleMoves()`: Calculates and returns a boolean matrix indicating the possible moves for the rook on the board.

# Chess Game Logic Documentation

## ChessMatch Class

The `ChessMatch` class represents the chess match itself, managing the game flow, player turns, and piece movements.

### Properties

- `Board`: Represents the game board.
- `Round`: Tracks the current round of the game.
- `CurrentPlayer`: Indicates which player's turn it is.
- `Finished`: Tracks whether the game has finished.
- `Checkmate`: Tracks whether a player is in checkmate.
- `vulnerableEnPassant`: Stores the pawn that is vulnerable to en passant.

### Constructor

- `ChessMatch()`: Initializes a new chess match, setting up the board, round count, players, and pieces.

### Methods

- `peformMovement(Position origin, Position destiny)`: Performs a piece movement from `origin` to `destiny`, handling captures, special moves like castling and en passant, and promotion.
- `undoMove(Position origin, Position destiny, Piece capturedPiece)`: Undoes a piece movement, reverting the board to its previous state.
- `makePlay(Position origin, Position destiny)`: Executes a player's move, checking for checkmate, promoting pawns, and updating game state.
- `validateOriginPosition(Position pos)`: Validates if the origin position chosen for a move is valid.
- `validateDestinyPosition(Position origin, Position destiny)`: Validates if the destination position chosen for a move is valid.
- `switchPlayer()`: Switches the current player's turn.
- `capturedPieces(Color color)`: Returns the set of pieces captured by a specific color.
- `pieceInGame(Color color)`: Returns the set of pieces in the game for a specific color.
- `adversary(Color color)`: Returns the adversary color.
- `king(Color color)`: Finds and returns the king piece of a specific color.
- `isCheckmate(Color color)`: Checks if a player of a specific color is in checkmate.
- `checkmateTest(Color color)`: Tests if a player of a specific color is in checkmate, considering possible moves.
- `insertNewPiece(char column, int line, Piece piece)`: Inserts a new piece onto the board.
- `insertPiece()`: Initializes the board with standard chess piece positions.

## ChessPosition Class

The `ChessPosition` class represents a position on the chessboard using algebraic notation.

### Properties

- `Column`: Represents the column of the position.
- `Line`: Represents the line of the position.

### Constructor

- `ChessPosition(char column, int line)`: Initializes a new instance of the `ChessPosition` class.

### Methods

- `ToPositon()`: Converts the algebraic notation position to a `Position` object.
- `ToString()`: Returns the string representation of the position.

## Screen Class

The `Screen` class handles the visual representation of the chess game in the console.

### Methods

- `printMatch(ChessMatch match)`: Prints the current state of the match including the board, captured pieces, round number, and current player.
- `printCapturedPieces(ChessMatch match)`: Prints the captured pieces for both players.
- `printSet(HashSet<Piece> set)`: Prints a set of pieces.
- `PrintBoard(Board boa)`: Prints the game board.
- `PrintBoard(Board boa, bool[,] PossiblePositions)`: Prints the game board highlighting possible moves.
- `ReadChessPosition()`: Reads and returns a chess position input by the user.
- `PrintPiece(Piece piece)`: Prints a piece on the board.


### Method `Main(string[] args)`

This is the entry point of the application. It initializes a chess match and continues executing until the match is finished.

1. **Initializing the match**: The method starts by creating a new instance of a `ChessMatch` object, representing a chess match. This creates a new board and positions the pieces according to the rules of chess.

2. **Main loop**: It then enters a loop while the match is not finished (`!match.Finished`). Within this loop, the game is displayed on the console and waits for player input to make a move.

3. **Exception handling**: The main loop encompasses the entire process of playing a match, so any exceptions thrown during this process are handled. If a `BoardExceptions` type exception is thrown (for example, an invalid move), the program shows an error message and waits for the player to press Enter before continuing.

4. **Finishing the match**: When the match is finished, either by checkmate or another win condition, the loop is exited, and the final state of the match is printed to the console.

This method manages the execution of the chess game, interacting with the player, validating moves, and handling exceptions as necessary. It encapsulates all the logic for running the game within a main loop, making the code easy to understand and maintain.
