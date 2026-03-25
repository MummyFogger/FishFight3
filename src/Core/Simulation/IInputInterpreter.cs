using FishFight3.Core.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishFight3.Core.Simulation
{
    public interface IInputInterpreter
    {
        public void InterpretInputs(SimulationState state, uint currentFrame);
    }
}
