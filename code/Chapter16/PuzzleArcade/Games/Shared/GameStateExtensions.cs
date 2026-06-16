namespace PuzzleArcade.Games.Shared;

public static class GameStateExtensions
{
    public static string ToStatusText(this GameState state) => state switch
    {
        NotStarted _ => "Not started",
        Playing p => p.TurnsTaken == 0
            ? "Playing. No turns yet."
            : $"Playing. Turns taken: {p.TurnsTaken}.",
        Won w => $"Won in {FormatTurnCount(w.TurnsTaken)}.",
        Lost l => $"Lost. {l.Reason}",
        null => "Unknown game state."
    };

    private static string FormatTurnCount(int turns) =>
        turns == 1 ? "1 turn" : $"{turns} turns";
}
