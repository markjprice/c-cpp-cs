namespace PuzzleArcade.Tests.GridPuzzle;

using PuzzleArcade.Games.GridPuzzle;
using PuzzleArcade.Games.Shared;

public sealed class GridPuzzleRulesTests
{
    [Fact]
    public void SelectingTileWhileNotStartedDoesNotChangeBoard()
    {
        GridPuzzleModel model = GridPuzzleRules.CreateInitial();

        GridPuzzleModel updated =
            GridPuzzleRules.Update(model, new SelectCell(Row: 1, Column: 1));

        Assert.IsType<NotStarted>(updated.State.Value);
        Assert.Contains("Start", updated.Message);
    }

    [Fact]
    public void ResetReturnsToNotStarted()
    {
        GridPuzzleModel model =
            GridPuzzleRules.Update(
                GridPuzzleRules.CreateInitial(),
                new StartGame());

        GridPuzzleModel updated =
            GridPuzzleRules.Update(model, new ResetGame());

        Assert.IsType<NotStarted>(updated.State.Value);
        Assert.Equal(0, updated.MovesTaken);
    }
}
