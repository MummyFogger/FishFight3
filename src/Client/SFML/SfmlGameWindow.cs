using FishFight3.Core.Engine;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishFight3.Client.SFML
{
    internal class SfmlGameWindow : IGameWindow
    {
        private readonly ILogger _logger;
        private readonly RenderWindow _window;

        public SfmlGameWindow(uint width, uint height, string title, ILogger logger)
        {
            Vector2u windowSize = new Vector2u(width, height);
            _window = new RenderWindow(new VideoMode(windowSize), title);
            _window.SetVerticalSyncEnabled(true);
            _logger = logger;
        }

        public bool IsOpen => _window.IsOpen;

        public void DispatchEvents() => _window.DispatchEvents();

        public void Clear() => _window.Clear(Color.Black);

        public void Display() => _window.Display();

        public void Close() => _window.Close();

        // Helper for the Renderer to get the underlying SFML window
        public RenderWindow GetInternalWindow() => _window;
    }
}
