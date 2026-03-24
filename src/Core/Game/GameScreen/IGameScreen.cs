using FishFight3.Core.State;
using FishFight3.Core.Simulation;

namespace FishFight3.Core.Game.GameScreen
{
    public interface IGameScreenArgs { }
    public record SimulationArgs(SimulationType SimulationType, int[] ActiveProviders) : IGameScreenArgs;

    public interface IGameScreen
    {
        public void Update(ReadOnlySpan<InputState> inputs);
        public void Render(IGameWindow window, double dt);
        public void Dispose();
    }
}
