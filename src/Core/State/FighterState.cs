using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FishFight3.Core.State
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct FighterState
    {
        public const int INPUT_BUFFER_SIZE = 10; // Last 10 frames of input

        public FighterState()
        {
        }
        
        public readonly InputState[] InputBuffer = new InputState[INPUT_BUFFER_SIZE];
        public FixedPointLong PositionX { get; set; } = FixedPointLong.Zero;
        public FixedPointLong PositionY { get; set; } = FixedPointLong.Zero;
        public FixedPointLong VelocityX { get; set; } = FixedPointLong.Zero;
        public FixedPointLong VelocityY { get; set; } = FixedPointLong.Zero;
        public required uint FighterId { get; init; } // Set to 0 means disabled
        public required uint Health { get; set; }
        public required uint Meter { get; set; }
        public uint MoveId { get; set; } = 0; // MoveID 0 is reserved for Idle
        public uint StageIndex { get; set; } = 0;
        public uint StageFrame { get; set; } = 0;
        public uint StunDuration { get; set; } = 0;

        public readonly void AddInput(InputState input, uint currentFrame)
        {
            int index = (int)(currentFrame % INPUT_BUFFER_SIZE);
            InputBuffer[index] = input;
        }

        public readonly InputState? GetInput(uint frame) => InputBuffer[frame % INPUT_BUFFER_SIZE];
    }
}
