using FishFight3.Core.Rendering;
using FishFight3.Core.Simulation;
using FishFight3.Core.State;
using Microsoft.Extensions.Logging;

namespace FishFight3.Core.Game.GameScreen
{
    public class SimulationScreen : IGameScreen
    {
        private readonly ILogger _logger;
        private readonly GameLoop _gameLoop;
        private readonly ISimulationRenderer _simulationRenderer;
        private readonly ISimulation _simulation;
        private readonly int[] _activeProviders;
        private SimulationState _simulationState;
        private EffectState _effectState;

        public SimulationScreen(ISimulationFactory simFactory, ISimulationRenderer simulationRenderer, ILogger<SimulationScreen> logger, GameLoop gameLoop, SimulationArgs args)
        {
            _simulationRenderer = simulationRenderer;
            _logger = logger;
            _simulationState = new();
            _effectState = new();
            _activeProviders = [];
            _gameLoop = gameLoop;

            _simulation = simFactory.Create(args.SimulationType);
            _activeProviders = args.ActiveProviders;
            // TODO other simulation args here like fighter selection
        }

        public void Render(IGameWindow window, double dt)
        {
            _simulationRenderer.Draw(window, dt, _simulationState, _effectState);
        }

        public void Update(ReadOnlySpan<InputState> inputs)
        {
            // Get active inputs
            InputState[] activeInputs = new InputState[_activeProviders.Length];
            for (int i=0; i < _activeProviders.Length; i++)
            {
                activeInputs[i] = inputs[_activeProviders[i]];
            }

            _simulation.Update(activeInputs);
            _simulationState = _simulation.GetState();
            _effectState = _simulation.GetEffectState();

            if (_simulationState.StateType == SimulationStateType.Ended)
            {
                _logger.LogInformation("Simulation ended. Returning to main menu.");
                _gameLoop?.RequestScreenChange(GameScreenType.Splash);
            }
        }

        public void Dispose() { }
    }
}
