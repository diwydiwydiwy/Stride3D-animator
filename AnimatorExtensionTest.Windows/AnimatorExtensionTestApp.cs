using Stride.Engine;
using AvaloniaApplicationForStride;

using var game = new Game();

AvaloniaProgram.BuildAvaloniaApp().SetupWithoutStarting();
new MainWindow().Show();
game.Run();

