using System.Runtime.InteropServices;

namespace FishFight3.Core.State
{
    public enum SimulationStateType
    {
        RoundStart,
        RoundOver,
        Playing,
        Paused,
        Ended
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SimulationState
    {
        public SimulationStateType StateType = SimulationStateType.RoundStart;
        public uint Frame = 0;
        public FighterState P1State;
        public FighterState P2State;
        public FighterState P3State;
        public FighterState P4State;

        public SimulationState()
        {
        }
    }
}
