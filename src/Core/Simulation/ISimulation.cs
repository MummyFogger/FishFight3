using FishFight3.Core.State;

namespace FishFight3.Core.Physics
{
    public interface ISimulation
    {
        public SimulationState Update(ReadOnlySpan<InputState> inputStates);
        public SimulationState GetState();
    }
}
