namespace ChessUnitTest;
using ChessLibrary;

public class UnitTestKnight
{
    [Theory]
    [MemberData(nameof(TestData.ValidKnightPositionsData), MemberType = typeof(TestData))]
    public void CanMove_ValidMove_ReturnsTrue(int x1, int y1, int x2, int y2)
    {
        // Arrange
        var knight = new Knight(Color.White, 1);

        // Act
        var result = knight.CanMove(x1, y1, x2, y2);

        // Assert
        Assert.True(result);
    }

    [Theory]
    [MemberData(nameof(TestData.InvalidKnightPositionsData), MemberType = typeof(TestData))]
    public void CanMove_InvalidMove_ThrowsException(int x1, int y1, int x2, int y2)
    {
        // Arrange
        var knight = new Knight(Color.White, 1);

        // Act & Assert
        Assert.Throws<InvalidMovementException>(() => knight.CanMove(x1, y1, x2, y2));
    }
    
    [Fact]
    public void PossibleMoves_EmptyBoard_ReturnsCorrectMoves()
    {
        // Arrange
        var knight = new Knight(Color.White, 1);
        var chessboard = new Chessboard(new Case[8, 8],true);
        var caseInitial = new Case(4, 4, knight);

        // Act
        var result = knight.PossibleMoves(caseInitial, chessboard);

        // Assert
        Assert.Equal(8, result.Count);
    }
    
    [Fact]
    public void PossibleMoves_ChessboardIsNull_ThrowsArgumentNullException()
    {
        // Arrange
        var knight = new Knight(Color.White, 1);
        Chessboard chessboard = null!;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => knight.PossibleMoves(new Case(0, 0, knight), chessboard!));
    }
    
    [Fact]
    public void PossibleMoves_PotentialCaseNotEmptyAndDifferentColor_AddsToResult()
    {
        // Arrange
        var chessboard = new Chessboard(new Case[8, 8], true);
        var knight = new Knight(Color.White, 1);
        var enemyPiece = new Pawn(Color.Black, 2);
        chessboard.Board[4, 4] = new Case(4, 4, knight);
        chessboard.Board[6, 5] = new Case(6, 5, enemyPiece); // Potential case is not empty and contains a piece of different color

        // Act
        var result = knight.PossibleMoves(chessboard.Board[4, 4], chessboard);

        // Assert
        Assert.Contains(chessboard.Board[6, 5], result);
    }
    
}