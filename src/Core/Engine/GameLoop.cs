using FishFight3.Core.Rendering;
using FishFight3.Core.Input;
using FishFight3.Core.Physics;

namespace FishFight3.Core.Engine
{
    public class GameLoop(ISimulation sim, IRenderer render, ITimeProvider time, IGameWindow gameWindow, IInputProvider p1, IInputProvider p2, ILogger logger)
    {
        private readonly ISimulation _simulation = sim;
        private readonly IRenderer _renderer = render;
        private readonly ITimeProvider _time = time;
        private readonly IGameWindow _window = gameWindow;
        private readonly IInputProvider _p1Input = p1;
        private readonly IInputProvider _p2Input = p2;
        private readonly ILogger _logger = logger;

        public void Run()
        {
            _logger.Write("Starting game loop!");
            double accumulator = 0.0;
            const double dt = 1.0 / 60.0;
            int frame = 0;
            _time.Start();

            while (_window.IsOpen)
            {
                double elapsed = _time.GetElapsedMilliseconds();
                if (elapsed > 0.25) elapsed = 0.25;
                accumulator += elapsed;

                _window.DispatchEvents();

                while (accumulator >= dt)
                {
                    var in1 = _p1Input.GetInput(frame);
                    var in2 = _p2Input.GetInput(frame);
                    _simulation.Update(in1, in2);
                    accumulator -= dt;
                }

                _window.Clear();
                _renderer.Draw(_simulation.GetState(), (float)(accumulator / dt));
                _window.Display();
                frame++;
            }
        }
    }
}
