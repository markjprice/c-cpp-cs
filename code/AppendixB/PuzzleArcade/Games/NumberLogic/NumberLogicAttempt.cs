namespace PuzzleArcade.Games.NumberLogic;

public sealed record class NumberLogicAttempt(
    string Guess,
    NumberLogicClue Clue)
{
    public bool IsCorrect(int secretLength) =>
        Clue.ExactMatches == secretLength;

    public string ClueText => Clue.Summary;
}
