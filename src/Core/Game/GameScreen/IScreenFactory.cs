using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishFight3.Core.Game.GameScreen
{
    public enum GameScreenType
    {
        MainMenu,
        Options,
        Splash,
        Start,
        Loading,
        FighterSelect_Local,
        FighterSelect_Online,
        StageSelect_Local,
        StageSelect_Online,
        SyncClock,
        Simulation
    }
    public interface IScreenFactory
    {
        public IGameScreen CreateScreen(GameScreenType screenType, GameLoop gameLoop, IGameScreenArgs? args = null);
    }
}
