using AutoDrivingCarSimulation.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDrivingCarSimulation.Infrastructure.Services
{
    public class SimulationService : ISimulationService
    {
        public async Task<Tuple<int, int, char>> performCommand(Tuple<int, int, char> currentPosition, int x, int y, char moveCommand)
        {
            var output = new Tuple<int, int, char>(0,0,'N');

            return output;
        }
    }
}
