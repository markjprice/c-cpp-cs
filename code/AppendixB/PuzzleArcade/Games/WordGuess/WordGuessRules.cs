namespace PuzzleArcade.Games.WordGuess;

using PuzzleArcade.Games.Shared;

public static class WordGuessRules
{
    private static readonly string[] Words =
    [
        "apple",
        "beach",
        "chair",
        "dance",
        "eagle",
        "flame",
        "grape",
        "house",
        "lemon",
        "music",
        "river",
        "stone"
    ];

    public static WordGuessModel CreateInitial() =>
        new(
            State: new NotStarted(),
            Answer: "",
            Attempts: [],
            MaxGuesses: 6,
            HintsUsed: 0, // Added in Chapter 18.
            Message: "Start the game to choose a hidden word.");

    public static WordGuessModel Update(
        WordGuessModel model,
        PuzzleAction action) => action switch
        {
            StartGame => StartNewGame(model.MaxGuesses),

            ResetGame => CreateInitial(),

            ShowHint when model.State is Playing =>
                ShowWordHint(model), // Added in Chapter 18.

            MakeGuess guess =>
                ApplyGuess(model, guess.Text),

            _ => model
        };

    // Added in Chapter 18.
    private static WordGuessModel ShowWordHint(WordGuessModel model) =>
        model.HintsUsed switch
        {
            0 => model with
            {
                HintsUsed = 1,
                Message = $"Hint 1: the word starts with {char.ToUpperInvariant(model.Answer[0])}."
            },

            1 => model with
            {
                HintsUsed = 2,
                Message = $"Hint 2: the word ends with {char.ToUpperInvariant(model.Answer[^1])}."
            },

            _ => model with
            {
                Message = "No more hints available."
            }
        };

    private static WordGuessModel StartNewGame(int maxGuesses)
    {
        string answer = Words[Random.Shared.Next(Words.Length)];

        return new(
            State: new Playing(TurnsTaken: 0),
            Answer: answer,
            Attempts: [],
            MaxGuesses: maxGuesses,
            HintsUsed: 0, // Added in Chapter 18.
            Message: "A hidden word has been chosen. Make your first guess.");
    }

    private static WordGuessModel ApplyGuess(
        WordGuessModel model,
        string text)
    {
        GuessResult result = EvaluateGuess(model, text);

        return result switch
        {
            InvalidGuess invalid =>
                model with
                {
                    Message = invalid.Message
                },

            AlreadyTried tried =>
                model with
                {
                    Message = $"You already tried {tried.Guess.ToUpperInvariant()}."
                },

            AcceptedGuess accepted =>
                AcceptGuess(model, accepted.Attempt),

            _ => model
        };
    }

    private static GuessResult EvaluateGuess(
        WordGuessModel model,
        string text)
    {
        if (model.State is not Playing)
        {
            return new InvalidGuess("Start a new game before making a guess.");
        }

        string guess = NormalizeGuess(text);

        if (string.IsNullOrWhiteSpace(guess))
        {
            return new InvalidGuess("Enter a word before guessing.");
        }

        if (guess.Length != model.Answer.Length)
        {
            return new InvalidGuess(
                $"Enter a {model.Answer.Length}-letter word.");
        }

        if (!guess.All(char.IsLetter))
        {
            return new InvalidGuess("Use letters only.");
        }

        if (model.Attempts.Any(attempt => attempt.Text == guess))
        {
            return new AlreadyTried(guess);
        }

        GuessAttempt attempt = new(
            Text: guess,
            Feedback: BuildFeedback(guess, model.Answer));

        return new AcceptedGuess(attempt);
    }

    private static WordGuessModel AcceptGuess(
        WordGuessModel model,
        GuessAttempt attempt)
    {
        if (model.State is not Playing playing)
        {
            return model;
        }

        List<GuessAttempt> attempts = [.. model.Attempts, attempt];
        int turnsTaken = playing.TurnsTaken + 1;

        if (attempt.IsCorrect)
        {
            return model with
            {
                State = new Won(turnsTaken),
                Attempts = attempts,
                Message = "Correct. You found the hidden word."
            };
        }

        if (attempts.Count >= model.MaxGuesses)
        {
            return model with
            {
                State = new Lost($"The hidden word was {model.Answer}."),
                Attempts = attempts,
                Message = "No attempts remaining."
            };
        }

        return model with
        {
            State = new Playing(turnsTaken),
            Attempts = attempts,
            Message = "Guess accepted. Use the feedback to try again."
        };
    }

    private static IReadOnlyList<LetterFeedback> BuildFeedback(
        string guess,
        string answer)
    {
        LetterFeedbackKind[] kinds =
            Enumerable.Repeat(LetterFeedbackKind.Absent, guess.Length).ToArray();

        bool[] answerUsed = new bool[answer.Length];

        for (int i = 0; i < guess.Length; i++)
        {
            if (guess[i] == answer[i])
            {
                kinds[i] = LetterFeedbackKind.Exact;
                answerUsed[i] = true;
            }
        }

        for (int i = 0; i < guess.Length; i++)
        {
            if (kinds[i] == LetterFeedbackKind.Exact)
            {
                continue;
            }

            for (int j = 0; j < answer.Length; j++)
            {
                if (!answerUsed[j] && guess[i] == answer[j])
                {
                    kinds[i] = LetterFeedbackKind.Misplaced;
                    answerUsed[j] = true;
                    break;
                }
            }
        }

        return guess
            .Select((letter, index) => new LetterFeedback(letter, kinds[index]))
            .ToList();
    }

    private static string NormalizeGuess(string text) =>
        text.Trim().ToLowerInvariant();
}
