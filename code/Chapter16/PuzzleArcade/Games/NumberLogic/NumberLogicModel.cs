namespace PuzzleArcade.Games.NumberLogic;

using PuzzleArcade.Games.Shared;

public sealed record class NumberLogicModel(
    GameState State,
    string Secret,
    int SecretLength,
    IReadOnlyList<NumberLogicAttempt> Attempts,
    int MaxGuesses,
    string Message)
{
    public int AttemptsUsed => Attempts.Count;

    public int AttemptsRemaining => Math.Max(0, MaxGuesses - AttemptsUsed);

    public bool CanGuess => State is Playing && AttemptsRemaining > 0;
}
