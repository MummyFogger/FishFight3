using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishFight3.Core.Input
{
    public class InputMapping
    {
        // Directions
        public string Up { get; set; } = "W";
        public string Down { get; set; } = "S";
        public string Left { get; set; } = "A";
        public string Right { get; set; } = "D";

        // Buttons (mapped to your ButtonMask bits)
        public string Light { get; set; } = "J";
        public string Medium { get; set; } = "K";
        public string Heavy { get; set; } = "L";
        public string Special { get; set; } = "U";
        public string Dash { get; set; } = "Space";
        public string Meter { get; set; } = "I";
        public string Break { get; set; } = "O";
        public string Taunt { get; set; } = "P";

        // Additional buttons can be added as needed, up to 16 total for the ButtonBitmask
        public string Button8 { get; set; } = "Num1";
        public string Button9 { get; set; } = "Num2";
        public string Button10 { get; set; } = "Num3";
        public string Button11 { get; set; } = "Num4";
        public string Button12 { get; set; } = "Num5";
        public string Button13 { get; set; } = "Num6";
        public string Button14 { get; set; } = "Num7";
        public string Button15 { get; set; } = "Num8";
    }
}
