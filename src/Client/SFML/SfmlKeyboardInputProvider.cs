using FishFight3.Core.Input;
using FishFight3.Core.State;
using SFML.Window;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FishFight3.Client.SFML
{
    internal class SfmlKeyboardInputProvider : IInputProvider
    {
        private readonly ILogger<SfmlKeyboardInputProvider> _logger;
        private readonly Dictionary<string, string> _simulationInputMapping;
        private InputState _currentInput;
        private MappingMode _mappingMode;

        public SfmlKeyboardInputProvider(
            SfmlClientWindow window,
            IOptionsMonitor<InputSettings> options,
            ILogger<SfmlKeyboardInputProvider> logger)
        {
            _logger = logger;
            _mappingMode = MappingMode.None;
            var mapping = options.Get("keyboard")?.InputMappings ?? [];

            if (mapping == null)
            {
                _logger.LogError("No input mapping found for 'keyboard'. Defaulting to empty mapping.");
                _simulationInputMapping = DefaultInputMappings.KeyboardGameplay;
            }
            else
            {
                _simulationInputMapping = mapping;
            }

            window.GetInternalWindow().KeyPressed += (s, e) => HandleKey(e.Code, true);
            window.GetInternalWindow().KeyReleased += (s, e) => HandleKey(e.Code, false);
        }

        private void HandleKey(Keyboard.Key key, bool isPressed)
        {
            string keyName = key.ToString().ToLower(); // Convert SFML key to string for mapping lookup

            switch (_mappingMode)
            {
                case MappingMode.Simulation:
                    if (_simulationInputMapping.TryGetValue(keyName, out var gameplayAction))
                    {
                        _currentInput.SetAction(gameplayAction, isPressed);
                    }
                    break;
                case MappingMode.Menu:
                    if (DefaultInputMappings.KeyboardMenu.TryGetValue(keyName, out var menuAction))
                    {
                        _currentInput.SetAction(menuAction, isPressed);
                    }
                    break;
                case MappingMode.None:
                    // No input mapping, ignore all inputs
                    break;
            }
        }

        public void SetMappingMode(MappingMode mode)
        {
            _mappingMode = mode;
            _currentInput.Clear();
        }

        public InputState GetInput()
        {
            return _currentInput;
        }
    }
}
