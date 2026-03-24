using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishFight3.Core.Game
{
    public class GameSettings
    {
        public int TargetFps { get; set; }
        public required string WindowTitle { get; set; }
        public int WindowWidth { get; set; }
        public int WindowHeight { get; set; }
        public bool EnableRollback { get; set; }
    }
}
