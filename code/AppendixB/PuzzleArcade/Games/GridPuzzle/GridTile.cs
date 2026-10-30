namespace PuzzleArcade.Games.GridPuzzle;

public sealed record class GridTile(
    GridPosition Position,
    TileState State)
{
    public bool IsOn => State is TileState.On;
}
