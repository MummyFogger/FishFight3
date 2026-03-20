using FishFight3.Core.Engine;
using FishFight3.Core.Physics;
using FishFight3.Core.Rendering;
using Microsoft.Extensions.Logging;

namespace FishFight3.Client.SFML
{
    internal class SfmlRenderer(ILogger<SfmlRenderer> logger) : IRenderer
    {
        private readonly ILogger<SfmlRenderer> _logger = logger;
        public void Draw(GameState state, float alpha)
        {
            // Implement renderer
        }
    }
}
