using FishFight3.Core.Game;
using FishFight3.Core.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishFight3.Core.Rendering
{
    public interface IMenuRenderer
    {
        public void Draw(IGameWindow gameWindow, double alpha, MenuState menuState);
    }
}
