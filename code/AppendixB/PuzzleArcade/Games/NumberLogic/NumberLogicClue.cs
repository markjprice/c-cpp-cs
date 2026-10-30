namespace PuzzleArcade.Games.NumberLogic;

public sealed record class NumberLogicClue(
    int ExactMatches,
    int MisplacedMatches)
{
    public int TotalMatches => ExactMatches + MisplacedMatches;

    public string Summary
    {
        get
        {
            string exactText = ExactMatches == 1
                ? "1 exact"
                : $"{ExactMatches} exact";

            string misplacedText = MisplacedMatches == 1
                ? "1 misplaced"
                : $"{MisplacedMatches} misplaced";

            return $"{exactText}, {misplacedText}";
        }
    }
}
