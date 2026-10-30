namespace PuzzleArcade.Games.WordGuess;

public sealed record class GuessAttempt(
    string Text,
    IReadOnlyList<LetterFeedback> Feedback)
{
    public bool IsCorrect =>
        Feedback.All(item => item.Kind == LetterFeedbackKind.Exact);
}
