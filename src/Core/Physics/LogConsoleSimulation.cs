using FishFight3.Core.Engine;
using FishFight3.Core.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishFight3.Core.Physics
{
    public class LogConsoleSimulation(ILogger logger) : ISimulation
    {
        private readonly ILogger _logger = logger;
        public GameState GetState()
        {
            return new GameState();
        }

        public GameState Update(PlayerInput p1Input, PlayerInput p2Input)
        {
            _logger.Write(p1Input, p2Input);

            return new GameState();
        }
    }
}
