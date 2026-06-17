namespace PuzzleArcade.Games.Shared;

public static class PuzzleActionExtensions
{
    public static string ToDisplayText(this PuzzleAction action) => action switch
    {
        StartGame _ => "Start game",
        MakeGuess g => $"Make guess: {g.Text}",
        SelectCell c => $"Select cell: row {c.Row}, column {c.Column}",
        ResetGame _ => "Reset game",
        ShowHint _ => "Show hint",
        null => "Unknown action"
    };
}
