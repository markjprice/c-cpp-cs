# Intelligence versus wisdom

It’s easy to confuse intelligence with wisdom, especially when working with AI tools.

AI systems like GitHub Copilot or ChatGPT are clearly intelligent. They can generate code, explain concepts, and solve problems at a speed that would have seemed absurd a few years ago. In many narrow tasks, they outperform most humans. But intelligence is not the same thing as wisdom.

Intelligence is the ability to produce answers. Wisdom is the ability to decide which answers matter, which ones to trust, and what should be done in the first place. AI has plenty of the first. It has none of the second.

## What AI is actually good at

Modern AI systems are extremely effective at:
- Generating code from a description
- Suggesting multiple approaches to a problem
- Translating between languages and frameworks
- Filling in gaps quickly when you already understand the direction

AI is good at execution. If you point it at a well-defined task, it will often give you something useful in seconds. But that usefulness depends entirely on the quality of the direction it receives.

## Where AI falls short

AI does not:
- Understand your system in a deep, lived way
- Know your users or their real-world constraints
- Recognize subtle trade-offs between competing goals
- Take responsibility for outcomes

It can sound confident while being wrong. It can generate working code that solves the wrong problem. It can optimize something that should never have been built. That’s not a flaw in the technology. It’s a category error to expect wisdom from a system that doesn’t have judgment.

## The human role is changing

When AI tools are involved, the limiting factor is no longer how fast you can type or how many APIs you’ve memorized. The limiting factor is how well you can think. A developer who relies purely on AI’s intelligence will produce:
- bloated solutions
- unnecessary features
- fragile systems that “mostly work”

A developer who brings wisdom to the process will:
- question whether the feature is needed at all
- choose the simplest viable approach
- spot when the AI is heading in the wrong direction
- refine outputs instead of accepting them blindly

This is not a subtle difference. It shows up very quickly in the quality of the final system.

## A practical way to think about it

When working with AI, separate your thinking into two layers:
1.	Intelligence layer (AI-driven)
  - “How do I implement this?”
  - “What are some options?”
  - “Write the code for X”
2.	Wisdom layer (human-driven)
  - “Should this exist?”
  - “Is this the right approach?”
  - “What are the trade-offs?”
  - “What happens in production?”

Most beginners push everything into the first layer. They treat AI as a faster keyboard. That’s a mistake. The better results come from improving the second layer.

## The cost of skipping wisdom

As AI becomes metered and usage-based, this distinction becomes even more concrete. Every prompt costs something. Every generated solution has downstream consequences. If you skip the thinking and rely entirely on AI:
- you generate more code than necessary
- you iterate blindly
- you increase both cost and complexity

If you apply judgment first:
- you ask fewer, better questions
- you get more useful answers
- you build simpler systems

Judgment reduces both technical debt and financial cost.

## Intelligence is not enough

In his work on tuberculosis, author and educator John Green makes a useful distinction between intelligence and wisdom. Tuberculosis is not an unsolved mystery. We know what causes it, we know how it spreads, and we have treatments that can cure it. Yet it still kills huge numbers of people around the world. Green’s point is that the continuing tragedy of tuberculosis is not mainly a failure of intelligence. It is a failure of wisdom, justice, organization, and care. Humanity has enough knowledge to reduce suffering, but knowledge alone does not guarantee that we will use it well.

An AI coding assistant can be impressively intelligent. It can generate code, explain error messages, suggest designs, and summarize documentation. But it does not automatically know what matters most for your project, your users, your future maintenance work, or your ethical responsibilities.

You can read a longer article about this idea in the book’s GitHub repository: Intelligence Is Not Wisdom: What John Green’s Tuberculosis Argument Can Teach Us About AI: https://github.com/markjprice/markjprice/blob/main/with-ai/tuberculosis.md
