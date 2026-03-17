using FishFight3.Core.Engine;
using SFML.System;

namespace FishFight3.Client.SFML
{
    internal class SfmlTimeProvider : ITimeProvider
    {
        private Clock? _clock;
        public bool IsRunning => _clock?.IsRunning ?? false;

        public double GetElapsedMilliseconds()
        {
            return _clock?.Restart().AsMilliseconds() ?? 0.0;
        }

        public void Reset()
        {
            _clock?.Restart();
        }

        public void Start()
        {
            _clock?.Restart();
            _clock ??= new Clock();
        }

        public void Stop()
        {
            _clock?.Stop();
        }
    }
}
