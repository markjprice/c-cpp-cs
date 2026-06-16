namespace PuzzleArcade.Games.GridPuzzle;

public sealed class GridBoard
{
    private readonly TileState[,] tiles;

    private GridBoard(TileState[,] tiles)
    {
        this.tiles = tiles;
    }

    public int RowCount => tiles.GetLength(0);

    public int ColumnCount => tiles.GetLength(1);

    public bool IsSolved
    {
        get
        {
            foreach (TileState state in tiles)
            {
                if (state is TileState.On)
                {
                    return false;
                }
            }

            return true;
        }
    }

    public static GridBoard Empty(
        int rowCount,
        int columnCount) =>
        new(new TileState[rowCount, columnCount]);

    public static GridBoard FromRows(params string[] rows)
    {
        if (rows.Length == 0)
        {
            throw new ArgumentException(
                "At least one row is required.",
                nameof(rows));
        }

        int columnCount = rows[0].Length;

        if (rows.Any(row => row.Length != columnCount))
        {
            throw new ArgumentException(
                "All rows must have the same length.",
                nameof(rows));
        }

        TileState[,] tiles = new TileState[rows.Length, columnCount];

        for (int row = 0; row < rows.Length; row++)
        {
            for (int column = 0; column < columnCount; column++)
            {
                tiles[row, column] = rows[row][column] switch
                {
                    '1' => TileState.On,
                    '0' => TileState.Off,
                    char symbol => throw new ArgumentException(
                        $"Unexpected board symbol: {symbol}.",
                        nameof(rows))
                };
            }
        }

        return new GridBoard(tiles);
    }

    public TileState GetState(GridPosition position)
    {
        if (!IsInside(position))
        {
            throw new ArgumentOutOfRangeException(
                nameof(position),
                position,
                "The position is outside the board.");
        }

        return tiles[position.Row, position.Column];
    }

    public bool IsInside(GridPosition position) =>
        position.Row >= 0
        && position.Row < RowCount
        && position.Column >= 0
        && position.Column < ColumnCount;

    public GridBoard TogglePattern(GridPosition position)
    {
        TileState[,] copy = CopyTiles();

        foreach (GridPosition affected in position.SelfAndOrthogonalNeighbors())
        {
            Toggle(copy, affected);
        }

        return new GridBoard(copy);
    }

    public IEnumerable<GridTile> GetTiles()
    {
        for (int row = 0; row < RowCount; row++)
        {
            for (int column = 0; column < ColumnCount; column++)
            {
                GridPosition position = new(row, column);

                yield return new GridTile(
                    Position: position,
                    State: GetState(position));
            }
        }
    }

    private TileState[,] CopyTiles()
    {
        TileState[,] copy = new TileState[RowCount, ColumnCount];

        for (int row = 0; row < RowCount; row++)
        {
            for (int column = 0; column < ColumnCount; column++)
            {
                copy[row, column] = tiles[row, column];
            }
        }

        return copy;
    }

    private static void Toggle(
        TileState[,] tiles,
        GridPosition position)
    {
        int rowCount = tiles.GetLength(0);
        int columnCount = tiles.GetLength(1);

        bool isInside =
            position.Row >= 0
            && position.Row < rowCount
            && position.Column >= 0
            && position.Column < columnCount;

        if (!isInside)
        {
            return;
        }

        tiles[position.Row, position.Column] =
            tiles[position.Row, position.Column] switch
            {
                TileState.On => TileState.Off,
                TileState.Off => TileState.On,
                _ => TileState.Off
            };
    }
}
