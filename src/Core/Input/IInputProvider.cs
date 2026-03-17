using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishFight3.Core.Input
{
    public interface IInputProvider
    {
        public PlayerInput GetInput(int frame);
    }
}
