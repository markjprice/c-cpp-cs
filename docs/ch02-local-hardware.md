# Choosing a local model for your hardware

A local model is an AI model that runs on your own computer instead of on a cloud service. The advantage is privacy, offline use, predictable cost, and the freedom to experiment. The disadvantage is that your hardware matters a lot. A model that sounds small because it has 12 billion parameters can still need more than 16 GB of memory once you include precision, quantization, the runtime, and the context window.

The first rule when choosing a local model is simple: do not judge a local model only by its parameter count. You must also check its quantization level, context length, architecture, and whether you want to use it as a chat assistant, a coding helper, or a coding agent that reads lots of files and repeatedly calls tools.

Google’s Gemma 4 family is a useful current example. Google lists Gemma 4 in E2B, E4B, 12B, 26B A4B, and 31B sizes, and says the smaller models support a 128K context window while the medium models support 256K. Google’s own memory table estimates Gemma 4 12B at about 26.7 GB in BF16, 13.4 GB in SFP8, and 6.7 GB in Q4_0 before adding context-window memory and supporting software overhead. That means Gemma 4 12B can be realistic on a 16 GB VRAM GPU in 4-bit form, but not in full 16-bit precision.

> Gemma 4 model overview: https://ai.google.dev/gemma/docs/core. 

> Gemma 4 model card: https://ai.google.dev/gemma/docs/core/model_card_4

## Practical model choices by hardware

The following guidance assumes one user, one model, and a local tool such as Ollama, LM Studio, llama.cpp, MLX, vLLM, or SGLang.

### 16 GB system RAM, no dedicated GPU

- Practical model size: 3B to 7B
- Example local models: Gemma 4 E2B/E4B Q4, Mistral/Ministral 3B/8B-class models
- Suggested quantization: Q4
- Practical context for chat: 4K to 16K
- Practical context for coding agents: 4K to 8K
  
Summary: Usable for learning, summaries, and simple code snippets. A coding agent will feel slow because the CPU must do most of the work.

### Laptop GPU with 8 GB VRAM

- Practical model size: 4B to 8B
- Example local models: Llama 3.1 8B Q4, Ministral 8B-class, Gemma E4B Q4
- Suggested quantization: Q4 or Q5
- Practical context for chat: 8K to 32K
- Practical context for coding agents: 8K to 16K

Summary: Good entry point for local coding assistance. Do not expect whole-repository context.

### GPU with 16 GB VRAM

- Practical model size: 8B to 14B comfortably, some 20B-class with care
- Example local models: Gemma 4 12B Q4, Phi-4 Q4, Qwen 14B-class, Mistral/Ministral 14B-class
- Suggested quantization: Q4 or Q5
- Practical context for chat: 32K to 128K
- Practical context for coding agents: 32K to 64K

Summary: Strong practical tier. Good for code explanation, refactoring suggestions, and moderate agent workflows.

### 32 GB VRAM workstation GPU

- Practical model size: 30B to 40B Q4, or 14B to 30B at higher precision
- Example local models: Qwen3.6-35B-A3B, Gemma 4 31B, large Mistral-class models
- Suggested quantization: Q4, Q5, Q8 for smaller models
- Practical context for chat: 128K to 256K
- Practical context for coding agents: 128K+

Summary: Strong local workstation setup. Better for coding agents, retrieval, and tool use, but still not equivalent to frontier cloud models.

### 64 GB to 96 GB unified memory Mac

- Practical model size: 8B to 32B, sometimes larger with quantization
- Example local models: Gemma 4 12B/31B Q4, Qwen3-Coder-30B-A3B Q4, Llama 3.1 8B/70B with compromises
- Suggested quantization: Q4 or Q5 via MLX/llama.cpp
- Practical context for chat: 32K to 128K
- Practical context for coding agents: 32K to 64K

Summary: Very useful because unified memory is flexible, but GPU VRAM and unified memory are not identical. Leave memory for macOS and apps.

### 128 GB to 256 GB unified memory Mac or AI workstation

- Practical model size: 70B Q4 and some larger MoE models
- Example local models: Llama 3.1 70B, large Qwen/Mistral MoE models, Gemma 4 31B at better precision
- Suggested quantization: Q4, Q5, Q8 depending on model
- Practical context for chat: 128K+ 
- Practical context for coding agents: 128K+

Summary: Best single-machine local tier for writers and developers who want private, long-context workflows. Speed still depends heavily on memory bandwidth and framework support.

The preceding guidance is deliberately conservative. Many users can squeeze larger models into smaller systems, especially with CPU offload, smaller context windows, or more aggressive quantization. But just getting a model to run is not the same as making it pleasant to use while learning or coding.

## Setting expectations for the local versus cloud

Local models are great for routine refactors, test scaffolding, and “explain this codebase” tasks. They may be weaker at deep reasoning than the top cloud models. 

**Bring Your Own Key (BYOK)** model support is a fast-moving feature set, and some capabilities may differ between chat, inline chat, and completions.
If you want the easiest start, use Copilot Free (cloud). You get a monthly allowance without configuring any keys.

If you want best quality and do not mind API spend, keep Copilot models for day-to-day coding and optionally add your OpenAI API key so you can use specific provider models when needed.

If you want to avoid per-request costs and keep data local, run Ollama and select it via VS Code’s model management so Copilot Chat can use a local model for many tasks.
