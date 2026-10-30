namespace PuzzleArcade.Games.GridPuzzle;

using PuzzleArcade.Games.Shared;

public sealed record class GridPuzzleModel(
    GameState State,
    GridBoard Board,
    int MovesTaken,
    string Message)
{
    public int RowCount => Board.RowCount;

    public int ColumnCount => Board.ColumnCount;

    public bool IsSolved => Board.IsSolved;

    public bool CanSelectTiles => State is Playing;
}
