using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishFight3.Core.Game.GameScreen
{
    public class ScreenFactory : IScreenFactory
    {
        private readonly IServiceProvider _serviceProvider;
        public ScreenFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IGameScreen CreateScreen(GameScreenType screenType, GameLoop gameLoop, IGameScreenArgs? args = null)
        {
            switch(screenType)
            {
                //GameScreenType.MainMenu => _serviceProvider.GetRequiredService<MainMenuScreen>(),
                //GameScreenType.Options => _serviceProvider.GetRequiredService<OptionsScreen>(),
                case GameScreenType.Splash:
                    return ActivatorUtilities.CreateInstance<SplashScreen>(_serviceProvider, gameLoop);
                //GameScreenType.Start => _serviceProvider.GetRequiredService<StartScreen>(),
                //GameScreenType.Loading => _serviceProvider.GetRequiredService<LoadingScreen>(),
                //GameScreenType.FighterSelect_Local => _serviceProvider.GetRequiredService<FighterSelectLocalScreen>(),
                //GameScreenType.FighterSelect_Online => _serviceProvider.GetRequiredService<FighterSelectOnlineScreen>(),
                //GameScreenType.StageSelect_Local => _serviceProvider.GetRequiredService<StageSelectLocalScreen>(),
                //GameScreenType.StageSelect_Online => _serviceProvider.GetRequiredService<StageSelectOnlineScreen>(),
                //GameScreenType.SyncClock => _serviceProvider.GetRequiredService<SyncClockScreen>(),
                case GameScreenType.Simulation:
                    if (args is not SimulationArgs)
                        throw new ArgumentException($"Expected args of type {typeof(SimulationArgs)}, but got {args?.GetType()}");
                    return ActivatorUtilities.CreateInstance<SimulationScreen>(_serviceProvider, gameLoop, (SimulationArgs)args);
                default:
                    throw new ArgumentException($"Unsupported screen type: {screenType}");
            };
        }
    }
}
