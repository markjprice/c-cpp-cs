namespace PuzzleArcade.Games.Shared;

public sealed record class NotStarted;

public sealed record class Playing(int TurnsTaken);

public sealed record class Won(int TurnsTaken);

public sealed record class Lost(string Reason);

public union GameState(NotStarted, Playing, Won, Lost);
