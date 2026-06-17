namespace PuzzleArcade.Games.Shared;

public sealed record class StartGame;

public sealed record class MakeGuess(string Text);

public sealed record class SelectCell(int Row, int Column);

public sealed record class ResetGame;

public sealed record class ShowHint;

public union PuzzleAction(
    StartGame,
    MakeGuess,
    SelectCell,
    ResetGame,
    ShowHint);
