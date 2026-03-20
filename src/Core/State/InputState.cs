using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FishFight3.Core.State
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
        Up = 1 << 8,
        Left = 1 << 9,
        Down = 1 << 10,
        Right = 1 << 11,
        Start = 1 << 12,
        Select = 1 << 13,
        Button14 = 1 << 14,
        Button15 = 1 << 15
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct InputState
    {
        public ButtonBitmask PressedButtons;
        public ButtonBitmask ReleasedButtons;
        public void SetAction(string action, bool pressed)
        {
            if (Enum.TryParse<ButtonBitmask>(action, out var button))
            {
                if (pressed)
                {
                    PressedButtons |= button; // Set the pressed bit
                }
                else
                {
                    ReleasedButtons |= button; // Set the released bit
                }
            }
        }

        public void Clear()
        {
            PressedButtons = ButtonBitmask.None;
            ReleasedButtons = ButtonBitmask.None;
        }
    }
}
