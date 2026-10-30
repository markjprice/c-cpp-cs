namespace PuzzleArcade.Games.WordGuess;

public enum LetterFeedbackKind
{
    Exact,
    Misplaced,
    Absent
}

public sealed record class LetterFeedback(
    char Letter,
    LetterFeedbackKind Kind);
