namespace PuzzleArcade.Games.WordGuess;

using PuzzleArcade.Games.Shared;

public sealed record class WordGuessModel(
    GameState State,
    string Answer,
    IReadOnlyList<GuessAttempt> Attempts,
    int MaxGuesses,
    int HintsUsed, // Added in Chapter 18.
    string Message)
{
    public int AttemptsUsed => Attempts.Count;

    public int AttemptsRemaining => Math.Max(0, MaxGuesses - AttemptsUsed);

    public bool CanGuess => State is Playing && AttemptsRemaining > 0;
}
