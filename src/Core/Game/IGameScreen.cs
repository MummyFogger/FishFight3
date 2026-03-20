using FishFight3.Core.State;

namespace FishFight3.Core.Game
{
    public interface IGameScreen
    {
        void Update(ReadOnlySpan<InputState> inputs);
        void Render(IGameWindow window);
    }
}
