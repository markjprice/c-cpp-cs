namespace PuzzleArcade.Games.Shared;

public static class PuzzleActionRules
{
    public static bool IsNormallyAvailable(
        this PuzzleAction action,
        GameState state) => (state, action) switch
        {
            (NotStarted, StartGame) => true,
            (NotStarted, ResetGame) => true,

            (Playing, MakeGuess) => true,
            (Playing, SelectCell) => true,
            (Playing, ResetGame) => true,
            (Playing, ShowHint) => true,

            (Won, ResetGame) => true,
            (Lost, ResetGame) => true,

            _ => false
        };
}
