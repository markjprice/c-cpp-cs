namespace PuzzleArcade.Games.GridPuzzle;

public readonly record struct GridPosition(int Row, int Column)
{
    public IEnumerable<GridPosition> SelfAndOrthogonalNeighbors()
    {
        yield return this;
        yield return new GridPosition(Row - 1, Column);
        yield return new GridPosition(Row + 1, Column);
        yield return new GridPosition(Row, Column - 1);
        yield return new GridPosition(Row, Column + 1);
    }
}
