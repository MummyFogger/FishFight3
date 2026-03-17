using FishFight3.Client.Infrastructure;
using FishFight3.Client.SFML;
using FishFight3.Core.Engine;
using FishFight3.Core.Input;
using FishFight3.Core.Physics;
using FishFight3.Core.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishFight3.Client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ConsoleLogger logger = new();
            ISimulation simulation = new LogConsoleSimulation(logger);
            IRenderer renderer = new SfmlRenderer(logger);
            ITimeProvider timeProvider = new SfmlTimeProvider();
            IGameWindow gameWindow = new SfmlGameWindow(1366, 768, "MyGame", logger);
            InputMapping p1Im = new(); // Default
            InputMapping p2Im = new()
            {
                Up = "Up",
                Down = "Down",
                Left = "Left",
                Right = "Right",
                Light = "Numpad1",
                Medium = "Numpad2",
                Heavy = "Numpad3",
                Special = "Numpad4",
                Dash = "Numpad5",
                Meter = "Numpad6",
                Break = "Numpad7",
                Taunt = "Numpad8"
            };
            IInputProvider p1Input = new SfmlInputProvider(p1Im, logger);
            IInputProvider p2Input = new SfmlInputProvider(p2Im, logger);
            var gameLoop = new GameLoop(simulation, renderer, timeProvider, gameWindow, p1Input, p2Input, logger);

            gameLoop.Run();
        }
    }
}
