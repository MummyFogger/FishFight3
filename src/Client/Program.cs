using FishFight3.Client.SFML;
using FishFight3.Core.Game;
using FishFight3.Core.Input;
using FishFight3.Core.Simulation;
using FishFight3.Core.Rendering;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Xml;
using FishFight3.Core.Game.GameScreen;

namespace FishFight3.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);

            // Options
            builder.Services.Configure<InputSettings>("keyboard",
                builder.Configuration.GetSection("Input:Keyboard"));
            builder.Services.PostConfigure<InputSettings>("Keyboard",
                options => options.Sanitize(DefaultInputMappings.KeyboardGameplay));

            builder.Services.Configure<GameSettings>(builder.Configuration.GetSection("GameSettings"));

            // Register services
            builder.Services.AddSingleton<SfmlClientWindow>();
            builder.Services.AddSingleton<IGameWindow>(sp => sp.GetRequiredService<SfmlClientWindow>());
            builder.Services.AddSingleton<IMenuRenderer, SfmlMenuRenderer>();
            builder.Services.AddSingleton<ISimulationRenderer, SfmlSimulationRenderer>();
            builder.Services.AddSingleton<IInputProvider, SfmlKeyboardInputProvider>();
            //builder.Services.AddSingleton<VisualEffectQueue>();

            // Register transient
            builder.Services.AddTransient<ITimeProvider, SfmlTimeProvider>();
            builder.Services.AddTransient<StandardTwoPlayer>();
            builder.Services.AddTransient<SplashScreen>();
            builder.Services.AddTransient<SimulationScreen>();

            // Register hosted services (background workers)
            //builder.Services.AddHostedService<ParticleSimulationWorker>();

            builder.Services.AddSingleton<GameLoop>();

            // 3. Build the Host
            using IHost host = builder.Build();

            // 4. Start Background Services (Non-blocking)
            await host.StartAsync();

            // 5. The Main Thread Game Loop
            var logger = host.Services.GetRequiredService<ILogger<Program>>();

            var gameLoop = host.Services.GetRequiredService<GameLoop>();
            gameLoop.Run();

            // 6. Graceful Shutdown
            logger.LogInformation("Shutting down...");
            await host.StopAsync();
        }
    }
}
