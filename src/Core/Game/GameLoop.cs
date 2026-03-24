using FishFight3.Core.Input;
using FishFight3.Core.Simulation;
using FishFight3.Core.State;
using Microsoft.Extensions.Logging;
using FishFight3.Core.Game.GameScreen;

namespace FishFight3.Core.Game
{
    public class GameLoop
    {
        private readonly IScreenFactory _screenFactory;
        private readonly ITimeProvider _time;
        private readonly IGameWindow _gameWindow;
        private readonly List<IInputProvider> _inputs;
        private readonly ILogger<GameLoop> _logger;
        private IGameScreen _gameScreen; // TODO reimplement this as a stack

        public GameLoop(
            IScreenFactory screenFactory,
            ITimeProvider time,
            IGameWindow gameWindow,
            IEnumerable<IInputProvider> inputs,
            ILogger<GameLoop> logger)
        {
            _screenFactory = screenFactory;
            _time = time;
            _gameWindow = gameWindow;
            _inputs = [.. inputs];
            _logger = logger;

            foreach (var input in _inputs)
            {
                input.SetMappingMode(MappingMode.Menu);
            }

            _gameScreen = screenFactory.CreateScreen(GameScreenType.Splash, this);
        }

        public void RequestScreenChange(GameScreenType newScreenType, IGameScreenArgs? args = null)
        {
            _logger.LogDebug("Requesting screen change to {newScreenType}", newScreenType);
            _gameScreen = _screenFactory.CreateScreen(newScreenType, this, args);
            if (newScreenType == GameScreenType.Simulation)
            {
                foreach (var input in _inputs)
                {
                    input.SetMappingMode(MappingMode.Simulation);
                }
            }
            else
            {
                foreach (var input in _inputs)
                {
                    input.SetMappingMode(MappingMode.Menu);
                }
            }
        }

        public void Run()
        {
            _logger.LogDebug("Starting game loop!");
            double accumulator = 0.0;
            const double frameSpeed = 1.0 / 60.0;
            _time.Start();

            while (_gameWindow.IsOpen)
            {
                double elapsed = _time.GetElapsedMilliseconds();
                if (elapsed > 0.25) elapsed = 0.25;
                accumulator += elapsed;

                _gameWindow.DispatchEvents();

                while (accumulator >= frameSpeed)
                {
                    InputState[] inputStates = [.. _inputs.Select(i => i.GetInput())];
                    _gameScreen.Update(inputStates);
                    accumulator -= frameSpeed;
                }

                _gameWindow.Clear();
                _gameScreen.Render(_gameWindow, accumulator); // TODO fix the double passed to be the correct value
                _gameWindow.Display();
            }
        }
    }
}
