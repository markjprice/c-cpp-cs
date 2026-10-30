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

    public IEnumerable<GridPosition> SelfAndAllNeighbors()
    {
        for (int rowOffset = -1; rowOffset <= 1; rowOffset++)
        {
            for (int columnOffset = -1; columnOffset <= 1; columnOffset++)
            {
                yield return new GridPosition(
                    Row + rowOffset,
                    Column + columnOffset);
            }
        }
    }
}
