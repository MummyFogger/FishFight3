using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishFight3.Core.Simulation
{
    public class SimulationFactory : ISimulationFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public SimulationFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ISimulation Create(SimulationType simType)
        {
            return simType switch
            {
                SimulationType.LocalTwoPlayer => _serviceProvider.GetRequiredService<StandardTwoPlayer>(),
                //SimulationType.Online => new OnlineSimulation(),
                _ => throw new ArgumentException($"Unsupported simulation type: {simType}")
            };
        }
    }
}
