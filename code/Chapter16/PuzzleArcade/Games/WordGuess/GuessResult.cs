namespace PuzzleArcade.Games.WordGuess;

public sealed record class InvalidGuess(string Message);

public sealed record class AlreadyTried(string Guess);

public sealed record class AcceptedGuess(GuessAttempt Attempt);

public union GuessResult(
    InvalidGuess,
    AlreadyTried,
    AcceptedGuess);
