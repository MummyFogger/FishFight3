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

    public enum MenuType
    {
        MainMenu,
        Options,
        SplashScreen,
        StartScreen,
        LoadingScreen
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct MenuState
    {
        public MenuState(MenuType menu)
        {
            MenuType = menu;
            StateType = MenuStateType.TransitionTo;
            CursorIndex = 0;
            FrameCounter = 0;
            KeyboardActive = true;
        }

        public readonly MenuType MenuType;
        public MenuStateType StateType;
        public int CursorIndex;
        public int FrameCounter; // Used for animations and transitions
        public bool KeyboardActive;
        public MenuState()
        {
        }
    }
}
