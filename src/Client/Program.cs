using FishFight3.Client.SFML;
using FishFight3.Core.Engine;
using FishFight3.Core.Input;
using FishFight3.Core.Physics;
using FishFight3.Core.Rendering;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Xml;

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
            builder.Services.AddSingleton<IRenderer, SfmlRenderer>();
            builder.Services.AddTransient<ITimeProvider, SfmlTimeProvider>();
            builder.Services.AddTransient<ISimulation, LogConsoleSimulation>();
            builder.Services.AddSingleton<IInputProvider, SfmlKeyboardInputProvider>();
            //builder.Services.AddSingleton<VisualEffectQueue>();
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
