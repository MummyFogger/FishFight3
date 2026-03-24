using FishFight3.Core.State;

namespace FishFight3.Core.Simulation
{
    public interface ISimulation
    {
        public void Update(ReadOnlySpan<InputState> inputStates);
        public SimulationState GetState();
        public EffectState GetEffectState();
    }
}
