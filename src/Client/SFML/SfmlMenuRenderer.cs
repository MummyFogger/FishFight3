using FishFight3.Core.Game;
using FishFight3.Core.Simulation;
using FishFight3.Core.Rendering;
using FishFight3.Core.State;
using Microsoft.Extensions.Logging;

namespace FishFight3.Client.SFML
{
    internal class SfmlMenuRenderer(ILogger<SfmlMenuRenderer> logger) : IMenuRenderer
    {
        private readonly ILogger<SfmlMenuRenderer> _logger = logger;
        public void Draw(IGameWindow gameWindow, double alpha, MenuState menuState)
        {
            // TODO Implement renderer
        }
    }
}
