using System.Runtime.CompilerServices;

namespace FishFight3.Core.State
{
    public class RollbackManager
    {
        public const int MAX_ROLLBACK_FRAMES = 120;
        private static readonly uint _stateSize = (uint)Unsafe.SizeOf<SimulationState>();
        private readonly SimulationState[] _history = new SimulationState[MAX_ROLLBACK_FRAMES];

        public unsafe void SaveState(int frameIndex, in SimulationState currentState)
        {
            fixed (SimulationState* dst = &_history[frameIndex % MAX_ROLLBACK_FRAMES])
            {
                fixed (SimulationState* src = &currentState)
                {
                    Unsafe.CopyBlock(dst, src, _stateSize);
                }
            }
        }

        public unsafe void LoadState(int frameIndex, ref SimulationState stateToLoad)
        {
            fixed (SimulationState* src = &_history[frameIndex % MAX_ROLLBACK_FRAMES])
            fixed (SimulationState* dst = &stateToLoad)
            {
                Unsafe.CopyBlock(dst, src, _stateSize);
            }
        }
    }
}
