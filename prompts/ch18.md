**Prompts for *Chapter 18 AI-Assisted Variations, Testing, and Review***

- [Using AI to generate safe game variations](#using-ai-to-generate-safe-game-variations)
- [Testing game logic separately from the UI](#testing-game-logic-separately-from-the-ui)


# Using AI to generate safe game variations

```text
Please explain why Puzzle Arcade is a good project for practicing safe AI-assisted development. Focus on shared components, game-specific rule classes, models, and clear boundaries. Include an explanation of the difference between using AI as a variation partner and using AI as an automatic programmer.
```

```text
Give me a checklist for turning a vague AI coding request into a focused prompt with target files, constraints, and review steps.
```

```text
Please explain why a developer should ask an AI assistant for variation ideas before asking it for code. Then suggest ten small variations for Word Guess that preserve the existing WordGuessModel, WordGuessRules, GameState, PuzzleAction, GameStatusBar, and GameCommandBar design.
```

```text
Please explain why generated word lists, board layouts, and test cases are often safer AI tasks than asking AI to rewrite a rule class.
```

# Testing game logic separately from the UI

```text
Please explain why code that is buried inside .razor event handlers is harder to test than ordinary C# rule methods.
```

```text
Please explain why unit tests should create known models instead of depending on random answers chosen by StartGame. Then explain the “Given this model, when this action happens, then the returned model should have these values” testing style.
```

```text
Please explain why testing GridBoard directly is better than trying to test its behavior through the Blazor page.
```

```text
Please explain the difference between manual browser testing and unit testing. Use Puzzle Arcade as the example.
```
