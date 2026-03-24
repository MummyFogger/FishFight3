using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishFight3.Core.Simulation
{
    public enum SimulationType
    {
        LocalTwoPlayer,
        Online
    }
    public interface ISimulationFactory
    {
        public ISimulation Create(SimulationType simType);
    }
}
