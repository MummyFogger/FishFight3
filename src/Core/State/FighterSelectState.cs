using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FishFight3.Core.State
{
    public enum FighterSelectStateType
    {
        TransitionTo,
        FighterSelect,
        TransitionToStageSelect,
        StageSelect,
        TransitionFrom
    }

    public enum FighterSelectType
    {
        NetworkSingle,
        NetworkDouble,
        NetworkTripple,
        LocalDouble,
        LocalTripple,
        LocalQuadruple
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct FighterSelectState
    {
        public FighterSelectStateType StateType;
        public FighterSelectType SelectType;
        public int FrameCounter; // Used for animations and transitions
        public int P1CursorIndex;
        public int P2CursorIndex;
        public int P3CursorIndex;
        public int P4CursorIndex;
        public FighterSelectState()
        {
        }
    }
}
