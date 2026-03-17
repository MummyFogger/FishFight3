using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FishFight3.Core.Input;

namespace FishFight3.Core.Physics
{
    public interface ISimulation
    {
        public GameState Update(PlayerInput p1Input, PlayerInput p2Input);
        public GameState GetState();
    }
}
