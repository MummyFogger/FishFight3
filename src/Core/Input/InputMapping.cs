using FishFight3.Core.State;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishFight3.Core.Input
{
    public class InputSettings
    {
        public Dictionary<string, string> InputMappings { get; set; } = [];
        public void Sanitize(Dictionary<string, string> defaultMappings)
        {
            // Remove invalid actions
            //     Null / Whitespace
            //     Cannot be parsed to Direction or ButtonBitmask
            var invalidKeys = InputMappings
                .Where(kvp => string.IsNullOrWhiteSpace(kvp.Value) || !Enum.TryParse<ButtonBitmask>(kvp.Value, false, out var _))
                .Select(kvp => kvp.Key).ToList();
            foreach (var key in invalidKeys) InputMappings.Remove(key);

            // Add default mappings for any actions that aren't mapped to ANY key in the JSON
            foreach (var (defaultKey, action) in defaultMappings)
            {
                // If the action (e.g. "Jump") isn't mapped to ANY key in the JSON...
                if (!InputMappings.ContainsValue(action))
                {
                    // ...add the default mapping
                    InputMappings[defaultKey] = action;
                }
            }
        }
    }

    public static class DefaultInputMappings
    {
        public static readonly Dictionary<string, string> KeyboardMenu = new()
        {
            { "w", "Up" },
            { "a", "Left" },
            { "s", "Down" },
            { "d" , "Right" },
            { "j" , "Light" },
            { "k" , "Medium" },
            { "l" , "Heavy" },
            { "u" , "Special" },
            { "space" , "Dash" },
            { "i" , "Meter" },
            { "o" , "Break" },
            { "p" , "Taunt" },
            { "enter", "Start" },
            { "tab", "Select" }
        };

        public static readonly Dictionary<string, string> KeyboardGameplay = new()
        {
            { "w", "Up" },
            { "a", "Left" },
            { "s", "Down" },
            { "d" , "Right" },
            { "j" , "Light" },
            { "k" , "Medium" },
            { "l" , "Heavy" },
            { "u" , "Special" },
            { "space" , "Dash" },
            { "i" , "Meter" },
            { "o" , "Break" },
            { "p" , "Taunt" },
            { "enter", "Start" },
            { "tab", "Select" }
        };
    }
}
