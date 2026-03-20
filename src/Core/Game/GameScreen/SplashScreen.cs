using FishFight3.Core.Rendering;
using FishFight3.Core.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishFight3.Core.Game.GameScreen
{
    public class SplashScreen : IGameScreen
    {
        private readonly IMenuRenderer _menuRenderer;
        private MenuState _menuState;

        public SplashScreen(IMenuRenderer menuRenderer)
        {
            _menuRenderer = menuRenderer;
            _menuState = new MenuState(MenuType.SplashScreen);
        }

        public void Render(IGameWindow gameWindow)
        {
            _menuRenderer.Draw(gameWindow, _menuState);
        }

        public void Update(ReadOnlySpan<InputState> inputs)
        {
            switch (_menuState.MenuType)
            {
                case MenuType.SplashScreen:
                    switch (_menuState.StateType)
                    {
                        case MenuStateType.TransitionTo:
                            // We could add some transition effects here if desired
                            _menuState.StateType = MenuStateType.Menu;
                            break;
                        case MenuStateType.Menu:
                            // Wait for the frame counter to reach a certain threshold before transitioning to the main menu
                            if (_menuState.FrameCounter > 120) // Stay on the splash screen for 2 seconds (assuming 60 FPS)
                            {
                                _menuState.StateType = MenuStateType.TransitionFrom;
                                _menuState.FrameCounter = 0; // Reset frame counter for transition
                            }
                            else
                            {
                                _menuState.FrameCounter++;
                            }
                            break;
                    }
                    break;
            }
        }
    }
}
