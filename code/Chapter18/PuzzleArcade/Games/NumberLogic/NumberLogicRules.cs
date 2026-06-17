namespace PuzzleArcade.Games.NumberLogic;

using PuzzleArcade.Games.Shared;

public static class NumberLogicRules
{
    private const int DefaultSecretLength = 4;
    private const int DefaultMaxGuesses = 8;

    private sealed record class DifficultySettings(
        int SecretLength,
        int MaxGuesses);

    private static DifficultySettings GetSettings(DifficultyLevel difficulty) =>
        difficulty switch
        {
            DifficultyLevel.Easy => new(SecretLength: 3, MaxGuesses: 10),
            DifficultyLevel.Normal => new(SecretLength: 4, MaxGuesses: 8),
            DifficultyLevel.Hard => new(SecretLength: 5, MaxGuesses: 7),
            _ => new(SecretLength: 4, MaxGuesses: 8)
        };

    public static NumberLogicModel CreateInitial()
    {
        // Added in Chapter 18.
        DifficultyLevel difficulty = DifficultyLevel.Normal;
        DifficultySettings settings = GetSettings(difficulty);

        return new (
            State: new NotStarted(),
            Difficulty: difficulty, // Added in Chapter 18.
            Secret: "",
            SecretLength: DefaultSecretLength,
            Attempts: [],
            MaxGuesses: DefaultMaxGuesses,
            Message: "Start the game to choose a hidden digit sequence.");        
    }

    public static NumberLogicModel Update(
        NumberLogicModel model,
        PuzzleAction action) => action switch
        {
            StartGame _ => StartNewGame(model.Difficulty),

            ResetGame _ => CreateInitial(),

            ShowHint _ when model.State is Playing =>
                model with
                {
                    Message = $"Hint: the sequence has {model.SecretLength} different digits."
                },

            MakeGuess guess =>
                ApplyGuess(model, guess.Text),

            _ => model
        };

    private static NumberLogicModel StartNewGame(
        DifficultyLevel difficulty)
    {
        DifficultySettings settings = GetSettings(difficulty);
        string secret = CreateSecret(settings.SecretLength);

        return new(
            State: new Playing(TurnsTaken: 0),
            Difficulty: difficulty,
            Secret: secret,
            SecretLength: settings.SecretLength,
            Attempts: [],
            MaxGuesses: settings.MaxGuesses,
            Message: "A hidden digit sequence has been chosen. Make your first guess.");
    }

    private static NumberLogicModel ApplyGuess(
        NumberLogicModel model,
        string text)
    {
        if (model.State is not Playing playing)
        {
            return model with
            {
                Message = "Start a new game before making a guess."
            };
        }

        string guess = NormalizeGuess(text);

        string? validationMessage = ValidateGuess(guess, model.SecretLength);

        if (validationMessage is not null)
        {
            return model with
            {
                Message = validationMessage
            };
        }

        if (model.Attempts.Any(attempt => attempt.Guess == guess))
        {
            return model with
            {
                Message = $"You already tried {guess}."
            };
        }

        NumberLogicClue clue = CompareGuess(guess, model.Secret);

        NumberLogicAttempt attempt = new(
            Guess: guess,
            Clue: clue);

        List<NumberLogicAttempt> attempts = [.. model.Attempts, attempt];
        int turnsTaken = playing.TurnsTaken + 1;

        if (attempt.IsCorrect(model.SecretLength))
        {
            return model with
            {
                State = new Won(turnsTaken),
                Attempts = attempts,
                Message = "Correct. You found the hidden sequence."
            };
        }

        if (attempts.Count >= model.MaxGuesses)
        {
            return model with
            {
                State = new Lost($"The hidden sequence was {model.Secret}."),
                Attempts = attempts,
                Message = "No attempts remaining."
            };
        }

        return model with
        {
            State = new Playing(turnsTaken),
            Attempts = attempts,
            Message = "Guess accepted. Use the clue to try again."
        };
    }

    private static string? ValidateGuess(string guess, int secretLength)
    {
        if (string.IsNullOrWhiteSpace(guess))
        {
            return "Enter a sequence of digits before guessing.";
        }

        if (guess.Length != secretLength)
        {
            return $"Enter exactly {secretLength} digits.";
        }

        if (!guess.All(char.IsDigit))
        {
            return "Use digits only.";
        }

        if (guess.Distinct().Count() != guess.Length)
        {
            return "Do not repeat digits.";
        }

        return null;
    }

    private static NumberLogicClue CompareGuess(
        string guess,
        string secret)
    {
        int exactMatches = 0;
        int misplacedMatches = 0;

        for (int i = 0; i < guess.Length; i++)
        {
            if (guess[i] == secret[i])
            {
                exactMatches++;
            }
            else if (secret.Contains(guess[i]))
            {
                misplacedMatches++;
            }
        }

        return new NumberLogicClue(
            ExactMatches: exactMatches,
            MisplacedMatches: misplacedMatches);
    }

    private static string CreateSecret(int length)
    {
        List<char> digits =
        [
            '0', '1', '2', '3', '4',
            '5', '6', '7', '8', '9'
        ];

        for (int i = 0; i < digits.Count; i++)
        {
            int swapIndex = Random.Shared.Next(i, digits.Count);
            (digits[i], digits[swapIndex]) = (digits[swapIndex], digits[i]);
        }

        return new string(digits.Take(length).ToArray());
    }

    private static string NormalizeGuess(string text) =>
        text.Trim();
}
