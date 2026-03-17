using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FishFight3.Core.Engine;
using FishFight3.Core.Physics;
using FishFight3.Core.Rendering;

namespace FishFight3.Client.SFML
{
    internal class SfmlRenderer(ILogger logger) : IRenderer
    {
        private readonly ILogger _logger = logger;
        public void Draw(GameState state, float alpha)
        {
            // Implement renderer
        }
    }
}
