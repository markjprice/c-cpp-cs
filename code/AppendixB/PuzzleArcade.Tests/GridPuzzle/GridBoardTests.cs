namespace PuzzleArcade.Tests.GridPuzzle;

using PuzzleArcade.Games.GridPuzzle;

public sealed class GridBoardTests
{
    [Fact]
    public void TogglePatternChangesSelectedTile()
    {
        GridBoard board = GridBoard.FromRows(
            "000",
            "000",
            "000");

        GridBoard updated =
            board.TogglePattern(new GridPosition(Row: 1, Column: 1));

        Assert.Equal(
            TileState.On,
            updated.GetState(new GridPosition(Row: 1, Column: 1)));
    }

    [Fact]
    public void EmptyBoardIsSolved()
    {
        GridBoard board = GridBoard.FromRows(
            "000",
            "000",
            "000");

        Assert.True(board.IsSolved);
    }

    [Fact]
    public void BoardWithOnTileIsNotSolved()
    {
        GridBoard board = GridBoard.FromRows(
            "000",
            "010",
            "000");

        Assert.False(board.IsSolved);
    }
}
