using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FishFight3.Core.State
{
    public enum FighterStateType : byte
    {
        Idle,
        Walking,
        Jumping,
        Falling,
        Crouching,
        Attacking,
        Blocking,
        Hitstun,
        Knockdown,
        Teching
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct FighterState
    {
        public const int INPUT_BUFFER_SIZE = 10; // Last 10 frames of input

        public FighterState()
        {
        }

        public FighterStateType StateType;
        public readonly InputState[] InputBuffer = new InputState[INPUT_BUFFER_SIZE];
        public FixedPointLong PositionX = FixedPointLong.Zero;
        public FixedPointLong PositionY = FixedPointLong.Zero;
        public FixedPointLong VelocityX = FixedPointLong.Zero;
        public FixedPointLong VelocityY = FixedPointLong.Zero;
        public int Health;
    }
}
