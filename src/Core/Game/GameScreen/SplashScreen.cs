using FishFight3.Core.Rendering;
using FishFight3.Core.State;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishFight3.Core.Game.GameScreen
{
    public class SplashScreen : IGameScreen
    {
        private readonly ILogger _logger;
        private readonly GameLoop _gameLoop;
        private readonly IMenuRenderer _menuRenderer;
        private MenuState _menuState;

        public SplashScreen(IMenuRenderer menuRenderer, ILogger logger, GameLoop gameLoop)
        {
            _logger = logger;
            _gameLoop = gameLoop;
            _menuRenderer = menuRenderer;
            _menuState = new();
        }

        public void Render(IGameWindow gameWindow, double alpha)
        {
            _menuRenderer.Draw(gameWindow, alpha, _menuState);
        }

        public void Update(ReadOnlySpan<InputState> inputs)
        {
            switch (_menuState.StateType)
            {
                case MenuStateType.TransitionTo:
                    if (_menuState.FrameCounter > 30) //  0.5 seconds (assuming 60 FPS)
                    {
                        _menuState.FrameCounter = 0;
                        _menuState.StateType = MenuStateType.Menu;
                    }
                    else
                        _menuState.FrameCounter++;
                    break;
                case MenuStateType.Menu:
                    if (_menuState.FrameCounter > 60) // 1 seconds (assuming 60 FPS)
                    {
                        _menuState.FrameCounter = 0;
                        _menuState.StateType = MenuStateType.TransitionFrom;
                    }
                    else
                        _menuState.FrameCounter++;
                    break;
                case MenuStateType.TransitionFrom:
                    if (_menuState.FrameCounter > 30) // 0.5 seconds (assuming 60 FPS)
                    {
                        _menuState.FrameCounter = 0;
                        _gameLoop.RequestScreenChange(GameScreenType.Simulation); // TODO change to start screen
                    }
                    else
                        _menuState.FrameCounter++;
                    break;
            }
        }

        public void Dispose() { }
    }
}
