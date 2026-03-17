using FishFight3.Core.Engine;
using FishFight3.Core.Input;
using SFML.Window;

namespace FishFight3.Client.SFML
{
    internal class SfmlInputProvider : IInputProvider
    {
        private readonly ILogger _logger;

        // A simple history of local inputs for rollback support
        private readonly Dictionary<int, PlayerInput> _inputHistory = [];

        private readonly Dictionary<ButtonBitmask, Keyboard.Key> _cachedButtons = [];
        private readonly Keyboard.Key _up;
        private readonly Keyboard.Key _down;
        private readonly Keyboard.Key _left;
        private readonly Keyboard.Key _right;

        public SfmlInputProvider(InputMapping im, ILogger logger)
        {
            _logger = logger;

            _up = Translate(im.Up);
            _down = Translate(im.Down);
            _left = Translate(im.Left);
            _right = Translate(im.Right);

            _cachedButtons.Clear();
            _cachedButtons[ButtonBitmask.Light] = Translate(im.Light);
            _cachedButtons[ButtonBitmask.Medium] = Translate(im.Medium);
            _cachedButtons[ButtonBitmask.Heavy] = Translate(im.Heavy);
            _cachedButtons[ButtonBitmask.Special] = Translate(im.Special);
            _cachedButtons[ButtonBitmask.Dash] = Translate(im.Dash);
            _cachedButtons[ButtonBitmask.Meter] = Translate(im.Meter);
            _cachedButtons[ButtonBitmask.Break] = Translate(im.Break);
            _cachedButtons[ButtonBitmask.Taunt] = Translate(im.Taunt);

            //  Additional buttons can be cached as needed, up to 16 total for the ButtonBitmask
            _cachedButtons[ButtonBitmask.Button8] = Translate(im.Button8);
            _cachedButtons[ButtonBitmask.Button9] = Translate(im.Button9);
            _cachedButtons[ButtonBitmask.Button10] = Translate(im.Button10);
            _cachedButtons[ButtonBitmask.Button11] = Translate(im.Button11);
            _cachedButtons[ButtonBitmask.Button12] = Translate(im.Button12);
            _cachedButtons[ButtonBitmask.Button13] = Translate(im.Button13);
            _cachedButtons[ButtonBitmask.Button14] = Translate(im.Button14);
            _cachedButtons[ButtonBitmask.Button15] = Translate(im.Button15);
        }

        private Keyboard.Key Translate(string keyName)
        {
            // TryParse is efficient and prevents crashes if the JSON has a typo
            if (Enum.TryParse<Keyboard.Key>(keyName, true, out var sfmlKey))
            {
                return sfmlKey;
            }
            _logger.Write($"{keyName} is not a valid SFML key name. Defaulting to Unknown.", LogLevel.Error);
            return Keyboard.Key.Unknown;
        }

        public PlayerInput GetInput(int frameNumber)
        {
            // If we already recorded this frame, return it (used during rollback)
            if (_inputHistory.TryGetValue(frameNumber, out var historicalInput))
                return historicalInput;

            // Otherwise, poll the hardware for the CURRENT frame
            var currentInput = new PlayerInput
            {
                Direction = CalculateNumpad(),
                Buttons = CalculateButtons()
            };

            _inputHistory[frameNumber] = currentInput;
            return currentInput;
        }

        private Direction CalculateNumpad()
        {
            // TODO Implement input mapping
            bool up = Keyboard.IsKeyPressed(_up);
            bool down = Keyboard.IsKeyPressed(_down);
            bool left = Keyboard.IsKeyPressed(_left);
            bool right = Keyboard.IsKeyPressed(_right);

            // Simple SOCD: Left + Right = Neutral; Up + Down = Up
            int lr = left && right ? 0 : (left ? -1 : (right ? 1 : 0));
            int ud = up && down ? 1 : (up ? 1 : (down ? -1 : 0));

            switch (true)
            {
                case bool _ when lr == -1 && ud == -1: return Direction.DownBack;
                case bool _ when lr == 0 && ud == -1: return Direction.Down;
                case bool _ when lr == 1 && ud == -1: return Direction.DownForward;
                case bool _ when lr == -1 && ud == 0: return Direction.Back;
                case bool _ when lr == 0 && ud == 0: return Direction.Neutral;
                case bool _ when lr == 1 && ud == 0: return Direction.Forward;
                case bool _ when lr == -1 && ud == 1: return Direction.UpBack;
                case bool _ when lr == 0 && ud == 1: return Direction.Up;
                case bool _ when lr == 1 && ud == 1: return Direction.UpForward;
                default:
                {
                    _logger.Write($"Could not determine direction input; up:{up}, down:{down}, left:{left}, right:{right}", LogLevel.Error);
                    return Direction.Neutral;
                }
            }
        }

        private ButtonBitmask CalculateButtons()
        {
            ButtonBitmask buttons = ButtonBitmask.None;
            foreach (var kvp in _cachedButtons)
            {
                if (kvp.Value != Keyboard.Key.Unknown && Keyboard.IsKeyPressed(kvp.Value))
                    buttons |= kvp.Key;
            }
            return buttons;
        }
    }
}
