using FishFight3.Core.State;

namespace FishFight3.Core.Input
{
    public enum MappingMode
    {
        Simulation,
        Menu,
        None
    }

    public interface IInputProvider
    {
        public InputState GetInput();
        public void SetMappingMode(MappingMode mode);
    }
}
