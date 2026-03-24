using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FishFight3.Core.State
{
    public enum MenuStateType
    {
        TransitionTo,
        Menu,
        TransitionFrom
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct MenuState
    {
        public MenuState()
        {
            StateType = MenuStateType.TransitionTo;
            P1CursorIndex = 0;
            P2CursorIndex = 0;
            P3CursorIndex = 0;
            P4CursorIndex = 0;
            FrameCounter = 0;
            KeyboardActive = true;
        }

        public MenuStateType StateType;
        public int P1CursorIndex;
        public int P2CursorIndex;
        public int P3CursorIndex;
        public int P4CursorIndex;
        public int FrameCounter; // Used for animations and transitions
        public bool KeyboardActive;
    }
}
