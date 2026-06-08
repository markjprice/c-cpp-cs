using GameEngine.Graphics;
using EngineLogger = GameEngine.Logging.Logger;
using DiagnosticLogger = Company.Diagnostics.Logger;
using IO = System.IO;

Sprite player = new("Player");
player.Draw();

EngineLogger engineLogger = new();
engineLogger.Write("Sprite created.");

DiagnosticLogger diagnosticLogger = new();
diagnosticLogger.Write("Namespace alias resolved the Logger name collision.");

string current = IO.Directory.GetCurrentDirectory();
Console.WriteLine($"Current directory: {current}");

Type type = typeof(string);
Console.WriteLine($"Reflection example: {type.FullName}");

// The following type is internal to the GameEngine.Core assembly, so this app cannot use it:
// var loader = new GameEngine.Core.Internal.ConfigurationLoader();
