using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishFight3.Core.Game
{
    public interface IGameWindow
    {
        public bool IsOpen { get; }
        public void DispatchEvents();
        public void Clear();
        public void Display();
    }
}
