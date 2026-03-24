using FishFight3.Core.State;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishFight3.Core.Simulation
{
    public class StandardTwoPlayer : ISimulation
    {
        private readonly ILogger<StandardTwoPlayer> _logger;
        private SimulationState _simulationState;
        private EffectState _effectState;

        public StandardTwoPlayer(ILogger<StandardTwoPlayer> logger)
        {
            _logger = logger;
            _simulationState = new SimulationState();
            _effectState = new EffectState();
        }

        public EffectState GetEffectState() => _effectState;
        public SimulationState GetState() => _simulationState;

        public void Update(ReadOnlySpan<InputState> inputStates)
        {
            uint currentFrame = _simulationState.Frame;
            for (int i = 0; i < inputStates.Length; i++)
            {
                var inputState = inputStates[i];
                switch (i)
                {
                    case 0:
                        _simulationState.P1State.AddInput(inputState, currentFrame);
                        break;
                    case 1:
                        _simulationState.P2State.AddInput(inputState, currentFrame);
                        break;
                    default:
                        // TODO : Handle more than 2 players if needed
                        break;
                }
            }
            _simulationState.Frame++;
        }
    }
}
