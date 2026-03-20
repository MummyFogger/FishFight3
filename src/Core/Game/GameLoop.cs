using FishFight3.Core.Rendering;
using FishFight3.Core.Input;
using FishFight3.Core.Physics;
using FishFight3.Core.State;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace FishFight3.Core.Game
{
    public class GameLoop
    {
        private readonly ITimeProvider _time;
        private readonly IGameWindow _gameWindow;
        private readonly IEnumerable<IInputProvider> _inputs;
        private readonly ILogger<GameLoop> _logger;
        private readonly 
        private IGameScreen _gameScreen;

        public GameLoop(
            ITimeProvider time,
            IGameWindow gameWindow,
            IEnumerable<IInputProvider> inputs,
            ILogger<GameLoop> logger)
        {
            _time = time;
            _gameWindow = gameWindow;
            _inputs = inputs;
            _logger = logger;

            foreach (var input in _inputs)
            {
                input.SetMappingMode(MappingMode.Menu);
            }

            _gameScreen = new SplashScreen();
        }

        public void Run()
        {
            _logger.LogDebug("Starting game loop!");
            double accumulator = 0.0;
            const double dt = 1.0 / 60.0;
            _time.Start();

            while (_gameWindow.IsOpen)
            {
                double elapsed = _time.GetElapsedMilliseconds();
                if (elapsed > 0.25) elapsed = 0.25;
                accumulator += elapsed;

                _gameWindow.DispatchEvents();

                while (accumulator >= dt)
                {
                    InputState[] inputStates = [.. _inputs.Select(i => i.GetInput())];
                    _gameScreen.Update(inputStates);
                    accumulator -= dt;
                }

                _gameWindow.Clear();
                _gameScreen.Render(_gameWindow);
                _gameWindow.Display();
            }
        }
    }
}
