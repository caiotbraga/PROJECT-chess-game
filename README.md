# Chess Game Documentation

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
