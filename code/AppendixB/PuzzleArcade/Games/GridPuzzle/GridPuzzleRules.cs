namespace PuzzleArcade.Games.GridPuzzle;

using PuzzleArcade.Games.Shared;

public static class GridPuzzleRules
{
    public static GridPuzzleModel CreateInitial() =>
        new(
            State: new NotStarted(),
            Board: GridBoard.Empty(rowCount: 3, columnCount: 3),
            MovesTaken: 0,
            Message: "Start the game to load the puzzle.");

    public static GridPuzzleModel Update(
        GridPuzzleModel model,
        PuzzleAction action) => action switch
        {
            StartGame _ => StartNewGame(),

            ResetGame _ => CreateInitial(),

            ShowHint _ when model.State is Playing =>
                model with
                {
                    Message = "Hint: clicking a tile also toggles its up, down, left, and right neighbors."
                },

            SelectCell cell =>
                ApplyTileSelection(
                    model,
                    new GridPosition(cell.Row, cell.Column)),

            _ => model
        };

    private static GridPuzzleModel StartNewGame() =>
        new(
            State: new Playing(TurnsTaken: 0),
            Board: CreateStartingBoard(),
            MovesTaken: 0,
            Message: "Turn all tiles off.");

    private static GridPuzzleModel ApplyTileSelection(
        GridPuzzleModel model,
        GridPosition position)
    {
        if (model.State is not Playing)
        {
            return model with
            {
                Message = "Start the puzzle before selecting tiles."
            };
        }

        if (!model.Board.IsInside(position))
        {
            return model with
            {
                Message = "That tile is outside the board."
            };
        }

        int movesTaken = model.MovesTaken + 1;
        GridBoard board = model.Board.TogglePattern(position);

        GridPuzzleModel updated = model with
        {
            Board = board,
            MovesTaken = movesTaken,
            State = new Playing(movesTaken),
            Message = "Tile selected."
        };

        if (updated.IsSolved)
        {
            return updated with
            {
                State = new Won(movesTaken),
                Message = "Solved. You turned all tiles off."
            };
        }

        return updated;
    }

    private static GridBoard CreateStartingBoard() =>
        GridBoard.FromRows(
            "101",
            "110",
            "010");
}
