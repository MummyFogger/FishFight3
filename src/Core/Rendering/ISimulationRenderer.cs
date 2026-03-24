using FishFight3.Core.Game;
using FishFight3.Core.State;

namespace FishFight3.Core.Rendering
{
    public interface ISimulationRenderer
    {
        public void Draw(IGameWindow gameWindow, double alpha, SimulationState simState, EffectState effectState);
    }
}
