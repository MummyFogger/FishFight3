using FishFight3.Core.Input;
using Microsoft.Extensions.Logging;

namespace FishFight3.Core.Physics
{
    public class LogConsoleSimulation(ILogger<LogConsoleSimulation> logger) : ISimulation
    {
        private readonly ILogger<LogConsoleSimulation> _logger = logger;
        public GameState GetState()
        {
            return new GameState();
        }

        public GameState Update(PlayerInput p1Input, PlayerInput p2Input)
        {
            _logger.LogInformation("Buttons1: " + p1Input.Buttons.ToString());
            _logger.LogInformation("Buttons2: " + p2Input.Buttons.ToString());

            return new GameState();
        }
    }
}
