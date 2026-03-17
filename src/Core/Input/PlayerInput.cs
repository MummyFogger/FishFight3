using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishFight3.Core.Input
{
    [Flags]
    public enum ButtonBitmask : ushort
    {
        None = 0,
        Light = 1 << 0,
        Medium = 1 << 1,
        Heavy = 1 << 2,
        Special = 1 << 3,
        Dash = 1 << 4,
        Meter = 1 << 5,
        Break = 1 << 6,
        Taunt = 1 << 7,
        Button8 = 1 << 8,
        Button9 = 1 << 9,
        Button10 = 1 << 10,
        Button11 = 1 << 11,
        Button12 = 1 << 12,
        Button13 = 1 << 13,
        Button14 = 1 << 14,
        Button15 = 1 << 15
    }

    public enum Direction : byte
    {
        DownBack = 1,
        Down = 2,
        DownForward = 3,
        Back = 4,
        Neutral = 5,
        Forward = 6,
        UpBack = 7,
        Up = 8,
        UpForward = 9
    }

    public struct PlayerInput
    {
        public ButtonBitmask Buttons;
        public Direction Direction; // not a bitmask, but a single value from 1-9
        public readonly bool IsButtonPressed(ButtonBitmask b) => (Buttons & b) != 0;
    }
}
