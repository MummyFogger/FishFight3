using FishFight3.Core.Engine;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FishFight3.Client.SFML
{
    internal class SfmlClientWindow : IGameWindow
    {
        private readonly ILogger<SfmlClientWindow> _logger;
        private readonly RenderWindow _window;

        public SfmlClientWindow(IOptions<GameSettings> settings, ILogger<SfmlClientWindow> logger)
        {
            int width = settings.Value.WindowWidth;
            int height = settings.Value.WindowHeight;
            string title = settings.Value.WindowTitle;
            Vector2u windowSize = new(Convert.ToUInt32(width), Convert.ToUInt32(height));
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
